using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumTest.Enums;
using SeleniumTest.Utility;
using System;
using System.Threading;
namespace SeleniumTest.PageObject
{
    public class NewRepairPageObject : DefaultPageObject
    {
        private readonly IWebDriver driver;
        
        private readonly string urlSearchRepairInsurer;
        private readonly string urlSearchRepairBodyShop;
      

        private WebDriverWait wait;
        private const string prefix = Utils.Prefix;
        public NewRepairPageObject(IWebDriver browser) : base(browser)
        {
            this.driver = browser;

            urlSearchRepairInsurer = Utils.UrlBase + "/frmQuotationBodyShopNew.aspx";
            urlSearchRepairBodyShop = Utils.UrlBase + "/frmQuotationInsurerNew.aspx";
           

            wait = new WebDriverWait(browser, TimeSpan.FromSeconds(25));
            PageFactory.InitElements(browser, this);
        }

        #region Fields
        [FindsBy(How = How.Id, Using = "ctl00_cphBody_btnNewQuotation")]
        public IWebElement BtnNewRepair { get; set; }


        /*TC16 - Create a New Repair Manually by the Bodyshop*/

        
        [FindsBy(How = How.XPath, Using = ".//*[@id='" + prefix + "ctl00_cphBody_ddlInsurer_chosen']/a")]
        public IWebElement DdlInsurer_chosen { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='" + prefix + "ctl00_cphBody_ddlInsurer_chosen']/a']/a/span")]
        public IWebElement DdlInsurer_chosen_wait1 { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='" + prefix + "ctl00_cphBody_ddlInsurer_chosen']/a/span")]
        public IWebElement DdlInsurer_chosen_wait2 { get; set; }

        
        [FindsBy(How = How.XPath, Using = ".//*[@id='" + prefix + "ctl00_cphBody_ddlInsurer_chosen']/div/ul/li[2]")]
        public IWebElement DdlInsurer_chosen2 { get; set; }


        [FindsBy(How = How.XPath, Using = ".//*[@id='" + prefix + "ctl00_cphBody_ddlVehiclesManufacture_chosen']/a")]
        public IWebElement DdlManufaturer1 { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='" + prefix + "ctl00_cphBody_ddlVehiclesManufacture_chosen']/div/ul/li[5]")]
        public IWebElement DdlManufaturer2 { get; set; }

        [FindsBy(How = How.Id, Using = prefix + "ctl00_cphBody_ddlVehicleBranch_chosen")]
        public IWebElement DdlVehicleBranch1 { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='" + prefix + "ctl00_cphBody_ddlVehicleBranch_chosen']/div/ul/li[2]")]
        public IWebElement DdlVehicleBranch2 { get; set; }

        [FindsBy(How = How.Id, Using = prefix + "ctl00_cphBody_ddlVehicleModel_chosen")]
        public IWebElement DdlVehicleModel1 { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='" + prefix + "ctl00_cphBody_ddlVehicleModel_chosen']/div/ul/li[2]")]
        public IWebElement DdlVehicleModel2 { get; set; }

        [FindsBy(How = How.Id, Using = prefix + "ctl00_cphBody_lkbAddItems")]
        public IWebElement LkbAddItems { get; set; }

        [FindsBy(How = How.Id, Using = prefix + "ctl00_cphBody_ucQuotationItems_txtAmount")]
        public IWebElement TxtAmount { get; set; }

        [FindsBy(How = How.Id, Using = prefix + "ctl00_cphBody_ucQuotationItems_txtPriceCap")]
        public IWebElement TxtPriceCap { get; set; }

        [FindsBy(How = How.Id, Using = prefix + "ctl00_cphBody_ucQuotationItems_txtDescription")]
        public IWebElement TxtDescription { get; set; }

        
        [FindsBy(How = How.Id, Using = prefix + "ctl00_cphBody_ucQuotationItems_btnDescriptionClean")]
        public IWebElement BtnDescriptionClean { get; set; }

        [FindsBy(How = How.Id, Using = prefix + "ctl00_cphBody_ucQuotationItems_btnDescriptionSave")]
        public IWebElement BtnDescriptionSave { get; set; }

        [FindsBy(How = How.Id, Using = prefix + "ctl00_cphBody_ucQuotationItems_txtPartNumber")]
        public IWebElement TxtPartNumber { get; set; }
   
        [FindsBy(How = How.Id, Using = prefix + "ctl00_cphBody_ucQuotationItems_btnParNumberClean")]
        public IWebElement BtnPartNumberClean { get; set; }

