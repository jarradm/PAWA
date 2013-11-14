<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<AwesomeMvcDemo.Models.Meal>>" %>
<% foreach (var o in Model)
   {%>
<li class="awe-li" data-val="<%=o.Id %>">
    <table style="width: 100%;">
        <tr>
            <td style="width: 200px;">
            <button class="awe-movebtn awe-btn" type="button"><span class='awe-icon'></span></button>
                <%=o.Name %>
            </td>
            <td style="width: 200px;">
                <%=o.Category!=null?o.Category.Name:"" %>
            </td>
            <td>
                <%=o.Description %>
            </td>
            <td style="width: 70px;">
                <button onclick="<%:Url.Awe().PopupAction().Url(Url.Action("Details",new{o.Id})).Modal(true) %>"
                    class="awe-btn">Details</button>
            </td>
        </tr>
    </table>
</li>
<%} %>
