using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumTest.Utility;
using System;
using System.Threading;
using OpenQA.Selenium.Interactions;


namespace SeleniumTest.PageObject
{
    public class LoginPageObject 
    {
        private readonly IWebDriver driver;
        
        private readonly string url;
        private WebDriverWait wait;
        private const string prefix = Utils.Prefix;

        public LoginPageObject(IWebDriver browser) 
        {
            this.driver = browser;
            
            url = Utils.UrlBase;
            wait = new WebDriverWait(browser, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(browser, this);
        }

        #region Fields of the login screen and after logoff login

        [FindsBy(How = How.Id, Using = "email")]
        public IWebElement TxtLogin { get; set; }

        [FindsBy(How = How.Id, Using = prefix + "pass")]
        public IWebElement TxtPassword { get; set; }

        [FindsBy(How = How.Id, Using = "loginbutton")]
        public IWebElement BtnSignIn { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='navItem_100029801873205']")]
        public IWebElement FeedNoticias { get; set; }


        [FindsBy(How = How.XPath, Using = ".//*[@id='facebook']/body/div[8]/div[1]")]
        public IWebElement clickPoup { get; set; }
        


        [FindsBy(How = How.XPath, Using = ".//*[@id='globalContainer']/div[3]/div/div/div")]
        public IWebElement MsgError { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='js_33']")]
        public IWebElement MsgETimeline { get; set; }


        [FindsBy(How = How.XPath, Using = ".//*[@id='rc.u_ps_fetchstream_1_3_4']/div[1]/span[1]/a/span/span[1]")]
        public IWebElement BtnCriarPublicacao { get; set; }
        

        [FindsBy(How = How.XPath, Using = ".//*[@id='js_j']/div[2]/div[3]/div[2]/div/div/span/button")]
        public IWebElement BtnShared { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='js_3r']/div/div/div/div/div/div/div/span/span")]
        public IWebElement MsgTime { get; set; }
        

        //*[@id="js_1u"]/div/div/div[2]/div/div/div/div
        //*[@id="js_1u"]
        //*[@id="js_1u"]/div/div/div[2]/div/div


        #endregion

        #region Screen clicks

        public void BtnCriarPublicacao_Click()
        {
            Utils.XWaitForObjectBePresentAndEnabled(BtnCriarPublicacao, wait);
            BtnCriarPublicacao.Click();
           // Utils.XWaitForObjectBePresentAndEnabled(MsgTime, wait);
        }

        public void BtnShared_click() {
            Utils.XWaitForObjectBePresentAndEnabled(BtnShared, wait);
            BtnShared.Click();
        }

        public void BtnLogin_Click()
        {
            Utils.WaitForObjectBePresent(BtnSignIn, wait);
            BtnSignIn.Click();
            Utils.XWaitForObjectBePresentAndEnabled(FeedNoticias, wait);
         }

        public void FeedNoticias_Click()
        {
            Utils.XWaitForObjectBePresentAndEnabled(FeedNoticias, wait);
            FeedNoticias.Click();
            Thread.Sleep(800);
           // Utils.XWaitForObjectBePresentAndEnabled(MsgETimeline, wait);
        }

        public void BtnLoginError_Click()
        {
            Utils.WaitForObjectBePresent(BtnSignIn, wait);
            BtnSignIn.Click();
            Utils.XWaitForObjectBePresentAndEnabled(MsgError, wait);
        }

        public void Navigate()
        {
            this.driver.Navigate().GoToUrl(this.url);
            Utils.WaitForObjectBePresentAndEnabled(TxtLogin, wait);
        }

        #endregion
    }
}
