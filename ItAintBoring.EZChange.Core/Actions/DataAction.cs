﻿using ItAintBoring.EZChange.Common;
using ItAintBoring.EZChange.Core.Packaging;
using ItAintBoring.EZChange.Core.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ItAintBoring.EZChange.Core.Actions
{
    public class DataAction : BaseAction
    {


        public override string Version { get { return "1.0"; } }
        public override string Id { get { return "Data Action"; } }
        public override string Description { get { return "Data Action"; } }

        public override string Name { get; set; }

        public List<Type> supportedSolutionTypes = null;
        public override List<Type> SupportedSolutionTypes { get { return supportedSolutionTypes; } }

        public DataAction()
        {
            supportedSolutionTypes = new List<Type>();
            supportedSolutionTypes.Add(typeof(DynamicsSolution));
        }

        
        public string Title { get; set; }



        public override void ApplyUIUpdates()
        {
            XML = ((XMLEditor)uiControl).XML;
        }

        private UserControl uiControl = new XMLEditor();
        public override UserControl UIControl
        {
            get
            {
                ((XMLEditor)uiControl).XML = XML;
                return uiControl;
            }
        }



        public override void DoAction()
        {
            XML = ((XMLEditor)uiControl).XML;
        }
    }
}
