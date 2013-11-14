<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<System.Collections.Generic.IEnumerable<AwesomeMvcDemo.Models.Meal>>"
    MasterPageFile="~/Views/Shared/Site.Master" %>
<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">
    Awesome pager demo
</asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    <h3>Pager</h3>
    
    It will generate a pager with buttons that will redirect to the specified url by adding the page parameter in the query string
     
    <br/>
    <br/>
    <table style="width: 300px;">
        <tr>
            <td style="width: 150px;">
                Name
            </td>
            <td>
                Category
            </td>
        </tr>
        <% foreach (var o in Model)
           {%>
            <tr>
                <td>
                    <%=o.Name %>
                </td>
                <td>
                    <%=o.Category != null ? o.Category.Name : "" %>
                </td>
            </tr>
        <%}%>
    </table>

    <br/>
    <%--begin--%>
    <%:Html.Awe().Pager()
           .Url(Url.Action("Index")) // url to go to 
           .Count((int) ViewData["count"]) // page count
           .Page((int) ViewData["page"]) /* current page*/
    %>  
    <%--end--%>
    <br/>
    view:
    <pre><%:Html.Source("PagerDemo/Index.aspx") %></pre>
    <br/>
    controller:
    <pre><%:Html.Csource("PagerDemoController.cs") %></pre>
</asp:Content>
