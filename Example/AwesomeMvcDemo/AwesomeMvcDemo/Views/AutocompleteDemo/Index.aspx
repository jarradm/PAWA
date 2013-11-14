<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<AwesomeMvcDemo.ViewModels.AutocompleteDemoInput>"
    MasterPageFile="~/Views/Shared/Site.Master" %>

<%@ Import Namespace="AwesomeMvcDemo.Models" %>
<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">
    Autocomplete Demos</asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    <h3>
        Autocomplete</h3>
        <%--begin--%>
    Meal:<%=Html.Awe().AutocompleteFor(o => o.Meal).Placeholder("try Ma") %><%--end--%>
    <div class="code">
        <pre><%:Html.Source("AutocompleteDemo/Index.aspx") %></pre>
        <pre><%:Html.Csource("MealAutocompleteController.cs")%></pre>
        <div class="expl">
        <p>
            Autocomplete needs a controller or url to get data from, by default convention it
            will look for a controller with the same name as it + "Autocomplete"<br />
        </p>
        <ul>
            <li><code>action GetItems</code> - gets the items for the autocomplete, it
                will receive a <code>v</code> parameter which represents the value of the textbox</li>
        </ul>
    </div>
    </div>
    <h3>
        Autocomplete bound to one parent, storing key of the selected value in a hidden field using .PropId</h3>
    <%--begin1--%>
            Parent Category:
            <%=Html.Awe().AutocompleteFor(o => o.ParentCategory)
                       .Placeholder("try Le")
                       .PropId(o => o.ParentCategoryId)
                       .Controller<CategoryAutocompleteController>()%>
            <%=Html.HiddenFor(o => o.ParentCategoryId) %>
         
            Child Meal:
            <%=Html.Awe().AutocompleteFor(o =>o.ChildMeal)
                       .Parent(o => o.ParentCategoryId)
                       .Controller<MealChildAutocompleteController>()%>
    <%--end1--%>
    <br/>
    when the user selects a value from the autocomplete lists the PropId will be assigned the key of the selected value, but if the user will type something into the autocomlete after that the propId value will clear
    <div class="code">
        <pre>
<%:Html.Source("AutocompleteDemo/Index.aspx", 1) %>
</pre>
        </div>
    <h3>
        bound to many parents</h3>
    <div class="efield">
        <div class="elabel">
            Parent Categories (MultiLookup):</div>
        <div class="einput">
            <%:Html.Awe().MultiLookupFor(o => o.CategoriesData)
                       .Controller<CategoriesMultiLookupController>()
                       .ClearButton(true)%>
        </div>
        <%=Html.ValidationMessageFor(o=>o.CategoriesData) %>
    </div>
    <div class="efield">
        <div class="elabel">
            and Parent Category:</div>
        <div class="einput">
            <%:Html.Awe().AjaxRadioListFor(o => o.CategoryData)
                       .Controller<CategoryAjaxDropdownController>() %>
        </div>
        <%=Html.ValidationMessageFor(o=>o.CategoriesData) %>
    </div>
    <div class="efield">
        <div class="elabel">
            Child Meal:</div>
        <div class="einput">
            <%:Html.Awe().AutocompleteFor(o => o.ChildOfManyMeal)
                       .Controller<MealChildAutocompleteController>()
                       .Parent(o => o.CategoriesData)
                       .Parent(o => o.CategoryData)%>
        </div>
        <%=Html.ValidationMessageFor(o=>o.ChildOfManyMeal) %>
    </div>
    
    <h3>Numeric autocomplete</h3>
    <div class="efield">
        <div class="elabel">Prime number:</div>
        <div class="einput"><%:Html.Awe().AutocompleteFor(o => o.PrimeNumber)
                                            .Url(Url.Action("GetItems","PrimesAutocomplete"))
                                            .Numeric(true)
                                            .Placeholder("type a prime number") %></div>
    </div>

    <%
        var cat1 = Db.Categories[0];
        var cat2 = Db.Categories[1];
        var cat3 = Db.Categories[2];
    %>
    <h3>
        Using predefined parameters</h3>
    <div class="efield">
        <div class="elabel">
            Meal1 (parent =
            <%=cat1.Name %>):</div>
        <div class="einput">
            <%:Html.Awe().AutocompleteFor(o => o.Meal1)
                       .Controller<MealChildAutocompleteController>()
                       .Parameter("parent", cat1.Id)%>
        </div>
        <%=Html.ValidationMessageFor(o => o.Meal1)%>
    </div>
    <div class="efield">
        <div class="elabel">
            Meal2 (parent =
            <%=string.Join(", ",cat1.Name,cat2.Name,cat3.Name) %>):</div>
        <div class="einput">
            <%:Html.Awe().AutocompleteFor(o => o.Meal2)
                       .Controller<MealChildAutocompleteController>()
                       .Parameter("parent", new[]{cat1.Id,cat2.Id,cat3.Id})
            %>
        </div>
        <%=Html.ValidationMessageFor(o => o.Meal2)%>
    </div>
</asp:Content>
