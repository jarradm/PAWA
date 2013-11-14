<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<System.Web.Mvc.HandleErrorInfo>" %>

<asp:Content ID="errorTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Sorry, an error occured
</asp:Content>
<asp:Content ID="errorContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Oops! Something Bad Happened!</h1>
    <hr />
    <img width="500" src="<%=Url.Content("~/Content/error-lolcat-problemz.jpg") %>" class="fl"
        alt="lolcat" style="margin: 10px;" />
    <div style="padding: 10px;">
        <p>We apologize for any inconvenience, but an unexpected error occurred while you were
            browsing our site. </p>
        <p>It's not you, it's us. <b>This is our fault.</b> </p>
        <p>Detailed information about this error has automatically been recorded and we have
            been notified. </p>
        <p>Yes, we do look at every error. We even try to fix some of them. </p>
        <p>It's not strictly necessary, but if you'd like to give us additional information
            about this error, do so at our feedback site, http://wwww.aspnetawesome.com/contactus . </p>
    </div>
    <%:ViewData["message"] %>
</asp:Content>
