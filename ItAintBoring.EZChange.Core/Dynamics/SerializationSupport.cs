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

    public class SerializableEntityAttribute
    {
        public string Key { get; set; }
        public string TypeName { get; set; }
        public string Value { get; set; }

        public SerializableEntityAttribute()
        {
        }

        public SerializableEntityAttribute(KeyValuePair<string, object> a)
        {
            ConvertFromAttribute(a);
        }

        public void ConvertFromAttribute(KeyValuePair<string, object> a)
        {
            Key = a.Key;
            TypeName = a.Value.GetType().ToString().ToLower();
            if (TypeName.Contains("guid"))
            {
                Value = a.Value.ToString();
            }
            else if (TypeName.Contains("entityreference"))
            {
                var er = (EntityReference)a.Value;
                Value = er.Id.ToString() + ":" + er.LogicalName;
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
            else
            {
                throw new InvalidPluginExecutionException("Type not supported: " + TypeName);
            }
        }

        public KeyValuePair<string, object> ConvertToAttribute()
        {
            if (Value == null) return new KeyValuePair<string, object>(Key, null);

            Object attributeValue = null;

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
                attributeValue = long.Parse((string)Value);
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
    public class SerializableEntity
    {
        public string LogicalName { get; set; }
        public Guid Id { get; set; }
        public List<SerializableEntityAttribute> Attributes { get; set; }

        public SerializableEntity()
        {
            Attributes = new List<SerializableEntityAttribute>();
        }

    }


}