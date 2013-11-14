<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<GridDemoCfgInput>" MasterPageFile="~/Views/Shared/Site.Master" %>
<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">
    ASP.net MVC Awesome Grid Custom Sorting And Paging Demo</asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    <h3>Grid custom querying</h3>
    The default scenario is that you give an IQueryable to the GridModelBuilder and it will sort it and page it 
    using <code>.OrderBy</code> and <code>.Skip/.Take</code>, this works ok on EntityFramework, 
    but if you're doing something like sql procedures, service calls etc. you might want to do this sorting and paging yourself.
    <br/><br/>
    Sorting rules and current page are in the <code>GridParams {SortNames[], SortDirections[], Page}</code> parameter and to tell the <code>GridModelBuilder</code> not to do any querying you have to set the <code>PageCount</code> parameter on it. 
    (grouping doesn't require any querying)
<%--begin--%>
    <%:Html.Awe().Grid("CustomQuerying")
                .Persistence(Persistence.Session)
                .Height(450)
                .Columns(new Column {Name = "Person"},
                        new Column { Name = "Food" })%>
<%--end--%>

<pre>
<%:Html.Source("GridDemo/CustomQuerying.aspx") %>
</pre>

<pre>
<%:Html.Csource("CustomQueryingGridController.cs") %>
</pre>
    
</asp:Content>
