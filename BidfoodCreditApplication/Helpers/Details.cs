using System.Collections.Generic;
using BidfoodCreditApplication.Models;

namespace BidfoodCreditApplication.Helpers
{
    public class Details
    {
        public static CherwellBusinessObject GetDetails(string busObj, string recId)
        {
            var businessObject = Global.CherwellConnection.GetBusinessObject(busObj, recId);
            return CherwellBusinessObject.FromXmlString(businessObject);
        }

        public static string UpdateDetails(string busObj, string recId, CherwellBusinessObject newUser)
        {
            return Global.CherwellConnection.UpdateBusinessObject(busObj, recId, newUser.ToXmlString());
        }

        public static CherwellBusinessObject GetEmptyCherwellBusinessObject(string busObj, string field,
            string fieldValue, string xmlElement)
        {
            var recordId = RecordId.GetRecordId(Global.CherwellConnection.QueryByFieldValue(busObj, field, fieldValue),
                xmlElement);
            var cherwellBusinessObject = new CherwellBusinessObject();
            foreach (var current in recordId)
            {
                cherwellBusinessObject = GetDetails(busObj, current);
                var fields = cherwellBusinessObject.FieldList.Fields;
                for (var i = 0; i < fields.Length; i++)
                {
                    var cherwellField = fields[i];
                    cherwellField.Value = "";
                }
            }
            return cherwellBusinessObject;
        }

        public static List<CherwellBusinessObject> GetListCherwellBusinessObjects(string busObj, string field,
            string fieldValue, string xmlElement)
        {
            var recordId = RecordId.GetRecordId(Global.CherwellConnection.QueryByFieldValue(busObj, field, fieldValue),
                xmlElement);
            var list = new List<CherwellBusinessObject>();
            foreach (var current in recordId)
                list.Add(GetDetails(busObj, current));
            return list;
        }

        public static string CreateCherwellBusinessObject(string busObj, CherwellBusinessObject createObject)
        {
            var text = createObject.ToXmlString();
            return Global.CherwellConnection.CreateBusinessObject(busObj, createObject.ToXmlString());
        }

        public static string GetBusObjType(string busObj, string field, string fieldValue, string xmlElement,
            string fieldName)
        {
            var recordId = RecordId.GetRecordId(Global.CherwellConnection.QueryByFieldValue(busObj, field, fieldValue),
                xmlElement);
            var result = string.Empty;
            foreach (var current in recordId)
            {
                var details = GetDetails(busObj, current);
                var fields = details.FieldList.Fields;
                for (var i = 0; i < fields.Length; i++)
                {
                    var cherwellField = fields[i];
                    if (cherwellField.Name == fieldName)
                        result = cherwellField.Value;
                }
            }
            return result;
        }
    }
}