using ItAintBoring.EZChange.Common;
using ItAintBoring.EZChange.Common.Packaging;
using ItAintBoring.EZChange.Core.UI;
using Microsoft.Crm.Sdk.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ItAintBoring.EZChange.Core.Packaging
{
    public class DynamicsSolution: BaseSolution
    {
        public override string Version { get { return "1.0"; } }
        public override string Id { get { return "Dynamics Solution"; } }
        public override string Description { get { return "Dynamics Solution"; } }

        public override string Name { get; set; }


        private List<Type> supportedPackageTypes = null;
        [XmlIgnore]
        public override List<Type> SupportedPackageTypes { get { return supportedPackageTypes; } }

        public DynamicsSolution(): base()
        {
            supportedPackageTypes = new List<Type>();
            supportedPackageTypes.Add(typeof(DynamicsChangePackage));
        }

        [XmlIgnore]
        public override UserControl UIControl { get { return null; } }

        public override void ApplyUIUpdates()
        {

        }

        public override void PrepareSolution(BaseComponent package)
        {
            ExportSolutionRequest exportSolutionRequest = new ExportSolutionRequest();
            exportSolutionRequest.Managed = false;
            exportSolutionRequest.SolutionName = Name;

            ExportSolutionResponse exportSolutionResponse = (ExportSolutionResponse)_serviceProxy.Execute(exportSolutionRequest);

            byte[] exportXml = exportSolutionResponse.ExportSolutionFile;
            string filename = solution.UniqueName + ".zip";
            File.WriteAllBytes(outputDir + filename, exportXml);
        }



    }
}
