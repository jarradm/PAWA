<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>"
    MasterPageFile="~/Views/Shared/Site.Master" %>

<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">
</asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    
    <%:Html.Awe().AjaxDropdown("W1") %>
    <%:Html.Awe().AjaxDropdown("W2") %>
    <%:Html.Awe().AjaxDropdown("W3").Parent("W1","w1").Parent("W2","w2") %>
    <br />
    <br />
    <%:Html.Awe().AjaxCheckboxList("WCategories").Parent("W1", "w1").Parent("W2", "w2") %>
    
    <br />
    <br />
    <%:Html.Awe().AjaxRadioList("WA3").Parent("W1", "w1").Parent("W2", "w2").Controller("W3AjaxDropdown") %>
    
    <br />
    <br />
    <%:Html.Awe().AjaxList("Meals").Parent("W1", "w1").Parent("W2", "w2") %>
    
    <br />
    <br />
    <%:Html.Awe().Grid("Lunch").Columns(new Column{Name = "Person"}).Parent("W1", "w1").Parent("W2", "w2") %>
</asp:Content>
