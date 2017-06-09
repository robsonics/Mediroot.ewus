using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromeDriverTest2
{
    class Program
    {
        static void Main(string[] args)
        {
            var login = "";
            var pass = "";
            var inputPesel = "";
            //var downloadPath
            //var q =  new DefaultSelenium(“”, 4444, @“*chrome”, @“”); 
            var capabilities = DesiredCapabilities.Chrome();
            capabilities.SetCapability("download.default_directory", @"/home/rtki");
            capabilities.SetCapability("intl.accept_languages", "nl");
            capabilities.SetCapability("disable-popup-blocking", "true");
            capabilities.SetCapability("download.prompt_for_download", false);
            capabilities.SetCapability("download.directory_upgrade", true);
            capabilities.SetCapability("safebrowsing.enabled", true);
            var driver = new RemoteWebDriver(new Uri("http://192.168.99.100:4444/wd/hub"), capabilities);
            //var chromeOptions = new ChromeOptions();
           
            //ChromeDriverService
            //var driver = new ChromeDriver(chromeOptions);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl("https://ewus.nfz.gov.pl/ap-ewus/");
            driver.SwitchTo().Frame(driver.FindElement(By.Id("info")));
            var element = driver.FindElementById("FFFRAXownfz");
            new SelectElement(element).SelectByText("Wielkopolski (15)");
            driver.FindElementByName("FFFRAXlogin").SendKeys(login);
            driver.FindElementByName("FFFRAXpasw").SendKeys(pass);
            driver.FindElementByName("sub1").Click();
            driver.FindElementByName("FFFRAQ11@pesel").SendKeys(inputPesel);
            driver.FindElementByName("SEARCH_BUTTON").Click();
            var result  = driver.FindElementByClassName("validationTitle").Text;
            Console.WriteLine(result);

            driver.FindElementByXPath(@"//*[@id=""contentFooter""]/div/div[3]/div[5]/a").Click();
            // TODO check if file is downloaded

        }
    }
}
