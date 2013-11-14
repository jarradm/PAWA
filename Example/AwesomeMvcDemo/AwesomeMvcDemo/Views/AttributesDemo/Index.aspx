<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<AwesomeMvcDemo.ViewModels.AttributesDemoInput>"
    MasterPageFile="~/Views/Shared/Site.Master" %>

<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">
</asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    <h3>Attributes demo</h3>
    <p>this view uses only EditorFor helpers, and parameters for the helpers are set using
        attributes</p>
    <% using (Html.BeginForm())
       {%>
       <div class="efield">
        <div class="elabel">
            Category:</div>
        <div class="einput">
            <%=Html.EditorFor(o => o.Category1)%>
        </div>
        <%=Html.ValidationMessageFor(o => o.Category1)%>
    </div>
    <div class="efield">
        <div class="elabel">
            Parent Category:</div>
        <div class="einput">
            <%=Html.EditorFor(o => o.ParentCategory)%>
        </div>
        <%=Html.ValidationMessageFor(o => o.ParentCategory)%>
    </div>
    <div class="efield">
        <div class="elabel">
            Child Meal:</div>
        <div class="einput">
            <%=Html.EditorFor(o => o.ChildMeal)%>
        </div>
        <%=Html.ValidationMessageFor(o => o.ChildMeal)%>
    </div>
    <div class="efield">
        <div class="elabel">
            Meal1:</div>
        <div class="einput">
            <%=Html.EditorFor(o => o.Meal1)%>
        </div>
        <%=Html.ValidationMessageFor(o => o.Meal1)%>
    </div>
    <div class="efield">
        <div class="elabel">
            Meal custom search:</div>
        <div class="einput">
            <%=Html.EditorFor(o => o.MealCustomSearch)%>
        </div>
        <%=Html.ValidationMessageFor(o => o.MealCustomSearch)%>
    </div>
    
    <div class="efield">
        <div class="elabel">
            Some meals:</div>
        <div class="einput">
            <%=Html.EditorFor(o => o.SomeMeals)%>
        </div>
        <%=Html.ValidationMessageFor(o => o.SomeMeals)%>
    </div>
    <div class="efield">
        <div class="elabel">
            Some categories:</div>
        <div class="einput">
            <%=Html.EditorFor(o => o.SomeCategories)%>
        </div>
        <%=Html.ValidationMessageFor(o => o.SomeCategories)%>
    </div>

    <%:Html.HiddenFor(o => o.MealId) %>
    <div class="efield">
        <div class="elabel">
            Meal Autocomplete:</div>
        <div class="einput">
            <%=Html.EditorFor(o => o.MealAuto)%>
        </div>
        <%=Html.ValidationMessageFor(o => o.MealAuto)%>
    </div>
    <div class="efield">
        <div class="elabel">
            Date:</div>
        <div class="einput">
            <%=Html.EditorFor(o => o.Date)%>
        </div>
        <%=Html.ValidationMessageFor(o => o.Date)%>
    </div>
    <input type="submit" value="submit" class="awe-btn" />
    <%} %>
    <pre>
    <%:Html.Csourcem("AttributesDemoInput.cs") %>
    </pre>
</asp:Content>
