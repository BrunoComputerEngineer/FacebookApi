using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using SeleniumTest.Enums;
using SeleniumTest.TestCase;
using System;
using System.Runtime.InteropServices;
using System.Text;
using SeleniumTest.Domain;
using OpenQA.Selenium.Chrome;
using NUnit.Framework.Interfaces;

namespace SeleniumTest.TestScript
{
    [TestFixture]
    public class TestScript
    {
        #region Parameters

        private IWebDriver driver;

        private LoginTestCase loginTestCase;
        private StringBuilder verificationErrors;
        public string navegator = "ChromeDriver";
        private EnvironmentData environment;

        #endregion

        #region SetUp

        [SetUp]
        public void SetupTest()
        {


            if (navegator == "ChromeDriver")
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArguments("--disable-infobars");
                options.AddArguments("start-maximized");
                driver = new ChromeDriver(options);
            }
            if (navegator == "FireFox")
            {
                driver = new FirefoxDriver();

            }
            loginTestCase = new LoginTestCase(driver);

            verificationErrors = new StringBuilder();
            environment = new EnvironmentData().GetEnvironmentData();

        }

        #endregion
        [Test]
        public void loginSucess()
        {
            loginTestCase.Login();
        }

        [Test]
        public void LoginWithInvalidEmail()
        {
            loginTestCase.LoginWithInvalidEmail();
        }

        [Test]
        public void LoginWithInvalid__password()
        {
            loginTestCase.LoginWithInvalid__password();
        }

        [Test]
        public void LoginWithInvalid_passwordAndUser()
        {
            loginTestCase.LoginWithInvalid_passwordAndUser();
        }

        [Test]
        public void LoginWithout_password()
        {
            loginTestCase.LoginWithout_password();
        }

        [Test]
        public void LoginWithaAllBlankFields()
        {
            loginTestCase.LoginWithaAllBlankFields();
        }

        [Test]
        public void LoginWithoutEmail()
        {
            loginTestCase.LoginWithoutEmail();
        }

        [Test]
        public void PostInTimeLine()
        {
            loginTestCase.Login();
            loginTestCase.PostInTimeLine();
        }






        

        #region end tests
        /*    [Test]f
            public void CancelQuotation()
             {
             if (parameterClaimNumberInsurer != "")
             {f
                 QuotationTestCase quotationTestCase = new QuotationTestCase(driver);
                 loginTestCase.Logon(UserTypeEnum.Insurer);
                 quotationTestCase.CancelQuotation(parameterClaimNumberInsurer);
                 loginTestCase.LogOff();
             }
             if (parameterClaimNumberBodyShop != "")
             {
                 QuotationTestCase quotationTestCase = new QuotationTestCase(driver);
                 loginTestCase.Logon(UserTypeEnum.BodyShop);
                 quotationTestCase.CancelQuotation(parameterClaimNumberBodyShop);
                 loginTestCase.LogOff();
             }
         }*/

        //[TearDown]
        //public void TeardownTest()
        //{
        //    try
        //    {
        //        #region Paramenters
        //        //PARAMETERS
        //        if (parameterParametersNumberBodyShop != "")
        //        {
        //            QuotationTestCase quotationTestCase = new QuotationTestCase(driver);
        //            ParametersTestCase parametersTestCase = new ParametersTestCase(driver);
        //            AgreementsTestCase agreementsTestCase = new AgreementsTestCase(driver);

        //            loginTestCase.Logon(UserTypeEnum.Admin);
        //            parametersTestCase.SearchConfigureParametersBodyshop();
        //            parametersTestCase.UnselectAutomaticSelectionOfSuppliersBodyShop();
        //            loginTestCase.LogOff();
        //        }
        //        if (parameterParametersNumberInsurer != "")
        //        {
        //            QuotationTestCase quotationTestCase = new QuotationTestCase(driver);
        //            ParametersTestCase parametersTestCase = new ParametersTestCase(driver);
        //            AgreementsTestCase agreementsTestCase = new AgreementsTestCase(driver);

        //            loginTestCase.Logon(UserTypeEnum.Admin);
        //            parametersTestCase.SearchConfigureParametersInsurer();
        //            parametersTestCase.UnselectAutomaticSelectionOfSuppliersInsurer();
        //            loginTestCase.LogOff();
        //        }
        //        #endregion

