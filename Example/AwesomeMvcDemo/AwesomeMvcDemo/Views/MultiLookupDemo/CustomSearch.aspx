<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<MultiLookupDemoCfgInput>"
    MasterPageFile="~/Views/Shared/Site.Master" %>
<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">
    ASP.net MVC Awesome MultiLookup Custom Search Demo</asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    <h3>
        MultiLookup Custom Search</h3>
        <%--<%:Html.Action("SearchForm","MealsCustomSearchMultiLookup") %>--%>
        <div class="efield">
            <div class="elabel">
                Meals:</div>
            <div class="einput">
                <%--begin--%>
<%:Html.Awe().MultiLookup("MealsCustomSearch").CustomSearch(true) %>
<%--end--%>
            </div>
        </div>
        <br/>
Custom search is achieved by setting <code>.CustomSearch(true)</code> and adding a <code>SearchForm</code> action in the Lookup's controller which will render the custom search view
<pre><%:Html.Source("MultiLookupDemo/CustomSearch.aspx") %></pre>
<pre><%:Html.Csource("MealsCustomSearchMultiLookupController.cs")%></pre>
</asp:Content>
