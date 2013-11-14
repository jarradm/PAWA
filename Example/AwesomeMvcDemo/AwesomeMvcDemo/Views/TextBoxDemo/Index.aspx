<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<TextBoxDemoInput>" MasterPageFile="~/Views/Shared/Site.Master" %>
<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">TextBox Demo</asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
<h3>TextBox with placeholder</h3>    
    <%--begin--%>
    <%:Html.Awe().TextBoxFor(o => o.Name)
                .Placeholder("type here...") %>
    <%--end--%>
    <pre><%:Html.Source("TextBoxDemo/Index.aspx") %></pre>
    <h3>Numeric Textbox, 3 characters max</h3>
    <%--begin1--%>
    <%:Html.Awe().TextBox("Number")
                .Placeholder("only 3 numbers here")            
                .Numeric(true)
                .MaxLength(3)
                 %>
    <%--end1--%>
    <pre><%:Html.Source("TextBoxDemo/Index.aspx",1) %></pre>

</asp:Content>
