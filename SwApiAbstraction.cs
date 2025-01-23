using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Drawing;

using SolidWorks.Interop.swconst;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swdocumentmgr;

using System.Data;
using System.Data.Common;
using System.Data.SQLite;

using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

using PropertyDataScaffold;
using System.Data.Entity.ModelConfiguration.Conventions;

using OpenCvSharp;


namespace SwApiAbstraction
{

    public class SwApiWrapper
    {
        private SldWorks swApp;
        private ModelDoc2 swMainModel;
        private DrawingDoc swDrawDoc;

        //#region Custom Property Data Structure

        //// SolidWorks custom property types:
        //// swCustomInfoType_e.swCustomInfoDate = 64
        //// swCustomInfoType_e.swCustomInfoDouble = 5
        //// swCustomInfoType_e.swCustomInfoNumber = 3
        //// swCustomInfoType_e.swCustomInfoText = 30
        //// swCustomInfoType_e.swCustomInfoUnknown = 0
        //// swCustomInfoType_e.swCustomInfoYesOrNo = 11
        ////
        //// We never use swCustomInfoYesOrNo because we can't bind a null value to a CheckBox control
        //// We only use swCustomInfoText because the others are too hard to parse
        ////

        //// ******************************************************************************
        //// ***                                                                        ***
        //// ***        The custom property for 'Units of Measure' was originally       ***
        //// ***        named 'Alternate Quantity'.  When we added a property for       ***
        //// ***        tracking alternate quantity values (double precision            ***
        //// ***        numbers), we didn't want to go back and change the custom       ***
        //// ***        properties in every part file.                                  ***
        //// ***        As a work around:                                               ***
        //// ***            -we labeled the 'Alternate Quantity' text field 'UOM'       ***
        //// ***            -we are writing the units of measure to the                 ***
        //// ***             'Alternate Quantity' custom property                       ***
        //// ***            -we labeled the 'UOM' text field 'Alternate Quantity'       ***
        //// ***            -we are writing the alternate quantity value to the         ***
        //// ***             'UOM' custom property                                      ***
        //// ***                                                                        ***
        //// ******************************************************************************

        //DataTable dtPropDefs;
        //public DataTable PropDefs
        //{
        //    get
        //    {
        //        return dtPropDefs;
        //    }
        //}

        //DataTable dtProps;
        //public DataTable PropTable
        //{
        //    get
        //    {
        //        return dtProps.Clone();
        //    }
        //}

        //public DataRow PropRow
        //{
        //    get
        //    {
        //        return dtProps.NewRow();
        //    }
        //}

        //private readonly List<string> propNames = new List<string>();
        //public List<string> PropNames
        //{
        //    get
        //    {
        //        return propNames;
        //    }
        //}

        //private readonly List<string> fieldNames = new List<string>();
        //public List<string> FieldNames
        //{
        //    get
        //    {
        //        return fieldNames;
        //    }
        //}

        //private readonly Dictionary<string, int> propTypes = new Dictionary<string, int>();
        //public Dictionary<string, int> PropTypes
        //{
        //    get
        //    {
        //        return propTypes;
        //    }
        //}

        //private readonly List<string> otherFieldNames = new List<string>();
        //public List<string> OtherFieldNames
        //{
        //    get
        //    {
        //        return otherFieldNames;
        //    }
        //}

        //private Dictionary<string, string> dictPropField = new Dictionary<string, string>();
        //public Dictionary<string, string> PropFieldMap
        //{
        //    get
        //    {
        //        return dictPropField;
        //    }
        //}

        //private Dictionary<string, string> dictFieldProp = new Dictionary<string, string>();
        //public Dictionary<string, string> FieldPropMap
        //{
        //    get
        //    {
        //        return dictFieldProp;
        //    }
        //}

        //#endregion

        private SwModelWrapper swModelWrap;
        public SwModelWrapper MainModel
        {
            get
            {
                return swModelWrap;
            }
        }

        public SwApiWrapper()
        {
            string attachMessage = SwAttach();
            if (attachMessage != null)
                throw new Exception(attachMessage);
            string loadMessage = LoadActiveModel();
            if (loadMessage != null)
                throw new Exception(loadMessage);
            //LoadPropertyData();
        }

        private string SwAttach()
        {

            string strMessage;
            //bool blnStatus = true;

            //Check for the status of existing solidworks apps
            if (System.Diagnostics.Process.GetProcessesByName("sldworks").Length < 1)
            {
                strMessage = "Solidworks instance not detected.";
                //blnStatus = false;
            }
            else if (System.Diagnostics.Process.GetProcessesByName("sldworks").Length > 1)
            {
                strMessage = "Multiple instances of Solidworks detected.";
                //blnStatus = false;
            }
            else
            {
                strMessage = null;
                //swApp = System.Diagnostics.Process.GetProcessesByName("SldWorks.Application");
                swApp = (SldWorks)System.Runtime.InteropServices.Marshal.GetActiveObject("SldWorks.Application");
                //swApp = (SolidWorks.Interop.sldworks.Application)
            }

            SwDMClassFactory swClassFact;
            swClassFact = new SwDMClassFactory();

            return strMessage;

        }

