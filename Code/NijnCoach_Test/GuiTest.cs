using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Reflection;
using System.Threading;
using NUnit.Framework;

namespace NijnCoach_Test
{
    abstract class GuiTest
    {
        /*With help of
         * http://msdn.microsoft.com/en-us/magazine/cc188784.aspx
         * http://stackoverflow.com/questions/1288310/activator-createinstance-how-to-create-instances-of-classes-that-have-paramete
         */ 

        Assembly testAssembly = null;
        Form _testForm = null;
        BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.FlattenHierarchy;

        public Form testForm
        {
            get
            {
                return _testForm;
            }
        }

        private static void RunApp(object state) 
        { 
            Application.Run((Form)state); 
        } 
        
        private void _InvokeMethod(Form form, string methodName, params object[] parms)
        { 
            EventHandler eh = (EventHandler)Delegate.CreateDelegate(typeof (EventHandler), form, methodName); 
            if (eh != null) { 
                form.Invoke(eh, parms); 
            }
        } 

        protected object GetField(object obj, string fieldName) 
        { 
            Type t = obj.GetType(); 
            FieldInfo fi = t.GetField(fieldName, flags); 
            return fi.GetValue(obj); 
        } 

        protected object GetProperty(object obj, string propertyName) 
        { 
            Type t = obj.GetType(); 
            PropertyInfo pi = t.GetProperty(propertyName, flags); 
            return pi.GetValue(obj, new object[0]); 
        }

        protected void InvokeMethod(String method)
        {
            object[] p = {this, new EventArgs()}; 
            _InvokeMethod(_testForm, method, p); 
        }

        public object GetPropertyFromFromField(string fieldName, string propertyName)
        {
            return GetProperty(GetField(_testForm, fieldName), propertyName);
        }



        public abstract object[] getParameters();
        public abstract String getAssembly();
        public abstract String getForm();

        [TestFixtureSetUp]
        public virtual void setUp()
        {
            testAssembly = Assembly.LoadFrom(getAssembly());
            Type t = testAssembly.GetType(getForm());
            Type[] pTypes = Type.GetTypeArray(getParameters());
            ConstructorInfo ctor = t.GetConstructor(pTypes);
            _testForm = ctor.Invoke(getParameters()) as Form;
            ThreadPool.QueueUserWorkItem(new WaitCallback(RunApp), _testForm);
        }

        [TestFixtureTearDown]
        public virtual void tearDown()
        {
            _testForm.Dispose();
            _testForm.Close();
        }

    }
}
