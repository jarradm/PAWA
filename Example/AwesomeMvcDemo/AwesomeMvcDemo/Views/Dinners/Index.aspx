<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<object>" MasterPageFile="~/Views/Shared/Site.Master" %>

<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">
    Dinners</asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    <script type="text/javascript">
        function create(o) {
            $('#Dinners').parent().find('tbody').prepend(o.Content);
        }
        function edit(o) {
            $('#dinner' + o.Id).fadeOut(300, function () { $(this).after(o.Content).remove(); });
        }
        function del(o) {
            $('#dinner' + o.Id).fadeOut(300, function () { $(this).remove(); });
        }
    </script>
    <h3>AjaxList crud demo - dinners</h3>
    <%:Html.Awe().TextBox("sname").Placeholder("search...").HtmlAttributes(new{style="float:right;"}) %>
    <button type="button" class="awe-btn" onclick="<%:Url.Awe().PopupFormAction().Url(Url.Action("create")).Success("create").Title("create dinner") %>">
        HIDING</button>
    

    <%:Html.Awe().AjaxList("Dinners").TableLayout(true).Parent("sname", "search") %>

    <%:Html.Awe()
            .Form()
            .FormClass("confirm")
            .Confirm(true)
            .Success("del") %>
</asp:Content>
