<%--begin--%>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IList<AwesomeMvcDemo.Models.Meal>>" %>

<%
    for (var i = 0; i < Model.Count; i++)
  {%>
<li class="awe-li" data-val="<%:Model[i].Id %>">Name:<%:Model[i].Name %>
    <br />
    Category: <%:Model[i].Category %>
    <br />
    Description:<%:Model[i].Description %>
</li>
<%} %>
<%--end--%>