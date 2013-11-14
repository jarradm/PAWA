<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage"  MasterPageFile="~/Views/Shared/Site.Master" %>

<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">
</asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
<script type="text/javascript">
    function create(o) {
        $('#MealsTable').parent().find('tbody').prepend(o.Content);
    }
    function edit(o) {
        $('#row' + o.Id).fadeOut(300, function () { $(this).after(o.Content).remove(); });
    }
    function del(o) {
        $('#row' + o.Id).fadeOut(300, function () { $(this).remove(); });
    }
</script>
    <fieldset style="min-height: 70px;"><legend>Search</legend>    
        <div class="elabel2">
            Name:</div>
        <div class="einput">
            <input type="text" name="search" id="search" />
        </div>
        <div class="elabel2">
            Categories:</div>
        <div class="einput">
            <%:Html.Awe().MultiLookup("Categories").ClearButton(true).Height(500)%>
        </div>

        
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
    <button onclick="<%:Url.Awe().PopupFormAction().Url(Url.Action("Create"))
    .Title("createa new meal")
    .success("create")
    .Name("cp")%>" class="awe-btn">Create</button>    
    <br />
    <br />

    <%:Html.Awe().Confirm().Success("del") %>

    <%:Html.Awe().AjaxList("MealsTable")
    .TableLayout(true)
    .Parent("Categories","categories")
    .Parent("search","name")
    .Parent("orderby", "orderby")
    %>
</asp:Content>
