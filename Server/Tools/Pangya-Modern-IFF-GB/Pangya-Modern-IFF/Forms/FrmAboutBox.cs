using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PangyaSuiteFiles.Forms
{
    public partial class FrmAboutBox : Form
    {
        public FrmAboutBox()
        {
            InitializeComponent();

            Text = "About App: " + App_Title;
            this.labelProductName.Text = "Pangya Suite Tools";
            this.labelVersion.Text = $"Version {App_Version}";
            this.labelCopyright.Text = App_Copyright;
            this.labelCompanyName.Text = " Version Private Server GB";
        }

        public string App_Title
        {
            get
            {
                object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (customAttributes.Length ==0)
                {
                    return "";
                }
                return ((AssemblyTitleAttribute)customAttributes[0]).Title;
            }
        }

        public string App_Version =>
            Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public string App_Description
        {
            get
            {
                object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (customAttributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)customAttributes[0]).Description;
            }
        }

        public string App_Product
        {
            get
            {
                object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (customAttributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)customAttributes[0]).Product;
            }
        }

        public string App_Copyright
        {
            get
            {
                object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (customAttributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)customAttributes[0]).Copyright;
            }
        }

        public string App_Company
        {
            get
            {
                object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (customAttributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)customAttributes[0]).Company;
            }
        }
    }
}
