using ItAintBoring.EZChange.Common.Packaging;
using ItAintBoring.EZChange.Common.Storage;
using ItAintBoring.EZChange.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ItAintBoring.EZChange
{
    public partial class MainForm : Form
    {
        public IPackageStorage storageProvider = null;

        private ChangePackage package = null;
        public ChangePackage Package
        {
            get
            {
                return package;
            }
            set
            {
                if (package != value)
                {
                    package = value;
                    ReSetUI();
                }

            }
        }

        public MainForm()
        {
            InitializeComponent();

            var storageList = StorageFactory.GetStorageList();
            storageProvider = storageList[0];
            ReSetUI();
        }

        public void ReSetUI()
        {
            return;
            if (Package == null)
            {
                tcPackage.TabPages.Remove(tpSolutions);
                tcPackage.TabPages.Remove(tpSource);
                tcPackage.TabPages.Remove(tpLogo);
                tcPackage.TabPages.Add(tpLogo);
            }
            else
            {
                tcPackage.TabPages.Remove(tpSolutions);
                tcPackage.TabPages.Remove(tpSource);
                tcPackage.TabPages.Remove(tpLogo);
                tcPackage.TabPages.Add(tpSolutions);
                tcPackage.TabPages.Add(tpSource);

            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private bool SaveIfRequired()
        {
            if (Package == null) return true;

            bool result = true;
            if (Package.HasUnsavedChanges)
            {
                var confirmResult = MessageBox.Show("There are unsaved changes - do you want to save them now?", this.Text,
                                     MessageBoxButtons.YesNoCancel);
                if (confirmResult == DialogResult.Yes)
                {
                    storageProvider.SavePackage(Package);
                }
                else if (confirmResult == DialogResult.No)
                {
                    storageProvider.SavePackage(Package);
                }
                else result = false;
            }
            return result;
        }



        private void tbSaveProject_Click(object sender, EventArgs e)
        {
            storageProvider.SavePackage(Package);
            
        }

        private void tbOpenProject_Click(object sender, EventArgs e)
        {
            if (SaveIfRequired())
            {
                Package = storageProvider.LoadPackage();
            }
        }

        private void tbSaveAsProject_Click(object sender, EventArgs e)
        {
            storageProvider.SavePackageAs(Package);
        }

        private void tbNew_Click(object sender, EventArgs e)
        {
            if (SaveIfRequired())
            {
                var pkg = new ChangePackage()
                {
                    Name = "New Change Package",
                    PackageLocation = "NewPackage.ecp",
                    Description = "",
                    HasUnsavedChanges = false
                };
                Package = pkg;
            }
        }

        private void tbExit_Click(object sender, EventArgs e)
        {
            if (SaveIfRequired())
            {
                Close();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
