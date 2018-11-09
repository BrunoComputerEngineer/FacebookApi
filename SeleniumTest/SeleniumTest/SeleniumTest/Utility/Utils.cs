using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTest.Domain;
using SeleniumTest.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;


namespace SeleniumTest.Utility
{
    public static class Utils
    {
        public const string Prefix = "";

        public static string UrlBase
        {
            get
            {
                return new EnvironmentData().GetEnvironmentData().UrlBase;
            }
        }

        public static void SelectItemDropDownListById(IWebElement dropDownList, DropDownListSelectTypeEnum dropDownListSelecTypeEnum, string val, IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            WaitForObjectBePresent(dropDownList, wait);
            SelectElement selectElement = new SelectElement(dropDownList);
            WaitForDropDownListPopulate(selectElement, wait);

            switch (dropDownListSelecTypeEnum)
            {
                case DropDownListSelectTypeEnum.Text:
                    selectElement.SelectByText(val);
                    break;
                case DropDownListSelectTypeEnum.Value:
                    selectElement.SelectByValue(val);
                    break;
                case DropDownListSelectTypeEnum.Index:
                    selectElement.SelectByIndex(Convert.ToInt32(val));
                    break;
                default:
                    break;
            }

            //WaitForObjectNotBePresent(pnlUpdProgress, wait);
            System.Threading.Thread.Sleep(1000);
        }

        public static void SelectItemDropDownList(IWebElement dropDownList, DropDownListSelectTypeEnum dropDownListSelecTypeEnum, string val, IWebDriver driver,IWebElement pnlUpdProgress)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            WaitForObjectBePresentAndEnabled(dropDownList, wait);
            SelectElement selectElement = new SelectElement(dropDownList);
            WaitForDropDownListPopulate(selectElement, wait);

            switch (dropDownListSelecTypeEnum)
            {
                case DropDownListSelectTypeEnum.Text:
                    selectElement.SelectByText(val);
                    break;
                case DropDownListSelectTypeEnum.Value:
                    selectElement.SelectByValue(val);
                    break;
                case DropDownListSelectTypeEnum.Index:
                    selectElement.SelectByIndex(Convert.ToInt32(val));
                    break;
                default:
                    break;
            }

            WaitForObjectNotBePresent(pnlUpdProgress,wait);
            System.Threading.Thread.Sleep(1000);
        }

        private static void WaitForDropDownListPopulate(SelectElement selectElement, WebDriverWait wait)
        {
            wait.Until<bool>((d) =>
            {
                if (selectElement.Options.Count > 0)
                {
                    return true;
                }

                return false;
            });
        }

        public static void WaitForObjectNotBePresent(IWebElement element, WebDriverWait wait)
        {
            wait.Until<bool>((d) =>
            {
                try
                {
                    d.FindElement(By.Id(element.GetAttribute("Id")));
                    if (!element.Displayed && element.Size.IsEmpty)
                    {
                        return true;
                    }
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return true;
                }
                catch(ElementNotVisibleException)
                {
                    return true;
                }
                catch (StaleElementReferenceException)
                {
                    return true;
                }
                catch (TargetInvocationException)
                {
                    return true;
                }
            });
        }

        public static void XWaitForObjectNotBePresent(IWebElement element, WebDriverWait wait)
        {
            wait.Until<bool>((d) =>
            {
                try
                {
                    if (!element.Displayed && element.Size.IsEmpty)
                    {
                        return true;
                    }
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return true;
                }
                catch (ElementNotVisibleException)
                {
                    return true;
                }
                catch (StaleElementReferenceException)
                {
                    return true;
                }
                catch (TargetInvocationException)
                {
                    return true;
                }
            });
        }

