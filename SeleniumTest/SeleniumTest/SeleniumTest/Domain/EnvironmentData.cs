using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTest.Domain
{
    public class EnvironmentData
    {
        public string UrlBase { get; set; }
       

        public EnvironmentData GetEnvironmentData()
        {
            var reader = new StreamReader(File.OpenRead(new DirectoryInfo(new System.Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath).Parent.Parent.Parent.FullName + @"\Data\EnvironmentData.csv"));
            Dictionary<string, string> environmentDataDic = new Dictionary<string, string>();

            var header = reader.ReadLine().Split(';');
            var line = reader.ReadLine().Split(';');

            for (int i = 0; i < line.Length; i++)
            {
                environmentDataDic.Add(header[i], line[i]);
            }

            EnvironmentData environmentData = new EnvironmentData();

            environmentData.UrlBase = environmentDataDic["UrlBase"];
            

            return environmentData;
        }
    }
}
