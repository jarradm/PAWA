<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" MasterPageFile="~/Views/Shared/Site.Master" %>
<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">Grid Choose columns demo - ASP.net MVC Awesome</asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    <%--begin--%>
    <h2>Grid choose columns demo</h2>
    <%:Html.Awe().Grid("GridChooseColumns")
                .Url(Url.Action("GetItems"))
                .Persistence(Persistence.Session)
                .ShowGroupBar(true)
                .SendColumns(true) %>

    <h3>using api</h3>
    <textarea id="vs" style="width: 100%;">
$('#GridChooseColumns').data('api').load({ oparams:{ selectedColumns:["Id","Person", "Location", "Date" ], choosingColumns:true } });
// all columns = "Id", "Person", "Food", "Location", "Date", "Price"
// Id and Person will be displayed regardless
    </textarea>

    <button type="button" class="awe-btn" id="btnExecute">Execute</button>

    <script>
        $(function () {
            $('#btnExecute').click(function() {
                eval($('#vs').val());
            });
        });
    </script>
    
    <h3>using checkboxlist</h3>
    <%:Html.Awe().AjaxCheckboxList("chkColumns").Url(Url.Action("GetColumnsItems")) %>
    <button type="button" class="awe-btn" id="btnUpdateColumns">Update columns</button>
    <script>
        $(function () {
            $('#GridChooseColumns').on('aweload', function (e, res) {
                $('#chkColumns').data('api').load({ params: res.Tag });
            });

            $('#btnUpdateColumns').click(function () {
                var val = $('#chkColumns').val();
                if (!val) val = "[]";
                $('#GridChooseColumns').data('api').load({ oparams: { selectedColumns: JSON.parse(val), choosingColumns: true } });
            });
        });
    </script>
    <%--end--%>
    <p>
        note: using persistence Session, try removing some columns, group by a column, and refresh, to mantain the same columns even after reopening browser change to Persistence.Local
    </p>
    <div class="code">
        <br/>
    The grid has .SendColumns(true) which will send the columns state information on each request, on the first request g.Columns.Length is 0, this is where we set the default column definition. 
    Columns are picked by sending additional parameters using oparams (one time parameters), 
    and by modifying/setting the g.Columns (when g.Columns has Columns in it, the grid will use it instead of what it's specified in the markup). 
    The gridModel.Tag is populated with data to be used by the AjaxCheckboxList, on grid aweload event the api of the AjaxCheckboxList is called.
    Persistence will save the state of the grid ( page, collapsed groups, columns )

    <pre><%:Html.Source("GridChooseColumnsDemo/Index.aspx") %></pre>
    <pre><%:Html.Csource("GridChooseColumnsDemoController.cs") %></pre>
        </div>
</asp:Content>
