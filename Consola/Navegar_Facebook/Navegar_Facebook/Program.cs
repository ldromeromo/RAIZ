using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Navegar_Facebook
{
    class Program
    {
        public static void Main(string[] args)
        {
            string error = string.Empty;
            //log xx
            pagFacebook(ref error);
        }
        public static void pagFacebook(ref string error)
        {
            try
            {
                WebProxy proxyObject = new WebProxy("http://fevernova.nh.inet:80/", false);
                WebRequest req = WebRequest.Create("https://825129715360.signin.aws.amazon.com/console");
                req.Proxy = proxyObject;
                IWebDriver driverassoc = null;

                string user = ConfigurationManager.AppSettings["Usuario"];
                string pass = ConfigurationManager.AppSettings["Pass"];
                Console.WriteLine();
                ChromeOptions opt = new ChromeOptions();
                opt.AddUserProfilePreference("disable-popup-blocking", "true");
                opt.AddArgument("--start-maximized");
                driverassoc = new ChromeDriver(opt); // Environment.CurrentDirectory);xxx

                //Login in
                driverassoc.Navigate().GoToUrl("https://www.facebook.com/"); // ConfigurationManager.AppSettings["urlmaui"]);
                driverassoc.FindElement(By.XPath("//*[@id='email']")).SendKeys(user);
                driverassoc.FindElement(By.XPath("//*[@name='pass']")).SendKeys(pass);

                Thread.Sleep(2000);
                driverassoc.FindElement(By.XPath("//*[@name='login']")).Click();
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                Console.WriteLine(error);
                //throw;
            }
        }
    }
}
