using Microsoft.Xrm.Sdk;
using Microsoft.Crm.Sdk.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
using System.Runtime.Serialization;
using System.ServiceModel.Description;
using Microsoft.Xrm.Sdk.Client;
using System.Net;
using ItAintBoring.EZChange.Common;

namespace ItAintBoring.EZChange.Core.Dynamics
{
    public class DynamicsService
    {



        public DynamicsService(string connectionString)
        {
            this.connectionString = connectionString;
        }

        private string connectionString = null;
        public string ConnectionString
        {
            get
            {
                return connectionString;
            }
            set
            {
                if (connectionString != value)
                {
                    connectionString = value;
                    internalService = null;
                }
            }
        }

        private IOrganizationService internalService = null;
        public IOrganizationService Service
        {
            get
            {
                if (internalService == null)
                {

                    try
                    {
                        var conn = new Microsoft.Xrm.Tooling.Connector.CrmServiceClient(connectionString);
                        if (conn.OrganizationServiceProxy != null)
                        {
                            conn.OrganizationServiceProxy.Timeout = new TimeSpan(0, 20, 0);
                        }
                        internalService = (IOrganizationService)conn.OrganizationWebProxyClient != null ? (IOrganizationService)conn.OrganizationWebProxyClient : (IOrganizationService)conn.OrganizationServiceProxy;

                        if (internalService == null)
                        {
                            string[] pairs = connectionString.Split(';');
                            Uri oUri = null;
                            ClientCredentials clientCredentials = new ClientCredentials();


                            foreach (string p in pairs)
                            {
                                string[] keyValue = p.Trim().Split('=');
                                switch (keyValue[0].ToLower())
                                {
                                    case "url":
                                        oUri = new Uri(keyValue[1] + "/XRMServices/2011/Organization.svc");
                                        break;
                                    case "domain":
                                        clientCredentials.UserName.UserName = keyValue[1] + "\\" + clientCredentials.UserName.UserName;
                                        break;
                                    case "username":
                                        clientCredentials.UserName.UserName = clientCredentials.UserName.UserName + keyValue[1];
                                        break;
                                    case "password":
                                        clientCredentials.UserName.Password = keyValue[1];
                                        break;
                                }
                            }


                            var service = new OrganizationServiceProxy(oUri, null, clientCredentials, null);
                            service.Timeout = new TimeSpan(0, 20, 0);
                            internalService = service;
                        }
                    }
                    catch(Exception ex)
                    {
                        throw new Exception("Could not connect to Dynamics");
                    }
                }
                return internalService;

            }
        }

        public void SetFieldPermission(string fieldSecurityProfileId, string entityName, string attributeName, bool canRead, bool canCreate, bool canUpdate)
        {
            QueryExpression qe = new QueryExpression("fieldpermission");
            qe.Criteria.AddCondition(new ConditionExpression("fieldsecurityprofileid", ConditionOperator.Equal, Guid.Parse(fieldSecurityProfileId)));
            qe.Criteria.AddCondition(new ConditionExpression("entityname", ConditionOperator.Equal, entityName));
            qe.Criteria.AddCondition(new ConditionExpression("attributelogicalname", ConditionOperator.Equal, attributeName));
            qe.ColumnSet = new ColumnSet("fieldpermissionid");
            var fp = Service.RetrieveMultiple(qe).Entities.FirstOrDefault();
            if(fp != null && !canRead && !canCreate && !canUpdate)
            {
                Service.Delete(fp.LogicalName, fp.Id);
            }
            else if(fp != null)
            {
                fp["canread"] = new OptionSetValue(canRead ? FieldPermissionType.Allowed : FieldPermissionType.NotAllowed);
                fp["cancreate"] = new OptionSetValue(canCreate ? FieldPermissionType.Allowed : FieldPermissionType.NotAllowed);
                fp["canupdate"] = new OptionSetValue(canUpdate ? FieldPermissionType.Allowed : FieldPermissionType.NotAllowed);
                Service.Update(fp);
            }
            else 
            {
                fp = new Entity("fieldpermission");
                fp["fieldsecurityprofileid"] = new EntityReference("fieldsecurityprofile", Guid.Parse(fieldSecurityProfileId));
                fp["entityname"] = entityName;
                fp["attributelogicalname"] = attributeName;
                fp["canread"] = new OptionSetValue(canRead ? FieldPermissionType.Allowed : FieldPermissionType.NotAllowed);
                fp["cancreate"] = new OptionSetValue(canCreate ? FieldPermissionType.Allowed : FieldPermissionType.NotAllowed);
                fp["canupdate"] = new OptionSetValue(canUpdate ? FieldPermissionType.Allowed : FieldPermissionType.NotAllowed);
                Service.Create(fp);
            }
        }

