using System.Net;
using System;
using BidfoodCreditApplication.WebAPI;

namespace BidfoodCreditApplication.Models
{
    public class CherwellWebConnector
    {
        private api _cherwellService;
        private DateTime LoginTimer;
            
            internal bool Login(string username, string password)
        {
            _cherwellService = new api
            {
                CookieContainer = new CookieContainer(500,100,8192)

        };
            
            return _cherwellService.Login(username, password);


        }

        internal bool Logout()
        {
            var result = false;
            try
            {
                result = !_cherwellService.Logout();
                _cherwellService = null;
               
            }
            catch
            {

                
            }

            return result;
            
        }

        public string CreateBusinessObject(string busObName, string objectXml)
        {
            var text = _cherwellService.CreateBusinessObject(busObName, objectXml);
            if (!string.IsNullOrEmpty(text))
                return text;
            return GetLastError();
        }

        public string UpdateBusinessObject(string busObName, string recId, string objectXml)
        {
            var flag = _cherwellService.UpdateBusinessObject(busObName, recId, objectXml);
            if (flag)
                return "Record Updated Successfully";
            return GetLastError();
        }

        public string UpdateBusinessObjectByPublicId(string busObName, string publicId, string objectXml)
        {
            var flag = _cherwellService.UpdateBusinessObjectByPublicId(busObName, publicId, objectXml);
            if (flag)
                return "Record Updated Successfully";
            return GetLastError();
        }

        public string QueryByStoredQuery(string busObName, string searchQuery)
        {
            var text = _cherwellService.QueryByStoredQuery(busObName, searchQuery);
            if (!string.IsNullOrEmpty(text))
                return text;
            return GetLastError();
        }

        public string QueryByFieldValue(string busObName, string fieldName, string fieldValue)
        {
            var text = _cherwellService.QueryByFieldValue(busObName, fieldName, fieldValue);
            if (!string.IsNullOrEmpty(text))
                return text;
            return GetLastError();
        }

        public string GetBusinessObject(string busObName, string recId)
        {
            var businessObject = _cherwellService.GetBusinessObject(busObName, recId, true);
            if (!string.IsNullOrEmpty(businessObject))
                return businessObject;
            return GetLastError();
        }

        public string QuickSearch(string busObName, string searchText)
        {
            var text = _cherwellService.QuickSearch(busObName, searchText, true, true, 30, "Seconds");
            if (!string.IsNullOrEmpty(text))
                return text;
            return GetLastError();
        }

        public string GetBusinessObjectDefinition(string busObName)
        {
            var businessObjectDefinition = _cherwellService.GetBusinessObjectDefinition(busObName);
            if (!string.IsNullOrEmpty(businessObjectDefinition))
                return businessObjectDefinition;
            return GetLastError();
        }

        public bool ConfirmLogin(string username, string password)
        {
            
            if (_cherwellService == null)
            {

                _cherwellService = new api
                {
                    CookieContainer = new CookieContainer(500, 100, 8192)

                };
                LoginTimer = DateTime.Now;
                return _cherwellService.Login(username, password);

            }
            if (DateTime.Now >= LoginTimer.AddMilliseconds(300000))
            {
                LoginTimer = DateTime.Now;
                return _cherwellService.Login(username, password);
            }
            LoginTimer = DateTime.Now;
            return true;
        }

        public bool AttachFile(string busObj, string recId, string attachementName, string attachementData)
        {
            return _cherwellService.AddAttachmentToRecord(busObj, recId, attachementName, attachementData);
        }

        private string GetLastError()
        {
            return _cherwellService.GetLastError();
        }


    }
}