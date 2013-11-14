<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<AwesomeMvcDemo.Models.Meal>>" %>
<% foreach (var o in Model)
   {%>
<tr class="awe-li" data-val="<%=o.Id %>" id="meal<%=o.Id %>">
    <td>
        <%=o.Name %>
    </td>
    <td>
        <%=o.Category == null ? "": o.Category.Name %>
    </td>
    <td>
        <%=o.Description %>
    </td>
    <td>
        <button type="button" onclick="<%:Url.Awe().PopupFormAction().Url(Url.Action("edit","meals",new{o.Id})).Success("edit") %>" class="awe-btn">
            <span class="ico-edit"></span>
             </button>
    </td>
    <td>
        <form action="<%:Url.Action("delete","meals",new{o.Id}) %>" method="post" class="confirm">
        <button type="submit" value="" class="awe-btn">
            <span class="ico-del"></span>
        </button>
        </form>
    </td>
</tr>
<%} %>
