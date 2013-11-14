<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<AwesomeMvcDemo.Models.Meal>>" %>
<%foreach (var o in Model)
  {%>
<tr class="awe-li" data-val="<%:o.Id %>">
    <td>
        <%if (ViewData["multilookup"] != null)
          {%>
        <button class="awe-movebtn awe-btn" type="button"><span class="awe-icon"></span></button>
        <%} %>
        <%:o.Name %>
    </td>
    <td>
        <%:o.Category != null ? o.Category.Name : ""%>
    </td>
    <td>
        <%:o.Description %>
    </td>
</tr>
<%} %>
