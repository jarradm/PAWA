<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Step1Model>" %>

<div id="wizardData" style="height: 235px;">
<% using (Html.BeginForm())
   {%>
Hi, please write a name and select a category 
<br/>
<br/>

<div class="efield">
    <div class="elabel">
        <%:Html.LabelFor(o => o.Name) %>
    </div>
    <div class="einput">
        <%:Html.Awe().TextBoxFor(o => o.Name).Placeholder("type a name here ...") %>
        <%:Html.ValidationMessageFor(o => o.Name) %>
    </div>
</div>
<div>
    <div class="elabel">
        Category
    </div>
    <div class="einput">
        <%:Html.Awe().AjaxDropdownFor(o => o.CategoryId).Url(Url.Action("GetItems","CategoryFoAjaxDropdown")) %>
        <%:Html.ValidationMessageFor(o => o.CategoryId) %>
    </div>
</div>
<%} %>
    </div>

<div style="text-align: center;">
<input type="submit" value="Continue" class="awe-btn" onclick="$('#wizardData form').submit()" style="width:100px;"/>
    </div>