        private string LoadActiveModel()
        {
            /// <summary>Load active model
            /// <list type="bullet">
            ///   <listheader>
            ///     <description>Set model properties</description>
            ///   </listheader>
            ///   <item>Model file name with path</item>
            ///   <item>Model file name</item>
            ///   <item>Referenced configuration</item>
            /// </list>
            /// <returns>Error message string</returns>
            /// </summary>

            ModelDoc2 swDoc;
            SolidWorks.Interop.sldworks.View swDrawView;
            swDocumentTypes_e swDocType;

            string strModelFile;
            string strModelName;
            string strConfigName = null;

            int intErrors = 0;
            int intWarnings = 0;

            // get the active document
            swDoc = (ModelDoc2)this.swApp.ActiveDoc;
            if (swDoc == null)
            {
                return "Could not acquire an active document";
            }

            // Check for the correct doc type
            strModelFile = swDoc.GetPathName();
            strModelName = strModelFile.Substring(strModelFile.LastIndexOf("\\") + 1, strModelFile.Length - strModelFile.LastIndexOf("\\") - 1);
            swDocType = (swDocumentTypes_e)swDoc.GetType();

            // get model document from drawing document
            if (swDocType == swDocumentTypes_e.swDocDRAWING)
            {

                swDrawDoc = (DrawingDoc)swDoc;
                swDrawView = (SolidWorks.Interop.sldworks.View)swDrawDoc.GetFirstView();
                swDrawView = (SolidWorks.Interop.sldworks.View)swDrawView.GetNextView();

                strModelFile = swDrawView.GetReferencedModelName();
                strConfigName = swDrawView.ReferencedConfiguration;
                strModelName = strModelFile.Substring(strModelFile.LastIndexOf("\\") + 1, strModelFile.Length - strModelFile.LastIndexOf("\\") - 1);
                swDocType = (swDocumentTypes_e)GetTypeFromString(strModelFile);

                if (swDocType != swDocumentTypes_e.swDocASSEMBLY & swDocType != swDocumentTypes_e.swDocPART)
                {
                    return "error getting file type from drawing view's referenced model";
                }

                // Try to load the model file
                try
                {
                    swMainModel = swApp.OpenDoc6(strModelFile, (int)swDocType, (int)swOpenDocOptions_e.swOpenDocOptions_LoadModel, strConfigName, ref intErrors, ref intWarnings);
                    swMainModel = swApp.ActivateDoc3(strModelFile, true, (int)swRebuildOnActivation_e.swDontRebuildActiveDoc, intErrors);
                }
                catch (Exception e)
                {
                    return e.Message;
                }

            }
            else
            {
                swMainModel = swDoc;
            }

            swModelWrap = new SwModelWrapper(this, swApp, swDocType, swMainModel, strConfigName: null);

            return null;

        }

        private SwDmDocumentType GetTypeFromString(string ModelPathName)
        {

            // ModelPathName = fully qualified name of file
            SwDmDocumentType nDocType = 0;

            // Determine type of SOLIDWORKS file based on file extension
            if (ModelPathName.ToLower().EndsWith("sldprt"))
            {
                nDocType = SwDmDocumentType.swDmDocumentPart;
            }
            else if (ModelPathName.ToLower().EndsWith("sldasm"))
            {
                nDocType = SwDmDocumentType.swDmDocumentAssembly;
            }
            else if (ModelPathName.ToLower().EndsWith("slddrw"))
            {
                nDocType = SwDmDocumentType.swDmDocumentDrawing;
            }
            else
            {
                // Not a SOLIDWORKS file
                nDocType = SwDmDocumentType.swDmDocumentUnknown;
            }

            return nDocType;

        }

        //private void LoadPropertyData()
        //{
        //    DbConnection cnn = new SQLiteConnection("Data Source=|DataDirectory|\\property_field_mapping.db3");
        //    cnn.Open();
        //    DbCommand comm = cnn.CreateCommand();
        //    comm.CommandText = "select * from field_property order by sequence";
        //    dtPropDefs = new DataTable();
        //    using (DbDataReader dr = comm.ExecuteReader())
        //    {
        //        dtPropDefs.Load(dr);
        //    }

        //    // Get custom properties from api wrapper
        //    foreach (DataRow dr in dtPropDefs.Select("", "sequence asc"))
        //    {
        //        if (!dr.IsNull("sw_prop"))
        //        {
        //            // build name lists
        //            propNames.Add((string)dr["sw_prop"]);
        //            fieldNames.Add((string)dr["scan_field"]);
        //            // Map SolidWorks custom property names to SolidWorks custom property types
        //            propTypes.Add((string)dr["sw_prop"], (int)dr["sw_type"]);
        //            // Map SolidWorks custom property names to DB field names
        //            dictPropField.Add((string)dr["sw_prop"], (string)dr["scan_field"]);
        //            // Map DB field names to SolidWorks custom property names
        //            dictFieldProp.Add((string)dr["scan_field"], (string)dr["sw_prop"]);
        //        }
        //        else
        //            otherFieldNames.Add((string)dr["sw_prop"]);

