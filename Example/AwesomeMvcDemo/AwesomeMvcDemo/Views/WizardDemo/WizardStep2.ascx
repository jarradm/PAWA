<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<AwesomeMvcDemo.Controllers.Step2Model>" %>

<div id="wizardData" style="height: 235px;">
    <% using (Html.BeginForm())
       {%>
good, now select a meal
    <br />
    <br />
    <div class="efield">
        <div class="elabel">
            Meal:
        </div>
        <div class="einput">
            <%:Html.Awe().AjaxCheckboxListFor(o => o.MealIds)
                     .Url(Url.Action("GetItems","ChildMealsAjaxCheckboxList"))
                     .Parameter("parent", Model.CategoryId) %>

            <%:Html.ValidationMessageFor(o => o.MealIds ) %>
        </div>
    </div>
    <%} %>
</div>
<div>
    <div style="float: left; margin-right: -100px;">
        <% using (Html.BeginForm("WizardStep1", null, new { Model.WizardId }, FormMethod.Get))
           {%>
        <input type="submit" value="Go back" class="awe-btn" style="width: 100px;" />
        <%} %>
    </div>

    <div style="text-align: center;">
        <input type="submit" value="Continue" class="awe-btn" onclick="$('#wizardData form').submit()" style="width: 100px;" />
    </div>
</div>
