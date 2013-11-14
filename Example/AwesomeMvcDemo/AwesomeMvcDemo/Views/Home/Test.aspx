<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" MasterPageFile="~/Views/Shared/Site.Master" %>
<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent"></asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
<h2>Error handling</h2>

<%:Html.Awe().MultiLookup("MealsError")%><br/>
<%:Html.Awe().Lookup("MealError").Prefix("Lookup")%><br/>
<%:Html.Awe().AjaxDropdown("MealError")%><br/>
<%:Html.Awe().AjaxRadioList("MealError").Prefix("radio") %><br/>
<%:Html.Awe().AjaxCheckboxList("CategoriesError") %><br/>
<%:Html.Awe().Autocomplete("MealError").Prefix("autocomplete") %><br/>
<%:Html.Awe().Grid("LunchError").Columns(new Column{ Name = "Name"}) %>
<%:Html.Awe().AjaxList("MealsError").Prefix("ajaxlist") %>
<%:Html.Awe().PopupActionLink().Url(Url.Action("ShowPopup","PopupError")).LinkText("open popup") %>
<%:Html.Awe().PopupActionLink().Url(Url.Action("ShowPopupForm","PopupError")).LinkText("open popupform") %>
</asp:Content>
