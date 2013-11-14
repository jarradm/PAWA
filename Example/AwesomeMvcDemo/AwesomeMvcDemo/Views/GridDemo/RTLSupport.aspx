<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage" MasterPageFile="~/Views/Shared/Site.Master" %>

<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">
    ASP.net MVC Awesome Grid RTL Support demo
</asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    <h3>Grid RTL Support</h3>
    
    <p>The grid will detect if the html direction is rtl and construct itself accordingly</p>
    <%--begin--%>
    <div style="direction: rtl;">
    <%:Html.Awe().Grid("RTLGrid")
                .Url(Url.Action("GetItems","LunchGrid"))
                .Height(300)
                .Persistence(Persistence.Session)
                .Columns(
                new Column { Name = "Id", Width = 55 },
                new Column { Name = "Person" },
                new Column { Name = "Food" },
                new Column { Name = "Price", Width = 100 },
                new Column { Name = "Location" })
    %>
        </div>
    <%--end--%>

    <pre>
<%:Html.Source("GridDemo/RTLSupport.aspx") %>
</pre>
</asp:Content>
