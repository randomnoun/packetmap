using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PacketMap {
    
    /// <summary>
    /// Utility class
    /// </summary>
    class Util {
        
        /// <summary>
        /// Enumerate recusively for all files under a subdirectory. Code
        /// creatively borrowed from http://blogs.msdn.com/brada/archive/2004/03/04/84069.aspx
        /// </summary>
        /// 
        /// <param name="path">path to search</param>
        /// <param name="glob">file specification (e.g. "*.txt")</param>
        /// <returns></returns>
        public static IEnumerable<string> GetFiles(string path, String glob) {
            foreach (string s in Directory.GetFiles(path, glob)) {
                yield return s;
            }
            foreach (string s in Directory.GetDirectories(path)) {
                foreach (string s1 in GetFiles(s, glob)) {
                    yield return s1;
                }
            }
        }
    }
}
