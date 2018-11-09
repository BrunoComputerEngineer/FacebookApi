using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTest.Domain;
using SeleniumTest.Enums;
using SeleniumTest.PageObject;
using SeleniumTest.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium.Support.UI;



namespace SeleniumTest.TestCase
{
    public class NewRepairTestCase : NewRepairPageObject
    {
        
        private IWebDriver driver;
        private NewRepairPageObject newRepairPageObject;
        private NewRepair repair;
        private VehicleManufacturer vehicleManufacturer;
        private BodyShop bodyShop;
        private WebDriverWait wait;


        public NewRepairTestCase(IWebDriver browser) : base(browser)
        {
            driver = browser;
            
            newRepairPageObject = new NewRepairPageObject(driver);
          
            repair = new NewRepair().GetNewRepair();
            vehicleManufacturer = new VehicleManufacturer().GetVehicleManufacturer();
            bodyShop = new BodyShop().GetBodyShop();
            

        }

        public void SelecteAllRepair()
      {
            
            
           

        }

       

        public void NewRepair_BodyShop()
        {
            
            //SelecteAllRepair();

            newRepairPageObject.BtnNewRepair_Click();


            //Assert.IsTrue(newRepairPageObject.DdlInsurer_chosen.GetAttribute("value") == repair.CompanyName, "Claim Number value does not match");

            //bool existe = new WebDriverWait(driver, TimeSpan.FromSeconds(600)).Until(d => d.FindElement(By.Id("ctl00_cphBody_ddlInsurer_chosen")).Text.Contains("Seleccione"));

            //Ddl Company
            newRepairPageObject.DdlInsurer_chosen_Click();
            newRepairPageObject.DdlInsurer_chosen2_Click();
            //Ddl Manufacturer
            newRepairPageObject.DdlManufaturer1_Click();
            newRepairPageObject.DdlManufaturer2_Click();
            //Ddl Branch/Model
            newRepairPageObject.DdlVehicleBranch1_Click();
            newRepairPageObject.DdlVehicleBranch2_Click();
            //Ddl Model/Version
            newRepairPageObject.DdlVehicleModel1_Click();
            newRepairPageObject.DdlVehicleModel2_Click();

            newRepairPageObject.TxtVIN.SendKeys(repair.VIN);

            //AddItems
            newRepairPageObject.LkbAddItems_Click();

            newRepairPageObject.TxtAmount.Clear();
            newRepairPageObject.TxtAmount.SendKeys(repair.NumberofParts);
            newRepairPageObject.TxtPriceCap.SendKeys(repair.PVP);

            newRepairPageObject.TxtDescription.SendKeys(repair.Description);
            newRepairPageObject.BtnDescriptionClean_Click();
            newRepairPageObject.TxtDescription.SendKeys(repair.Description);
            //newRepairPageObject.BtnDescriptionSave.Click();

            newRepairPageObject.TxtPartNumber.SendKeys(repair.AddPartNumber);
            newRepairPageObject.BtnPartNumberClean_Click();
            newRepairPageObject.TxtPartNumber.SendKeys(repair.AddPartNumber);
            newRepairPageObject.BtnSearchPartNumber_Click();
            newRepairPageObject.BtnPartNumberSave_Click();
            newRepairPageObject.BtnSaveRepair_Click();


        }

    }
}
