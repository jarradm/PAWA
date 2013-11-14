<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<LookupDemoCfgInput>"
    MasterPageFile="~/Views/Shared/Site.Master" %>
<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">
    ASP.net MVC Awesome Grid Demo</asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    <h3>
        Lookup</h3>
    <div>
        <fieldset class="section">
            <legend>configure</legend>
            <form action="<%=Url.Action("IndexContent","LookupDemo") %>" method="post" class="ConfigForm">
            <label>
                ClearButton:
                <%:Html.CheckBoxFor(o => o.ClearButton) %></label>
            <label>
                HighlightChange:
                <%:Html.CheckBoxFor(o => o.HighlightChange) %></label>
            <label>
                Fullscreen:
                <%:Html.CheckBoxFor(o => o.Fullscreen) %></label>
            <label>
                Popup Height:
                <%:Html.Awe().TextBoxFor(o => o.Height).Numeric(true).MaxLength(3).CssClass("mini") %></label>
            <label>
                Popup Width:
                <%:Html.Awe().TextBoxFor(o => o.Width).Numeric(true).MaxLength(3).CssClass("mini") %>
                <input type="submit" value="OK" class="awe-btn" /></label>
            <br />
            </form>
        </fieldset>
    </div>
    <div id="demoContent">
        <% Html.RenderPartial("IndexContent"); %>
    </div>
    <pre><%:Html.Source("LookupDemo/IndexContent.ascx") %></pre>
    <pre><%:Html.Csource("MealLookupController.cs") %></pre>
    <div class="expl">
        <p>
            Lookup needs a controller or urls to be specified, by default convention the lookup
            will look for a controller with the same name as it + "LookupController"<br />
        </p>
        <ul>
            <li><code>action GetItem</code> - used to show the value in the readonly field, it will
                receive a <code>v</code> parameter which is going to be the key of the selected item</li>
            <li><code>action Search</code> - gets data for the search result in it's popup, it should
                return a <code>Json(AjaxListResult)</code>, so it has same features as the AjaxList (table layout,
                custom item template)</li>
        </ul>
    </div>
    <%:Html.Awe().Form().FormClass("ConfigForm").Success("setContent") %>
    <script type="text/javascript">
        function setContent(o) {
            $('#Meal-awepw').dialog('close');
            $('#demoContent').html(o).addClass('awe-changing').removeClass('awe-changing', 1000);
        }
    </script>
</asp:Content>
