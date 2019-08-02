// copied from https://github.com/moylop260/odoo-dev/blob/master/addons/plugin_outlook/static/openerp-outlook-plugin/OpenERPClient/XMLRPCClient.cs
// (permalink) https://github.com/moylop260/odoo-dev/blob/b27a3351af1cad72b852788a2a59a79256e6e644/addons/plugin_outlook/static/openerp-outlook-plugin/OpenERPClient/XMLRPCClient.cs#L54
// also from https://stackoverflow.com/questions/51404705/how-to-connect-or-login-with-odoo-using-c-sharp-code-and-after-connect-with-odo

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookComputing.XmlRpc;

namespace OdooClient
{

    public interface IOdooCommon : IXmlRpcProxy
    {
        [XmlRpcMethod("login")]
        int Login(string dbname, string username, string pwd);

    }

    public interface IOdooObject : IXmlRpcProxy
    {

        [XmlRpcMethod("execute")]
        Object Execute(string dbName, int userId, string pwd, string model, string method, params Object[] args);

        [XmlRpcMethod("execute")]
        int Create(String dbName, int userId, string dbPwd, string model, string method, XmlRpcStruct fieldValues);

        [XmlRpcMethod("execute")]
        object[] Read(string dbName, int userId, string dbPwd, string model, string method, int[] ids, object[] fields);

        [XmlRpcMethod("execute")]
        int[] Search(string dbName, int userId, string dbPwd, string model, string method, object[] filter);

    }

    public interface IOdooDB : IXmlRpcProxy
    {

        [XmlRpcMethod("list")]
        Object[] DBList();

        [XmlRpcMethod("server_version")]
        string ServerVersion();

    }

    public interface Ixmlrpcconnect : IOdooCommon, IOdooDB, IOdooObject
    {
    }

    public class XMLRPCClient : Ixmlrpcconnect
    {
        Ixmlrpcconnect rpcclient = (Ixmlrpcconnect)XmlRpcProxyGen.Create(typeof(Ixmlrpcconnect));

        private string dbName;
        public string DbName
        {
            get
            {
                return dbName;
            }
        }
        private string userName;
        public string UserName
        {
            get
            {
                return userName;
            }
        }
        private string userPwd;
        public string UserPwd
        {
            get
            {
                return userPwd;
            }
        }
        private int userId = 0;
        public int UserId
        {
            get
            {
                return userId;
            }
        }

        public XMLRPCClient(string ServiceUrl)
        {
            rpcclient.Url = ServiceUrl;
        }

        #region Ixmlrpcconnect Members

        public int Login(string dbname, string username, string pwd)
        {
            int uid = rpcclient.Login(dbname, username, pwd);
            this.userId = uid;
            this.userName = username;
            this.userPwd = pwd;
            this.dbName = dbname;
            return uid;
        }

        public object Execute(string dbName, int userId, string pwd, string model, string method, params object[] args)
        {
            return rpcclient.Execute(dbName, userId, pwd, model, method, args);
        }

        public int Create(string dbName, int userId, string pwd, string model, string method, XmlRpcStruct fieldValues)
        {
            return rpcclient.Create(dbName, userId, pwd, model, method, fieldValues);
        }

        public object[] Read(string dbName, int userId, string pwd, string model, string method, int[] ids, object[] fields)
        {
            try
            {
                return rpcclient.Read(dbName, userId, pwd, model, method, ids, fields);
            }
            catch
            {
                return null;
            }
        }

        public int[] Search(string dbName, int userId, string pwd, string model, string method, object[] filter)
        {
            try
            {
                return rpcclient.Search(dbName, userId, pwd, model, method, filter);
            }
            catch
            {
                return null;
            }
        }

        public object[] DBList()
        {
            return rpcclient.DBList();
        }

        public string ServerVersion()
        {
            return rpcclient.ServerVersion();
        }
        #endregion


        #region IXmlRpcProxy Members

        public bool AllowAutoRedirect
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public System.Security.Cryptography.X509Certificates.X509CertificateCollection ClientCertificates
        {
            get { throw new NotImplementedException(); }
        }

        public string ConnectionGroupName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public System.Net.CookieContainer CookieContainer
        {
            get { throw new NotImplementedException(); }
        }

