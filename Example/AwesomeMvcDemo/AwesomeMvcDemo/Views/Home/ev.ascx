<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    var t = ViewData["task"];
    var i = ViewData["index"];
%>
    <div class="efield">
        <div class="elabel">
            Evidence:</div>
        <div class="einput">
        aaa
            <input type="hidden" value="<%=i %>" name="Tasks[<%=t %>].Evidences.Index" >
            vvv
            <input type="hidden" value="<%=ViewData["Id"] %>" name="Tasks[<%=t %>].Evidences[<%=i %>].Id">           

            <input type="text" value="<%=ViewData["Evidence"] %>" name="Tasks[<%=t %>].Evidences[<%=i %>].Evidence">

            <span class="del">delete</span>
        </div>        
    </div>