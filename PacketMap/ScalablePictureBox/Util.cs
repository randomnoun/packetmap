using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Reflection;

/// <summary>
/// This is public domain software - that is, you can do whatever you want
/// with it, and include it software that is licensed under the GNU or the
/// BSD license, or whatever other licence you choose, including proprietary
/// closed source licenses.  I do ask that you leave this lcHeader in tact.
///
/// QAlbum.NET makes use of this control to display pictures.
/// Please visit <a href="http://www.qalbum.net/en/">http://www.qalbum.net/en/</a>
/// </summary>
namespace QAlbum
{
    static public class Util
    {
        /// <summary>
        /// Load colored cursor handle from a file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "LoadCursorFromFileW",
                CharSet = CharSet.Unicode)]
        static public extern IntPtr LoadCursorFromFile(string fileName);

        /// <summary>
        /// Create cursor from embedded cursor
        /// </summary>
        /// <param name="cursorResourceName">embedded cursor resource name</param>
        /// <returns>cursor</returns>
        public static Cursor CreateCursorFromFile(String cursorResourceName)
        {
            // read cursor resource binary data
            Stream inputStream = GetEmbeddedResourceStream(cursorResourceName);
            byte[] buffer = new byte[inputStream.Length];
            inputStream.Read(buffer, 0, buffer.Length);
            inputStream.Close();

            // create temporary cursor file
            String tmpFileName = System.IO.Path.GetRandomFileName();
            FileInfo tempFileInfo = new FileInfo(tmpFileName);
            FileStream outputStream = tempFileInfo.Create();
            outputStream.Write(buffer, 0, buffer.Length);
            outputStream.Close();

            // create cursor
            IntPtr cursorHandle = LoadCursorFromFile(tmpFileName);
            Cursor cursor = new Cursor(cursorHandle);

            tempFileInfo.Delete();  // delete temporary cursor file
            return cursor;
        }

        /// <summary>
        /// Get image from embedded resource in the given assembly
        /// </summary>
        /// <param name="resourceName">resouce name</param>
        /// <returns>embedded image</returns>
        public static Image GetImageFromEmbeddedResource(string resourceName)
        {
            Stream stream = Assembly.GetCallingAssembly().GetManifestResourceStream(resourceName);
            return new Bitmap(stream);
        }
        
        /// <summary>
        /// Get image from embedded resource in excuting assembly
        /// </summary>
        /// <param name="resourceName">resouce name</param>
        /// <returns>embedded image</returns>
        internal static Image GetImageFromScalablePictureBoxEmbeddedResource(string resourceName)
        {
            return new Bitmap(GetEmbeddedResourceStream(resourceName));
        }

        /// <summary>
        /// Get embedded resource stream
        /// </summary>
        /// <param name="resourceName">resource name</param>
        /// <returns>the stream of embedded resource</returns>
        private static Stream GetEmbeddedResourceStream(string resourceName)
        {
            return System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
        }
    }
}
