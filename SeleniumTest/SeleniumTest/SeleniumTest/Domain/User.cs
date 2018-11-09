using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTest.Domain
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public string UserNameInvalid { get; set; }
        public string PasswordInvalid { get; set; }

        public User GetUser()
        {
            var reader = new StreamReader(File.OpenRead(new DirectoryInfo(new System.Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath).Parent.Parent.Parent.FullName + @"\Data\user.csv"));
            Dictionary<string, string> userDic = new Dictionary<string, string>();

            var header = reader.ReadLine().Split(';');
            var line = reader.ReadLine().Split(';');

            for (int i = 0; i < line.Length; i++)
            {
                userDic.Add(header[i], line[i]);
            }

            User User = new User();

            User.UserName = userDic["UserName"];
            User.Password = userDic["Password"];
            User.PasswordInvalid = userDic["PasswordInvalid"];
            User.UserNameInvalid = userDic["UserNameInvalid"];
            return User;
        }
    }
}
