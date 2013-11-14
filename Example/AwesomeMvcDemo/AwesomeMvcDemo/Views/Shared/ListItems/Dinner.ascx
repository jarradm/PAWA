<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<AwesomeMvcDemo.Models.Dinner>>" %>
<% foreach (var o in Model)
   {%>
     <tr class="awe-li" id="dinner<%:o.Id %>" data-val="<%=o.Id %>">
     <td><%:o.Name %></td>
     <td><%:o.Date.ToShortDateString() %></td>
     <td><%:o.Chef.FirstName %> <%=o.Chef.LastName %></td>
     <td><%:string.Join(", ",o.Meals.Select(z => z.Name)) %></td>     
    <td>
        <button type="button" onclick="<%:Url.Awe().PopupFormAction().Url(Url.Action("edit","dinners",new{o.Id})).Success("edit").Title("edit dinner").Modal(true) %>" class="awe-btn">
            <span class="ico-edit"></span>
             </button>
    </td>
    <td>
        <form action="<%:Url.Action("delete","dinners",new{o.Id}) %>" method="post" class="confirm">
        <button type="submit" class="awe-btn">
            <span class="ico-del"></span>
        </button>
        </form>
    </td>
     </tr>
   <%} %>

