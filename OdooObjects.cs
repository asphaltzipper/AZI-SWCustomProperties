using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using PropertyDataScaffold;

namespace OdooObjects
{
    public class OdooProduct
    {
        private PropertyScaffold scaffold;
        private OdooRpcCs.OdooClient oClient;
        private string productCode;
        private string engCode;
        private string engRev;
        private int productId;
        private int templateId;
        private ArrayList versionIds;
        private ArrayList prodFields = new ArrayList();
        private ArrayList tmplFields = new ArrayList();

        private Hashtable productRecord;
        public Hashtable ProductRecord
        {
            get
            {
                return productRecord;
            }
        }
        private Hashtable templateRecord;
        public Hashtable TemplateRecord
        {
            get
            {
                return templateRecord;
            }
        }
        public Dictionary<string, object> Record
        {
            get
            {
                return GetRecordDict();
            }
        }
        private DataTable productTable;
        public DataTable Table
        {
            get
            {
                return productTable;
            }
        }

        private DataTable pushTable;
        public DataTable PushTable
        {
            get
            {
                return pushTable;
            }
        }

        private DataTable ecoTable;
        public DataTable Ecos
        {
            get
            {
                return ecoTable;
            }
        }

        private string latestException = "";
        public string LatestException
        {
            get
            {
                return latestException;
            }
        }

        public bool HasProduct { get; set; }


        public OdooProduct(OdooRpcCs.OdooClient oClient, string productCode, PropertyScaffold scaffold)
        {
            this.scaffold = scaffold;
            this.oClient = oClient;
            this.productCode = productCode;
            (this.engCode, _, this.engRev) = ParseProductCode(productCode);
            foreach (DataRow dr in scaffold.FieldDefs.Select("odoo_model='product.product'"))
                prodFields.Add(dr["odoo_field"].ToString());
            foreach (DataRow dr in scaffold.FieldDefs.Select("odoo_model='product.template'"))
                tmplFields.Add(dr["odoo_field"].ToString());
            Refresh();
        }

        private (string code, string delimiter, string revision) ParseProductCode(string productCode)
        {
            if (productCode == null)
                return (code: null, delimiter: null, revision: null);
            Regex rx = new Regex(@"([a-zA-Z_0-9\-]+)(\.)([-A-Z][0-9])");
            MatchCollection matches = rx.Matches(productCode);
            if (matches.Count == 0 || matches[0].Groups.Count != 4)
                return (code: null, delimiter: null, revision: null);
            return (
                code: matches[0].Groups[1].Value,
                delimiter: matches[0].Groups[2].Value,
                revision: matches[0].Groups[3].Value);
        }

