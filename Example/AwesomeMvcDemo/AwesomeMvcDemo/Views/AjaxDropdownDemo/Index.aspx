<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<AwesomeMvcDemo.ViewModels.AjaxDropdownDemoInput>"
    MasterPageFile="~/Views/Shared/Site.Master" %>

<%@ Import Namespace="AwesomeMvcDemo.Models" %>

<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">
    AjaxDropdown Demo - ASP.net MVC Awesome AjaxDropdown / Cascading dropdown
</asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    <h3>Simple AjaxDropdown</h3>
    <%--begin--%>
    Category:<%:Html.Awe().AjaxDropdownFor(o => o.Category) %><%--end--%>
    <div class="code">
        <pre><%:Html.Source("AjaxDropdownDemo/Index.aspx") %></pre>
        <pre><%:Html.Csource("CategoryAjaxDropdownController.cs") %></pre>
        <div class="expl">
            <p>
                AjaxDropdown needs a controller or url to get data from, by default convention it
            will look for a controller with the same name as it + "AjaxDropdown"<br />
            </p>
            <ul>
                <li><code>action GetItems</code> - gets the items for the dropdown, it
                will receive a <code>v</code> parameter which represents the current value</li>
            </ul>
        </div>
    </div>
    <h3>Bound to parent</h3>
    <%--begin1--%>
    Parent Category:
    <%:Html.Awe().AjaxDropdownFor(o => o.ParentCategory)
                 .Url(Url.Action("GetItems","CategoryAjaxDropdown")) %>

    Child Meal:
    <%:Html.Awe().AjaxDropdownFor(o => o.ChildMeal)
                    .Parent(o => o.ParentCategory)
                    .Url(Url.Action("GetItems","MealAjaxDropdown")) %>
    <%--end1--%>
    <div class="code">
        <pre>
<%:Html.Source("AjaxDropdownDemo/Index.aspx",1) %>
</pre>
        <pre><%:Html.Csource("CategoryAjaxDropdownController.cs") %>
<%:Html.Csource("MealAjaxDropdownController.cs") %>
</pre>
    </div>
    <h3>Bound to many parents</h3>

    <%--beginm--%>
    <%:Html.Awe().AjaxRadioListFor(o => o.Category1).Controller<CategoryAjaxRadioListController>()%>
    +
    <%:Html.Awe().AjaxCheckboxList("Categories") %>+
    <%:Html.Awe().TextBox("txtMealName").Placeholder("where name contains") %>
    = 
    <%:Html.Awe().AjaxDropdownFor(o => o.ChildOfManyMeal)
                          .Controller<MealBoundToManyController>()
                          .Parent(o => o.Category1)
                          .Parent("Categories")
                          .Parent("txtMealName","mealName")
    %>
    =
    <%:Html.Awe().AjaxRadioList("ChildOfManyMealRadioList")
                          .Controller<MealBoundToManyController>()
                          .Parent(o => o.Category1)
                          .Parent("Categories")
                          .Parent("txtMealName","mealName")
    %>
    <%--endm--%>
    <div class="code">
        <pre><%:Html.Source("AjaxDropdownDemo/Index.aspx","m") %></pre>
        parent Category1 and "Categories" are being merged together and received by the controller as int[] parent 
    <pre><%:Html.Csource("MealBoundToManyController.cs") %></pre>
    </div>
    <h3>Using predefined parameters</h3>
    <%--beginp--%>
    <%
        var category1 = Db.Categories[0];
        var category2 = Db.Categories[1];
        var category3 = Db.Categories[2];
    %>
    <div class="efield">
        <div class="elabel">Meal (category = <%:category1.Name %>):</div>
        <div class="einput">
            <%:Html.Awe().AjaxDropdownFor(o => o.Meal1)
                         .Url(Url.Action("GetItems","MealAjaxDropdown"))
                         .Parameter("parent", category1.Id)
            %>
        </div>
    </div>
    <div class="efield">
        <div class="elabel">Meal (category = <%:category2.Name %>):</div>
        <div class="einput">
            <%:Html.Awe().AjaxDropdownFor(o => o.Meal2)
                          .Parameter("parent", category2.Id)
                          .Controller<MealAjaxDropdownController>()%>
        </div>
    </div>
    <div class="efield">
        <div class="elabel">Meal (category = <%:category3.Name %>):</div>
        <div class="einput">
            <%:Html.Awe().AjaxDropdownFor(o => o.Meal3)
                          .Parameter("parent", category3.Id)
                          .Controller<MealAjaxDropdownController>()%>
        </div>
    </div>
    <%--endp--%>
    <div class="code">
        <pre><%:Html.Source("AjaxDropdownDemo/Index.aspx","p") %></pre>
        <pre><%:Html.Csource("MealAjaxDropdownController.cs") %></pre>
        using .Parameter(name, value) additional parameters are sent to the controller
    </div>
    <h3>Events and Api</h3>
    
    call $('#id').data('api').load() to trigger load;<br/>

    <%:Html.Awe().AjaxDropdown("ApiMeal")
                    .Url(Url.Action("GetItems","ApiMealAjaxDropdown"))%>
    <br/>
<fieldset class="section">
        <legend>call api</legend>
            <textarea id="vs" cols="70" rows="7">
//click execute to load all meals that contain 'ma'

$('#ApiMeal').data('api').load({ params:{ text: 'ma' } });    

// other things you can try
// $('#ApiMeal').data('api').load({ params:{ text: 'a' } });    
// or just reload
// $('#ApiMeal').data('api').load();
            
</textarea><br/>
            <button id="bApi" class="awe-btn">Execute</button>
    </fieldset>

    <script>
        $(function () {
            $('#bApi').on('click', function () {
                eval($('#vs').val());
            });
            
            $('#ApiMeal').on('aweload', function (e, data) {
                $('#log').prepend('aweload handled, data: ' + JSON.stringify(data) + '\n\n');
            });
        });
    </script>
    <br/>
    aweload event triggered on load<br/>
    <fieldset><legend>Event log</legend>
        <textarea id="log" rows="7" style="width:100%">
logging aweload event
</textarea>
    </fieldset>
</asp:Content>
