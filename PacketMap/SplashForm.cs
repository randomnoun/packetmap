using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Reflection;

namespace PacketMap {

    public partial class SplashForm : Form, ISplashForm {
        public SplashForm() {
            InitializeComponent();
        }

        public void AddText(string text) {
            this.rtbProgress.AppendText(text + "\r\n");
        }
        public void SetProgress(int progress) {
            this.progressBar.Value = progress;
        }

    }

    public interface ISplashForm 
    {
        void AddText(string NewStatusInfo);
        void SetProgress(int progress);
    }


    public class Splasher {
        private static Form m_SplashForm = null;
        private static ISplashForm m_SplashInterface = null;
        private static Thread m_SplashThread = null;
        private static string m_TempStatus = string.Empty;

        /// <summary>
        /// Show the SplashForm
        /// </summary>
        public static void Show(Type splashFormType) {
            if (m_SplashThread != null)
                return;
            if (splashFormType == null) {
                throw (new Exception("splashFormType is null"));
            }

            m_SplashThread = new Thread(new ThreadStart(delegate() {
                CreateInstance(splashFormType);
                Application.Run(m_SplashForm);
            }));
            m_SplashThread.Name = "SplashThread";
            m_SplashThread.IsBackground = true;
            m_SplashThread.SetApartmentState(ApartmentState.STA);
            m_SplashThread.Start();
        }



        /// <summary>
        /// set the loading Status
        /// </summary>
        public static void AddText(string value) {
            if (m_SplashInterface == null || m_SplashForm == null) {
                // m_TempStatus = value;
                return;
            }
            // urgh ? reflection ?
            m_SplashForm.Invoke(
                    new SplashAddTextHandle(delegate(string str) { m_SplashInterface.AddText(str); }),
                    new object[] { value }
                );
        }

        /// <summary>
        /// set the loading Status
        /// </summary>
        public static void SetProgress(int value) {
            if (m_SplashInterface == null || m_SplashForm == null) {
                return;
            }
            // urgh ? reflection ?
            m_SplashForm.Invoke(
                    new SplashSetProgressHandle(delegate(int val) { m_SplashInterface.SetProgress(val); }),
                    new object[] { value }
                );
        }


        /// <summary>
        /// Colse the SplashForm
        /// </summary>
        public static void Close() {
            if (m_SplashThread == null || m_SplashForm == null) return;

            try {
                m_SplashForm.Invoke(new MethodInvoker(m_SplashForm.Close));
            } catch (Exception) {
            }
            m_SplashThread = null;
            m_SplashForm = null;
        }

        private static void CreateInstance(Type FormType) {

            object obj = FormType.InvokeMember(null,
                                BindingFlags.DeclaredOnly |
                                BindingFlags.Public | BindingFlags.NonPublic |
                                BindingFlags.Instance | BindingFlags.CreateInstance, null, null, null);
            m_SplashForm = obj as Form;
            m_SplashInterface = obj as ISplashForm;
            if (m_SplashForm == null) {
                throw (new Exception("Splash Screen must inherit from System.Windows.Forms.Form"));
            }
            if (m_SplashInterface == null) {
                throw (new Exception("must implement interface ISplashForm"));
            }

            /*if (!string.IsNullOrEmpty(m_TempStatus))
                m_SplashInterface.SetStatusInfo(m_TempStatus);
             */
        }

        private delegate void SplashAddTextHandle(string NewStatusInfo);
        private delegate void SplashSetProgressHandle(int progress);
    }

}