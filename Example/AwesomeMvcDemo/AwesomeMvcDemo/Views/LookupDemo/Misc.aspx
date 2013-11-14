<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<AwesomeMvcDemo.ViewModels.LookupDemoInput>"
    MasterPageFile="~/Views/Shared/Site.Master" %>

<%@ Import Namespace="AwesomeMvcDemo.Models" %>
<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">
    Lookup Demo
</asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    The Search action of the LookupController returns json of AjaxListResult, so doing
    Custom Item Template and Table Layout is exactly the same as for the AjaxList
  <h4>
        Lookup with Custom Item template</h4>
    <div class="efield">
        <div class="elabel">
            Meal:</div>
        <div class="einput">
            <%:Html.Awe().LookupFor(o => o.MealCustomItem).Fullscreen(true) %>
        </div>
    </div>
    <h4>
        Lookup with Table Layout</h4>
    <div class="efield">
        <div class="elabel">
            Meal table:</div>
        <div class="einput">
            <%:Html.Awe().LookupFor(o => o.MealTableLayout).Fullscreen(true).TableLayout(true) %>
        </div>
    </div>
    <br />
    Binding to parents and setting predefined parameters is done exactly as for
    the AjaxDropdown using .Parent() and .Parameter(), values are passed to both GetItem and Search actions
    <h4>
        Lookup bound to many parents</h4>
    <div class="efield">
        <div class="elabel">
            Parent Categories:</div>
        <div class="einput">
            <%:Html.Awe().MultiLookupFor(o => o.CategoriesData)
                .Controller<CategoriesMultiLookupController>()
                .ClearButton(true)%>
        </div>
    </div>
    <div class="efield">
        <div class="elabel">
            Parent Category:</div>
        <div class="einput">
            <%:Html.Awe().AjaxDropdownFor(o => o.Category) %>
        </div>
    </div>
    <div class="efield">
        <div class="elabel">
            Child Meal:</div>
        <div class="einput">
            <%:Html.Awe().LookupFor(o => o.ChildOfMany)
                .Parent(o => o.CategoriesData,"categories")
                .Parent(o => o.Category, "categories")
                .Controller<MealCustomSearchLookupController>()
            %>
        </div>
    </div>
    <h4>
        Setting predefinded parameters</h4>
        <%
          var cat0 = Db.Categories[0];
          var cat1 = Db.Categories[1];
    %>
    <div class="efield">
        <div class="elabel">
            Meal1 (categories = <%:cat1.Name %>):</div>
        <div class="einput">
            <%:Html.Awe().LookupFor(o => o.Meal1)
                .Parameter("categories", cat1.Id)
                .Controller<MealCustomSearchLookupController>()
            %>
        </div>
    </div>
    
    <div class="efield">
        <div class="elabel">
            Meal1 (categories = {<%:cat0.Name %>,<%:cat1.Name %>}):</div>
        <div class="einput">
            <%:Html.Awe().LookupFor(o => o.Meal2)
                .Parameter("categories",new []{cat0.Id})
                .Controller<MealCustomSearchLookupController>()
                .ParameterFunc("giveParams")
            %>
        </div>
    </div>
    <script>
        function giveParams() {
            return { categories: <%:cat1.Id%> };
        }
    </script>
</asp:Content>
