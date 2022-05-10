﻿using MarsFramework.Global;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Threading;
using System.Diagnostics;
using static MarsFramework.Global.GlobalDefinitions;
using AutoItX3Lib;



namespace MarsFramework.Pages
{
    public class ShareSkill 
    {
        public ShareSkill()
        {
            PageFactory.InitElements(GlobalDefinitions.driver, this);
        }

        #region Initialize Web Elements (Page Factory style)

        //Click on ShareSkill Button
        [FindsBy(How = How.LinkText, Using = "Share Skill")]
        private IWebElement ShareSkillButton { get; set; }

        //Enter the Title in textbox
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement Title { get; set; }

        //Enter the Description in textbox
        [FindsBy(How = How.Name, Using = "description")]
        private IWebElement Description { get; set; }

        //Click on Category Dropdown
        [FindsBy(How = How.Name, Using = "categoryId")]
        private IWebElement CategoryDropDown { get; set; }

        //Click on SubCategory Dropdown
        [FindsBy(How = How.Name, Using = "subcategoryId")]
        private IWebElement SubCategoryDropDown { get; set; }

        //Enter Tag names in textbox
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]")]
        private IWebElement Tags { get; set; }

        //Select the Service type
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div")]
        private IWebElement ServiceTypeOptions { get; set; }

        //Select the Location Type
        [FindsBy(How = How.XPath, Using = "//form/div[6]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement LocationTypeOption { get; set; }

        //Click on Start Date dropdown
        [FindsBy(How = How.Name, Using = "startDate")]
        private IWebElement StartDateDropDown { get; set; }

        //Click on End Date dropdown
        [FindsBy(How = How.Name, Using = "endDate")]
        private IWebElement EndDateDropDown { get; set; }

        //Storing the table of available days
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[3]/div[1]/div/input")]
        private IWebElement Days { get; set; }

        //Click on StartTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        private IWebElement StartTimeDropDown { get; set; }

        //Click on EndTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[3]/input[1]")]
        private IWebElement EndTimeDropDown { get; set; }

        //Click on Skill Trade option
        [FindsBy(How = How.XPath, Using = "//form/div[8]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement SkillTradeOption { get; set; }

        //Enter Skill Exchange
        [FindsBy(How = How.XPath, Using = "//div[@class='form-wrapper']//input[@placeholder='Add new tag']")]
        private IWebElement SkillExchange { get; set; }

        //Click on Work Sample
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i")]
        private IWebElement WorkSample { get; set; }

        //Enter the amount for Credit
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Amount']")]
        private IWebElement CreditAmount { get; set; }

        //Click on Active/Hidden option
        [FindsBy(How = How.XPath, Using = "//form/div[10]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement ActiveOption { get; set; }

        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement Save { get; set; }

        //Click on Manage Listings Link
        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        private IWebElement manageListingsLink { get; set; }      

        #endregion

        #region public void EnterShareSkill()

        public void EnterShareSkill()
        {
            // Referencing to an excel file and sheet name
            GlobalDefinitions.ExcelLib.PopulateInCollection(Bace.ExcelPath, "ShareSkill");
            try
            {
                ShareSkillButton.Click();
                Thread.Sleep(1000);
                Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));
                Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));
                CategoryDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Category"));
                SubCategoryDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Subcategory"));
                Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tags"));
                Tags.SendKeys(Keys.Enter);
                ServiceTypeOptions.Click();
                LocationTypeOption.Click();
                StartDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Start date"));
                EndDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "End date"));
                Days.Click();

                string startTime = (GlobalDefinitions.ExcelLib.ReadData(2, "Start time"));
                StartTimeDropDown.SendKeys(ExtractTimeInfo(startTime, "hh"));
                StartTimeDropDown.SendKeys(ExtractTimeInfo(startTime, "mm"));
                StartTimeDropDown.SendKeys(ExtractTimeInfo(startTime, "ampm"));

                string endTime = (GlobalDefinitions.ExcelLib.ReadData(2, "End time"));
                EndTimeDropDown.SendKeys(ExtractTimeInfo(endTime, "hh"));
                EndTimeDropDown.SendKeys(ExtractTimeInfo(endTime, "mm"));
                EndTimeDropDown.SendKeys(ExtractTimeInfo(endTime, "ampm"));
                
                SkillTradeOption.Click();
                SkillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill-Exchange"));
                SkillExchange.SendKeys(Keys.Enter);
                WorkSample.Click();

                AutoItX3 autoIt = new AutoItX3();
                string workSampleFile = (ExcelLib.ReadData(2, "Work Samples"));
                autoIt.WinActivate("Open");
                Thread.Sleep(1000);
                autoIt.Send(Bace.FileUploadPath + workSampleFile);
                Thread.Sleep(2000);
                autoIt.Send("{ENTER}");
                Thread.Sleep(1000);

                ActiveOption.Click();
                Thread.Sleep(5000);
                Save.Click();
                Thread.Sleep(2000);


                // Wait for Manage listings page to load 
                //Thread.Sleep(2000);
            }
            catch (Exception e) 
            {
                Console.WriteLine(e);
            }
        }

        #endregion


        #region public void EditShareSkill()

        public void EditShareSkill()
        {
            // Referencing to an excel file and sheet name
            GlobalDefinitions.ExcelLib.PopulateInCollection(Bace.ExcelPath, "ShareSkill");

            try
            {
                // Goal is to edit: Category, title, description, Service type, Skill trade, Active
                manageListingsLink.Click();

                // Wait for the page to load
                GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("(//i[@class='outline write icon'])[1]"), 4);

                ManageListings manageLsObj = new ManageListings();
                manageLsObj.edit.Click();

                // Wait for the page to load
                Thread.Sleep(1000);

                Title.Clear();
                Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Title"));
                Thread.Sleep(1000);
                Description.Clear();
                Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Description"));
                Thread.Sleep(1000);
                CategoryDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Category"));
                Thread.Sleep(1000);
                Save.Click();

                // Wait for Manage listings page to load 
                Thread.Sleep(4000);
            }
            catch (Exception e) 
            {
                Console.WriteLine(e);
            }
        }

        #endregion


        public static string ExtractTimeInfo(string timeToExtract, string extractWhat)
        {
            string[] _eTime = timeToExtract.Split(' ');
            string[] eTime = _eTime[1].Split(':');
            string returnValue;

            if (extractWhat == "hh")
            {
                returnValue = eTime[0];
            }
            else if (extractWhat == "mm")
            {
                returnValue = eTime[1];
            }
            else if (extractWhat == "ampm")
            {
                returnValue = timeToExtract.Substring(eTime.Length - 2);
            }
            else
            {
                returnValue = "00";
            }

            return returnValue;
        }
    }
}