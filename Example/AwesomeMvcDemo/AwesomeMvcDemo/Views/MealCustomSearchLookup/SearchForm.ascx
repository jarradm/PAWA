<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<object>" %>
<div style="border: gainsboro solid 1px; vertical-align: top; padding: 15px; border-radius: 3px;">
    <div class="elabel2">
        Name:</div>
    <div class="einput">
        <input type="text" name="search" />
    </div>
    &nbsp;&nbsp;&nbsp;
    <div class="elabel2">
        Categories:</div>
    <div class="einput">
        <%:Html.Awe().MultiLookup("Categories").Prefix("MealLookup").ClearButton(true).Modal(true) %></div>
    <div class="einput">
        <input type="submit" value="Search" class="awe-btn" style="padding:1px 3px;" /></div>
</div>
