<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<MultiLookupDemoCfgInput>"
    MasterPageFile="~/Views/Shared/Site.Master" %>

<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">
    ASP.net MVC Awesome Grid Demo</asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    <h3>
        MultiLookup</h3>
    <div>
        <fieldset class="section">
            <legend>configure</legend>
            <form action="<%=Url.Action("IndexContent","MultiLookupDemo") %>" method="post" class="ConfigForm">
            <label>
                ClearButton:
                <%:Html.CheckBoxFor(o => o.ClearButton) %></label>
            <label>
                HighlightChange:
                <%:Html.CheckBoxFor(o => o.HighlightChange) %></label>
            <label>
                Full screen:
                <%:Html.CheckBoxFor(o => o.Fullscreen) %></label>
            <label>
                Drag and Drop:
                <%:Html.CheckBoxFor(o => o.DragAndDrop) %></label>
            <br />
            <label>
                Popup Height:
                <%:Html.Awe().TextBoxFor(o => o.Height).Numeric(true).MaxLength(3).HtmlAttributes(new {style="width:50px;"}) %></label>
            <label>
                Popup Width:
                <%:Html.Awe().TextBoxFor(o => o.Width).Numeric(true).MaxLength(3).HtmlAttributes(new {style="width:50px;"}) %>
                <input type="submit" value="OK" class="awe-btn" />
            </label>
            </form>
        </fieldset>
    </div>
    <br/>
    <div id="demoContent">
        <% Html.RenderPartial("IndexContent"); %>
    </div>
    in the view:
    <pre>
<%:Html.Source("MultiLookupDemo/IndexContent.ascx") %>
</pre>
    <pre>
<%:Html.Csource("MealsMultiLookupController.cs") %>
</pre>
    <div class="expl">
        <p>
            MultiLookup needs a controller or urls to be specified, by default convention it
            will look for a controller with the same name as it + "MultiLookupController"<br />
        </p>
        <ul>
            <li><code>action GetItems</code> - used to show the value in the readonly field, it
                will receive a <code>v</code> parameter which is going to be the keys of the selected
                items</li>
            <li><code>action Search</code> - gets data for the search result in it's popup, it receives
                a <code>selected</code> parameter that represents the selected values, it should
                return a <code>Json(AjaxListResult)</code>, so it has same features as the AjaxList
                (table layout, custom item template)</li>
                <li><code>action Selected</code> - gets data for the selected items in the popup</li>
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
