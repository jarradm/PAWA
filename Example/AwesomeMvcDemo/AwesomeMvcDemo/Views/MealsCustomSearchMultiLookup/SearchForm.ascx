<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<object>" %>
<div>
<label>Name:<input type="text" name="search"/> </label>
<label>
    Categories:
    <%:Html.Awe().AjaxDropdown("Categories").Controller<CategoryAjaxDropdownController>().Prefix("MealLookup") %>
    <input type="submit" class="awe-btn" value="Search"/>
</label>
</div>