        public static void WaitForTextBePresentInLabel(IWebElement label, string text, WebDriverWait wait)
        {
            wait.Until<bool>((d) =>
            {
                try
                {
                    if (label.Text.Contains(text))
                    {
                        return true;
                    }
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
                catch (ElementNotVisibleException)
                {
                    return false;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (TargetInvocationException)
                {
                    return false;
                }
            });
        }

        public static void WaitForTextInTextBoxBeEqual(IWebElement textBox, string value, WebDriverWait wait)
        {
            wait.Until<bool>((d) =>
            {
                try
                {
                    if (textBox.GetAttribute("value") == value)
                    {
                        return true;
                    }
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
                catch (ElementNotVisibleException)
                {
                    return false;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (TargetInvocationException)
                {
                    return false;
                }
            });
        }

        public static void WaitForObjectBePresentAndEnabled(IWebElement element, WebDriverWait wait)
        {
            wait.Until<bool>((d) =>
            {
                try
                {
                    d.FindElement(By.Id(element.GetAttribute("Id")));
                    if (element.Displayed && element.Enabled && !element.Size.IsEmpty)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
                catch (ElementNotVisibleException)
                {
                    return false;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (TargetInvocationException)
                {
                    return false;
                }
            });
        }

        public static void XWaitForObjectBePresentAndEnabled(IWebElement element, WebDriverWait wait)
        {
            wait.Until<bool>((d) =>
            {
                try
                {
                    if (element.Displayed && element.Enabled && !element.Size.IsEmpty)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
                catch (ElementNotVisibleException)
                {
                    return false;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (TargetInvocationException)
                {
                    return false;
                }
            });
        }

        public static void WaitForObjectBePresent(IWebElement element, WebDriverWait wait)
        {
            wait.Until<bool>((d) =>
            {
                try
                {
                    d.FindElement(By.Id(element.GetAttribute("Id")));
                    if (element.Displayed && !element.Size.IsEmpty)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
                catch (ElementNotVisibleException)
                {
                    return false;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (TargetInvocationException)
                {
                    return false;
                }
            });
        }

        public static void WaitForObjectBeVisible(IWebElement element, WebDriverWait wait)
        {

            wait.Until<bool>((d) =>
            {
                try
                {
                    if (element.Displayed)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
                catch (ElementNotVisibleException)
                {
                    return false;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (TargetInvocationException)
                {
                    return false;
                }
            });
        }

        public static void WaitForObjectNotBeVisible(IWebElement element, WebDriverWait wait)
        {
            wait.Until<bool>((d) =>
            {
                try
                {
                    if (element.Displayed)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                catch (NoSuchElementException)
                {
                    return true;
                }
                catch (ElementNotVisibleException)
                {
                    return true;
                }
                catch (StaleElementReferenceException)
                {
                    return true;
                }
                catch (TargetInvocationException)
                {
                    return true;
                }
            });
        }

        public static string WaitAndGetTextFromSelectedItemDropDownList(IWebElement dropDownList, IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            WaitForObjectBePresent(dropDownList, wait);
            SelectElement selectElement = new SelectElement(dropDownList);
            WaitForDropDownListPopulate(selectElement, wait);

            string text = "";

            wait.Until<bool>((d) =>
            {
                try
                {
                    text = selectElement.SelectedOption.Text;
                    if (text != "")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
                catch (ElementNotVisibleException)
                {
                    return false;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (TargetInvocationException)
                {
                    return false;
                }
            });

            return text;
        }

        public static int GetNumberOfRowsOnGridThatContainsValue(IWebElement grid, string value, IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            int numberOfRows = 0;

            WaitForObjectBePresentAndEnabled(grid, wait);
            IReadOnlyCollection<IWebElement> gridRows = grid.FindElements(By.TagName("tr"));

            foreach (var row in gridRows)
            {
                if (row.Text.Contains(value))
                {
                    numberOfRows++;
                }
            }

            return numberOfRows;
        }

        public static void WaitForWindowWithContainsTitleAndSwitchTo(string title, WebDriverWait wait)
        {
            wait.Until<bool>((d) =>
            {
                foreach (var handle in d.WindowHandles)
                {
                    d.SwitchTo().Window(handle);
                    if (d.Title.Contains(title))
                    {
                        return true;
                    }
                }
                return false;
            });
        }

        public static string  GetConcatenatedTableRowsValue(IWebElement table, WebDriverWait wait)
        {
            WaitForObjectBePresentAndEnabled(table, wait);
            IReadOnlyCollection<IWebElement> tableRows = table.FindElements(By.TagName("tr"));
            StringBuilder concatenatedTableRows = new StringBuilder();

            foreach (var row in tableRows)
            {
                concatenatedTableRows.Append(row.Text);
            }

            return concatenatedTableRows.ToString();
        }

        public static void WaitForNumberOfWindowsOpenedBeEqual(int numberOfWindowsOpened, WebDriverWait wait)
        {
            wait.Until<bool>((d) =>
            {
                if (d.WindowHandles.Count == numberOfWindowsOpened)
                {
                    return true;
                }
                return false;
            });
        }

        public static void WaitForNumberOfSearchedItensOnGridBeEqual(int number, IWebElement gridResultLegend, WebDriverWait wait)
        {
            wait.Until<bool>((d) =>
            {
                try
                {
                    wait.Until(ExpectedConditions.ElementToBeClickable(gridResultLegend));
                    if (Regex.Replace(gridResultLegend.Text, @"[^0-9]+", "") == number.ToString())
                    {
                        return true;
                    }

                    return false;
                }
                catch (TargetInvocationException)
                {
                    return false;
                }
            });
        }

        public static bool VerifyIfObjectExists(IWebElement element, IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));

            try
            {
                wait.Until<bool>((d) =>
                {
                    try
                    {
                        d.FindElement(By.Id(element.GetAttribute("Id")));
                        if (element.Displayed && !element.Size.IsEmpty)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    catch (NoSuchElementException)
                    {
                        return false;
                    }
                    catch (ElementNotVisibleException)
                    {
                        return false;
                    }
                    catch (StaleElementReferenceException)
                    {
                        return false;
                    }
                    catch (TargetInvocationException)
                    {
                        return false;
                    }
                    catch (NullReferenceException)
                    {
                        return false;
                    }
                });
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }

            return true;
        }

        public static void ForceClick(IWebElement element, WebDriverWait wait)
        {
            wait.Until<bool>((d) =>
            {
                try
                {
                    element.Click();
                    return true;
        
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
                catch (ElementNotVisibleException)
                {
                    return false;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (TargetInvocationException)
                {
                    return false;
                }
            });
        }

        public static string ForceGetLabelText(IWebElement label, WebDriverWait wait)
        {
            string text = "";

            wait.Until<bool>((d) =>
            {
                try
                {
                    text = label.Text;
                    return true;

                }
                catch (NoSuchElementException)
                {
                    return false; 
                }
                catch (ElementNotVisibleException)
                {
                    return false;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (TargetInvocationException)
                {
                    return false;
                }
            });

            return text;
        }

    }
}