        Guid trackerResourceId = Guid.Parse("8c427a1c-cda6-4a2d-9073-b75728259427");
        public string GetTrackerResource()
        {
            QueryExpression qe = new QueryExpression("webresource");
            qe.Criteria.AddCondition(new ConditionExpression("webresourceid", ConditionOperator.Equal, trackerResourceId));
            qe.ColumnSet = new ColumnSet(true);
            var result = Service.RetrieveMultiple(qe).Entities.FirstOrDefault();
            string content = "";
            if(result == null)
            {
                UpdateTrackerResource("");
            }
            else
            {
                content = result.Contains("content") ? (string)result["content"] : "";
            }
            if (content != "")
            {
                content = System.Text.Encoding.Default.GetString(System.Convert.FromBase64String(content));
            }
            return content;
                
        }

        public void UpdateTrackerResource(string content)
        {
            QueryExpression qe = new QueryExpression("webresource");
            qe.Criteria.AddCondition(new ConditionExpression("webresourceid", ConditionOperator.Equal, trackerResourceId));
            qe.ColumnSet = new ColumnSet(true);
            var result = Service.RetrieveMultiple(qe).Entities.FirstOrDefault();
            if(result == null)
            {
                result = new Entity("webresource");
                result.Id = trackerResourceId;
                result["content"] = System.Convert.ToBase64String(System.Text.Encoding.Default.GetBytes(content));
                result["displayname"] = "Package Tracker - DO NOT DELETE";
                result["description"] = "Package Tracker";
                result["name"] = "ita_packagetracker";
                result["webresourcetype"] = new OptionSetValue(1);//HTML
                Service.Create(result);
            }
            else
            {
                result["content"] = System.Convert.ToBase64String(System.Text.Encoding.Default.GetBytes(content));
                Service.Update(result);
            }
        }

        public bool IsPackageDeployed(string packageName)
        {
            string data = GetTrackerResource();
            return data.IndexOf("#" + packageName + "#") > -1;
        }


        public void LogPackageDeployment(string packageName)
        {
            UpdateTrackerResource(GetTrackerResource() + "#" + packageName + "#,");
            PublishAll();
        }

        

        public void ExportSolution(string solutionName, string folder, bool managed)
        {
            ExportSolutionRequest exportSolutionRequest = new ExportSolutionRequest();
            exportSolutionRequest.Managed = managed;
            exportSolutionRequest.SolutionName = solutionName;

            ExportSolutionResponse exportSolutionResponse = (ExportSolutionResponse)Service.Execute(exportSolutionRequest);

            System.IO.Directory.CreateDirectory(folder);
            byte[] exportXml = exportSolutionResponse.ExportSolutionFile;
            string filename = solutionName + ".zip";
            System.IO.File.WriteAllBytes(System.IO.Path.Combine(folder, filename), exportXml);
        }


        public void ImportSolution(string fileName)
        {
            byte[] importXml = System.IO.File.ReadAllBytes(fileName);

            Guid importId = Guid.NewGuid();
            ImportSolutionRequest importSolutionRequest = new ImportSolutionRequest();
            importSolutionRequest.ImportJobId = importId;
            importSolutionRequest.CustomizationFile = importXml;
            importSolutionRequest.PublishWorkflows = true;
            importSolutionRequest.OverwriteUnmanagedCustomizations = true;
            importSolutionRequest.PublishWorkflows = true;
            importSolutionRequest.SkipProductUpdateDependencies = false;
            try
            {
                ImportSolutionResponse resp = (ImportSolutionResponse)Service.Execute(importSolutionRequest);
                if(resp.Results.Count > 0)
                {
                    //Testing
                    resp = resp;
                }
            }
            catch (Exception ex)
            {
                //Could not find the import job. Let's output asyncJobError (hopefully there is something)
                throw new Exception("An error has occured while exporting the solution: " + ex.Message);
            }

            /*
            var requestAsync = new ExecuteAsyncRequest
            {
                Request = importSolutionRequest
            };

            string asyncJobError = "";
            var response = (ExecuteAsyncResponse)Service.Execute(requestAsync);

                DateTime end = DateTime.Now.AddSeconds(600);
            while (end >= DateTime.Now && String.IsNullOrEmpty(asyncJobError))
            {
                Entity asyncOperation = Service.Retrieve("asyncoperation", response.AsyncJobId,
                   new ColumnSet("asyncoperationid", "statuscode", "message"));
                switch (((OptionSetValue)asyncOperation["statuscode"]).Value)
                {
                    //Succeeded
                    case 30:
                        break;
                    //Pausing //Canceling //Failed //Canceled
                    case 21:
                    case 22:
                    case 31:
                    case 32:
                        asyncJobError = (string)asyncOperation["message"];
                        break;
                    default:
                        break;
                }
            }

            try
            {
                var job = Service.Retrieve("importjob", importId, new ColumnSet(true));

                if (job.Contains("completedon"))
                {
                    string data = (string)job["data"];
                    if (data.IndexOf("result=\"failure\"") > 0 || !String.IsNullOrEmpty(asyncJobError))
                    {
                        throw new Exception("An error has occured while exporting the solution: " + asyncJobError + data);
                    }

                }
            }
            catch (System.ServiceModel.FaultException ex)
            {
                //Could not find the import job. Let's output asyncJobError (hopefully there is something)
                throw new Exception("An error has occured while exporting the solution: " + asyncJobError);
            }
            */
            PublishAll();
        }

