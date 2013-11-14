<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<GridHideColumnsDemoInput>" MasterPageFile="~/Views/Shared/Site.Master" %>
<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">Grid Hide Columns Demo - ASP.net MVC Awesome</asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    <h2>Grid show hide columns</h2>
    <fieldset class="section">
        <legend>pick columns</legend>
    <form class="cfgForm">
    <label>Show Food <%:Html.CheckBoxFor(o => o.ShowFood) %></label>
    <label>Show Location <%:Html.CheckBoxFor(o => o.ShowLocation) %></label>
    <label>Show Date <%:Html.CheckBoxFor(o => o.ShowDate) %></label>
        <input type="submit" value="Apply" class="awe-btn"/>
        </form>
        </fieldset>
    
    <%:Html.Awe().Form().FormClass("cfgForm").Url(Url.Action("GridContent")).Success("placeGrid") %>
    
    <div id="gridContent">
    <%:Html.Partial("GridContent") %>
        </div>
    
    <script>
        function placeGrid(result) {
            $('#gridContent').html(result);
        }
    </script>
    <br/>
    <pre><%:Html.Source("GridShowHideColumnsDemo/GridContent.ascx") %></pre>
</asp:Content>