<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Master Details Demo using ASP.net MVC Awesome Grid and PopupForm
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Master Detail Demo using Grid and PopupForm</h2>
    <button type="button" class="awe-btn" onclick="<%:Url.Awe().PopupFormAction().Url("Create").Success("refreshGridAndReorder").Height(500) %>">Create</button>
    
     <%
        // these will be used for the grid actions
        var deleteFormat =
        string.Format("<form action='{0}' class='deleteForm'><button class='awe-btn' type='submit'><span class='ico-del'></span></button></form>",
        Url.Action("Delete", new { Id = ".Id" }));

        var editFormat = string.Format("<button type='button' class='awe-btn' onclick=\"{0}\"><span class='ico-edit'></span></button>",
            Url.Awe().PopupFormAction()
                .Height(500)
                .Url(Url.Action("Edit", new { Id = ".Id" }))
                .Success("refreshGrid"));
    %>

    <%:Html.Awe().Grid("RestaurantGrid")
                .Height(350)
                .Url(Url.Action("RestaurantGridGetItems"))
                .Groupable(false)
                .Columns(
                new Column{ Name ="Id", Width = 100 },
                new Column{ Name = "Name" },
                new Column{ClientFormat = editFormat, Width = 50},
                new Column{ClientFormat = deleteFormat, Width = 50 }) %>
    
    <%--this will make the forms with class 'deleteForm' to be confirmed, submitted via ajax, 
        and the result will be sent to the refreshGrid js function--%>
    <%:Html.Awe().Form().FormClass("deleteForm").Confirm(true).Success("refreshGrid") %>

    <script type="text/javascript">
        function refreshGrid() {
            $('#RestaurantGrid').data('api').load({});
        }
        
        function refreshGridAndReorder() {
            $('#RestaurantGrid').data('api').load({ sort: [{ Prop: "Id", Sort: 2 }], oparams:{ page:1 } });
        }
    </script>

</asp:Content>
