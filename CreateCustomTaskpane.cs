using Microsoft.Win32;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swpublished;
using System;
using System.Runtime.InteropServices;

namespace CustomTaskpane
{
    public class CreateCustomTaskpane : ISwAddin
    {
        #region Private Members
        public SldWorks swApp;
        private int mSwCookie;
        private TaskpaneView mTaskpaneView;
        #endregion Private Members

        #region Public Members
        public const string PROG_ID = "My Solidworks Add-in";
        #endregion

        #region Solidworks Add-In Callbacks
        bool ISwAddin.ConnectToSW(object ThisSW, int Cookie)
        {
            swApp = (SldWorks)ThisSW;
            mSwCookie = Cookie;

            _ = swApp.SetAddinCallbackInfo2(0, this, mSwCookie);

            #region Create UI
            string[] bitmap = new string[6];
            string toolTip = "Phan Nguyen Ngoc Hien | Solidworks Expert";
            string assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string directory = Directory.GetParent(assemblyFolder).Parent.FullName + "\\Resources\\";
            
            bitmap[0] = directory + "logo_large20x20.png";
            bitmap[1] = directory + "logo_large32x32.png";
            bitmap[2] = directory + "logo_large40x40.png";
            bitmap[3] = directory + "logo_large64x64.png";
            bitmap[4] = directory + "logo_large96x96.png";
            bitmap[5] = directory + "logo_large128x128.png";

            mTaskpaneView = swApp.CreateTaskpaneView3(bitmap, toolTip);

            mTaskpaneView.AddControl(PROG_ID, string.Empty);
            #endregion

            return true;
        }

        bool ISwAddin.DisconnectFromSW()
        {
            #region Exit UI

            mTaskpaneView.DeleteView();

            Marshal.ReleaseComObject(mTaskpaneView);

            mTaskpaneView = null;
            #endregion

            return true;
        }
        #endregion Solidworks Add-In callbacks

        #region COM Registration
        [ComRegisterFunction]
        public static void RegisterFunction(Type t)
        {
            RegistryKey mLocalMachine = Registry.LocalMachine;

            string subKey = "SOFTWARE\\SOLIDWORKS\\ADDINS\\{" + t.GUID.ToString() + "}";
            RegistryKey mRegistryKey = mLocalMachine.CreateSubKey(subKey);

            mRegistryKey.SetValue(null, 0);
            mRegistryKey.SetValue("Description", "My Solidworks Add-In");
            mRegistryKey.SetValue("Title", "My Task pane");
        }

        [ComUnregisterFunction]
        public static void UnregisterFunction(Type t)
        {
            RegistryKey mLocalMachine = Registry.LocalMachine;

            string subkey = "SOFTWARE\\SOLIDWORKS\\ADDINS\\{" + t.GUID.ToString() + "}";
            mLocalMachine.DeleteSubKey(subkey);
        }
        #endregion COM Registration
    }

}
