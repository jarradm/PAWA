<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" MasterPageFile="~/Views/Shared/Site.Master" %>
<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">Export grid to Excel using NPOI - ASP.net MVC Awesome Demo</asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    <h2>Export grid to excel demo</h2>
    export the content of a grid to excel, to create an excel file we're using the <a href="http://npoi.codeplex.com">NPOI library</a>
    <br/>
    <br/>
    <%--begin--%>
    <%:Html.Awe().Grid("LunchGrid")
                    .Url(Url.Action("GetItems"))
                    .Persistence(Persistence.Session)
                    .Height(350)
                    .Columns(
                    new Column{ Name = "Id", Width = 80},
                    new Column{ Name = "Person"},
                    new Column{ Name = "Food"},
                    new Column{ Name = "Price"},
                    new Column{ Name = "Date"},
                    new Column{ Name = "Location"}) %>

    
    <button id="exportGrid" type="button" class="awe-btn">Export grid to excel</button> 
    <form id="exportGridForm" method="post" action="<%:Url.Action("ExportGridToExcel")%>">
    </form>

    <form method="post" action="<%:Url.Action("ExportAllToExcel")%>">
        <input id="export" type="submit" class="awe-btn" value="Export all records to excel" />
    </form>

    <script>
        $(function () {
            $('#exportGrid').click(function () {
                $('#exportGridForm').empty();
                
                var req = $('#LunchGrid').data('api').getRequest();
                
                for (var i = 0; i < req.length; i++) {
                    $('#exportGridForm').append("<input type='hidden' name='" + req[i].name + "' value='" + req[i].value + "'/>");
                }
                $('#exportGridForm').submit();
            });
        });
    </script><%--end--%>
    <pre><%:Html.Source("GridExportToExcelDemo/Index.aspx") %></pre>
    <pre><%:Html.Csource("GridExportToExcelDemoController.cs") %></pre>

</asp:Content>
