<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage" MasterPageFile="~/Views/Shared/Site.Master" %>
<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">
    Form Demo
</asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    <h3>Form used to post form via ajax and pass result to Success js function</h3>
    <%if(TempData["word"] !=null){%>
    <p style="background-color: green;color:white;">
        you posted:<%:TempData["word"] %>
    </p>
    <%}%>
    <%--begin--%>
    <% using (Html.BeginForm("AskName", "FormDemo", FormMethod.Post, new { @class = "ajaxForm" }))
      { %>
    <%:Html.Partial("AskName") %>
    <%} %>

    <div id="result" style="color:green;">
    </div>
    <br/>
    <%:Html.Awe().Form()
                .FormClass("ajaxForm")
                .Confirm(true)
                .ConfirmOptions(o => { o.YesText = "Yes, do it !"; o.Message = "really post the form ?"; })// change default options
                .Success("showResult")// js func to be called after successful post
                .FillFormOnContent(true) %>

    <script type="text/javascript">
        function showResult(o) {
            $('#result').html('server says your name is ' + o.Name);
        }
    </script>
    
    <%--end--%>
    <div class="expl">
        The <code>Html.Awe.Form</code> helper will make forms of a certain class defined by <code>.FormClass(string)</code> to be posted via ajax,
        form submission can also be prevented with a confirm dialog by setting <code>.Confirm(bool)</code>. 
        A js function can be set to handle the result from the server using <code>.Success(string)</code>.
        Ajax post can be disabled by using <code>.UseAjax(false)</code>
    </div>
    <div class="code">
    <pre><%:Html.Source("FormDemo/Index.aspx") %></pre>
        </div>
    <br/>

    <h3>Form used to post form via ajax and replace the content of the form with the result</h3>
    <%--begin1--%>
    <% using (Html.BeginForm("FillForm", "FormDemo", FormMethod.Post, new { @class = "c2" }))
       {%>
        <%:Html.Action("FillForm") %>
    <%} %>
    
    <%:Html.Awe().Form()
                .FormClass("c2")
                .FillFormOnContent(true) /* when true and the result is Content/View, the result will be used to fill the form's content*/
                .BeforeSubmit("validate")
                %>

    <script type="text/javascript">
        function validate() {
            if (!$('#SaySomething').val()) {
                alert('please write something in the textbox');
                return false;
            }
            return true;
        }           
    </script>
    <%--end1--%>
    <div class="code">
    <pre><%:Html.Source("FormDemo/Index.aspx",1) %></pre>
        </div>
    
    <h3>
        Used to confirm a form post, and post the form without ajax
    </h3>
    <%--begin2--%>
    <% using (Html.BeginForm("Index", "FormDemo", FormMethod.Post, new { @class = "normalPost" }))
       {%>
        <input type="text" name="word" value="click the button"/><input type="submit" value="Submit" class="awe-btn"/>
    <%} %>
    <%:Html.Awe().Form()
                .UseAjax(false)
                .Confirm(true)
                .FormClass("normalPost") %>
    <%--end2--%>
    <div class="code">
    <pre><%:Html.Source("FormDemo/Index.aspx",2) %></pre>
        </div>
</asp:Content>
