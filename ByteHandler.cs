using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KimSangjin
{
    class ByteHandler
    {
        /// <summary>
        /// 파일 경로로부터 모든 바이트를 리턴한다.
        /// </summary>
        public static byte[] GetWholeBytes(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(path);
            }

            using (Stream sr = new FileStream(path, FileMode.Open))
            using (BinaryReader br = new BinaryReader(sr))
            {
                return br.ReadBytes((int)sr.Length);
            }
        }

        /// <summary>
        /// 로부터 모든 바이트를 리턴한다.
        /// </summary>
        public static byte[] GetWholeBytes(Stream sr)
        {
            using (BinaryReader br = new BinaryReader(sr))
            {
                return br.ReadBytes((int)sr.Length);
            }
        }

        /// <summary>
        /// 바이트 정보를 해당 경로에 저장한다.
        /// </summary>
        private static void SaveBytes(byte[] bytes, string path)
        {
            using (Stream sw = new FileStream(path, FileMode.Create))
            using (BinaryWriter bw = new BinaryWriter(sw))
            {
                bw.Write(bytes);
            }
        }

        /// <summary>
        /// bytes 를 출력한다.
        /// </summary>
        public static void PrintBytes(byte[] bytes)
        {
            int i = 1;
            foreach (byte b in bytes)
            {
                Console.Write(b);
                Console.Write(" ");
                if (i % 16 == 0)
                    Console.WriteLine();
                i++;
            }

        }
    }
}
