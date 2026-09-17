using Microsoft.VisualBasic.CompilerServices;
using PangyaSuiteFiles.Forms;
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
namespace PangyaSuiteFiles.My
{
    internal sealed class MyProject
    {
        private static readonly ThreadSafeObjectProvider<Program> m_AppObjectProvider = new ThreadSafeObjectProvider<Program>();
        private static ThreadSafeObjectProvider<MyForms> m_MyFormsObjectProvider = new ThreadSafeObjectProvider<MyForms>();

        internal static Program Application =>
            m_AppObjectProvider.GetInstance;
        [HelpKeyword("My.Forms")]
        internal static MyForms Forms =>
            m_MyFormsObjectProvider.GetInstance;
        internal sealed class MyForms
        {
            public FrmMain _MainApp;
            [ThreadStatic]
            private static Hashtable m_FormBeingCreated;

            private static T Create_Instance<T>(T Instance) where T: Form, new()
            {
                if ((Instance == null) || Instance.IsDisposed)
                {
                    TargetInvocationException exception = new TargetInvocationException(new Exception());
                    if (m_FormBeingCreated != null)
                    {
                        if (m_FormBeingCreated.ContainsKey(typeof(T)))
                        {
                            throw new InvalidOperationException(Utils.GetResourceString("WinForms_RecursiveFormCreate", new string[0]));
                        }
                    }
                    else
                    {
                        m_FormBeingCreated = new Hashtable();
                    }
                    m_FormBeingCreated.Add(typeof(T), null);
                    try
                    {
                        return Activator.CreateInstance<T>();
                    }
                    catch (TargetInvocationException exception1) when (exception.InnerException != null)
                    {
                        ProjectData.SetProjectError(exception = exception1);
                        throw new InvalidOperationException(Utils.GetResourceString("WinForms_SeeInnerException", new string[] { exception.InnerException.Message }), exception.InnerException);
                    }
                    finally
                    {
                        m_FormBeingCreated.Remove(typeof(T));
                    }
                }
                return Instance;
            }

            private void Dispose_Instance<T>(ref T instance) where T: Form
            {
                instance.Dispose();
                instance = default;
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public override bool Equals(object o) => 
                base.Equals(RuntimeHelpers.GetObjectValue(o));

            [EditorBrowsable(EditorBrowsableState.Never)]
            public override int GetHashCode() => 
                base.GetHashCode();

            [EditorBrowsable(EditorBrowsableState.Never)]
            public override string ToString() => 
                base.ToString();

            public FrmMain MainApp
            {
                [DebuggerNonUserCode]
                get
                {
                    this._MainApp = Create_Instance(this.MainApp);
                    return this._MainApp;
                }
                [DebuggerNonUserCode]
                set
                {
                    if (value != this._MainApp)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose_Instance(ref this._MainApp);
                    }
                }
            }
        }

        internal sealed class ThreadSafeObjectProvider<T> where T: new()
        {
            [CompilerGenerated, ThreadStatic]
            private static T m_ThreadStaticValue;

            internal T GetInstance
            {
                [DebuggerHidden]
                get
                {
                    if (m_ThreadStaticValue == null)
                    {
                        m_ThreadStaticValue = Activator.CreateInstance<T>();
                    }
                    return m_ThreadStaticValue;
                }
            }
        }
    }
}

