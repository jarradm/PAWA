<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<WizardFinishModel>" %>

<div id="wizardData" style="height: 235px;">
    <%using (Html.BeginForm())
      {%>
    <%:Html.HiddenFor(o => o.WizardId) %>

Name : <%:Model.Name %><br />
    Category: <%:Model.Category %><br />
    Meals: <%:string.Join(",", Model.Meals) %>
    <%} %>
</div>

<div>
    <div style="float: left; margin-right: -100px;">
        <% using (Html.BeginForm("WizardStep2", null, new { Model.WizardId }, FormMethod.Get))
           {%>
        <input type="submit" value="Go back" class="awe-btn" style="width: 100px;" />
        <%} %>
    </div>

    <div style="text-align: center;">
        <input type="submit" value="Finish" class="awe-btn" onclick="$('#wizardData form').submit()" style="width: 100px;" />
    </div>
</div>
