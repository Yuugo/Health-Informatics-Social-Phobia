﻿using System;
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

        public static void surprise()
        {
            IStateName proxy = (IStateName)XmlRpcProxyGen.Create(typeof(IStateName));
            proxy.surprisex(1);
        }

        public static void happy()
        {
            IStateName proxy = (IStateName)XmlRpcProxyGen.Create(typeof(IStateName));
            proxy.happyx(1);
        }

        public static void sad()
        {
            IStateName proxy = (IStateName)XmlRpcProxyGen.Create(typeof(IStateName));
            proxy.sadx(1);
        }

        public static void angry()
        {
            IStateName proxy = (IStateName)XmlRpcProxyGen.Create(typeof(IStateName));
            proxy.angryx(1);
        }

        public static void disgust()
        {
            IStateName proxy = (IStateName)XmlRpcProxyGen.Create(typeof(IStateName));
            proxy.disgustx(1);
        }

        public static void fear()
        {
            IStateName proxy = (IStateName)XmlRpcProxyGen.Create(typeof(IStateName));
            proxy.fearx(1);
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
            setAvatarEmotionViaString(emotion, 1);
        }

        public static void setAvatarEmotionViaString(String emotion, int length)
        {
            if (emotionThread != null) emotionThread.Abort();
            emotionThread = new Thread(() => setAvatarEmotionViaStringWithThread(emotion, length));
            emotionThread.Start();
        }

        private static void setAvatarEmotionViaStringWithThread(String emotion, int length)
        {
            for (int i = 0; i < length; i++)
            {
                switch (emotion)
                {
                    case "Sad":
                        sad();
                        break;
                    case "Happy":
                        happy();
                        break;
                    case "Angry":
                        angry();
                        break;
                    case "Disgust":
                        disgust();
                        break;
                    case "Fear":
                        fear();
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
                        surprise();
                        break;
                    default:
                        break;
                }
            }
        }

        public static void setAvatarEmotionViaEntry(IEntry entry, int length)
        {
            setAvatarEmotionViaString(entry.Emotion(), length);
        }

        public static void setAvatarEmotionViaEntry(IEntry entry)
        {
            setAvatarEmotionViaString(entry.Emotion()); 
        }
    }
}
