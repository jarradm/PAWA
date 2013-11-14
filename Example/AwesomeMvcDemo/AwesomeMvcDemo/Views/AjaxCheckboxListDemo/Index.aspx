<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<AwesomeMvcDemo.ViewModels.AjaxCheckboxListDemoInput>"
    MasterPageFile="~/Views/Shared/Site.Master" %>
<%@ Import Namespace="AwesomeMvcDemo.Models" %>

<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">
    AjaxCheckBoxList Demo
</asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    <h3>AjaxCheckboxList</h3>
    <div class="expl"><p>the AjaxCheckboxList works the same as the AjaxDropdown/AjaxRadioList except in the controller receives a collection of selected values instead of just one value</p></div>
    <br/>
    <%--begin--%>
    Category: <%:Html.Awe().AjaxCheckboxListFor(o => o.Categories) %><%--end--%>
    
    <pre><%:Html.Source("AjaxCheckboxListDemo/Index.aspx") %></pre>
    <pre><%:Html.Csource("CategoriesAjaxCheckboxListController.cs") %></pre>
    
    <h3>
        Bound to parent</h3>
    <div class="ib">
        <div class="elabel">
            Parent Category:</div>
        <%:Html.Awe().AjaxDropdownFor(o => o.ParentCategory)
                            .Controller<CategoryAjaxDropdownController>()%>
    </div>
    <div class="ib">
        <div class="elabel">
            Child Meal:</div>
        <%:Html.Awe().AjaxCheckboxListFor(o => o.ChildMeals)
                            .Parent(o => o.ParentCategory)%>
    </div>
    <h3>
        Bound to many parents</h3>
    <div class="ib">
        <div class="elabel">
            Parent Categories (MultiLookup):</div>
            <%:Html.Awe().MultiLookupFor(o => o.CategoriesData)
                 .Controller<CategoriesMultiLookupController>()
                 .ClearButton(true)%>
    </div>
    <div class="ib">
        <div class="elabel">
            and Parent Category:</div>
            <%:Html.Awe().AjaxRadioListFor(o => o.CategoryData)
                 .Controller<CategoryAjaxDropdownController>() %>
    </div>
    <div class="ib">
        <div class="elabel">
            Child of Many Meal:</div>
            <%:Html.Awe().AjaxCheckboxListFor(o => o.ChildOfManyMeal)
                 .Controller<MealOfManyController>()
                 .Parent(o => o.CategoriesData)
                 .Parent(o => o.CategoryData)
            %>
    </div>
    <h3>
        Using predefined parameters</h3>
        <% 
            var category1 = Db.Categories[0];
            var category2 = Db.Categories[1];
            var category3 = Db.Categories[2];
            %>
    <div class="ib">
        <div class="elabel">Meals1 (categories = {<%:category1.Name %>, <%:category2.Name %>}):</div>
            <%:Html.Awe().AjaxCheckboxListFor(o => o.Meals1)
                            .Parameter("parent", new[]{category1.Id, category2.Id})
                            .Controller<MealOfManyController>()%>
    </div>
    <div class="ib">
        <div class="elabel">Meals2 (parent = <%:category3.Name %>):</div>
            <%:Html.Awe().AjaxCheckboxListFor(o => o.Meals2)
                            .Parameter("parent", category3.Id)
                            .Controller<MealOfManyController>()%>
    </div>
</asp:Content>
