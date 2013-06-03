using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Reflection;
using System.Threading;
using NUnit.Framework;

namespace NijnCoach_Test.View
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
        private delegate void OnEvent(EventArgs ea);


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

        private object _GetField(object obj, string fieldName) 
        { 
            Type t = obj.GetType(); 
            FieldInfo fi = t.GetField(fieldName, flags); 
            return fi.GetValue(obj); 
        }

        private object _GetProperty(object obj, string propertyName) 
        { 
            Type t = obj.GetType(); 
            PropertyInfo pi = t.GetProperty(propertyName, flags); 
            return pi.GetValue(obj, new object[0]); 
        }

        private void _SetProperty(object obj, string propertyName, object value)
        {
            Type t = obj.GetType();
            PropertyInfo pi = t.GetProperty(propertyName, flags);
            pi.SetValue(obj, value, new object[0]);
        }

        protected void InvokeMethod(String method)
        {
            object[] p = {this, new EventArgs()}; 
            _InvokeMethod(_testForm, method, p); 
        }

        private object firstPart(object obj, string longName)
        {
            object o = obj;
            String[] parts = longName.Split(new char[] { '.' });
            for (int i = 0; i < parts.Length - 1; i++)
            {
                o = _GetField(o, parts[i]);
            }
            return o;
        }

        private string lastPart(string longName)
        {
            String[] parts = longName.Split(new char[] { '.' });
            return parts[parts.Length - 1];
        }

        public object GetProperty(string longName)
        {
            return GetProperty(_testForm, longName);
        }

        public object GetProperty(object obj, string longName)
        {
            return _GetProperty(firstPart(obj, longName), lastPart(longName));
        }

        public void SetProperty(string longName, object value)
        {
            SetProperty(_testForm, longName, value);
        }

        public void SetProperty(object obj, string longName, object value)
        {
            _SetProperty(firstPart(obj, longName), lastPart(longName), value);
        }

        public object GetField(string longName)
        {
            return GetField(_testForm, longName);
        }

        public object GetField(object obj, string longName)
        {
            return _GetField(firstPart(obj, longName), lastPart(longName));
        }

        
        public void RaiseEvent(string longName, string eventName, EventArgs ea)
        {
            RaiseEvent(_testForm, longName, eventName, ea);
        }

        public void RaiseEvent(object obj, string longName, string eventName, EventArgs ea)
        {
            object o = GetField(obj, longName);
            MethodInfo mi = o.GetType().GetMethod("On" + eventName, flags);
            OnEvent methodDelegate = (OnEvent) Delegate.CreateDelegate(typeof(OnEvent), o, mi);
            ((Control)o).Invoke(methodDelegate, new object[] {ea});
        }
         

        public abstract object[] getParameters();
        public abstract String getAssembly();
        public abstract String getForm();

        [SetUp]
        public virtual void setUp()
        {
            testAssembly = Assembly.LoadFrom(getAssembly());
            Type t = testAssembly.GetType(getForm());
            Type[] pTypes = Type.GetTypeArray(getParameters());
            ConstructorInfo ctor = t.GetConstructor(pTypes);
            _testForm = ctor.Invoke(getParameters()) as Form;
            ThreadPool.QueueUserWorkItem(new WaitCallback(RunApp), _testForm);
            while (!_testForm.IsHandleCreated)
                ;
        }

        [TearDown]
        public virtual void tearDown()
        {
            if (_testForm != null)
            {
                _testForm.Close();
            }
        }

    }
}
