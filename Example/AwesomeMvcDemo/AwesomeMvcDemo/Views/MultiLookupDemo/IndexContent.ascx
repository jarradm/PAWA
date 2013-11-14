<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MultiLookupDemoCfgInput>" %>
<div class="efield">
    <div class="elabel">
        Pick some Meals:</div>
    <div class="einput">
        <%--begin--%>
<%:Html.Awe().MultiLookupFor(o => o.Meals)
        .ClearButton(Model.ClearButton)
        .HighlightChange(Model.HighlightChange)
        .Height(Model.Height)
        .Width(Model.Width)
        .Fullscreen(Model.Fullscreen)
        .DragAndDrop(Model.DragAndDrop)
%>
        <%--end--%>
    </div>
</div>