        //        // build DataTable
        //        DataColumn col = new DataColumn((string)dr["scan_field"]);
        //        col.DataType = System.Type.GetType((string)dr["dt_type"]);
        //        dtProps.Columns.Add(col);
        //    }
        //}

        //public static byte[] ImageToByteArray(Bitmap bitmapIn)
        //{
        //    Image imageIn = (Image)bitmapIn;
        //    if (imageIn == null) return null;
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        try
        //        {
        //            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
        //            return ms.ToArray();
        //        }
        //        catch
        //        {
        //            return null;
        //        }
        //    }
        //}

        //public static Image ByteArrayToImage(byte[] byteArrayIn)
        //{
        //    if (byteArrayIn == null) return null;
        //    using (MemoryStream ms = new MemoryStream(byteArrayIn))
        //    {
        //        Image returnImage = Image.FromStream(ms);
        //        return returnImage;
        //    }
        //}

    }


    public class SwModelWrapper
    {
        private SwApiWrapper swApi;
        private PropertyScaffold propScaffold = new PropertyScaffold();
        private SldWorks swApp;
        private ModelDoc2 swMainModel;
        private Configuration swMainConfig;
        private ModelDocExtension swModelDocExt;
        private AssemblyDoc swMainAssembly;

        #region Class Properties

        // model name with path
        private string pathName;
        public string PathName
        {
            get
            {
                return pathName;
            }
        }

        // model name
        private string modelName;
        public string ModelName
        {
            get
            {
                return modelName;
            }
        }

        private List<string> configNames = new List<string>();
        public List<string> ConfigNames
        {
            get
            {
                return configNames;
            }
        }

        // referenced configuration name
        private string currentConfigName;
        public string CurrentConfigName
        {
            get
            {
                return currentConfigName;
            }
            set
            {
                SetConfigName(value);
            }
        }

        public int LiteCompCount
        {
            get
            {
                if (swMainAssembly != null)
                    return swMainAssembly.GetLightWeightComponentCount();
                else
                    return 0;
            }
        }

        public bool ShowChildComponentsInBOM
        {
            get
            {
                return swMainConfig.ShowChildComponentsInBOM;
            }
        }

        #endregion

        #region Initialization

        public SwModelWrapper(SwApiWrapper swApi, SldWorks swApp, swDocumentTypes_e swDocType, ModelDoc2 swMainModel, string strConfigName)
        {
            this.swApi = swApi;
            this.swApp = swApp;
            this.swMainModel = swMainModel;

            swModelDocExt = (ModelDocExtension)swMainModel.Extension;

            if (swDocType == swDocumentTypes_e.swDocASSEMBLY)
                swMainAssembly = (AssemblyDoc)swMainModel;

            if (strConfigName != null)
                this.swMainConfig = (Configuration)swMainModel.GetConfigurationByName(strConfigName);
            else
                this.swMainConfig = (Configuration)swMainModel.GetActiveConfiguration();
                strConfigName = this.swMainConfig.Name;


            // Write model info to shared variables
            string[] configsArray = swMainModel.GetConfigurationNames();
            this.configNames.AddRange(configsArray);
            this.configNames.Sort();
            this.pathName = swMainModel.GetPathName();
            this.modelName = swMainModel.GetTitle();
            this.currentConfigName = strConfigName;
        }

        private void SetConfigName(string configName)
        {
            if (configName == this.currentConfigName || configName == "")
                return;
            if (!configNames.Contains(configName))
            {
                string strExcept = String.Format("Config name {0} is not in this model", configName);
                throw new Exception(strExcept);
            }
            swMainConfig = (Configuration)swMainModel.GetConfigurationByName(configName);
            this.currentConfigName = configName;
        }
        #endregion

        #region Custom Properties

        public static object GetPropDefaultValue(string value, string type, string name)
        {
            if (value != "")
            {
                try
                {
                    return Convert.ChangeType(value, Type.GetType(type));
                }
                catch (Exception e)
                {
                    throw new Exception(String.Format("Failed converting {0} to type {1} for field {2}: {3}", value, type, name, e.Message));
                }
            }
            else
            {
                if (type == "System.String")
                    return DBNull.Value;
                else if (type == "System.Boolean")
                    return false;
                else if (type == "System.Int32")
                    return 0;
                else if (type == "System.Decimal")
                    return 0.0;
                else
                    throw new Exception(String.Format("Unknown data type {0} for property {1}", type, name));
            }
        }

        private bool CheckPropDefaultValue(object value, string type)
        {
            if (type == "System.String" && value.ToString() == "")
                return true;
            else if (type == "System.Boolean" && !(bool)value)
                return true;
            else if (type == "System.Int32" && (int)value == 0)
                return true;
            else if (type == "System.Decimal" && (Decimal)value == 0.0M)
                return true;
            else
                return false;
        }

