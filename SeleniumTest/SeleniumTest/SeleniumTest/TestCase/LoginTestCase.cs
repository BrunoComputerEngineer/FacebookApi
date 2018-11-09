using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTest.Domain;
using SeleniumTest.Enums;
using SeleniumTest.PageObject;
using SeleniumTest.TestScript;
using SeleniumTest.Utility;
using System.Threading;

namespace SeleniumTest.TestCase
{
    public class LoginTestCase 
    {
        private WebDriverWait wait;
      
        private IWebDriver driver;
        private LoginPageObject loginPageObject;
        private EnvironmentData environmentData;
        private User user = new User().GetUser();
        public string navegator = "IE";
        public LoginTestCase(IWebDriver browser)
        {
            driver = browser;
            
        
            loginPageObject = new LoginPageObject(driver);
        }

        public void Login()
        {
            loginPageObject.Navigate();

            loginPageObject.TxtLogin.SendKeys(user.UserName);
            loginPageObject.TxtPassword.SendKeys(user.Password);
            loginPageObject.BtnLogin_Click();
        }


        public void LoginWithInvalidEmail()
        {
            loginPageObject.Navigate();

            loginPageObject.TxtLogin.SendKeys(user.UserNameInvalid);
            loginPageObject.TxtPassword.SendKeys(user.Password);
            loginPageObject.BtnLoginError_Click();

            string msgErro = loginPageObject.MsgError.Text;
            
            Assert.IsTrue(loginPageObject.MsgError.Text.Contains("O email ou o número de telefone inserido não corresponde a nenhuma conta. Cadastre-se para abrir uma conta."));
        }



        public void LoginWithInvalid__password()
        {
            loginPageObject.Navigate();

            loginPageObject.TxtLogin.SendKeys(user.UserName);
            loginPageObject.TxtPassword.SendKeys(user.PasswordInvalid);
            loginPageObject.BtnLoginError_Click();
            Assert.IsTrue(loginPageObject.MsgError.Text.Contains("A senha inserida está incorreta. Esqueceu a senha?"));


        }

        
        public void LoginWithInvalid_passwordAndUser()
        {
            loginPageObject.Navigate();

            loginPageObject.TxtLogin.SendKeys(user.UserNameInvalid);
            loginPageObject.TxtPassword.SendKeys(user.PasswordInvalid);
            loginPageObject.BtnLoginError_Click();
            Assert.IsTrue(loginPageObject.MsgError.Text.Contains("O email ou o número de telefone inserido não corresponde a nenhuma conta. Cadastre-se para abrir uma conta."));

        }

        
        public void LoginWithout_password()
        {
            loginPageObject.Navigate();

            loginPageObject.TxtLogin.SendKeys(user.UserName);
            loginPageObject.TxtPassword.SendKeys("");
            loginPageObject.BtnLoginError_Click();
            Assert.IsTrue(loginPageObject.MsgError.Text.Contains("A senha inserida está incorreta. Esqueceu a senha?"));
        }

        
        public void LoginWithaAllBlankFields()
        {
            loginPageObject.Navigate();

            loginPageObject.TxtLogin.SendKeys("");
            loginPageObject.TxtPassword.SendKeys("");
            loginPageObject.BtnLoginError_Click();
            Assert.IsTrue(loginPageObject.MsgError.Text.Contains("O email ou o número de telefone inserido não corresponde a nenhuma conta. Cadastre-se para abrir uma conta."));
        }

        
        public void LoginWithoutEmail()
        {
            loginPageObject.Navigate();

            loginPageObject.TxtLogin.SendKeys("");
            loginPageObject.TxtPassword.SendKeys(user.Password);
            loginPageObject.BtnLoginError_Click();
            Assert.IsTrue(loginPageObject.MsgError.Text.Contains("O email ou o número de telefone inserido não corresponde a nenhuma conta. Cadastre-se para abrir uma conta."));
        }

        public void PostInTimeLine()
        {
            loginPageObject.clickPoup.Click();
            loginPageObject.FeedNoticias_Click();
            loginPageObject.BtnCriarPublicacao_Click();
            loginPageObject.MsgTime.Click();
            loginPageObject.MsgTime.SendKeys("Escrevendo no time line");
            loginPageObject.BtnShared_click();
        }

    }
}
