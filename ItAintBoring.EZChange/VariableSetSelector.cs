using ItAintBoring.EZChange.Common.Packaging;
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
    public partial class VariableSetSelector : Form
    {
        public VariableSetSelector()
        {
            InitializeComponent();
        }

        public void Initilize(string folder, string defaultSet)
        {
            cbVariableSet.Items.Clear();
            var variableSets = PackageRunner.LoadVariableSets(folder);
            //variableSets.Sort();
            variableSets.Insert(0, "");
            cbVariableSet.Items.AddRange(variableSets.ToArray());
            cbVariableSet.SelectedIndex = variableSets.IndexOf(defaultSet);
        }

        public string SelectedSet
        {
            get
            {
                if (cbVariableSet.SelectedIndex == -1) return null;
                return (String)cbVariableSet.SelectedItem;
            }
        }
    }
}
