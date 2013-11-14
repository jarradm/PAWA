<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<ListBindingInput>"
    MasterPageFile="~/Views/Shared/Site.Master" %>

<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">
    Asp.net mvc awesome list binding demo</asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    <style>
        .tt td
        {
            vertical-align: top;
        }
    </style>
    <h3>
        Model binding to a list</h3>
    Phil Haack Article: <a href="http://haacked.com/archive/2008/10/23/model-binding-to-a-list.aspx">
        http://haacked.com/archive/2008/10/23/model-binding-to-a-list.aspx</a>
    <br />
    <br />
    <br />
    <% using (Html.BeginForm())
       {%>
    <table class="tt">
        <% for (var j = 0; j < Model.Dinners.Count(); j++)
           {
               var i = j;%>
        <tr>
            <td>
                <%:Html.HiddenFor(o => o.Dinners[i].Id) %>
                <%:Html.Awe().TextBoxFor(o => o.Dinners[i].Name).Value(Model.Dinners[i].Name)%>
                <%:Html.ValidationMessageFor(o => o.Dinners[i].Name) %>
                <br />
            </td>
            <td>
                <%:Html.Awe().DatePickerFor(o => o.Dinners[i].Date).Value(Model.Dinners[i].Date).ClearButton(true)%><br />
                <%:Html.ValidationMessageFor(o => o.Dinners[i].Date) %>
            </td>
            <td>
                <%:Html.Awe().LookupFor(o => o.Dinners[i].Chef).Value(Model.Dinners[i].Chef).ClearButton(true)%><br />
                <%:Html.ValidationMessageFor(o => o.Dinners[i].Chef) %>
            </td>
            <td>
                <%:Html.Awe().MultiLookupFor(o => o.Dinners[i].Meals).Value(Model.Dinners[i].Meals).ClearButton(true)%><br />
                <%:Html.ValidationMessageFor(o => o.Dinners[i].Meals) %>
            </td>
        </tr>
        <%
       }%>
    </table>
    <input type="submit" value="submit" class="awe-btn"/>
    <%}%>
</asp:Content>
