<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" MasterPageFile="~/Views/Shared/Site.Master" %>
<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">Grid mantain selection demo - ASP.net MVC Awesome Helpers</asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    <h2>Grid mantain selection after reaload</h2>
    In this demo the selected items are being reselected after grid reload, providing that after reload the grid still contains the previously selected items.<br/>
    To try it select a few items and after click on the grid refresh button or on the current page.
    <%--begin--%>
    <%:Html.Awe().Grid("MealsGrid")
                 .Url(Url.Action("MealsGrid"))
                 .Selectable(SelectionType.Multicheck)
                 .Columns(new Column{ Name = "Name"})
                 %>
    
    <script>
        $(function () {
            var lastSelectedIds;
            $('#MealsGrid').on('aweselect', function () {
                lastSelectedIds = $.map($(this).data('api').getSelection(), function (val) { return val.Id; });
            });

            $('#MealsGrid').on('aweload', function () {
                if (lastSelectedIds) {
                    $(this).find('.awe-row').each(function (i, row) {
                        if ($.inArray($(row).data('model').Id, lastSelectedIds) > -1) {
                            $(row).addClass('awe-selected');
                        }
                    }).trigger('aweselect');
                }
            });
        });
    </script><%--end--%>
    <pre><%:Html.Source("GridMantainSelectionDemo/Index.aspx") %></pre>
</asp:Content>