        public DataRow GetCustomProp(string configName, bool withImage = false, bool merge = false)
        {
            DataRow dr = propScaffold.MainRow;

            // Return an empty DataRow if the config name doesn't exist in this model
            if (configName != "" && !configNames.Contains(configName))
                return dr;

            dr["filename"] = pathName;
            dr["configname"] = configName;
            dr["PlaceHoldFlag"] = false;
            dr["ShowChildren"] = swMainConfig.ShowChildComponentsInBOM;
            CustomPropertyManager swAltCustPropMgr = (CustomPropertyManager)swModelDocExt.get_CustomPropertyManager("");

            // Get property manager for this config
            CustomPropertyManager swCustPropMgr = (CustomPropertyManager)swModelDocExt.get_CustomPropertyManager(configName);
            string[] nameArray = swCustPropMgr.GetNames();
            List<string> propNames = new List<string>();
            if (nameArray != null)
                propNames.AddRange(swCustPropMgr.GetNames());

            //// The GetAll3 method is faster than getting one property at a time with the Get6 method, but it can't get unresolved values
            //// Get custom properties from this configuration
            //object oPropNames = null;
            //object oPropTypes = null;
            //object oPropValues = null;
            //object oResolved = null;
            //object oPropLink = null;
            //Dictionary<string, string> dProps = new Dictionary<string, string>();
            //swCustPropMgr.GetAll3(ref oPropNames, ref oPropTypes, ref oPropValues, ref oResolved, ref oPropLink);
            //string[] aPropNames = (string[])oPropNames;
            //object[] aPropValues = (object[])oPropValues;
            //for (int i = 0; i < swCustPropMgr.Count; i++)
            //{
            //    dProps[aPropNames[i]] = aPropValues[i].ToString().Trim();
            //}

            //// Get the file level properties (the config name is an empty string, i.e. "")
            //Dictionary<string, string> dAltProps = new Dictionary<string, string>();
            //if (merge && configName != "")
            //{
            //    swAltCustPropMgr.GetAll3(ref oPropNames, ref oPropTypes, ref oPropValues, ref oResolved, ref oPropLink);
            //    aPropNames = (string[])oPropNames;
            //    aPropValues = (object[])oPropValues;
            //    for (int i = 0; i < swAltCustPropMgr.Count; i++)
            //    {
            //        dAltProps[aPropNames[i]] = aPropValues[i].ToString().Trim();
            //    }
            //}

            //// Assign property values to datarow fields
            //string strResolved;
            //foreach (DataRow drField in propScaffold.FieldDefs.Select("sw_prop is not null"))
            //{
            //    string propName = drField["sw_prop"].ToString();
            //    string fieldName = drField["field"].ToString();
            //    string typeName = drField["dt_type"].ToString();
            //    if (!dProps.TryGetValue(propName, out strResolved))
            //    {
            //        strResolved = "";
            //    }
            //    dr[fieldName] = GetPropDefaultValue(strResolved, typeName);

            //    // If merging config specific properties with the file level properties
            //    if (merge && configName != "" && !propNames.Contains(propName))
            //    {
            //        if (!dAltProps.TryGetValue(propName, out strResolved))
            //        {
            //            strResolved = "";
            //        }
            //        dr[fieldName] = GetPropDefaultValue(strResolved, typeName);
            //    }
            //}

            // On models with many configs, getting the property values with Get6 takes a bit longer that GetAll3
            // Get property values and assign to datarow fields
            foreach (DataRow drField in propScaffold.FieldDefs.Select("sw_prop is not null"))
            {
                string propName = drField["sw_prop"].ToString();
                string fieldName = drField["field"].ToString();
                string typeName = drField["dt_type"].ToString();
                bool rawValue = ((long)drField["raw_value"]) != 0;
                swCustPropMgr.Get6(
                    propName,
                    true,
                    out string strVal,
                    out string strResolved,
                    out bool blnWasResolved,
                    out bool blnLinkToProperty);
                if (!rawValue)
                {
                    strResolved = strResolved.Trim();
                    dr[fieldName] = GetPropDefaultValue(strResolved, typeName, propName);
                }
                else
                {
                    dr[fieldName] = strVal;
                }

                // If merging config specific properties with the file level properties
                if (merge && configName != "" && !propNames.Contains(propName))
                {
                    swAltCustPropMgr.Get6(
                        propName,
                        true,
                        out strVal,
                        out strResolved,
                        out blnWasResolved,
                        out blnLinkToProperty);
                    if (!rawValue)
                    {
                        strResolved = strResolved.Trim();
                        dr[fieldName] = GetPropDefaultValue(strResolved, typeName, propName);
                    }
                    else
                    {
                        dr[fieldName] = strVal;
                    }
                }
            }

            // Get model image
            // The default is swIsometricView = 7
            // Only get an image if the part is measured in discreet (non-continuous) units
            propScaffold.UomMapping.TryGetValue(dr["Uom"].ToString(), out string matchedUom);
            if (withImage && matchedUom == "EA")
            {
                byte[] bytes = PropertyScaffold.ImageToByteArray(GetIsometricImage());
                string imageString = Convert.ToBase64String(bytes);
                dr["Image"] = imageString;
            }

            // Get sheet metal properties
            if (swMainModel.GetType() == (int)swDocumentTypes_e.swDocPART && IsSheetMetal())
            {
                Feature cutList = GetUpdatedCutList();

                if (cutList != null)
                {
                    // Get sheet metal properties
                    //Feature cutList = swMainModel.SelectionManager.GetSelectedObject6(1, 0);
                    CustomPropertyManager cutPropMgr = cutList.CustomPropertyManager;
                    List<string> names = new List<string>(cutPropMgr.GetNames());
                    string strValOut; string strResolvedValOut; decimal decimalValOut; int intValOut; bool blnWasResolved, blnLinkToProperty;
                    cutPropMgr.Get6(
                        "Sheet Metal Thickness",
                        true,
                        out strValOut,
                        out strResolvedValOut,
                        out blnWasResolved,
                        out blnLinkToProperty);
                    Decimal.TryParse(strResolvedValOut, out decimal sheetThickness);
                    dr["Thickness"] = sheetThickness;
                    if (names.Contains("Sheet Metal Thickness") && sheetThickness != 0.0M)
                    {
                        cutPropMgr.Get6(
                            "Cutting Length-Outer",
                            true,
                            out strValOut,
                            out strResolvedValOut,
                            out blnWasResolved,
                            out blnLinkToProperty);
                        Decimal.TryParse(strResolvedValOut, out decimalValOut);
                        dr["CuttingLengthOuter"] = Decimal.Round(decimalValOut, 2);

                        cutPropMgr.Get6(
                            "Cutting Length-Inner",
                            true,
                            out strValOut,
                            out strResolvedValOut,
                            out blnWasResolved,
                            out blnLinkToProperty);
                        Decimal.TryParse(strResolvedValOut, out decimalValOut);
                        dr["CuttingLengthInner"] = Decimal.Round(decimalValOut, 2);

                        cutPropMgr.Get6(
                            "Cut Outs",
                            true,
                            out strValOut,
                            out strResolvedValOut,
                            out blnWasResolved,
                            out blnLinkToProperty);
                        int.TryParse(strResolvedValOut, out intValOut);
                        dr["CutOutCount"] = intValOut;

                        cutPropMgr.Get6(
                            "Bends",
                            true,
                            out strValOut,
                            out strResolvedValOut,
                            out blnWasResolved,
                            out blnLinkToProperty);
                        int.TryParse(strResolvedValOut, out intValOut);
                        dr["BendCount"] = intValOut;

                        Decimal mult = AZI_SWCustomProperties.Properties.AppSettings.Default.AreaFactor;
                        cutPropMgr.Get6(
                            "Bounding Box Length",
                            true,
                            out strValOut,
                            out strResolvedValOut,
                            out blnWasResolved,
                            out blnLinkToProperty);
                        Decimal.TryParse(strResolvedValOut, out decimal boxLength);
                        cutPropMgr.Get6(
                            "Bounding Box Width",
                            true,
                            out strValOut,
                            out strResolvedValOut,
                            out blnWasResolved,
                            out blnLinkToProperty);
                        Decimal.TryParse(strResolvedValOut, out decimal boxWidth);
                        Decimal qty = Math.Ceiling((boxLength + mult * sheetThickness) * (boxWidth + mult * sheetThickness));
                        dr["ChildQty"] = Decimal.Round(qty, 2);
                    }
                }
            }

            return dr;
        }

