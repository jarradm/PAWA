<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<GridDemoCfgInput>" MasterPageFile="~/Views/Shared/Site.Master" %>
<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">
    ASP.net MVC Awesome Grid Demo</asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    <h3>Grid Demo</h3>
    <div>
    <fieldset class="section">
        <legend>configure</legend>
        <form action="<%=Url.Action("IndexContent","GridDemo") %>" method="post" class="ConfigForm">
        <label>Sortable:
        <%:Html.CheckBoxFor(o => o.Sortable) %></label>
        <label>Groupable:
        <%:Html.CheckBoxFor(o => o.Groupable) %></label>
                <label>Single column sorting:
        <%:Html.CheckBoxFor(o => o.SingleColumnSorting) %></label>
         <label>Show grouped column:
        <%:Html.CheckBoxFor(o => o.ShowGroupedColumn) %></label>
        <br />
        <label>
        Height:
        <%:Html.Awe().TextBoxFor(o => o.Height).Numeric(true).MaxLength(3).CssClass("mini") %>
        set to 0 for autosize</label>
            <input type="submit" value="OK" class="awe-btn awe-il" />
        </form>
    </fieldset>
    
    <!--begin-->
    <div>
        Person:<%:Html.Awe().TextBox("txtperson").Placeholder("search for person ...") %>
        Food:<%:Html.Awe().TextBox("txtfood").Placeholder("search for food ...")%>        
        <button type="button" class="awe-btn">search</button>
        <div style="float:right;">Page Size: <%:Html.Awe().TextBox("PageSize").CssClass("mini").Numeric(true).MaxLength(2) %></div>
    </div>
    </div>
    <!--end-->
    <div id="demoContent">
        <% Html.RenderPartial("IndexContent"); %>
    </div>
    <%:Html.Awe().Form().FormClass("ConfigForm").Success("setContent") %>
    
    
    <script type="text/javascript">
        function setContent(o) {
            $('#Grid').data('api').clearpersist();
            $('#demoContent').html(o);
        }
    </script>
    <br />
    in the view:
    <pre><%:Html.Source("GridDemo/IndexContent.ascx") %></pre>
    controller:
    <pre><%:Html.Csource("LunchGridController.cs") %></pre>
    <br/>
    <div class="expl">
        <p>
        Awesome Grid is declared using <code>Html.Awe().Grid(name)</code> helper and requires <code>.Columns()</code> to be specified.
        </p>
        <ul>
            <li><code>Column.Name</code> - used to bind this column to the model, it can be bound to one or more properties 
            and subproperties in the model,  examples: "FirstName", "FirstName,LastName", "Country.Name", "Chef.FirstName, Chef.LastName"</li>
            <li><code>Persistence</code> - makes the grid save it's state ( collapsed groups, current page, sorting, grouping), it can be None - no persistence, View - view context (will loose state on page refresh); Session - using HTML sessionStorage (will loose state on closing browser); Local - using HTML localStorage ( state will be persisted even after the browser is closed)</li>
            <li><code>GridModelBuilder&lt;Model&gt;</code> - builds the model of the grid by sorting, paging and grouping the items.</li>
            <li><code>GridModelBuilder&lt;Model&gt;.Map</code> - defines a function that maps the Model to a Dto, this way Column.Name will still be bound the the Model's properties
but for cell values the values from the Dto will be used</li>
<li><code>GridModelBuilder&lt;Model&gt;.Key</code> - defines a property on which the data will be sorted when there's no sorting, this is needed when using Entity Framework because it does not allow paging if the data is not ordered at least by one column</li>
        </ul>
    </div>
    <hr/>
    See also:<br/>
    <a href="<%:Url.Action("Index", "MasterDetailCrudDemo") %>">Master Detail Crud Demo using Grid and PopupForm</a><br/>
    <a href="<%:Url.Action("Index", "GridChooseColumnsDemo") %>">Grid choose columns demo</a><br/>
    <a href="<%:Url.Action("Index", "PurchasesCrudDemo") %>">Grid Crud Demo</a><br/>
</asp:Content>
