using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMS.Models;

namespace TMS.Helpers
{
    public abstract class SubMenuItem
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public Constants.Constants.UserType AccessRole { get; set; }

        protected SubMenuItem(string name,  string title, Constants.Constants.UserType access = Constants.Constants.UserType.Guest)
        {
            Name = name;
            Title = title;
            AccessRole = access;
        }

        public abstract string ToLi(int hSize = -1);
    }

    public class SubMenuLink : SubMenuItem
    {
        public string Url { get; set; }

        public SubMenuLink(string name, string url, string title, Constants.Constants.UserType access = Constants.Constants.UserType.Guest) : base(name, title, access)
        {
            Url = url;
        }

        public override string ToLi(int hSize = -1)
        {
            var result = new TagBuilder("li");
            if (string.Equals(Name, "divider"))
            {
                result.AddCssClass("nav-divider");
            }
            else
            {
                if (hSize != -1) Name = string.Format("<h{0}>{1}</h{0}>", hSize, Name);
                result.InnerHtml = string.Format("<a href=\"{1}\" title=\"{2}\">{0}</a>", Name, Url, Title);
            }
            var loggedUser = (UserModel)System.Web.HttpContext.Current.Session["loggedUser"];
            var currAcceess = Constants.Constants.UserType.Admin;
            if (loggedUser != null) currAcceess = loggedUser.UserType;
            if (AccessRole > currAcceess) return string.Empty;
            return result.ToString();
        }
    }

    public class SubMenuButton : SubMenuItem
    {
        public string Type { get; set; }

        public SubMenuButton(string name, string type, string title, Constants.Constants.UserType access = Constants.Constants.UserType.Guest) : base(name, title, access)
        {
        }

        public override string ToLi(int hSize = -1)
        {
            var result = new TagBuilder("li");
            
            if (hSize != -1) Name = string.Format("<h{0}>{1}</h{0}>", hSize, Name);
            result.InnerHtml = string.Format("<button type=\"{2}\" title=\"{1}\">{0}</button>", Name, Title, Type);
            
            var loggedUser = (UserModel)System.Web.HttpContext.Current.Session["loggedUser"];
            var currAcceess = Constants.Constants.UserType.Admin;
            if (loggedUser != null) currAcceess = loggedUser.UserType;
            if (AccessRole > currAcceess) return string.Empty;
            return result.ToString();
        }
    }

    public class SubMenuElement
    {
        private List<SubMenuItem> _subMenu = new List<SubMenuItem>();
        private int hSize = -1;

        public SubMenuElement(int hNum = -1)
        {
            hSize = hNum;
        }

        public void AddItem(string name, string url, string title)
        {
            _subMenu.Add(new SubMenuLink(name, url, title));
        }

        public void AddDivider()
        {
            AddItem("divider", "#", "");
        }

        public void AddItem(SubMenuLink link)
        {
            _subMenu.Add(link);
        }

        public void AddButton(string name, string type, string title)
        {
            _subMenu.Add(new SubMenuButton(name, type, title));
        }

        public MvcHtmlString ToHtml()
        {
            var result = new TagBuilder("ul");

            result.AddCssClass("text-center");
            result.AddCssClass("nav-stacked");
            result.AddCssClass("nav-pills");
            result.AddCssClass("nav");
            foreach (var item in _subMenu)
            {
                result.InnerHtml += item.ToLi(hSize);
            }

            return new MvcHtmlString(result.ToString());
        }
    }
}