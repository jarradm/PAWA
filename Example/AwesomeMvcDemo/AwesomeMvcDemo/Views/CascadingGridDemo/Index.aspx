<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" MasterPageFile="~/Views/Shared/Site.Master" %>
<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">Cacading Grid Demo - ASP.net MVC Awesome jQuery Ajax Helpers</asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    <h2>Cascading grids</h2>
    click on the rows of the first grid to select categories and watch the second grid reload
    
    <%--begin--%>
    <%:Html.Awe().Grid("CategoriesGrid")
        .Groupable(false)
        .Url(Url.Action("CategoriesGrid"))
        .Columns(new Column{Name = "Name"})
        .Selectable(SelectionType.Multicheck)%>
    <br/>
    <%:Html.Awe().Grid("MealsGrid")
        .Groupable(false)
        .Url(Url.Action("MealsGrid"))
        .Columns(new Column{Name = "Name"}) %>
    
    <script>
        $(function () {
            $('#CategoriesGrid')
                .on('aweselect aweload', function () {
                    var selectedIds = $(this).data('api').getSelection().map(function (o) { return o.Id; });
                    $("#MealsGrid").data('api').load({ params: { categories: selectedIds} });
                });
        });
    </script><%--end--%>
    <pre><%:Html.Source("CascadingGridDemo/Index.aspx") %></pre>
    <pre><%:Html.Csource("CascadingGridDemoController.cs") %></pre>
</asp:Content>
