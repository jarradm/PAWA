<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<AwesomeMvcDemo.ViewModels.FormDemoInput>" %>
<%--begin--%>
<div class="efield">
    <div class="elabel">
        First Name:
    </div>
    <div class="einput">
        <%:Html.TextBoxFor(o => o.FName) %>
    </div>
    <%:Html.ValidationMessageFor(o => o.FName) %>
</div>
<div class="efield">
    <div class="elabel">
        Last Name :
    </div>
    <div class="einput">
        <%:Html.TextBoxFor(o => o.LName) %>
    </div>
    <%:Html.ValidationMessageFor(o => o.LName) %>
</div>
<input type="submit" value="that's my name" class="awe-btn"/>
<%--end--%>