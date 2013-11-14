<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<AwesomeMvcDemo.Models.Meal>>" %>
<% foreach (var o in Model)
   {%>
<li class="awe-li" data-val="<%=o.Id %>">
    <table style="width: 100%;">
        <tr>
            <td style="width: 200px;">
                <%=o.Name %>
            </td>
            <td style="width: 200px;">
                <%=o.Category!=null?o.Category.Name:"" %>
            </td>
            <td>
                <%=o.Description %>
            </td>
            <td style="width: 70px;">
            <button onclick="<%:Url.Awe().PopupAction().Url(Url.Action("Details",new{o.Id})) %>" class="awe-btn awe-nonselect">Details</button>                
            </td>
        </tr>
    </table>
</li>
<%} %>
