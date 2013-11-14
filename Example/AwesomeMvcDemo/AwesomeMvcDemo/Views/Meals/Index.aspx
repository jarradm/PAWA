<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage"  MasterPageFile="~/Views/Shared/Site.Master" %>
<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">
    ASP.net MVC Awesome AjaxList CRUD Demo - Meals list + search, order by
</asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    <h3>AjaxList CRUD and Search Demo - Meals list</h3>
<script type="text/javascript">
    function create(o) {
        $('#MealsTable').parent().find('tbody').prepend(o.Content);
    }
    function edit(o) {
        $('#meal' + o.Id).fadeOut(300, function () { $(this).after(o.Content).remove(); });
    }
    function del(o) {
        $('#meal' + o.Id).fadeOut(300, function () { $(this).remove(); });
    }
</script>
    <fieldset style="min-height: 70px;"><legend>Search</legend>
        <div class="elabel2">
            Name:</div>
        <div class="einput">
            <%:Html.Awe().TextBox("txtSearch").Placeholder("search...") %>
        </div>
        <div class="elabel2">
            Categories:</div>
        <div class="einput">
            <%:Html.Awe().MultiLookup("Categories").ClearButton(true).Height(500)%>
        </div>
        <button type="button" class="awe-btn">search</button>
        <div style="float:right;">
        <div class="elabel2">
            Order by:</div>
        <div class="einput">
            <select id="orderby">
                <option>Default</option>
                <option>Name</option>
                <option>Category</option>
            </select></div>
            </div>
    </fieldset>
    <button type="button" onclick="<%:Url.Awe().PopupFormAction().Url(Url.Action("Create"))
    .Title("create a new meal")
    .Success("create")
    .Name("cp")%>" class="awe-btn">Create</button>    
    <br />
    <br />

    <%:Html.Awe().Form().FormClass("confirm").Confirm(true).Success("del") %>

    <%:Html.Awe().AjaxList("MealsTable")
    .TableLayout(true)
    .Parent("Categories","categories")
    .Parent("txtSearch","name")
    .Parent("orderby", "orderby")
    %>
    <br/>
    <%:Html.ActionLink("see dinners demo","index","Dinners") %>
</asp:Content>