        [FindsBy(How = How.Id, Using = prefix + "ctl00_cphBody_ucQuotationItems_btnPartNumberSave")]
        public IWebElement BtnPartNumberSave { get; set; }

        [FindsBy(How = How.Id, Using = prefix + "ctl00_cphBody_ucQuotationItems_btnSearchPartNumber")]
        public IWebElement BtnSearchPartNumber { get; set; }


        [FindsBy(How = How.Id, Using = prefix + "ctl00_cphBody_btnSave")]
        public IWebElement BtnSaveRepair { get; set; }

        [FindsBy(How = How.Id, Using = prefix + "ctl00_cphBody_lblTitle")]
        public IWebElement LblTitleRepair { get; set; }

        /**/

        #endregion

        public void BtnNewRepair_Click()
        {

            Utils.WaitForObjectBePresent(BtnNewRepair, wait);
            BtnNewRepair.Click();
            Utils.WaitForObjectBeVisible(DdlInsurer_chosen, wait);

        }

       public void DdlInsurer_chosen_Click()
        {
            Utils.WaitForObjectBeVisible(DdlInsurer_chosen, wait);
            DdlInsurer_chosen.Click();
            Utils.WaitForObjectBeVisible(DdlInsurer_chosen2, wait);
        }

        public void DdlInsurer_chosen2_Click()
        {
            Utils.WaitForObjectBeVisible(DdlInsurer_chosen2, wait);
            DdlInsurer_chosen2.Click();
            Utils.WaitForObjectBeVisible(DdlManufaturer1, wait);
        }

        public void DdlManufaturer1_Click()
        {

            //Utils.WaitForObjectBePresent(DdlInsurer_chosen_wait1, wait);
            Utils.WaitForObjectBeVisible(DdlManufaturer1, wait);
            DdlManufaturer1.Click();
            Utils.WaitForObjectBeVisible(DdlManufaturer2, wait);

        }
        
        public void DdlManufaturer2_Click()
        {
            Utils.WaitForObjectBeVisible(DdlManufaturer2, wait);
            DdlManufaturer2.Click();
            Utils.WaitForObjectBeVisible(DdlVehicleBranch1, wait);
        }
        
        //Ddl Branch/Model
        public void DdlVehicleBranch1_Click()
        {
            Utils.WaitForObjectBeVisible(DdlVehicleBranch1, wait);
            DdlVehicleBranch1.Click();
            Utils.WaitForObjectBeVisible(DdlVehicleBranch2, wait);
        }

        public void DdlVehicleBranch2_Click()
        {
            Utils.WaitForObjectBeVisible(DdlVehicleBranch2, wait);
            DdlVehicleBranch2.Click();
            Utils.WaitForObjectBeVisible(DdlVehicleModel1, wait);
        }

        //Ddl Model/Version
        public void DdlVehicleModel1_Click()
        {
            Utils.WaitForObjectBeVisible(DdlVehicleModel1, wait);
            DdlVehicleModel1.Click();
            Utils.WaitForObjectBeVisible(DdlVehicleModel2, wait);
        }

        public void DdlVehicleModel2_Click()
        {
            Thread.Sleep(800);
            DdlVehicleModel2.Click();
            Thread.Sleep(800);
        }

        //AddItems
        public void LkbAddItems_Click()
        {
            Thread.Sleep(800);
            LkbAddItems.Click();
            Thread.Sleep(800);
        }

        public void BtnDescriptionClean_Click()
        {
            Utils.WaitForObjectBePresent(BtnDescriptionClean, wait);
            BtnDescriptionClean.Click();
            Utils.WaitForTextInTextBoxBeEqual(TxtDescription, "", wait);
        }



        //newRepairPageObject.BtnDescriptionSave.Click();

        public void BtnPartNumberClean_Click()
        {
            Utils.WaitForObjectBePresent(BtnPartNumberClean, wait);
            BtnPartNumberClean.Click();
            Utils.WaitForTextInTextBoxBeEqual(TxtPartNumber, "", wait);
        }

        public void BtnSearchPartNumber_Click()
        {
            Utils.WaitForObjectBePresent(BtnSearchPartNumber, wait);
            BtnSearchPartNumber.Click();
        }

        public void BtnPartNumberSave_Click()
        {
            Utils.WaitForObjectBePresent(BtnPartNumberSave, wait);
            BtnPartNumberSave.Click();

        }
        
        public void BtnSaveRepair_Click()

        {
            Utils.WaitForObjectBePresent(BtnSaveRepair, wait);
            BtnSaveRepair.Click();
        }
    }
}
