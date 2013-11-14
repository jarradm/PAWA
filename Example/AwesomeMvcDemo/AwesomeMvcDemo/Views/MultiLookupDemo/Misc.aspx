<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<AwesomeMvcDemo.ViewModels.MultiLookupDemoInput>"
    MasterPageFile="~/Views/Shared/Site.Master" %>
    <%@ Import Namespace="AwesomeMvcDemo.Models" %>
<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">
    MultiLookup Demo</asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    <h3>
        MultiLookup with custom Items Layout
    </h3>
    <div class="efield">
        <div class="elabel">
            Meals:</div>
        <div class="einput">
            <%:Html.Awe().MultiLookupFor(o => o.MealsCustomItem)
                          .Fullscreen(true)
                          .HighlightChange(true) %>
        </div>
    </div>
    <h3>
        MultiLookup with Table Layout</h3>
    <div class="efield">
        <div class="elabel">
            Meals Table Layout:</div>
        <div class="einput">
            <%:Html.Awe().MultiLookupFor(o => o.MealsTableLayout)
                          .TableLayout(true)
                          .Fullscreen(true) %>
        </div>
    </div>
    <h3>
        MultiLookup bound to many parents</h3>
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
            Child Meals:</div>
        <div class="einput">
            <%:Html.Awe().MultiLookupFor(o => o.ChildOfMany)
                          .Parent(o => o.CategoriesData,"categories")
                          .Parent(o => o.Category, "categories")
                          .Controller<MealsCustomSearchMultiLookupController>()
                          .Fullscreen(true)
            %>
        </div>
    </div>
    the search of "child meals" will return results only from the categories of the
    parents
    <h3>
        Setting predefined parameters</h3>
    <%
        var category1 = Db.Categories[0];
        var category2 = Db.Categories[1];
        var category3 = Db.Categories[2];
    %>
    <div class="efield">
        <div class="elabel">
            Meals1 (categories =
            <%:category3.Name %>):</div>
        <div class="einput">
            <%:Html.Awe().MultiLookupFor(o => o.Meals1)
                          .Parameter("categories", category3.Id)
                          .Controller<MealsCustomSearchMultiLookupController>()
                          .Fullscreen(true)%>
        </div>
    </div>
    <div class="efield">
        <div class="elabel">
            Meals1 (categories =
            <%:category1.Name %>,
            <%:category2.Name %>):</div>
        <div class="einput">
            <%:Html.Awe().MultiLookupFor(o => o.Meals2)
                          .Parameter("categories",new[]{category1.Id})
                          .Controller<MealsCustomSearchMultiLookupController>()
                          .Fullscreen(true)
                          .ParameterFunc("giveParams")
            %>
        </div>
    </div>
        <script>
            function giveParams() {
                return { categories: <%:category2.Id%> };
        }
    </script>
</asp:Content>
