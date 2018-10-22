using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using System.Collections;

namespace ItAintBoring.EZChange.Core.Dynamics
{
    public class ReferenceResolution
    {
        static Hashtable metadataHash = new Hashtable();

        public static EntityMetadata GetMetadata(IOrganizationService service, string logicalName)
        {
            string keyName = logicalName + "_meta";
            if (!metadataHash.Contains(keyName))
            {
                RetrieveEntityRequest request = new RetrieveEntityRequest
                {
                    EntityFilters = EntityFilters.Entity | EntityFilters.Relationships,
                    LogicalName = logicalName
                };
                RetrieveEntityResponse response = (RetrieveEntityResponse)service.Execute(request);
                metadataHash[keyName] = response.EntityMetadata;
            }
            return (EntityMetadata)metadataHash[keyName];
        }

        public static bool RecordExists(IOrganizationService service, EntityReference er)
        {
            bool result = false;
            var metadata = GetMetadata(service, er.LogicalName);
            QueryExpression qe = new QueryExpression(er.LogicalName);
            qe.Criteria.AddCondition(new ConditionExpression(metadata.PrimaryIdAttribute, ConditionOperator.Equal, er.Id));
            result = service.RetrieveMultiple(qe).Entities.FirstOrDefault() != null;
            return result;
        }


        private static EntityReference defaultBusinessUnit = null;
        public static EntityReference GetDefaultBusinessUnit(IOrganizationService service)
        {
            if (defaultBusinessUnit == null)
            {
                QueryExpression qe = new QueryExpression("businessunit");
                qe.ColumnSet = new ColumnSet("businessunitid");
                qe.Criteria.AddCondition(new ConditionExpression("parentbusinessunitid", ConditionOperator.Null));
                var bu = service.RetrieveMultiple(qe).Entities.FirstOrDefault();
                if (bu != null) defaultBusinessUnit = bu.ToEntityReference();
            }
            return defaultBusinessUnit;
        }
        public static void ResolveReferences(IOrganizationService service, Entity entity)
        {
            var metadata = GetMetadata(service, entity.LogicalName);
            if (entity.Contains("businessunitid") && entity["businessunitid"] != null) //it's there and it's not being set to null
            {
                entity["businessunitid"] = GetDefaultBusinessUnit(service); 
            }

            List<string> removeAttributes = new List<string>();
            foreach (var a in entity.Attributes)
            {

                if (a.Key != "businessunitid" //can't update the attribute here since it's a for loop
                    && a.Value is EntityReference
                    && !RecordExists(service, (EntityReference)a.Value))
                {

                    removeAttributes.Add(a.Key);
                }
            }

            foreach (var key in removeAttributes)
            {
                entity.Attributes.Remove(key);
            }
        }

    }
}