        public System.Net.ICredentials Credentials
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool EnableCompression
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool Expect100Continue
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public System.Net.WebHeaderCollection Headers
        {
            get { throw new NotImplementedException(); }
        }

        public Guid Id
        {
            get { throw new NotImplementedException(); }
        }

        public int Indentation
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool KeepAlive
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public XmlRpcNonStandard NonStandard
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool PreAuthenticate
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Version ProtocolVersion
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public System.Net.IWebProxy Proxy
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public System.Net.CookieCollection ResponseCookies
        {
            get { throw new NotImplementedException(); }
        }

        public System.Net.WebHeaderCollection ResponseHeaders
        {
            get { throw new NotImplementedException(); }
        }

        public int Timeout
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string Url
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool UseEmptyParamsTag
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool UseIndentation
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool UseIntTag
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool UseStringTag
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string UserAgent
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Encoding XmlEncoding
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string XmlRpcMethod
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string[] SystemListMethods()
        {
            throw new NotImplementedException();
        }

        public object[] SystemMethodSignature(string MethodName)
        {
            throw new NotImplementedException();
        }

        public string SystemMethodHelp(string MethodName)
        {
            throw new NotImplementedException();
        }

        public event XmlRpcRequestEventHandler RequestEvent;

        public event XmlRpcResponseEventHandler ResponseEvent;

        #endregion
    }

    public class OdooProduct
    {
        private XMLRPCClient oObject;
        private string productCode;
        private int productId;
        private int templateId;
        private string db;
        private int ui;
        private string pw;
        private object[] prodFields = new object[] {
            "id",
            "default_code",
            "product_tmpl_id",
        };
        private object[] tmplFields = new object[] {
            "id",
            "name",
            "display_name",
            "uom_id",
            "eng_categ_id",
            "image",
            "cutting_length_outer",
            "cutting_length_inner",
            "cut_out_count",
            "bend_count",
        };

        private XmlRpcStruct productRecord;
        public XmlRpcStruct ProductRecord
        {
            get
            {
                return productRecord;
            }
        }
        private XmlRpcStruct templateRecord;
        public XmlRpcStruct TemplateRecord
        {
            get
            {
                return templateRecord;
            }
        }

        public OdooProduct(string odooUrl, XMLRPCClient oClient, string productCode)
        {
            this.productCode = productCode;
            this.db = oClient.DbName;
            this.ui = oClient.UserId;
            this.pw = oClient.UserPwd;
            this.oObject = new XMLRPCClient(odooUrl + "/object");
            Refresh();
        }

        public void Refresh()
        {
            object[] filter = new object[1];
            filter[0] = new object[3] { "default_code", "=", productCode };
            int[] ids = oObject.Search(db, ui, pw, "product.product", "search", filter);
            object[] records = oObject.Read(db, ui, pw, "product.product", "read", ids, this.prodFields);
            if (records == null)
                return;
            this.productRecord = (XmlRpcStruct)records[0];
            this.productId = ids[0];

            this.templateId = (int)((object[])this.productRecord["product_tmpl_id"])[0];
            filter[0] = new object[3] { "id", "=", this.templateId };
            ids = oObject.Search(db, ui, pw, "product.template", "search", filter);
            records = oObject.Read(db, ui, pw, "product.template", "read", ids, this.tmplFields);
            if (records == null)
                return;
            this.templateRecord = (XmlRpcStruct)records[0];
        }

        public void Write(Dictionary<string, Object> values)
        {
            XmlRpcStruct prodStruct = new XmlRpcStruct();
            XmlRpcStruct tmplStruct = new XmlRpcStruct();
            foreach (KeyValuePair<string, object> field in values)
                if (prodFields.Contains(field.Key))
                    prodStruct.Add(field.Key, field.Value);
                else if (tmplFields.Contains(field.Key))
                    tmplStruct.Add(field.Key, field.Value);
            if (prodStruct.Count > 0)
                oObject.Execute(db, ui, pw, "product.product", "write", this.productId, prodStruct);
            if (tmplStruct.Count > 0)
                oObject.Execute(db, ui, pw, "product.template", "write", this.templateId, tmplStruct);
            Refresh();
        }

    }

}
