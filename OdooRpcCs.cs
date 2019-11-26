using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nwc.XmlRpc;


namespace OdooRpcCs
{
    public class OdooClient
    {

        private string url;
        public string Url
        {
            get
            {
                return url;
            }
            set
            {
                url = value;
            }
        }

        private string dbName;
        public string DbName
        {
            get
            {
                return dbName;
            }
            set
            {
                dbName = value;
            }
        }

        private string userName;
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
            }
        }

        private string userPwd;
        public string UserPwd
        {
            get
            {
                return userPwd;
            }
            set
            {
                userPwd = value;
            }
        }

        private int userId;
        public int UserId
        {
            get
            {
                return userId;
            }
        }

        private int commonTimeout = 3000;
        public int CommonTimeout
        {
            get
            {
                return commonTimeout;
            }
            set
            {
                commonTimeout = value;
            }
        }

        private int objectTimeout = 5000;
        public int ObjectTimeout
        {
            get
            {
                return objectTimeout;
            }
            set
            {
                objectTimeout = value;
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

        public OdooClient(string url, string dbName, string userName, string userPwd)
        {
            this.url = url;
            this.dbName = dbName;
            this.userName = userName;
            this.userPwd = userPwd;
        }

        public bool Login(int? timeout = null)
        {
            latestException = "";
            int userTimeout = timeout == null ? commonTimeout : (int)timeout;

            XmlRpcRequest client = new XmlRpcRequest();
            client.MethodName = "login";
            client.Params.Clear();
            client.Params.Add(this.dbName);
            client.Params.Add(this.userName);
            client.Params.Add(this.userPwd);
            int ui;
            try
            {
                XmlRpcResponse response = client.Send(this.Url + "/common", userTimeout);
                if (response.IsFault)
                {
                    latestException = response.Value.ToString();
                    return false;
                }
                ui = (int)response.Value;
            }
            catch (Exception exc)
            {
                latestException = exc.Message;
                return false;
            }

            this.userId = ui;
            return true;
        }

        public object Execute(string model, string method, ArrayList parameters, int? timeout = null)
        {
            latestException = "";
            int userTimeout = timeout == null ? objectTimeout : (int)timeout;

            XmlRpcRequest objectClient = new XmlRpcRequest();
            objectClient.MethodName = "execute";
            objectClient.Params.Clear();
            objectClient.Params.Add(this.dbName);
            objectClient.Params.Add(this.userId);
            objectClient.Params.Add(this.userPwd);
            objectClient.Params.Add(model);
            objectClient.Params.Add(method);

            foreach (object obj in parameters)
                objectClient.Params.Add(obj);

            object resVal;
            try
            {
                XmlRpcResponse objectResponse = objectClient.Send(this.url + "/object", userTimeout);
                if (objectResponse.IsFault)
                {
                    throw new Exception(((Hashtable)objectResponse.Value)["faultCode"].ToString());
                    //latestException = objectResponse.Value.ToString();
                    //return null;
                }
                resVal = objectResponse.Value;
            }
            catch (Exception exc)
            {
                latestException = exc.Message;
                return null;
            }

            return resVal;
        }

        public ArrayList Read(string model, ArrayList ids, ArrayList fields)
        {
            ArrayList execParams = new ArrayList(2);
            execParams.Add(ids);
            execParams.Add(fields);
            object response = Execute(model, "read", execParams);
            if (response == null)
                return new ArrayList();
            return (ArrayList)response;
        }

        public ArrayList Search(string model, ArrayList domain)
        {
            ArrayList execParams = new ArrayList() { domain };
            object response = Execute(model, "search", execParams);
            if (response == null)
                return new ArrayList();
            return (ArrayList)response;
        }

        public ArrayList Browse(string model, ArrayList domain, ArrayList fields)
        {
            ArrayList ids = Search(model, domain);
            ArrayList response = Read(model, ids, fields);
            return response;
        }

        public bool Write(string model, int id, Hashtable values)
        {
            ArrayList execParams = new ArrayList() { id, values };
            object res = Execute(model, "write", execParams);
            return res != null ? (bool)res : true;
        }

        public int Create(string model, Hashtable values)
        {
            ArrayList execParams = new ArrayList() { values };
            object res = Execute(model, "create", execParams);
            return (int)res;
        }

    }

}
