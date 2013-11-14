<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GridDemoGroupingCfgInput>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Grouping
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h3>Grouping</h3>

<fieldset class="section">
        <legend>configure</legend>
        <form action="<%=Url.Action("GroupingContent","GridDemo") %>" method="post" class="ConfigForm">
            <label>
        Show Group Bar:
        <%:Html.CheckBoxFor(o => o.ShowGroupBar) %>
        </label>
        <label>
        Show Grouped Column:
        <%:Html.CheckBoxFor(o=> o.ShowGroupedColumn) %>
        </label>
        <label>
        Groupable:
        <%:Html.CheckBoxFor(o => o.Groupable) %>
        </label>
        <label>
        Collapsed: 
        <%:Html.CheckBoxFor(o => o.Collapsed) %>
        </label>
        <br />
        <label>
        Person - Groupable <%:Html.CheckBoxFor(o => o.PersonGroupable) %> </label>
        <label>Grouped <%:Html.CheckBoxFor(o => o.PersonGrouped) %></label>
        <label>Group Rank <%:Html.Awe().TextBoxFor(o => o.PersonRank).Numeric(true).CssClass("stx") %></label>
        <label>Group Removable <%:Html.CheckBoxFor(o => o.PersonRem) %></label>
        <br/>
        <label>
        Food &nbsp;&nbsp; - Groupable <%:Html.CheckBoxFor(o => o.FoodGroupable) %></label>
        <label>Grouped <%:Html.CheckBoxFor(o => o.FoodGrouped) %></label>
        <label>Group Rank <%:Html.Awe().TextBoxFor(o => o.FoodRank).Numeric(true).CssClass("stx") %></label>
        <label>Group Removable <%:Html.CheckBoxFor(o => o.FoodRem) %></label>
        <br />
        <label>
        Page Size:
        <%:Html.Awe().TextBoxFor(o => o.PageSize).Numeric(true).MaxLength(2).HtmlAttributes(new {style="width:50px;"}) %>
        <input type="submit" value="OK" class="awe-btn" />
        </label>
        </form>
    </fieldset>

    <div id="demoContent">
        <% Html.RenderPartial("GroupingContent"); %>
    </div>
        <%:Html.Awe().Form().FormClass("ConfigForm").Success("setContent") %>
        <script type="text/javascript">
            function setContent(o) {
                $('#Lunches').data('api').clearpersist();
                $('#demoContent').html(o);
            }
    </script>
    in the view:
    <pre><%:Html.Source("GridDemo/GroupingContent.ascx") %></pre>
    in the controller:
    <pre><%:Html.Csource("GroupingGridController.cs")%></pre>
    <br/>
    <div class="expl">
        <p>
        Grouping can be enabled or disabled for the whole grid by using the <code>.Groupable(bool)</code> 
        and can be set for each column by setting the <code>Column.Groupable</code>
        </p>
        <ul>
            <li><code>Column.Group</code> - defines whether initially the column is grouped </li>
            <li><code>Column.GroupRank</code> - group rank for this column</li>
            <li><code>Column.GroupRemovable</code> - (default is true) if set to false grouped column won't have the remove group button</li>
            <li><code>.ShowGroupedColumn</code> - if true the grouped columns will be hidden </li>
            <li><code>GridModelBuilder.MakeHeader</code> - defines a function for creating the GroupHeader</li>
            <li><code>GridModelBuilder.MakeFooter</code> - function for creating a group footer</li>
        </ul>
    </div>
</asp:Content>
