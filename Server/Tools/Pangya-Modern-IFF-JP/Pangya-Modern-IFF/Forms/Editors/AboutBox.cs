using System;
using System.Reflection;
using System.Windows.Forms;

namespace Pangya_Modern_Editor.Forms.Editors
{
    partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
          }

        #region Acessório de Atributos do Assembly

        public string App_Title
        {
            get
            {
                object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (customAttributes.Length == 0)
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
        #endregion

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AboutBox_Load(object sender, EventArgs e)
        {
            Text = "About";
            this.labelProductName.Text += ": Pangya Modern Editor";
            this.labelVersion.Text += $": {App_Version}";
            this.labelCopyright.Text += ":" + App_Copyright;
        }
    }
}
