using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NijnCoach.View.Greet;

namespace NijnCoach.View.Main
{
    public partial class MainForm : Form
    {

       private static MainForm _mainForm;
       //For Testing and debug purposes
       public static Boolean _loadAvatar = false;

       private MainForm(Boolean _loadAvatar = true)
       {
           InitializeComponent();
           replacePanel(new GreetPanel(_loadAvatar));
       }

       public static MainForm mainForm
       {
          get 
          {
              if (_mainForm == null)
             {
                 _mainForm = new MainForm(_loadAvatar);
             }
              return _mainForm;
          }
        }

        public void replacePanel(Panel panel)
        {
            if (innerPanel != null)
            {
                outerPanel.Controls.Remove(innerPanel);
                innerPanel.Dispose();
            }
            innerPanel = panel;
            if (innerPanel != null)
            {
                innerPanel.SuspendLayout();
                innerPanel.Size = new System.Drawing.Size(outerPanel.Size.Width, outerPanel.Size.Height);
                innerPanel.ResumeLayout();
                outerPanel.Controls.Add(innerPanel);
            }
        }
    }
}