        public void Refresh()
        {
            this.HasProduct = false;
            productTable = scaffold.OdooTable;
            DataRow dr = productTable.NewRow();
            productTable.Rows.Add(dr);

            if (this.engCode == null || productCode == null)
                return;

            // Get product versions
            ArrayList filter = new ArrayList();
            filter.Add(new ArrayList(3) { "eng_code", "=", this.engCode });
            filter.Add("|");
            filter.Add(new ArrayList(3) { "active", "=", true });
            filter.Add(new ArrayList(3) { "active", "=", false });
            this.versionIds = oClient.Search("product.product", filter);

            // Build eco datatable
            GetEcos();

            // Get product.product data
            filter = new ArrayList();
            filter.Add(new ArrayList(3) { "default_code", "=", productCode });
            filter.Add("|");
            filter.Add(new ArrayList(3) { "active", "=", true });
            filter.Add(new ArrayList(3) { "active", "=", false });
            ArrayList records = oClient.Browse("product.product", filter, this.prodFields);
            if (records == null || records.Count == 0)
            {
                latestException = oClient.LatestException;
                return;
            }
            this.productRecord = (Hashtable)records[0];
            this.productId = (int)this.productRecord["id"];

            // Get product.template data
            this.templateId = (int)((ArrayList)this.productRecord["product_tmpl_id"])[0];
            filter = new ArrayList();
            filter.Add(new ArrayList(3) { "id", "=", this.templateId });
            filter.Add("|");
            filter.Add(new ArrayList(3) { "active", "=", true });
            filter.Add(new ArrayList(3) { "active", "=", false });
            records = oClient.Browse("product.template", filter, this.tmplFields);
            if (records == null || records.Count == 0)
            {
                latestException = oClient.LatestException;
                return;
            }
            this.templateRecord = (Hashtable)records[0];

            // Fill Odoo DataRow
            foreach (DataRow drField in scaffold.FieldDefs.Select("odoo_field is not null"))
            {
                string colName = drField["field"].ToString();
                string type = drField["dt_type"].ToString();
                string field = drField["odoo_field"].ToString();
                string model = drField["odoo_model"].ToString();
                string refModel = drField["odoo_ref_model"].ToString();
                string refField = drField["odoo_ref_field"].ToString();
                bool refInactives = (long)drField["ref_inactives"] != 0;
                object rawValue;
                if (model == "product.product")
                    rawValue = productRecord[field];
                else
                    rawValue = templateRecord[field];
                if (rawValue == null)
                    continue;

                if (refField != "" && rawValue.GetType() != Type.GetType("System.Boolean"))
                {
                    // this field references another, and we have a reference id
                    int refId = (int)((ArrayList)rawValue)[0];
                    dr[colName] = GetRefValue(refModel, refField, refId, refInactives);
                }
                else if (type != "System.Boolean" && rawValue.GetType() == Type.GetType("System.Boolean"))
                    // Odoo returned a null value for this field
                    dr[colName] = System.DBNull.Value;
                //else if (type == "System.Decimal" || type == "System.Int32" && rawValue.ToString() == "0")
                //    // This is a number field that is zero
                //    dr[colName] = System.DBNull.Value;
                else
                    dr[colName] = rawValue;
            }
            // Transform UOM
            scaffold.UomMapping.TryGetValue(dr["Uom"].ToString(), out string uom);
            dr["Uom"] = uom;

            this.HasProduct = true;

        }



        public void RawWrite(Dictionary<string, Object> values)
        {
            Hashtable prodValues = new Hashtable();
            Hashtable tmplValues = new Hashtable();
            foreach (KeyValuePair<string, object> field in values)
                if (prodFields.Contains(field.Key))
                    prodValues.Add(field.Key, field.Value);
                else if (tmplFields.Contains(field.Key))
                    tmplValues.Add(field.Key, field.Value);
            if (prodValues.Count > 0)
                oClient.Write("product.product", this.productId, prodValues);
            if (tmplValues.Count > 0)
                oClient.Write("product.template", this.templateId, tmplValues);
            Refresh();
        }

        public void WriteRowChanges(DataRow[] changes)
        {
            /// Calls to WriteRowChanges should be wrapped in a try-catch block
            DataRow drOld = changes[0];
            DataRow drNew = changes[1];

            // Write single-component/raw-material type BOM changes
            if (!drNew.IsNull("MaterialPn"))
            {
                if (drNew.IsNull("RouteTemplate") || (decimal)drNew["ChildQty"] == 0)
                    throw new Exception("If a raw material is specified, you must also specify quantity and routing");

                if (!drNew["MaterialPn"].Equals(drOld["MaterialPn"]) ||
                    !drNew["ChildQty"].Equals(drOld["ChildQty"]) ||
                    !drNew["RouteTemplate"].Equals(drOld["RouteTemplate"]))
                {
                    // Lookup raw material product
                    ArrayList rmIds = GetRefId("product.product", "default_code", drNew["MaterialPn"].ToString());
                    if (rmIds.Count == 0)
                        throw new Exception("Failed to get a matching raw material");

                    // Lookup routing template
                    ArrayList routeIds = GetRefId("mrp.routing", "name", drNew["RouteTemplate"].ToString());
                    if (routeIds.Count == 0)
                        throw new Exception("Failed to get a matching routing template");

                    // Execute the Create Bom wizard
                    Hashtable wizValues = new Hashtable
                    {
                        { "product_tmpl_id", templateId },
                        { "rm_product_id", rmIds[0] },
                        { "rm_qty", ((decimal)drNew["ChildQty"]).ToString("0.0") },
                        { "routing_id", routeIds[0] },
                    };
                    int wizId = oClient.Create("mfg.create.bom", wizValues);
                    oClient.Execute("mfg.create.bom", "button_create_bom", new ArrayList { wizId }, 5000);
                }

            }
            
            Dictionary<string, Object> values = new Dictionary<string, Object>();
            foreach (DataRow drField in scaffold.FieldDefs.Select("write_odoo=1"))
            {
                string colName = drField["field"].ToString();
                if (drNew[colName].Equals(drOld[colName]))
                    continue;

                string type = drField["dt_type"].ToString();
                string field = drField["odoo_field"].ToString();
                string model = drField["odoo_model"].ToString();
                string refModel = drField["odoo_ref_model"].ToString();
                string refField = drField["odoo_ref_field"].ToString();
                object rawValue = drNew[colName];

                if (rawValue.ToString() == "")
                    values.Add(field, false);
                else if (refField != "")
                {
                    // Lookup id in referenced model
                    ArrayList ids = GetRefId(refModel, refField, rawValue);
                    if (ids.Count == 0)
                        throw new Exception(String.Format("Failed to get a matching id for {0} in {1}.{2}", rawValue.ToString(), refModel, refField));
                    if (ids.Count > 1)
                        throw new Exception(String.Format("Found multiple matching records for {0} in {1}.{2}", rawValue.ToString(), refModel, refField));
                    values.Add(field, ids[0]);
                }
                else
                    if (type == "System.Decimal")
                        values.Add(field, ((decimal)rawValue).ToString("0.00"));
                    else
                        values.Add(field, rawValue);
            }
            if (values.Count > 0)
                RawWrite(values);
        }

