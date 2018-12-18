using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;
using System.IO.Compression;
using Microsoft.Xrm.Sdk.Query;

namespace ItAintBoring.EZChange.Core.Dynamics
{
    public class Common
    {

        public static T GetAttribute<T>(Entity entity, Entity image, string attributeName)
        {
            if (entity.Contains(attributeName)) return (T)entity[attributeName];
            else if (image != null && image.Contains(attributeName)) return (T)image[attributeName];
            else return default(T);
        }

        public static Entity DeSerializeEntity(string data)
        {

            Entity result = null;
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                var lateBoundSerializer = new DataContractSerializer(typeof(Entity));
                System.IO.StreamWriter sw = new System.IO.StreamWriter(ms);
                sw.Write(data);
                sw.Flush();
                ms.Position = 0;
                result = (Entity)lateBoundSerializer.ReadObject(ms);
            }
            return result;
        }

        public static string ShiftString(string s, int guidShift)
        {
            if (guidShift > 0 && s != null)
            {
                while (guidShift > 0)
                {
                    s = s[s.Length - 1] + s.Substring(1, s.Length - 2) + s[0];
                    guidShift--;
                }
            }
            return s;
        }

        public static string BackShiftString(string s, int guidShift)
        {
            if (guidShift > 0 && s != null)
            {
                s = s.Substring(s.Length - guidShift) + s.Substring(0, s.Length - guidShift);
            }
            return s;
        }
        public static List<SerializableEntity> GetSerializableList(List<Entity> entities, int guidShift)
        {
            if (entities == null) return null;

            List<SerializableEntity> result = new List<SerializableEntity>();
            foreach (var e in entities)
            {
                SerializableEntity ent = new SerializableEntity();
                ent.LogicalName = e.LogicalName;
                ent.Id = Guid.Parse(ShiftString(e.Id.ToString(), guidShift));
                var attribList = e.Attributes.ToList();
                var removeList = attribList.FindAll(a => a.Value is AliasedValue);
                foreach (var a in removeList) e.Attributes.Remove(a.Key);

                foreach (var a in e.Attributes)
                {
                    var sa = new SerializableEntityAttribute(a, guidShift);
                    ent.Attributes.Add(sa);
                }
                result.Add(ent);
            }
            return result;
        }

        public static List<Entity> GetRegularEntityList(IOrganizationService service, List<SerializableEntity> entities, int guidShift)
        {
            if (entities == null) return null;

            List<Entity> result = new List<Entity>();
            foreach (var e in entities)
            {
                Entity ent = new Entity();
                ent.LogicalName = e.LogicalName;
                ent.Id = e.Id;

                foreach (var sa in e.Attributes)
                {
                    try
                    {
                        var a = sa.ConvertToAttribute(service, ent.LogicalName, guidShift);
                        ent.Attributes[a.Key] = a.Value;
                    }
                    catch(Exception ex)
                    {
                        throw new Exception("Error converting to attribute: " + sa.Key + "=" + sa.Value + "." + ex.Message);
                    }
                    
                }
                result.Add(ent);
            }
            return result;
        }

        public static string SerializeEntityList(List<Entity> entities, int guidShift)
        {
            string result = null;
            var serializableList = GetSerializableList(entities, guidShift);


            var lateBoundSerializer = new DataContractJsonSerializer(typeof(List<SerializableEntity>));
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                lateBoundSerializer.WriteObject(ms, serializableList);

                ms.Flush();
                ms.Position = 0;
                System.IO.StreamReader sr = new System.IO.StreamReader(ms);
                result = sr.ReadToEnd();
                
                //result = CompressString(result);
            }
            return result;
        }

        public static List<Entity> DeSerializeEntityList(IOrganizationService service, string data, int guidShift)
        {
            if (data == null) return null;
            //data = DecompressString(data);
            List<SerializableEntity> result = null;
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                var lateBoundSerializer = new DataContractJsonSerializer(typeof(List<SerializableEntity>));
                System.IO.StreamWriter sw = new System.IO.StreamWriter(ms);
                sw.Write(data);
                sw.Flush();
                ms.Position = 0;
                result = (List<SerializableEntity>)lateBoundSerializer.ReadObject(ms);
            }

            return GetRegularEntityList(service, result, guidShift);
        }

        public static DataSetResource ResourceFromString(string data)
        {
            DataSetResource result = null;
            using (MemoryStream ms = new MemoryStream())
            {
                StreamWriter sw = new StreamWriter(ms);
                sw.Write(data);
                sw.Flush();
                ms.Position = 0;
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(DataSetResource));
                result = (DataSetResource)serializer.ReadObject(ms);
            }
            return result;
        }

        public static string ResourceToString(DataSetResource dsr)
        {
            string result = null;
            using (MemoryStream ms = new MemoryStream())
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(DataSetResource));
                serializer.WriteObject(ms, dsr);
                ms.Flush();
                ms.Position = 0;
                StreamReader sr = new StreamReader(ms);
                result = sr.ReadToEnd();
                result = result.Replace("\\u000a", "");



            }
            return result;
        }

        public static string CurrentTime()
        {
            return DateTime.UtcNow.ToString();
        }

        public static bool RecordExists(IOrganizationService service, string entityName, string attributeName, Guid entityId)
        {
            QueryExpression qe = new QueryExpression(entityName);
            qe.Criteria.AddCondition(new ConditionExpression(attributeName, ConditionOperator.Equal, entityId));
            return service.RetrieveMultiple(qe).Entities.FirstOrDefault() != null;
        }
    }

}
