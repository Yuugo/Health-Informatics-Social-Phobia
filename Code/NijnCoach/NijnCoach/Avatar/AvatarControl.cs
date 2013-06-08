using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Web;
using System.Net;
using CookComputing.XmlRpc;
using System.Threading;

namespace NijnCoach.Avatar
{
    /* proxy interface */
    [XmlRpcUrl("http://localhost:8008")]
    public interface IStateName : IXmlRpcProxy
    {

        [XmlRpcMethod("surprisex")]
        string surprisex(double aValue);

        [XmlRpcMethod("happyx")]
        string happyx(double aValue);

        [XmlRpcMethod("sadx")]
        string sadx(double aValue);

        [XmlRpcMethod("angryx")]
        string angryx(double aValue);

        [XmlRpcMethod("disgustx")]
        string disgustx(double aValue);

        [XmlRpcMethod("fearx")]
        string fearx(double aValue);

        // Mixed

        [XmlRpcMethod("mixed0")]
        string mixed0(double aValue, double bValue);

        [XmlRpcMethod("mixed1")]
        string mixed1(double aValue, double bValue);

        [XmlRpcMethod("mixed2")]
        string mixed2(double aValue, double bValue);

        [XmlRpcMethod("mixed3")]
        string mixed3(double aValue, double bValue);

        [XmlRpcMethod("mixed4")]
        string mixed4(double aValue, double bValue);

        [XmlRpcMethod("myspeakx")]
        string myspeakx(string filename, int duration);

        //animation here
        [XmlRpcMethod("myanimation0")]
        string myanimation0();

        [XmlRpcMethod("myanimation1")]
        string myanimation1();

        [XmlRpcMethod("myanimation2")]
        string myanimation2();
    }


    class AvatarControl
    {
        private static Thread emotionThread;

        public static void surprise(double intensity)
        {
            IStateName proxy = (IStateName)XmlRpcProxyGen.Create(typeof(IStateName));
            proxy.surprisex(intensity);
        }

        public static void happy(double intensity)
        {
            IStateName proxy = (IStateName)XmlRpcProxyGen.Create(typeof(IStateName));
            proxy.happyx(intensity);
        }

        public static void sad(double intensity)
        {
            IStateName proxy = (IStateName)XmlRpcProxyGen.Create(typeof(IStateName));
            proxy.sadx(intensity);
        }

        public static void angry(double intensity)
        {
            IStateName proxy = (IStateName)XmlRpcProxyGen.Create(typeof(IStateName));
            proxy.angryx(intensity);
        }

        public static void disgust(double intensity)
        {
            IStateName proxy = (IStateName)XmlRpcProxyGen.Create(typeof(IStateName));
            proxy.disgustx(intensity);
        }

        public static void fear(double intensity)
        {
            IStateName proxy = (IStateName)XmlRpcProxyGen.Create(typeof(IStateName));
            proxy.fearx(intensity);
        }


        public static void surprise()
        {
            surprise(1);
        }

        public static void happy()
        {
            happy(1);
        }

        public static void sad()
        {
            sad(1);
        }

        public static void angry()
        {
            angry(1);
        }

        public static void disgust()
        {
            disgust(1);
        }

        public static void fear()
        {
            fear(1);
        }

        public static void sit()
        {
            IStateName proxy = (IStateName)XmlRpcProxyGen.Create(typeof(IStateName));
            proxy.myanimation1();
        }

        public static void run()
        {
            IStateName proxy = (IStateName)XmlRpcProxyGen.Create(typeof(IStateName));
            proxy.myanimation0();
        }

        public static void stand()
        {
            IStateName proxy = (IStateName)XmlRpcProxyGen.Create(typeof(IStateName));
            proxy.myanimation2();
        }

        public static void speak(string mp3name, int duration)
        {
            IStateName proxy = (IStateName)XmlRpcProxyGen.Create(typeof(IStateName));
            proxy.myspeakx(mp3name, duration);
        }

        public static void setAvatarEmotionViaString(String emotion)
        {
            setAvatarEmotionViaString(emotion, 1, 1);
        }

        public static void setAvatarEmotionViaString(String emotion, int length, double intensity)
        {
            if (emotionThread != null) emotionThread.Abort();
            emotionThread = new Thread(() => setAvatarEmotionViaStringWithThread(emotion, length, intensity));
            emotionThread.Start();
        }

        private static void setAvatarEmotionViaStringWithThread(String emotion, int length, double intensity)
        {
            for (int i = 0; i < length; i++)
            {
                switch (emotion)
                {
                    case "Sad":
                        sad(intensity);
                        break;
                    case "Happy":
                        happy(intensity);
                        break;
                    case "Angry":
                        angry(intensity);
                        break;
                    case "Disgust":
                        disgust(intensity);
                        break;
                    case "Fear":
                        fear(intensity);
                        break;
                    case "Run":
                        run();
                        break;
                    case "Sit":
                        sit();
                        break;
                    case "Stand":
                        stand();
                        break;
                    case "Surprise":
                        surprise(intensity);
                        break;
                    default:
                        break;
                }
            }
        }

        public static void setAvatarEmotionViaEntry(IEntry entry, int length, double intensity)
        {
            setAvatarEmotionViaString(entry.Emotion(), length, intensity);
        }

        public static void setAvatarEmotionViaEntry(IEntry entry)
        {
            setAvatarEmotionViaString(entry.Emotion()); 
        }
    }
}