        //        #region Cancel Quotations Insurer
        //        //Cancel Quotations Insurer
        //        if (parameterClaimNumberInsurer != "")
        //        {
        //            QuotationTestCase quotationTestCase = new QuotationTestCase(driver);
        //            loginTestCase.Logon(UserTypeEnum.Insurer);
        //            quotationTestCase.CancelQuotation(parameterClaimNumberInsurer);
        //            loginTestCase.LogOff();
        //        }
        //        if (parameterClaimNumberInsurer2 != "")
        //        {
        //            QuotationTestCase quotationTestCase = new QuotationTestCase(driver);
        //            loginTestCase.Logon(UserTypeEnum.Insurer);
        //            quotationTestCase.CancelQuotation(parameterClaimNumberInsurer2);
        //            loginTestCase.LogOff();
        //        }
        //        if (parameterClaimNumberInsurer3 != "")
        //        {
        //            QuotationTestCase quotationTestCase = new QuotationTestCase(driver);
        //            loginTestCase.Logon(UserTypeEnum.Insurer);
        //            quotationTestCase.CancelQuotation(parameterClaimNumberInsurer3);
        //            loginTestCase.LogOff();
        //        }
        //        if (parameterClaimNumberInsurer4 != "")
        //        {
        //            QuotationTestCase quotationTestCase = new QuotationTestCase(driver);
        //            loginTestCase.Logon(UserTypeEnum.Insurer);
        //            quotationTestCase.CancelQuotation(parameterClaimNumberInsurer4);
        //            loginTestCase.LogOff();
        //        }
        //        if (parameterClaimNumberInsurer5 != "")
        //        {
        //            QuotationTestCase quotationTestCase = new QuotationTestCase(driver);
        //            loginTestCase.Logon(UserTypeEnum.Insurer);
        //            quotationTestCase.CancelQuotation(parameterClaimNumberInsurer5);
        //            loginTestCase.LogOff();
        //        }

        //        #endregion

        //        #region Cancel Quotations Bodyshop
        //        //Cancel Quotations BodyShop
        //        if (parameterClaimNumberBodyShop != "")
        //        {
        //            QuotationTestCase quotationTestCase = new QuotationTestCase(driver);
        //            loginTestCase.Logon(UserTypeEnum.BodyShop);
        //            quotationTestCase.CancelQuotation(parameterClaimNumberBodyShop);
        //            loginTestCase.LogOff();
        //        }
        //        if (parameterClaimNumberBodyShop2 != "")
        //        {
        //            QuotationTestCase quotationTestCase = new QuotationTestCase(driver);
        //            loginTestCase.Logon(UserTypeEnum.BodyShop);
        //            quotationTestCase.CancelQuotation(parameterClaimNumberBodyShop2);
        //            loginTestCase.LogOff();
        //        }
        //        if (parameterClaimNumberBodyShop3 != "")
        //        {
        //            QuotationTestCase quotationTestCase = new QuotationTestCase(driver);
        //            loginTestCase.Logon(UserTypeEnum.BodyShop);
        //            quotationTestCase.CancelQuotation(parameterClaimNumberBodyShop3);
        //            loginTestCase.LogOff();
        //        }
        //        if (parameterClaimNumberBodyShop4 != "")
        //        {
        //            QuotationTestCase quotationTestCase = new QuotationTestCase(driver);
        //            loginTestCase.Logon(UserTypeEnum.BodyShop);
        //            quotationTestCase.CancelQuotation(parameterClaimNumberBodyShop4);
        //            loginTestCase.LogOff();
        //        }

        //        #endregion



        //        if (parameterAgreementsNumberBodyShop != "")
        //        {
        //            AgreementsTestCase agreementsTestCase = new AgreementsTestCase(driver);

        //            //Search Agreements between the buyers - (User: Administrator)
        //            loginTestCase.Logon(UserTypeEnum.Admin);
        //            agreementsTestCase.SearchAgreementsBetweenTheBuyers();
        //            agreementsTestCase.BackAgreementToDefault();
        //            loginTestCase.LogOff();
        //        }

        //        #region Column Delivere Type
        //        if (ColumnDelivereTypeBodyShop != "")
        //        {
        //            RegistrationTestCase registrationTestCase = new RegistrationTestCase(driver);
        //            loginTestCase.Logon(UserTypeEnum.Admin);
        //            registrationTestCase.SearchUserGroup("BodyShop");
        //            registrationTestCase.ColumnDeliveryType_deselect();
        //            loginTestCase.LogOff();
        //        }

        //        if (ColumnDelivereTypeInsurer != "")
        //        {
        //            RegistrationTestCase registrationTestCase = new RegistrationTestCase(driver);
        //            loginTestCase.Logon(UserTypeEnum.Admin);
        //            registrationTestCase.SearchUserGroup("Insurer");
        //            registrationTestCase.ColumnDeliveryType_deselect();
        //            loginTestCase.LogOff();
        //        }

        //        if (ColumnDelivereTypeSupplier != "")
        //        {
        //            RegistrationTestCase registrationTestCase = new RegistrationTestCase(driver);
        //            loginTestCase.Logon(UserTypeEnum.Admin);
        //            registrationTestCase.SearchUserGroup("Supplier");
        //            registrationTestCase.ColumnDeliveryType_deselect();
        //            loginTestCase.LogOff();
        //        }
        //        #endregion

        //        driver.Quit();
        //    }
        //    catch (Exception)
        //    {
        //        // Ignore errors if unable to close the browser
        //        driver.Quit();
        //    }
        //    Assert.AreEqual("", verificationErrors.ToString());
        //}

        #region TearDown Simples
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                driver.Quit();
            }

            finally
            {

            }
            driver.Quit();
        }
        #endregion

    }


    #endregion
}