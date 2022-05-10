using AventStack.ExtentReports;
using MarsFramework.Config;
using MarsFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using static MarsFramework.Global.GlobalDefinitions;


namespace MarsFramework.Global
{
    class Bace
    {
        #region To access Path from resource file

        public static int Browser = Int32.Parse(MarsResource.Browser);
        public static String ExcelPath = MarsResource.ExcelPath;
        public static string ScreenshotPath = MarsResource.ScreenshotPath;
        public static string ReportPath = MarsResource.ReportPath;
        public static string FileUploadPath = MarsResource.ReportPath;
        #endregion

        #region Report and Tests for ExtentReports  

        public static ExtentReports extent;
        public static ExtentTest test;

        #endregion



        #region setup and tear down

        [SetUp]
        public void Inititalize()
        {
            switch (Browser)
            {
                case 1:
                    GlobalDefinitions.driver = new FirefoxDriver();
                    break;
                case 2:
                    GlobalDefinitions.driver = new ChromeDriver();
                    break;
            }

            // Maximize browser window
            GlobalDefinitions.driver.Manage().Window.Maximize();


            if (MarsResource.IsLogin == "true")
            {
                SignIn loginobj = new SignIn();
                loginobj.login();
            }
            else
            {
                SignUp obj = new SignUp();
                obj.join();
            }
        }


        [TearDown]
        public void TearDown()
        {
            // Take a screenshot          
            string img = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Screenshot");
            test.AddScreenCaptureFromPath(img);

            // Quit browser
            GlobalDefinitions.driver.Quit();
        }

        #endregion
    }
}
