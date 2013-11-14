<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GridDemoSortingCfgInput>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Grouping
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h3>Sorting</h3>
<fieldset class="section">
        <legend>configure</legend>
        <form action="<%=Url.Action("SortingContent","GridDemo") %>" method="post" class="ConfigForm">
            <label>
        Sortable:
        <%:Html.CheckBoxFor(o => o.Sortable) %>
        </label>
        <label>
        Single Column Sort: <%:Html.CheckBoxFor(o =>o.SingleColumnSort) %></label>
        <br />
        <label>
        Person - Sortable <%:Html.CheckBoxFor(o => o.PersonSortable) %> </label>
        <label>
        Sort <%:Html.Awe().AjaxDropdownFor(o=> o.PersonSort).Controller<SortAjaxDropdownController>() %></label>
        <label>
        Sort Rank <%:Html.Awe().TextBoxFor(o => o.PersonRank).Numeric(true).CssClass("stx") %>
        </label>
        <br/>
        <label>
        Food &nbsp;&nbsp; - Sortable <%:Html.CheckBoxFor(o => o.FoodSortable) %>
        </label>
        <label>
        Sort <%:Html.Awe().AjaxDropdownFor(o => o.FoodSort).Controller<SortAjaxDropdownController>() %>
        </label>
        <label>
        Sort Rank <%:Html.Awe().TextBoxFor(o => o.FoodRank).Numeric(true).CssClass("stx") %>
        </label>
        <br />
        <label>
        Page Size:
        <%:Html.Awe().TextBoxFor(o => o.PageSize).Numeric(true).MaxLength(2).HtmlAttributes(new {style="width:50px;"}) %>
        <input type="submit" value="OK" class="awe-btn" />
        </label>
        </form>
    </fieldset>

    <div id="demoContent">
        <% Html.RenderPartial("SortingContent"); %>
    </div>
        <%:Html.Awe().Form().FormClass("ConfigForm").Success("setContent") %>
        <script type="text/javascript">
            function setContent(o) {
                $('#Fe').trigger('awegridclearpersist');
                $('#demoContent').html(o);
            }
    </script>
    <br/>
    <pre><%:Html.Source("GridDemo/SortingContent.ascx") %></pre>
    <pre><%:Html.Csource("LunchGridController.cs") %></pre>
    <br/>
    <div class="expl">
        <p>
        Sorting can be enabled or disabled for the whole grid by using the <code>.Sortable(bool)</code> 
        and can be set for each column by setting the <code>Column.Sortable</code>
        </p>
        <ul>
            <li><code>SingleColumnSort</code> - enables sorting by one column at a time</li>
            <li><code>Column.Sort</code> - initial sorting for this column (None | Asc | Desc)</li>
            <li><code>Column.SortRank</code> - initial sort rank for this column</li>
        </ul>
    </div>
</asp:Content>
