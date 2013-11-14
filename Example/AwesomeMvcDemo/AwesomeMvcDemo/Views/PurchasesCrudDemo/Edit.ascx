<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<AwesomeMvcDemo.ViewModels.PurchaseInput>" %>
<% using(Html.BeginForm()){%>
<div class="efield">
    <div class="elabel">
        <%:Html.LabelFor(o => o.Customer) %></div>
    <div class="einput">
        <%:Html.EditorFor(o => o.Customer) %></div>
    <%:Html.ValidationMessageFor(o => o.Customer) %>
</div>
<div class="efield">
    <div class="elabel">
        <%:Html.LabelFor(o => o.Product) %></div>
    <div class="einput">
        <%:Html.EditorFor(o => o.Product) %></div>
    <%:Html.ValidationMessageFor(o => o.Product) %>
</div>
<div class="efield">
    <div class="elabel">
        <%:Html.LabelFor(o => o.Quantity) %></div>
    <div class="einput">
        <%:Html.Awe().TextBoxFor(o => o.Quantity).Numeric(true).MaxLength(3) %></div>
    <%:Html.ValidationMessageFor(o => o.Quantity) %>
</div>
<div class="efield">
    <div class="elabel">
        <%:Html.LabelFor(o => o.Date) %></div>
    <div class="einput">
        <%:Html.EditorFor(o => o.Date) %></div>
    <%:Html.ValidationMessageFor(o => o.Date) %>
</div>
<%} %>
