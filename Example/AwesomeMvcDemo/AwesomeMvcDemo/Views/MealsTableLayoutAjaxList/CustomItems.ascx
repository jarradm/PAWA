<%--begin--%>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<AwesomeMvcDemo.Models.Meal>>" %>
<%foreach (var o in Model)
  {%>
<tr class="awe-li" data-val="<%:o.Id %>">
    <td><%:o.Name %></td>    
    <td><%:o.Category.Name %></td>
    <td><%:o.Description %></td>
</tr>
<%} %>
<%--end--%>