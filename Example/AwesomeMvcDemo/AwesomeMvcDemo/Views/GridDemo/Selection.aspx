<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage" MasterPageFile="~/Views/Shared/Site.Master" %>

<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">
    ASP.net MVC Awesome Grid Selection Demo
</asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    <h3>Grid Selection</h3>
    
    <h2>Multiselect</h2>
    <p>use click, ctrl+click, shift+click, ctrl+shift+click to select multiple rows</p>
    <%--begin--%>
    <%:Html.Awe().Grid("MultiselectGrid")
                .Url(Url.Action("GetItems","LunchGrid"))
                .Height(400)
                .Selectable(SelectionType.Multiple)
                .Columns(
                new Column { Name = "Id", Width = 55 },
                new Column { Name = "Person" },
                new Column { Name = "Food" },
                new Column { Name = "Price", Width = 100 },
                new Column { Name = "Location" })
    %>
    <button id="btnSelectAll" class="awe-btn">select all</button>
    <button id ="btnDeselectAll" class="awe-btn">deselect all</button>
    <button id="btnSelectByPrice" class="awe-btn">select where price > 50</button>

    <fieldset><legend>selection</legend>
        <div id="selection" class="wwrap"></div>
    </fieldset>
    <script>
        $(function () {
            $('#MultiselectGrid')
                .on('aweselect', function() {
                    var selectedItems = $('#MultiselectGrid').data('api').getSelection();
                    $('#selection').html(JSON.stringify(selectedItems));
                })
                .on('aweload', function () {
                    $('#selection').empty();
                });
            
            $('#btnSelectAll').click(function () {
                $('#MultiselectGrid .awe-row').addClass('awe-selected');
                $('#MultiselectGrid').trigger('aweselect');
            });
            
            $('#btnDeselectAll').click(function () {
                $('#MultiselectGrid .awe-row').removeClass('awe-selected');
                $('#MultiselectGrid').trigger('aweselect');
            });
            
            $('#btnSelectByPrice').click(function () {
                $('#MultiselectGrid .awe-row').removeClass('awe-selected').each(function (ix, item) {
                    if ($(item).data('model').Price > 50) {
                        $(item).addClass('awe-selected');
                    }
                });
                
                $('#MultiselectGrid').trigger('aweselect');
            });
        });
    </script>
    <%--end--%>

    <pre>
<%:Html.Source("GridDemo/Selection.aspx") %>
</pre>
    
    <h2>Single select</h2>
    <p>select one row by clicking on it</p>
    <%--begin1--%>
    <%:Html.Awe().Grid("SingleSelectGrid")
                .Url(Url.Action("GetItems","LunchGrid"))
                .Height(350)
                .Selectable(SelectionType.Single)
                .Columns(
                new Column { Name = "Id", Width = 55 },
                new Column { Name = "Person" },
                new Column { Name = "Food" },
                new Column { Name = "Price", Width = 100 },
                new Column { Name = "Location" })
    %>
    
    <fieldset><legend>selection</legend>
        <div id="selection2" class="wwrap"></div>
    </fieldset>
    <script>
        $(function () {
            $('#SingleSelectGrid')
                .on('aweselect', function () {
                    var selectedItems = $('#SingleSelectGrid').data('api').getSelection();
                    $('#selection2').html(JSON.stringify(selectedItems));
                })
                .on('aweload', function () {
                    $('#selection2').empty();
                });
        });
    </script>
    <%--end1--%>

    <pre>
<%:Html.Source("GridDemo/Selection.aspx", 1) %>
</pre>
    
        <h2>Multicheck select</h2>
    <p>select multiple rows by clicking on them</p>
    <%--begin3--%>
    <%:Html.Awe().Grid("MultiCheckSelectGrid")
                .Url(Url.Action("GetItems","LunchGrid"))
                .Height(350)
                .Selectable(SelectionType.Multicheck)
                .Columns(
                new Column { Name = "Id", Width = 55 },
                new Column { Name = "Person" },
                new Column { Name = "Food" },
                new Column { Name = "Price", Width = 100 },
                new Column { Name = "Location" })
    %>
    
    <fieldset><legend>selection</legend>
        <div id="selection3" class="wwrap"></div>
    </fieldset>
    <script>
        $(function () {
            $('#MultiCheckSelectGrid')
                .on('aweselect', function () {
                    var selectedItems = $('#MultiCheckSelectGrid').data('api').getSelection();
                    $('#selection3').html(JSON.stringify(selectedItems));
                })
                .on('aweload', function () {
                    $('#selection3').empty();
                });
        });
    </script>
    <%--end3--%>

    <pre>
<%:Html.Source("GridDemo/Selection.aspx", 3) %>
</pre>
    
    


    <div class="expl">
        <ul>
            <li><code>Selectable</code>
            - Set the grid rows selection type
        </ul>
    </div>
</asp:Content>
