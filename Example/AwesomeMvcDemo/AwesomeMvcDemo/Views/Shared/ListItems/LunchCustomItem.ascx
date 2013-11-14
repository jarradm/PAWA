<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IList<AwesomeMvcDemo.Models.Lunch>>" %>
<%
    for (var i = 0; i < Model.Count; i++)
  {%>
<li class="awe-li" data-val="<%:Model[i].Id %>">
    Person:<%:Model[i].Person %>
    <%:Html.Awe().TextBoxFor(o => o[i].Person).Value(Model[i].Person) %>
    <br />
    Chef: <%:Model[i].Chef.FirstName%>
    <%:Html.Awe().LookupFor(o => o[i].Chef.Id).Controller<ChefLookupController>().Value(Model[i].Chef.Id) %>
    <br />
    Date:<%:Model[i].Date %><%:Html.Awe().DatePickerFor(o => o[i].Date).Value(Model[i].Date) %>
</li>
<%} %>