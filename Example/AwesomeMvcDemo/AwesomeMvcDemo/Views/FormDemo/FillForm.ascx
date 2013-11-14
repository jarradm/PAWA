<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<AwesomeMvcDemo.ViewModels.SayInput>" %>

Say something: <%:Html.TextBoxFor(o => o.SaySomething) %>
<input type="submit" value="Say" class="awe-btn"/>
