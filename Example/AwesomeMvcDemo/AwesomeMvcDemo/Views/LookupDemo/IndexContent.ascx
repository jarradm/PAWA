<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<LookupDemoCfgInput>" %>
<div class="efield">
    <div class="elabel">
        Pick a Meal:</div>
    <div class="einput">
        <%--begin--%>
<%:Html.Awe().LookupFor(o => o.Meal)
        .ClearButton(Model.ClearButton)
        .HighlightChange(Model.HighlightChange)
        .Height(Model.Height)
        .Width(Model.Width)
        .Fullscreen(Model.Fullscreen)
%><%--end--%>
    </div>
</div>