        public object GetRefValue(string refModel, string refField, int refId, bool getInactive = false)
        {
            ArrayList filter = new ArrayList();
            filter.Add(new ArrayList(3) { "id", "=", refId });
            if (getInactive)
            {
                filter.Add("|");
                filter.Add(new ArrayList(3) { "active", "=", true });
                filter.Add(new ArrayList(3) { "active", "=", false });
            }
            ArrayList records = oClient.Browse(refModel, filter, new ArrayList { refField });
            if (records.Count == 0)
                return DBNull.Value;
            else
                return ((Hashtable)records[0])[refField];
        }

        public ArrayList GetRefId(string refModel, string refField, object value)
        {
            ArrayList filter = new ArrayList {
                        new ArrayList(3) { refField, "=", value },
                    };
            ArrayList ids = oClient.Search(refModel, filter);
            return ids;
        }

        private Dictionary<string, object> GetRecordDict()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            foreach (DataColumn dc in productTable.Columns)
            {
                string newKey = prodFields.Contains(dc.ColumnName) ?
                    "product.product." + dc.ColumnName :
                    "product.template." + dc.ColumnName;
                dict.Add(newKey, productTable.Rows[0][dc.ColumnName]);
            }
            return dict;
        }

        private DataTable GetEcoDataTable()
        {
            DataTable dt = new DataTable("ecos");
            dt.Columns.Add("Eco");
            dt.Columns.Add("Rev");
            dt.Columns.Add("Zone");
            dt.Columns.Add("Description");
            dt.Columns.Add("Date");
            dt.Columns.Add("Owner");
            return dt;
        }

