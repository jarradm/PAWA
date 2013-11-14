<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<AwesomeMvcDemo.ViewModels.MealInput>" %>
<%using (Html.BeginForm())
  {%>
  <%=Html.HiddenFor(o => o.Id) %>
<div class="efield">
    <div class="elabel">
        Name:</div>
    <div class="einput">
        <%:Html.Awe().TextBoxFor(o => o.Name).Placeholder("meal name") %></div>
    <%:Html.ValidationMessageFor(o => o.Name) %>
</div>
<div class="efield">
    <div class="elabel">
        Category:</div>
    <div class="einput">
        <%:Html.Awe().AjaxDropdownFor(o => o.Category) %></div>
        <%:Html.ValidationMessageFor(o => o.Category) %>
</div>
<div class="efield">
    <div class="elabel">
        Description:
    </div>
    <div class="einput">
        <%:Html.TextAreaFor(o => o.Description) %>
    </div>
    <%:Html.ValidationMessageFor(o => o.Description) %>
</div>
<%}%>