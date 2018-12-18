using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace ItAintBoring.EZChange.Core.Dynamics
{

    [DataContract]
    public class ImportAllSettings
    {
        [DataMember]
        public bool includeHome { get; set; }

        [DataMember]
        public bool alwaysUpdate { get; set; }
    }

    [DataContract]
    public class DataSetResource
    {
        [DataMember]
        public string description { get; set; }

        [DataMember]
        public string displayname { get; set; }

        [DataMember]
        public string order { get; set; }

        [DataMember]
        public string fetchxml { get; set; }

        [DataMember]
        public string lookupfield { get; set; }

        [DataMember]
        public bool createonly { get; set; }

        [DataMember]
        public string modifiedon { get; set; }

        [DataMember]
        public string appliedon { get; set; }

        [DataMember]
        public string appliedin { get; set; }

        [DataMember]
        public string homeorganization { get; set; }

        [DataMember]
        public string type { get; set; }

        [DataMember]
        public string resourcename { get; set; }

        [DataMember]
        public string webresourceid { get; set; }

    }

    [DataContract(Name = "Attribute")]
    public class SerializableEntityAttribute
    {
        [DataMember]
        public string Key { get; set; }

        //[DataMember(Name="Type")]
        public string TypeName { get; set; }

        [DataMember]
        public string Value { get; set; }

        public SerializableEntityAttribute()
        {
        }

        public SerializableEntityAttribute(KeyValuePair<string, object> a, int guidShift)
        {
            ConvertFromAttribute(a, guidShift);
        }

        

        public void ConvertFromAttribute(KeyValuePair<string, object> a, int guidShift)
        {
            Key = a.Key;
            TypeName = a.Value.GetType().ToString().ToLower();
            if (TypeName.Contains("guid"))
            {
                Value = Common.ShiftString(a.Value.ToString(), guidShift);
            }
            else if (TypeName.Contains("entityreference"))
            {
                var er = (EntityReference)a.Value;
                Value = Common.ShiftString(er.Id.ToString(), guidShift) + ":" + er.LogicalName;
            }
            else if (TypeName.Contains("string"))
            {
                Value = a.Value.ToString();
            }
            else if (TypeName.Contains("int"))
            {
                Value = a.Value.ToString();
            }
            else if (TypeName.Contains("double"))
            {
                Value = a.Value.ToString();
            }
            else if (TypeName.Contains("float"))
            {
                Value = a.Value.ToString();
            }
            else if (TypeName.Contains("decimal"))
            {
                Value = a.Value.ToString();
            }
            else if (TypeName.Contains("datetime"))
            {
                Value = a.Value.ToString();
            }
            else if (TypeName.Contains("optionsetvalue"))
            {
                Value = ((OptionSetValue)a.Value).Value.ToString();
            }
            else if (TypeName.Contains("money"))
            {
                Value = ((Money)a.Value).Value.ToString();
            }
            else if (TypeName.Contains("boolean"))
            {
                Value = a.Value.ToString();
            }
            else if (TypeName.Contains("entitycollection"))
            {
                Value = null;
            }
            else
            {
                throw new InvalidPluginExecutionException("Type not supported: " + TypeName);
            }
        }

        //No need for buid backshift - the point is to have new guids
        public KeyValuePair<string, object> ConvertToAttribute(IOrganizationService service, string entityName, int guidShift)
        {
            if (Value == null) return new KeyValuePair<string, object>(Key, null);

            Object attributeValue = null;

            TypeName = ReferenceResolution.GetAttributeCodeTypeName(service, entityName, Key).ToLower();
            if (TypeName == null) throw new Exception("Cannot find type name for " + entityName + ":" + Key);
            if (TypeName.Contains("guid"))
            {
                attributeValue = Guid.Parse(Value.ToString());
            }
            else if (TypeName.Contains("entityreference"))
            {
                string[] pair = ((string)Value).Split(':');
                attributeValue = new EntityReference(pair[1], Guid.Parse(pair[0]));
            }
            else if (TypeName.Contains("string"))
            {
                attributeValue = (string)Value;
            }
            else if (TypeName.Contains("int"))
            {
                attributeValue = int.Parse((string)Value);
            }
            else if (TypeName.Contains("double"))
            {
                attributeValue = double.Parse((string)Value);
            }
            else if (TypeName.Contains("float"))
            {
                attributeValue = float.Parse((string)Value);
            }
            else if (TypeName.Contains("decimal"))
            {
                attributeValue = decimal.Parse((string)Value);
            }
            else if (TypeName.Contains("datetime"))
            {
                attributeValue = DateTime.Parse((string)Value);
            }
            else if (TypeName.Contains("optionsetvalue"))
            {
                attributeValue = new OptionSetValue(int.Parse((string)Value));
            }
            else if (TypeName.Contains("money"))
            {
                attributeValue = new Money(decimal.Parse((string)Value));
            }
            else if (TypeName.Contains("boolean"))
            {
                attributeValue = bool.Parse((string)Value);
            }


            KeyValuePair<string, object> a = new KeyValuePair<string, object>(Key, attributeValue);
            return a;
        }
    }


    [DataContract(Name = "Entity")]
    public class SerializableEntity
    {
        [DataMember]
        public string LogicalName { get; set; }

        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public List<SerializableEntityAttribute> Attributes { get; set; }

        public SerializableEntity()
        {
            Attributes = new List<SerializableEntityAttribute>();
        }

    }


}