        private DataTable GetEcos()
        {
            ecoTable = GetEcoDataTable();
            if (this.versionIds.Count == 0)
                return ecoTable;

            ArrayList filter = new ArrayList();
            filter.Add(new ArrayList(3) { "product_id", "in", this.versionIds });
            ArrayList ids = oClient.Search("ecm.eco.rev.line", filter);

            ArrayList fields = new ArrayList() { "eco_id", "new_rev", "zone", "description", "target_date", "owner_id" };
            ArrayList records = oClient.Read("ecm.eco.rev.line", ids, fields);

            foreach (Hashtable rec in records)
            {
                DataRow row = ecoTable.NewRow();
                row["Eco"] = (string)((ArrayList)rec["eco_id"])[1];
                row["Rev"] = (string)rec["new_rev"];
                row["Zone"] = rec["zone"].GetType() == Type.GetType("System.Boolean") ? "" : (string)rec["zone"];
                row["Description"] = rec["description"].GetType() == Type.GetType("System.bool") ? "" : (string)rec["description"];
                row["Date"] = (string)rec["target_date"];
                row["Owner"] = (string)((ArrayList)rec["owner_id"])[1];
                ecoTable.Rows.Add(row);
            }
            ecoTable.DefaultView.Sort = "Eco ASC";

            return ecoTable;
        }

    }

    public class OdooTools
    {
        private OdooRpcCs.OdooClient oObject;

        public OdooTools(OdooRpcCs.OdooClient objectClient)
        {
            this.oObject = objectClient;
        }

        //public List<string> GetUomCodes()
        //{
        //    ArrayList filter = new ArrayList(1);
        //    filter.Add(new ArrayList(3) { "code", "!=", false });
        //    ArrayList ids = oObject.Search("product.uom", filter);
        //    ArrayList records = oObject.Read("product.uom", ids, new ArrayList(1) { "code" });

        //    List<string> uoms = new List<string>();
        //    foreach (Hashtable record in records)
        //    {
        //        if (!uoms.Contains((string)record["code"]))
        //            uoms.Add((string)record["code"]);
        //    }
        //    return uoms;
        //}

        public List<string> GetRouteTemplates()
        {
            ArrayList filter = new ArrayList(1);
            filter.Add(new ArrayList(3) { "name", "like", "_template" });
            ArrayList ids = oObject.Search("mrp.routing", filter);
            ArrayList records = oObject.Read("mrp.routing", ids, new ArrayList(1) { "name" });

            List<string> routes = new List<string>();
            foreach (Hashtable record in records)
            {
                if (!routes.Contains((string)record["name"]))
                    routes.Add((string)record["name"]);
            }
            routes.Sort();
            return routes;
        }

        public Dictionary<string, string> GetPartTypes()
        {
            Dictionary<string, string> types = new Dictionary<string, string>();

            ArrayList ids = oObject.Search("engineering.part.type", new ArrayList(1));
            ArrayList records = oObject.Read("engineering.part.type", ids, new ArrayList(2) { "code", "name" });
            if (records == null)
                return types;

            foreach (Hashtable record in records)
            {
                string code = (string)record["code"];
                string name = (string)record["code"] + " - " + (string)record["name"];
                types.Add(code, name);
            }
            return types;
        }

        public List<string> GetCoatings()
        {
            List<string> items = new List<string>();

            ArrayList ids = oObject.Search("engineering.coating", new ArrayList(1));
            ArrayList records = oObject.Read("engineering.coating", ids, new ArrayList(2) { "name" });
            if (records == null)
                return items;

            foreach (Hashtable record in records)
            {
                string name = (string)record["name"];
                items.Add(name);
            }
            return items;
        }

        public List<string> GetPreparations()
        {
            List<string> items = new List<string>();

            ArrayList ids = oObject.Search("engineering.preparation", new ArrayList(1));
            ArrayList records = oObject.Read("engineering.preparation", ids, new ArrayList(2) { "name" });
            if (records == null)
                return items;

            foreach (Hashtable record in records)
            {
                string name = (string)record["name"];
                items.Add(name);
            }
            return items;
        }

        public DataTable GetRawMaterials()
        {
            DataTable dtRawMaterial = new DataTable("raw_material");
            dtRawMaterial.Columns.Add("id");
            dtRawMaterial.Columns.Add("default_code");
            dtRawMaterial.Columns.Add("name");
            dtRawMaterial.Columns.Add("uom_name");
            dtRawMaterial.Columns.Add("categ_name");

            ArrayList filter = new ArrayList(2);
            filter.Add(new ArrayList(3) { "is_continuous", "=", true });
            filter.Add(new ArrayList(3) { "eng_management", "=", true });
            ArrayList ids = oObject.Search("product.template", filter);

            ArrayList fields = new ArrayList() { "id", "default_code", "name", "uom_id", "eng_categ_id" };
            ArrayList records = oObject.Read("product.template", ids, fields);

            foreach (Hashtable rec in records)
            {
                DataRow row = dtRawMaterial.NewRow();
                row["id"] = (int)rec["id"];
                row["default_code"] = (string)rec["default_code"];
                row["name"] = (string)rec["name"];
                row["uom_name"] = (string)((ArrayList)rec["uom_id"])[1];
                string categName = (string)((ArrayList)rec["eng_categ_id"])[1];
                categName = categName.Substring(categName.LastIndexOf(" / ") + 3);
                row["categ_name"] = categName;
                dtRawMaterial.Rows.Add(row);
            }

            return dtRawMaterial;
        }

    }

}
