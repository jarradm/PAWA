<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    var t = (int)ViewData["ti"];
%>
<div class="task">
    <input type="hidden" value="0" name="Tasks[<%=t %>].Id" data-val-required="The Id field is required."
        data-val-number="The field Id must be a number." data-val="true">
    <div class="efield">
        <div class="elabel">
            Title:</div>
        <div class="einput">
            <%: Html.Editor("Tasks["+t+"].Title")%>
            <%--<input type="text" name="Tasks[<%=t %>].Title" data-val-required="The Title field is required." data-val="true">--%>
        </div>
        <%--<span data-valmsg-replace="true" data-valmsg-for="Tasks[<%=t %>].Title" class="field-validation-valid">
        </span>--%>
    </div>
     <div class="evidences" data-count="4" data-task="<%=t %>">
     <span class="add">Adauga</span>
    <% for (int i = 0; i < 4; i++)
       {%>
          <%:Html.Action("AddEvidence", new { task = t, index = i})%>  
       <%} %>
</div>
