<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<AwesomeMvcDemo.ViewModels.AjaxDropdownDemoInput>"
    MasterPageFile="~/Views/Shared/Site.Master" %>

<%@ Import Namespace="AwesomeMvcDemo.Models" %>
<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">
    AjaxRadioList Demo  
</asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    <h3>AjaxRadioList</h3>
    <div class="expl">AjaxRadioList works like the AjaxDropdown, you could use the same url for both </div><br/>
    <%--begin--%>
    Category: <%:Html.Awe().AjaxRadioListFor(o => o.Category) %><%--end--%>
    <pre><%:Html.Source("AjaxRadioListDemo/Index.aspx") %></pre>
    <pre><%:Html.Csource("CategoryAjaxRadioListController.cs") %></pre>
    <h3>
        Bound to parent</h3>
    Parent Category:
    <%:Html.Awe().AjaxRadioListFor(o => o.ParentCategory)
                    .Controller<CategoryAjaxDropdownController>() %>
    Child Meal:
    <%:Html.Awe().AjaxRadioListFor(o => o.ChildMeal)
                    .Parent(o => o.ParentCategory)
                    .Controller<MealAjaxDropdownController>()%>
    <h3>
        Bound to many parents</h3>
    <div class="ib">
        <div class="elabel">
            Parent Categories (MultiLookup):</div>
        <div class="einput">
            <%:Html.Awe().MultiLookupFor(o => o.CategoriesData)
                 .Controller<CategoriesMultiLookupController>()
                 .ClearButton(true)%>
        </div>
    </div>
    <div class="ib">
        <div class="elabel">
            and Parent Category:</div>
        <div class="einput">
            <%:Html.Awe().AjaxRadioListFor(o => o.CategoryData)
                 .Controller<CategoryAjaxDropdownController>() %>
        </div>
    </div>
    <div class="ib">
        <div class="elabel">
            Child Meal:</div>
        <div class="einput">
            <%:Html.Awe().AjaxRadioListFor(o => o.ChildOfManyMeal)
                 .Controller<MealOfManyController>()
                 .Parent(o => o.CategoriesData)
                 .Parent(o => o.CategoryData)%>
        </div>
    </div>
    <h3>
        Using predefined parameters</h3>
    <%
        var category1 = Db.Categories[0];
        var category2 = Db.Categories[1];
        var category3 = Db.Categories[2];
    %>
    <div class="ib">
        <div class="elabel">Meal1 (parent = <%:category1.Name %>):</div>
    <%:Html.Awe().AjaxRadioListFor(o => o.Meal1)
                            .Parameter("parent", category1.Id)
                            .Controller<MealAjaxDropdownController>()%>
    </div>
    <div class="ib">
        <div class="elabel">Meal2 (parent = <%:category2.Name %>):</div>
    <%:Html.Awe().AjaxRadioListFor(o => o.Meal2)
                            .Parameter("parent", category2.Id)
                            .Controller<MealAjaxDropdownController>()%>
    </div>
    <div class="ib">
        <div class="elabel">Meal3 (parent = <%:category3.Name %>):</div>
    <%:Html.Awe().AjaxRadioListFor(o => o.Meal3)
                            .Parameter("parent", category3.Id)
                            .Controller<MealAjaxDropdownController>()%>
    </div>
    
   
</asp:Content>
