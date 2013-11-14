<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<div class="elabel2" >Name:</div><div class="einput"><input type="text" name="search"/></div>
<button type="submit" class="awe-btn">Search</button>
<div style="display:inline;"> 
<button type="button" class="awe-btn" onclick="<%:Url.Awe().PopupFormAction().Url(Url.Action("Create","Dinners")).Success("create").Modal(true) %>">Create</button>
</div>
<br style="clear:both;"/>
