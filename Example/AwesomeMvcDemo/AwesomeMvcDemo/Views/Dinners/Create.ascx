<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<AwesomeMvcDemo.ViewModels.DinnerInput>" %>
<% using(Html.BeginForm()){%>
<div class="efield">
    <div class="elabel">
        <%:Html.LabelFor(o => o.Name) %></div>
    <div class="einput">
        <%:Html.EditorFor(o => o.Name) %></div>
    <%:Html.ValidationMessageFor(o => o.Name) %>
</div>
<div class="efield">
    <div class="elabel">
        <%:Html.LabelFor(o => o.Date) %></div>
    <div class="einput">
        <%:Html.EditorFor(o => o.Date) %></div>
    <%:Html.ValidationMessageFor(o => o.Date) %>
</div>
<div class="efield">
    <div class="elabel">
        <%:Html.LabelFor(o => o.Chef) %></div>
    <div class="einput">
        <%:Html.EditorFor(o => o.Chef) %></div>
    <%:Html.ValidationMessageFor(o => o.Chef) %>
</div>
<div class="efield">
    <div class="elabel">
        <%:Html.LabelFor(o => o.Meals) %></div>
    <div class="einput">
        <%:Html.EditorFor(o => o.Meals) %></div>
    <%:Html.ValidationMessageFor(o => o.Meals) %>
</div>
<%} %>