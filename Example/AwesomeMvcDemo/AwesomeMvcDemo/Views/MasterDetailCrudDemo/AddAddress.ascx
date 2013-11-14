<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<RestaurantAddressInput>" %>

<% using (Html.BeginForm())
   {%>
<%:Html.HiddenFor(o => o.RestaurantId) %>
<div class="efield">
    <div class="elabel">
        <%:Html.LabelFor(o => o.Line1) %></div>
    <div class="einput">
        <%:Html.Awe().TextBoxFor(o => o.Line1) %>
    </div>
        <%:Html.ValidationMessageFor(o => o.Line1) %>
</div>

<div class="efield">
    <div class="elabel">
        <%:Html.LabelFor(o => o.Line2) %></div>
    <div class="einput">
        <%:Html.Awe().TextBoxFor(o => o.Line2) %>
    </div>
        <%:Html.ValidationMessageFor(o => o.Line2) %>
</div>
   <%} %>