        public DataTable GetCustomProps(string configName = null, bool withImage = false, bool merge = false)
        {
            DataTable dt = propScaffold.MainTable;
            dt.TableName = "mainProps";
            if (configName == null)
            {
                dt.ImportRow(GetCustomProp(configName: "", withImage: withImage, merge: merge));
                foreach (string config in this.configNames)
                    dt.ImportRow(GetCustomProp(configName: config, withImage: withImage, merge: merge));
            }
            else if (configName == "" || configNames.Contains(configName))
                // Only try to get a DataRow if the config name exists in this model
                dt.ImportRow(GetCustomProp(configName, withImage: withImage, merge: merge));
            return dt;
        }

        public void WriteCustomProp(DataRow dr)
        {
            string thisConfigName = (string)dr["configname"];
            if (thisConfigName != "" && !configNames.Contains(thisConfigName))
            {
                string strExcept = String.Format("Config name {0} is not in this model", thisConfigName);
                throw new Exception(strExcept);
            }
            CustomPropertyManager swCustPropMgr = (CustomPropertyManager)swModelDocExt.get_CustomPropertyManager(thisConfigName);

            // Get existing property names
            string[] nameArray = swCustPropMgr.GetNames();
            List<string> propNames = new List<string>();
            if (nameArray != null)
                propNames.AddRange(swCustPropMgr.GetNames());

            // Check for a part number
            bool hasPartNum = dr["PartNum"].ToString() != "";

            // So far, we always store custom properties as text (i.e. swCustomInfoType_e.swCustomInfoText)
            foreach (DataRow drField in propScaffold.FieldDefs.Select("sw_prop is not null and sw_write=1"))
            {
                string propName = drField["sw_prop"].ToString();
                string fieldName = drField["field"].ToString();
                string typeName = drField["dt_type"].ToString();
                if (CheckPropDefaultValue(dr[fieldName], typeName))
                    // Remove the custom property
                    swCustPropMgr.Delete2(propName);
                else
                    // Add the custom property
                    swCustPropMgr.Add3(
                        propName,
                        propScaffold.PropTypes[propName],
                        dr[fieldName].ToString(),
                        (int)swCustomPropertyAddOption_e.swCustomPropertyDeleteAndAdd);
            }

            swMainModel.SetSaveFlag();
        }

