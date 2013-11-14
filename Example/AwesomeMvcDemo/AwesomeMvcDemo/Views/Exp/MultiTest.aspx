<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MultiTestInput>" %>
<%@ Import Namespace="AwesomeMvcDemo.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    MultiTest
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>MultiTest</h2>

    <% using (Html.BeginForm())
       {%>
    
    <%:Html.Awe().MultiLookupFor(o => o.Foos) %><br/>
    <%:Html.Awe().AjaxCheckboxListFor(o => o.FoosChk).Controller<FoosAjaxCheckboxListController>() %><br/>
    <%:Html.Awe().AjaxRadioListFor(o => o.FoosRadio) %><br/>
    <%:Html.Awe().AjaxDropdownFor(o => o.FoosDd).Controller<FoosRadioAjaxRadioListController>() %><br/>
    <%:Html.Awe().LookupFor(o => o.FooLookup).Controller<FooLookupController>() %><br/>
    <%:Html.Awe().TextBoxFor(o => o.FooTxt) %><br/>
    <%:Html.Awe().AutocompleteFor(o => o.FooAuto).Controller<FooAutocompleteController>() %><br/>
    <hr/>
    <%:Html.Awe().MultiLookup("Foos2").Controller<FoosMultiLookupController>().Value(Db.Foos.First().Name) %><br/>
    <%:Html.Awe().AjaxCheckboxList("FoosChk2").Controller<FoosAjaxCheckboxListController>().Value(Db.Foos.Last().Name) %><br/>
    <input type="submit" value="Submit" class="awe-btn"/>
    <%} %>
</asp:Content>
