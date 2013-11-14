<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<AwesomeMvcDemo.Models.Message>" %>

From: <%:Model.From %> <br/>
Date received: <%:Model.DateReceived.ToShortDateString() %><br/>
<hr/>
Message:<br/>
<%:Model.Body %>