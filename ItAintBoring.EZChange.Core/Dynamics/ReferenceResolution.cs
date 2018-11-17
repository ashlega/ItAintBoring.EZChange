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
        static Hashtable attributeMetadataHash = new Hashtable();

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

        public static AttributeMetadata GetAttributeMetadata(IOrganizationService service, string entityLogicalName, string attributeLogicalName)
        {
            string keyName = entityLogicalName + "_" + attributeLogicalName;
            if (!attributeMetadataHash.Contains(keyName))
            {
                RetrieveAttributeRequest request = new RetrieveAttributeRequest
                {
                    EntityLogicalName = entityLogicalName,
                    LogicalName = attributeLogicalName
                };
                RetrieveAttributeResponse response = (RetrieveAttributeResponse)service.Execute(request);
                attributeMetadataHash[keyName] = response.AttributeMetadata;
            }
            return (AttributeMetadata)attributeMetadataHash[keyName];
        }

        public static string GetAttributeCodeTypeName(IOrganizationService service, string entityLogicalName, string attributeLogicalName)
        {
            var am = GetAttributeMetadata(service, entityLogicalName, attributeLogicalName);
            if (am == null) return null;
            switch (am.AttributeType.ToString())
            {
                case "Status": //Status
                    return (typeof(Microsoft.Xrm.Sdk.OptionSetValue)).Name;
                case "Picklist": //Picklist
                    return (typeof(Microsoft.Xrm.Sdk.OptionSetValue)).Name;
                case "State": //State
                    return (typeof(Microsoft.Xrm.Sdk.OptionSetValue)).Name;
                case "Decimal": //Decimal
                    return (typeof(Double)).Name;
                case "Enum": //Enum
                    break;
                case "Memo": //Memo
                    return (typeof(String)).Name;
                case "Money": //Money
                    return (typeof(Microsoft.Xrm.Sdk.Money)).Name;
                case "Lookup":
                case "Customer":
                    return (typeof(Microsoft.Xrm.Sdk.EntityReference)).Name;
                case "Integer":
                    return (typeof(int)).Name;
                case "Owner":
                    return (typeof(Microsoft.Xrm.Sdk.EntityReference)).Name;
                    //return (typeof(Guid)).Name;
                    
                case "DateTime": //DateTime
                    return (typeof(DateTime)).Name;
                    
                case "Boolean": //Boolean
                    return (typeof(bool)).Name;
                case "String": //String
                    return (typeof(String)).Name;
                    
                case "Double": //Double
                    return (typeof(Microsoft.Xrm.Sdk.OptionSetValue)).Name;
                case "EntityName": //Entity Name
                    break;
                case "Image": //Image, it will return image name.
                    break;
                case "BigInt":
                    break;
                case "ManagedProperty":
                    break;
                case "Uniqueidentifier":
                    return (typeof(Guid)).Name; ;
                case "Virtual":
                    break;
                default:
                    //TODO: Write Err Exception
                    break;
            }
            return null;
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