        #endregion

        #region Model Image

        private Bitmap GetViewImage(int width, int height, string namedView = null, int swStandardView = 0)
        {
            // Where swStandardView is one of the following:
            // swStandardViews_e.swIsometricView = 7
            // swStandardViews_e.swTrimetricView = 8
            // swStandardViews_e.swDimetricView = 9
            // current view = 0
            // named view = -1

            ModelView swModelView = this.swMainModel.ActiveView;
            int errors = 0;
            if (swModelView == null)
                swApp.ActivateDoc3(modelName, false, (int)swRebuildOnActivation_e.swRebuildActiveDoc, ref errors);
                swModelView = this.swMainModel.ActiveView;
            swModelView.FrameState = (int)swWindowState_e.swWindowMaximized;

            // get current user settings
            bool prefViewDisplayHideAllTypes = swMainModel.GetUserPreferenceToggle((int)swUserPreferenceToggle_e.swViewDisplayHideAllTypes);

            // change settings for image extraction
            swMainModel.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swViewDisplayHideAllTypes, true);
            swMainModel.Extension.InsertScene("\\scenes\\01 basic scenes\\11 white kitchen.p2s");
            swModelView.DisplayMode = (int)swViewDisplayMode_e.swViewDisplayMode_HiddenLinesRemoved;
            if (namedView != null | swStandardView != 0)
            {
                // see enumeration swStandardViews_e
                swMainModel.ShowNamedView2(namedView, swStandardView);
            }
            swMainModel.Extension.HideFeatureManager(true);
            swMainModel.ViewZoomtofit2();

            // extract the image to temp file
            string tmpFilePathName = Path.GetTempFileName() + ".bmp";
            swMainModel.SaveBMP(tmpFilePathName, width, height);

            // darken the image lines
            using Mat src = new Mat(tmpFilePathName);
            //File.Delete(tmpFilePathName);
            using Mat dst = new Mat();
            var element = Cv2.GetStructuringElement(MorphShapes.Ellipse, new OpenCvSharp.Size(5, 5));
            Cv2.MorphologyEx(src, dst, MorphTypes.Erode, element);
            Cv2.ImWrite(tmpFilePathName, dst);

            // reload image from temp file
            Bitmap bmp = (Bitmap)FromFile(tmpFilePathName);
            File.Delete(tmpFilePathName);

            // apply original user settings
            swMainModel.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swViewDisplayHideAllTypes, prefViewDisplayHideAllTypes);
            swModelView.DisplayMode = (int)swViewDisplayMode_e.swViewDisplayMode_ShadedWithEdges;
            swMainModel.Extension.HideFeatureManager(false);

