using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsgToPst
{
    //첨부 파일 관리 위한 클래스. attachment
    public class FileManager
    {
        private static string dir = "D:/test/MsgSample/files/";

        //loadfile
        public static byte[] LoadFile(string fileId)
        {
            string path = dir + fileId;
            byte[] bytes = null;
            try
            {
                bytes = File.ReadAllBytes(path);
            }
            catch(Exception ex)
            {
                bytes = new byte[1];
                Console.WriteLine("해당 파일이 존재하지 않습니다. " + path);
            }


            return bytes;
        }
        //savefile
        public static void SaveFile(string fileId)
        {
            string path = dir + fileId;
            FileStream fs = File.Create(path);
            AddText(fs, "This is some text");

            fs.Dispose();
        }

        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }
    }
}
