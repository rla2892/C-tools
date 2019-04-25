using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class Dic
    {
        public string Id { get; set; }
        public Dictionary<string, Dic> Sub { get; set; } = new Dictionary<string, Dic>();

        public static void PrintDic(Dic dic)
        {
            Console.WriteLine(dic.Id);
            foreach(Dic subDic in dic.Sub.Values)
            {
                PrintDic(subDic);
            }
        }

        public static void FindDic(Dic dic, string id)
        {
            if(dic.Id == id)
            {
                Console.WriteLine("found");
                return;
            }

            foreach(Dic subDic in dic.Sub.Values)
            {
                FindDic(subDic, id);
            }
        }

        public static Dic ReturnSelf(Dic dic)
        {
            return dic;
        }
    }
}
