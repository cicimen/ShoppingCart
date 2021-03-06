﻿using System;
using System.Text;
using System.Web.Mvc;
using ShoppingCart.UI.Models;
using System.Web;
using System.Xml.Linq;
using System.Xml;

using System.Collections.Generic;
using System.Linq;
using ShoppingCart.Domain.Concrete;
using ShoppingCart.Domain.Entities;

namespace ShoppingCart.UI.Helpers
{
    public static class HtmlHelpers
    {
        #region Htmlhelpers
        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a"); // Construct an <a> tag
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();

                if (i == pagingInfo.CurrentPage)
                    tag.AddCssClass("selected");
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }

        public static string GetLanguageCode(this HtmlHelper html)
        {
            HttpContext context = HttpContext.Current;
            if (context.Session["Language"] == null || context.Session["Language"] as string == "tr")
            {
                return "tr";
            }
            else 
            {
                return "en";
            }
        }

        public static MvcHtmlString GetProducAttributeAndValueFromXml(this HtmlHelper html, string xml)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            StringBuilder sb = new StringBuilder();
            HttpContext context = HttpContext.Current;
            string languageCode = "";
            if (context.Session["Language"] == null || context.Session["Language"] as string == "tr")
            {
                languageCode = "tr";
            }
            else
            {
                languageCode = "en";
            }
            ApplicationDbContext dbContext = new ApplicationDbContext();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xml);
            XmlNodeList productAttributes = xmlDocument.SelectNodes("/Attributes/ProductAttribute");
            foreach (XmlNode item in productAttributes)
            {
                 int productAttributeID = int.Parse(item.Attributes["ID"].Value);
                 int productAttributeValueID = int.Parse(item.FirstChild.FirstChild.InnerText);
                 result.Add(dbContext.ProductAttributeTranslations.FirstOrDefault(x => x.Language.LanguageCode == languageCode && x.ProductAttributeID == productAttributeID).ProductAttributeName
                     , dbContext.ProductAttributeValueTranslations.FirstOrDefault(x => x.Language.LanguageCode == languageCode && x.ProductAttributeValueID == productAttributeValueID).ProductAttributeValueName);
            }
            sb.AppendLine("<span>");
            foreach (var item in result)
            {
                sb.AppendLine("("+item.Key + ":" + item.Value +")");
            }
            sb.AppendLine("</span>");
            return new MvcHtmlString(sb.ToString());
            
        }

        public static MvcHtmlString GetCategoryBreadCrumb(this HtmlHelper html, string categoryLinkText, Func<string,string> categoryURL)
        { 
            HttpContext context = HttpContext.Current;
            EFCategoryRepository categoryRepository = new EFCategoryRepository();
            Category currentCategory = categoryRepository.Categories.SingleOrDefault(x=>x.CategoryURLText == categoryLinkText);
            if(currentCategory == null)
            {
                return null;
            }
            else
            {
                Stack<Category> parentCategoryList = new Stack<Category>();
                
                int i = 0;
                while(i<5)
                {
                    if(currentCategory == null)
                    {
                        break;
                    }
                    else
                    {
                        parentCategoryList.Push(currentCategory);
                        currentCategory = currentCategory.Parent;
                    }
                    i++;
                }
                StringBuilder sb= new StringBuilder();
                TagBuilder olTag = new TagBuilder("ol");
                olTag.AddCssClass("breadcrumb");

                foreach (var category in parentCategoryList)
	            {
		            TagBuilder liTag = new TagBuilder("li");
                    TagBuilder aTag = new TagBuilder("a");
                    aTag.MergeAttribute("href",categoryURL(category.CategoryURLText));
                    aTag.InnerHtml = category.CategoryTranslations.SingleOrDefault(x=> x.Language.LanguageCode == CodeHelpers.GetLanguageCode()).CategoryName;
                    liTag.InnerHtml = aTag.ToString();
                    sb.Append(liTag.ToString());
	            }
                olTag.InnerHtml =sb.ToString();
                return MvcHtmlString.Create(olTag.ToString());
			}
         }
     
    }

        #endregion
       
    

    public static class CodeHelpers
    {
        public static string GetLanguageCode()
        {
            HttpContext context = HttpContext.Current;
            if (context.Session["Language"] == null || context.Session["Language"] as string == "tr")
            {
                return "tr";
            }
            else
            {
                return "en";
            }
        }

        public static string CreateXmlForAttribute(int productAttributeValueID)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            ProductAttributeValue productAttributeValue =  context.ProductAttributeValues.Where(x => x.ProductAttributeValueID == productAttributeValueID).FirstOrDefault();
            if (productAttributeValue == null)
            {
                return null;
            }
            else
            {
                XDocument xml = new XDocument
                    (
                        new XElement("Attributes" ,
                                new XElement("ProductAttribute",
                                    new XAttribute("ID", productAttributeValue.ProductAttributeID),
                                    new XElement("ProductAttributeValue", 
                                            new XElement("Value",productAttributeValue.ProductAttributeValueID) )
                    )));
                return xml.ToString();
            }
        }
    }

}