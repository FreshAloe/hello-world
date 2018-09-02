using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace HttpWebRequestSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            HttpWebRequest req = WebRequest.Create("https://www.naver.com") as HttpWebRequest;
            HttpWebResponse res = req.GetResponse() as HttpWebResponse;

            using (StreamReader sr = new StreamReader(res.GetResponseStream()))
            {
                string responseText = sr.ReadToEnd();
                //Console.WriteLine(responseText);
                File.WriteAllText("naver.html", responseText);
            }

            //
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            string resText = wc.DownloadString("https://www.naver.com");
            Console.WriteLine(resText);
            File.WriteAllText("naver1.html", resText);
        }
    }
}