        public void PublishAll()
        {
            BaseComponent.LogInfo("Publishing customizations");
            PublishAllXmlRequest publishAll = new PublishAllXmlRequest();
            Service.Execute(publishAll);
        }

        public void DeserializeData(List<Entity> entities, bool createOnly)
        {
            foreach (var e in entities)
            {
                var metadata = ReferenceResolution.GetMetadata(Service, e.LogicalName);

                string lookupField = null;
                if (lookupField == null)
                {
                    lookupField = metadata.PrimaryIdAttribute;
                }

                ReferenceResolution.ResolveReferences(Service, e);

                if (metadata.IsIntersect == null || !metadata.IsIntersect.Value)
                {

                    if (lookupField != metadata.PrimaryIdAttribute && !e.Contains(lookupField))
                    {
                        throw new InvalidPluginExecutionException("Lookup error: The entity being imported does not have '" + lookupField + "' attribute");
                    }
                    QueryExpression qe = new QueryExpression(e.LogicalName);
                    qe.Criteria.AddCondition(new ConditionExpression(lookupField, ConditionOperator.Equal,
                        lookupField == metadata.PrimaryIdAttribute ? e.Id : e[lookupField]));

                    var existing = Service.RetrieveMultiple(qe).Entities.FirstOrDefault();
                    if (existing != null)
                    {
                        if (!createOnly)
                        {
                            e.Id = existing.Id;
                            Service.Update(e);
                        }
                    }
                    else
                    {
                        Service.Create(e);
                    }
                }
                else
                {
                    if (e.LogicalName == "listmember")
                    {
                        if (e.Contains("entityid") && e.Contains("listid"))
                        {
                            QueryExpression qe = new QueryExpression("listmember");
                            qe.Criteria.AddCondition(new ConditionExpression("entityid", ConditionOperator.Equal, ((EntityReference)e["entityid"]).Id));
                            qe.Criteria.AddCondition(new ConditionExpression("listid", ConditionOperator.Equal, ((EntityReference)e["listid"]).Id));
                            bool exists = Service.RetrieveMultiple(qe).Entities.FirstOrDefault() != null;
                            if (!exists)
                            {
                                AddMemberListRequest amlr = new AddMemberListRequest();
                                amlr.EntityId = ((EntityReference)e["entityid"]).Id;
                                amlr.ListId = ((EntityReference)e["listid"]).Id;
                                Service.Execute(amlr);
                            }
                        }
                    }
                    else
                    {
                        foreach (var r in metadata.ManyToManyRelationships)
                        {
                            if (r.IntersectEntityName == e.LogicalName)
                            {

                                if (e.Contains(r.Entity1IntersectAttribute)
                                    && e.Contains(r.Entity2IntersectAttribute)
                                    )
                                {
                                    QueryExpression qe = new QueryExpression(r.IntersectEntityName);
                                    qe.Criteria.AddCondition(new ConditionExpression(r.Entity1IntersectAttribute, ConditionOperator.Equal, (Guid)e[r.Entity1IntersectAttribute]));
                                    qe.Criteria.AddCondition(new ConditionExpression(r.Entity2IntersectAttribute, ConditionOperator.Equal, (Guid)e[r.Entity2IntersectAttribute]));
                                    bool exists = Service.RetrieveMultiple(qe).Entities.FirstOrDefault() != null;
                                    if (!exists
                                        && Common.RecordExists(Service, r.Entity1LogicalName, r.Entity1IntersectAttribute, (Guid)e[r.Entity1IntersectAttribute])
                                        && Common.RecordExists(Service, r.Entity2LogicalName, r.Entity2IntersectAttribute, (Guid)e[r.Entity2IntersectAttribute])
                                        )
                                    {

                                        Relationship rs = new Relationship(r.SchemaName);
                                        EntityReferenceCollection collection = new EntityReferenceCollection();

                                        collection.Add(new EntityReference(r.Entity2IntersectAttribute)
                                        {
                                            Id = (Guid)e[r.Entity2IntersectAttribute]
                                        });

                                        Service.Associate(r.Entity1LogicalName,
                                            (Guid)e[r.Entity1IntersectAttribute],
                                            rs,
                                            collection);
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
    }

   
    
}
