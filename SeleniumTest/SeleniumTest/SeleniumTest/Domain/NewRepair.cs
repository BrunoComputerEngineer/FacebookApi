using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace SeleniumTest.Domain
{
    public class NewRepair
    {
        public string CompanyName { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Version { get; set; }
        public string VIN { get; set; }
        public string Description { get; set; }
        public string NumberofParts { get; set; }
        public string PVP { get; set; }
        public string AddPartNumber { get; set; }

        

        #region Methods

        public NewRepair GetNewRepair()
        {
            EnvironmentData environment = new EnvironmentData().GetEnvironmentData();

            var reader = new StreamReader(File.OpenRead(new DirectoryInfo(new System.Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath).Parent.Parent.Parent.FullName + Path.Combine(@"\Data", environment.Environment, "NewRepair.csv")));
            Dictionary<string, string> newRepairDic = new Dictionary<string, string>();

            var header = reader.ReadLine().Split(';');
            var line = reader.ReadLine().Split(';');

            for (int i = 0; i < line.Length; i++)
            {
                newRepairDic.Add(header[i], line[i]);
            }

            NewRepair repair = new NewRepair();

            repair.CompanyName = newRepairDic["CompanyName"];
            repair.Brand = newRepairDic["Brand"];
            repair.Model = newRepairDic["Model"];
            repair.Version = newRepairDic["Version"];
            repair.VIN = newRepairDic["VIN"];
            repair.Description = newRepairDic["Description"];
            repair.NumberofParts = newRepairDic["NumberofParts"];
            repair.PVP = newRepairDic["PVP"];
            repair.AddPartNumber = newRepairDic["AddPartNumber"];

           
            return repair;
        }

        #endregion
    }
}
