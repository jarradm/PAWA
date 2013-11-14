
<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<object>" MasterPageFile="~/Views/Shared/Site.Master" %>

<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">
    ASP.net MVC Awesome Popup Form Wizard Demo 
</asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">

    <h3>Wizard Demo</h3>
    <%--begin--%>
    <%:Html.Awe().PopupFormActionLink()
                .Url(Url.Action("StartWizard"))
                .LinkText("click here to start wizard")
                .Success("wizardFinish")
                .UseDefaultButtons(false)
                .Modal(true)
                 %>

    <script type="text/javascript">
        function wizardFinish(res) {
            alert(res.Message);
        }
    </script><%--end--%>
    
    <p>
        In this demo a Wizard is built using the PopupForm helper. 
        We're not using the default Ok and Cancel buttons instead a submit button is placed on the bottom center of the form.
        <br/>
        Stepping back is performed by submitting a form with the wizardID parameter using GET to the needed step 
        (The popup form will handle any form that is being submited inside of it).
    </p>
    <div class="code">
    <pre><%:Html.Source("WizardDemo/Index.aspx") %></pre>
        controller:
    <pre><%:Html.Csource("WizardDemoController.cs") %></pre>
        step1 view:
    <pre><%:Html.Source("WizardDemo/WizardStep1.ascx") %></pre>
        step2 view:
    <pre><%:Html.Source("WizardDemo/WizardStep2.ascx") %></pre>
        finish view:
    <pre><%:Html.Source("WizardDemo/WizardFinish.ascx") %></pre>
        </div>
</asp:Content>
