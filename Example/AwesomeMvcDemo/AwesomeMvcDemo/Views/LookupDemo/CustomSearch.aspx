<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage" MasterPageFile="~/Views/Shared/Site.Master" %>
<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">
    Lookup Custom Search Demo
</asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    
    <h3>Lookup with Custom Search </h3>
        <div class="efield">
            <div class="elabel">
                Meal:</div>
            <div class="einput">
                <%--begin--%>
<%:Html.Awe().Lookup("MealCustomSearch").Fullscreen(true).CustomSearch(true) %>
<%--end--%>
            </div>
        </div>
    <br/>
    Custom search is achieved by setting <code>.CustomSearch(true)</code> and adding a <code>SearchForm</code> action
    in the Lookup's controller which will render the custom search view
    <pre><%:Html.Source("LookupDemo/CustomSearch.aspx") %></pre>
    <pre><%:Html.Csource("MealCustomSearchLookupController.cs") %></pre>
</asp:Content>
