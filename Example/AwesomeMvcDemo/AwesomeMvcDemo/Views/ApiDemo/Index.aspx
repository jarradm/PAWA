<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" MasterPageFile="~/Views/Shared/Site.Master" %>
<%@ Import Namespace="Omu.AwesomeMvc" %>
<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent"></asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    AjaxDropdown, AjaxRadioList and AjaxCheckboxList bound to AjaxDropdown<br />
    <%:Html.Awe().AjaxDropdown("Category").Url("api/CategoriesApi/GetItems") %>
    <br />
    <%:Html.Awe().AjaxDropdown("Meal").Url("api/MealsApi/GetItems").Parent("Category") %>
    <%:Html.Awe().AjaxRadioList("Meal2").Url("api/MealsApi/GetItems").Parent("Category") %>
    <%:Html.Awe().AjaxCheckboxList("Meal3").Url("api/MealsApi/GetItems").Parent("Category") %>

    <br />
    <br />
    <br />
    Search:
    <input type="text" name="search" id="txtSearch" />

    <%:Html.Awe().AjaxList("Meals").Url("api/MealsListApi/GetItems")
                .Parent("txtSearch")%>

    <br />

    <%=Html.Awe().Grid("Chefs")
                .Columns(
                    new Column{Name = "Id", Width = 55},
                    new Column{Name = "FirstName"},
                    new Column{Name = "LastName"},
                    new Column{Name = "Country.Name", ClientFormat = ".CountryName", Header = "Country"}
                )
                .Url("api/ChefGridApi/GetItems")
    %>
</asp:Content>
