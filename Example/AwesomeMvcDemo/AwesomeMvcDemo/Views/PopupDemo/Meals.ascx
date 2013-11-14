<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<object>" %>
<style>
.fixh
{
    height:370px;
    overflow-y: scroll;    
}
</style>
<div style="margin: 5px;">
<%:Html.Awe().AjaxList("Meals").CssClass("fixh") %>
</div>