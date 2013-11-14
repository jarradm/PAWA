<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<AwesomeMvcDemo.ViewModels.CategoryInput>" %>

<%using(Html.BeginForm())
  {%>
  <div class="efield">
    <div class="elabel">
        <%:Html.LabelFor(o => o.Name) %>
    </div>
    <div class="einput">
        <%:Html.TextBoxFor(o => o.Name) %>
    </div>
    <%:Html.ValidationMessageFor(o => o.Name) %>
</div>
  <%}%>