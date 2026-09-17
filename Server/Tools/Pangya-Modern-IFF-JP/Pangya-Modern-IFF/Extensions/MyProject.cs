using Pangya_Modern_Editor.Forms;
using Pangya_Modern_Editor.Forms.Editors;
using Pangya_Modern_Editor.Forms.Editors.Special;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pangya_Modern_Editor.Extensions
{
    internal sealed class MyProject
    {
        private static readonly ThreadSafeObjectProvider<MyForms> _formsProvider = new ThreadSafeObjectProvider<MyForms>();

        internal static MyForms Forms => _formsProvider.GetInstance;

        internal sealed class MyForms
        {
            private readonly Dictionary<Type, Form> _formInstances = new Dictionary<Type, Form>();

            public FrmBall FrmBall => GetFormInstance<FrmBall>();
            public FrmCaddie FrmCaddie => GetFormInstance<FrmCaddie>();
            public FrmCaddieItem FrmCaddieItem => GetFormInstance<FrmCaddieItem>();
            public FrmCadieMagicBox FrmCadieMagicBox => GetFormInstance<FrmCadieMagicBox>();
            public FrmCadieMagicBoxRandom FrmCadieMagicBoxRandom => GetFormInstance<FrmCadieMagicBoxRandom>();
            public FrmClub FrmClub => GetFormInstance<FrmClub>();
            public FrmClubSet FrmClubSet => GetFormInstance<FrmClubSet>();
            public FrmItem FrmItem => GetFormInstance<FrmItem>();
            public FrmMascot FrmMascot => GetFormInstance<FrmMascot>();
            public FrmPart FrmPart => GetFormInstance<FrmPart>();
            public FrmSetItem FrmSetItem => GetFormInstance<FrmSetItem>();

            public FrmMain FrmMain { get; set; } = new FrmMain();
            public FrmMenu FrmMenu => GetFormInstance<FrmMenu>();

            private T GetFormInstance<T>() where T : Form, new()
            {
                var type = typeof(T);

                if (!_formInstances.TryGetValue(type, out var form) || form.IsDisposed)
                {
                    form = new T();
                    _formInstances[type] = form;
                }
                return (T)form;
            }
        }
    }

    internal sealed class ThreadSafeObjectProvider<T> where T : new()
    {
        [ThreadStatic]
        private static T _threadStaticValue;

        internal T GetInstance
        {
            get
            {
                if (_threadStaticValue == null)
                {
                    _threadStaticValue = new T();
                }
                return _threadStaticValue;
            }
        }
    }
}
