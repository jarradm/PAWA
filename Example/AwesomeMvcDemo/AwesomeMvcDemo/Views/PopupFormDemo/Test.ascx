<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<TestInput>" %>

<% using (Html.BeginForm())
   {%>
<%:Html.Awe().AjaxDropdownFor(o => o.Name).Url(Url.Action("GetItems","CategoryAjaxDropdown")) %>
<%:Html.ValidationMessageFor(o => o.Name) %>
<%} %>