            return bmp;
        }

        private static Image FromFile(string path)
        {
            var bytes = File.ReadAllBytes(path);
            var ms = new MemoryStream(bytes);
            var img = Image.FromStream(ms);
            return img;
        }

        private static byte[][] GetRGB(Bitmap bmp)
        {

            BitmapData bmp_data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            IntPtr ptr = bmp_data.Scan0;
            int num_pixels = bmp.Width * bmp.Height;
            int num_bytes = bmp_data.Stride * bmp.Height;
            int padding = bmp_data.Stride - bmp.Width * 3;
            int i = 0;
            int ct = 1;

            byte[] r = new byte[num_pixels];
            byte[] g = new byte[num_pixels];
            byte[] b = new byte[num_pixels];
            byte[] rgb = new byte[num_bytes];
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgb, 0, num_bytes);

            for (int x = 0; x < num_bytes - 3; x += 3)
            {
                if (x == (bmp_data.Stride * ct - padding))
                {
                    x += padding; ct++;
                }
                r[i] = rgb[x];
                g[i] = rgb[x + 1];
                b[i] = rgb[x + 2];
                i++;
            }

            bmp.UnlockBits(bmp_data);
            return new byte[3][] { r, g, b };

        }

        private static Bitmap AutoCrop(Bitmap bmp)
        {

            //Get an array containing the R,G,B components of each pixel
            var pixels = GetRGB(bmp);

            int h = bmp.Height - 1;
            int w = bmp.Width;
            int top = 0;
            int bottom = h;
            int left = bmp.Width;
            int right = 0;
            int white = 0;
            int tolerance = 95; // 95%

            bool prev_color = false;
            for (int i = 0; i < pixels[0].Length; i++)
            {
                int x = (i % (w));
                int y = (int)(Math.Floor((decimal)(i / w)));
                int tol = 255 * tolerance / 100;

                if (pixels[0][i] >= tol && pixels[1][i] >= tol && pixels[2][i] >= tol)
                {
                    white++; right = (x > right && white == 1) ? x : right;
                }
                else
                {
                    left = (x < left && white >= 1) ? x : left;
                    right = (x == w - 1 && white == 0) ? w - 1 : right;
                    white = 0;
                }
                if (white == w)
                {
                    top = (y - top < 3) ? y : top;
                    bottom = (prev_color && x == w - 1 && y > top + 1) ? y : bottom;
                }
                left = (x == 0 && white == 0) ? 0 : left;
                bottom = (y == h && x == w - 1 && white != w && prev_color) ? h + 1 : bottom;
                if (x == w - 1)
                {
                    prev_color = (white < w) ? true : false; white = 0;
                }
            }
            right = (right == 0) ? w : right;
            left = (left == w) ? 0 : left;

            //Crop the image
            if (bottom - top > 1)
            {
                Bitmap bmpCrop = bmp.Clone(new Rectangle(left, top, right - left + 1, bottom - top), bmp.PixelFormat);

                return (Bitmap)(bmpCrop);
            }
            else
            {
                return bmp;
            }

        }

        private static Bitmap ResizeImage(Bitmap bmpOrig, int intWidth, int intHeight)
        {

            bmpOrig.Save("C:\\temp\\test_orig.png", System.Drawing.Imaging.ImageFormat.Png);
            Image sourceImage = (Image)AutoCrop(bmpOrig);
            sourceImage.Save("C:\\temp\\test_cropped.png", System.Drawing.Imaging.ImageFormat.Png);

            //return (Bitmap)sourceImage;

            System.Drawing.Size sizeOut = new System.Drawing.Size(intWidth, intHeight);
            int sourceWidth = sourceImage.Width;
            int sourceHeight = sourceImage.Height;

            // percent size change
            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;
            nPercentW = ((float)sizeOut.Width / (float)sourceWidth);
            nPercentH = ((float)sizeOut.Height / (float)sourceHeight);

            // keeping aspect ratio
            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;


            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);
            int leftOffset = (int)((sizeOut.Width - destWidth) / 2);
            int topOffset = (int)((sizeOut.Height - destHeight) / 2);

            var destRect = new Rectangle(leftOffset, topOffset, destWidth, destHeight);


            Bitmap destImage = new Bitmap(sizeOut.Width, sizeOut.Height);
            destImage.SetResolution(sourceImage.HorizontalResolution, sourceImage.VerticalResolution);

            using (var graphics = Graphics.FromImage((Image)destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.Clear(Color.White);

                //graphics.DrawImage(sourceImage, destRect, -leftOffset, -topOffset, sourceImage.Width, sourceImage.Height, GraphicsUnit.Pixel);
                graphics.DrawImage(sourceImage, destRect, 0, 0, sourceImage.Width, sourceImage.Height, GraphicsUnit.Pixel);

                //using (var wrapMode = new System.Drawing.Imaging.ImageAttributes())
                //{
                //    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                //    graphics.DrawImage(sourceImage, destRect, leftOffset, topOffset, sourceImage.Width, sourceImage.Height, GraphicsUnit.Pixel, wrapMode);
                //}
            }
            destImage.Save("C:\\temp\\test_resized.png", System.Drawing.Imaging.ImageFormat.Png);

            return (Bitmap)destImage;

        }

        public Bitmap GetIsometricImage()
        {
            int imageWidth = AZI_SWCustomProperties.Properties.AppSettings.Default.ImageWidth;
            int imageHeight = AZI_SWCustomProperties.Properties.AppSettings.Default.ImageHeight;
            Bitmap bmp = GetViewImage(imageWidth*2, imageHeight*2, null, (int)swStandardViews_e.swIsometricView);
            Bitmap bmp2 = ResizeImage(bmp, imageWidth, imageHeight);
            return bmp2;
        }

        public Bitmap GetNamedImage(string namedView)
        {
            int imageWidth = AZI_SWCustomProperties.Properties.AppSettings.Default.ImageWidth;
            int imageHeight = AZI_SWCustomProperties.Properties.AppSettings.Default.ImageHeight;
            Bitmap bmp = GetViewImage((int)(imageWidth * 2), (int)(imageHeight * 2), namedView, -1);
            Bitmap bmp2 = ResizeImage(bmp, imageWidth, imageHeight);
            return bmp2;
        }

        public Bitmap GetCurrentImage()
        {
            int imageWidth = AZI_SWCustomProperties.Properties.AppSettings.Default.ImageWidth;
            int imageHeight = AZI_SWCustomProperties.Properties.AppSettings.Default.ImageHeight;
            Bitmap bmp = GetViewImage((int)(imageWidth * 2), (int)(imageHeight * 2), null, -1);
            Bitmap bmp2 = ResizeImage(bmp, imageWidth, imageHeight);
            return bmp2;
        }

        public Bitmap GetStandardImage(int viewNumber)
        {
            int imageWidth = AZI_SWCustomProperties.Properties.AppSettings.Default.ImageWidth;
            int imageHeight = AZI_SWCustomProperties.Properties.AppSettings.Default.ImageHeight;
            Bitmap bmp = GetViewImage((int)(imageWidth * 2), (int)(imageHeight * 2), null, viewNumber);
            Bitmap bmp2 = ResizeImage(bmp, imageWidth, imageHeight);
            return bmp2;
        }

        #endregion

        private bool IsSheetMetal()
        {
            // Check if part is sheet metal
            PartDoc swPartDoc = (PartDoc)swMainModel;
            object[] bodies = (object[])swPartDoc.GetBodies2((int)swBodyType_e.swSolidBody, true);
            if (bodies == null)
                return false;
            foreach (Body2 body in bodies)
                if (body.IsSheetMetal())
                    return true;
            return false;

            // Check if part is sheet metal
            //Feature swFeat = (Feature)swMainModel.FirstFeature();
            //bool isSheetMetal = false;
            //while (swFeat != null)
            //{
            //    if (swFeat.GetTypeName2() == "SheetMetal")
            //    {
            //        isSheetMetal = true;
            //        break;
            //    }
            //    swFeat = swFeat.GetNextFeature();
            //}
            //return isSheetMetal;
        }

        private Feature GetUpdatedCutList()
        {
            Feature swFeat = (Feature)swMainModel.FirstFeature();
            while (swFeat != null)
            {
                if (swFeat.GetTypeName2() == "SolidBodyFolder")
                {
                    BodyFolder swBodyFolder = swFeat.GetSpecificFeature2();
                    swBodyFolder.SetAutomaticCutList(true);
                    swBodyFolder.SetAutomaticUpdate(true);
                    Feature cutList = swFeat.GetFirstSubFeature();
                    while (cutList != null)
                    {
                        if (cutList.GetTypeName2() == "CutListFolder")
                            return cutList;
                        cutList = cutList.GetNextSubFeature();
                    }
                    return null;
                }
                swFeat = swFeat.GetNextFeature();
            }
            return null;
        }

        public void ResolveAllComps()
        {
            swMainAssembly.ResolveAllLightWeightComponents(false);
        }

        public SwComponentWrapper GetRootComponentWrapper()
        {
            return new SwComponentWrapper(swApi, swApp, (Component2)swMainConfig.GetRootComponent());
        }
    }

    public class SwComponentWrapper
    {
        private SwApiWrapper swApi;
        private SldWorks swApp;
        private Component2 swComp;
        public bool Suppressed
        {
            get
            {
                return (swComponentSuppressionState_e)swComp.GetSuppression() == swComponentSuppressionState_e.swComponentSuppressed;
            }
        }
        public bool ExcludeFromBOM
        {
            get
            {
                return swComp.ExcludeFromBOM;
            }
        }
        public string PathName
        {
            get
            {
                return swComp.GetPathName();
            }
        }
        public string FileName
        {
            get
            {
                string pathName = swComp.GetPathName();
                return pathName.Substring(
                    pathName.LastIndexOf("\\") + 1,
                    pathName.Length - pathName.LastIndexOf("\\") - 1);
            }
        }
        public string ConfigName
        {
            get
            {
                return swComp.ReferencedConfiguration;
            }
        }

        public SwComponentWrapper(SwApiWrapper swApi, SldWorks swApp, Component2 SwCompWrap)
        {
            this.swApp = swApp;
            this.swComp = SwCompWrap;
        }

        public SwModelWrapper GetModelWrapper()
        {
            ModelDoc2 swModel = swComp.GetModelDoc2();
            return new SwModelWrapper(swApi, swApp, (swDocumentTypes_e)swModel.GetType(), swModel, this.swComp.ReferencedConfiguration);
        }

        public SwModelWrapper GetModelWrapper(string configName)
        {
            ModelDoc2 swModel = swComp.GetModelDoc2();
            return new SwModelWrapper(swApi, swApp, (swDocumentTypes_e)swModel.GetType(), swModel, configName);
        }

        public List<SwComponentWrapper> GetComponents()
        {
            object oChildren = this.swComp.GetChildren();
            System.Array aChildren = (Array)oChildren;
            List<SwComponentWrapper> comps = new List<SwComponentWrapper>();
            foreach (Component2 comp in aChildren)
            {
                comps.Add(new SwComponentWrapper(swApi, swApp, comp));
            }
            return comps;
        }

    }

}
