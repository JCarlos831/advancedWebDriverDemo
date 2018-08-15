using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace WebDriverDemo
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            ////IWebDriver driver = new FirefoxDriver("/Users/JuanCMontoya/Desktop");
            ////driver.Navigate().GoToUrl("https://www.google.com");


            //IWebDriver driver = new ChromeDriver();
            //driver.Navigate().GoToUrl("https://www.google.com");

            //driver.Url = "file:///Users/JuanCMontoya/Projects/PluralSight/AdvancedWebDriverDemo/AdvancedWebDriverDemo/TestPage.html";

            //var radioButtons = driver.FindElements(By.Name("color"));
            //foreach (var radioButton in radioButtons)
            //{
            //    if(radioButton.Selected)
            //        Console.WriteLine(radioButton.GetAttribute("value"));
            //}


            //var checkbox = driver.FindElement(By.Id("check1"));
            //checkbox.Click();
            //checkbox.Click();


            //var select = driver.FindElement(By.Id("select1"));

            //var selectElement = new SelectElement(select);
            //selectElement.SelectByText("Frank");


            ////var tomOption = select.FindElements(By.TagName("option"))[2];
            ////tomOption.Click();

            //var outerTable = driver.FindElement(By.TagName("table"));
            //var innerTable = outerTable.FindElement(By.TagName("table"));
            //// Find table 2 row 2 text
            ////var row = innerTable.FindElements(By.TagName("td"))[1];
            ////Console.WriteLine("Look what I found {0}", row.Text);

            //var row = innerTable.FindElement(By.XPath("/html/body/table/tbody/tr/td[2]/table/tbody/tr[2]/td"));
            //Console.WriteLine("Look what I found {0}", row.Text);

            //IWebDriver driver = new ChromeDriver();

            DesiredCapabilities cap = new DesiredCapabilities();
            cap.SetBrowserName("Chrome");

            ChromeOptions options = new ChromeOptions();
            IWebDriver driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), options.ToCapabilities());


            driver.Navigate().GoToUrl("https://www.google.com");

            var searchBox = driver.FindElement(By.Name("q"));
            searchBox.SendKeys("pluralsight");
            searchBox.Submit();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var imagesLink = wait.Until(d =>
                            {
                                var elements =  driver.FindElements(By.CssSelector(".q.qs"));
                                if (elements.Count > 0)
                                    return elements[2];
                                return null;
                            });

            //var imagesLink = driver.FindElements(By.CssSelector(".q.qs"))[2];
            imagesLink.Click();

            var col = driver.FindElement(By.CssSelector(".rg_bx.rg_di.rg_el.ivg-i"));
            var firstImageLink = col.FindElements(By.TagName("a"))[0];
            firstImageLink.Click();

        }
    }
}