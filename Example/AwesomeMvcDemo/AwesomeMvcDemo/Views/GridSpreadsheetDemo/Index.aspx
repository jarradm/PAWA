<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" MasterPageFile="~/Views/Shared/Site.Master" %>

<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">Grid Spreadsheet Demo - ASP.net MVC Awesome</asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    <h2>Grid Spreadsheet Demo</h2>
    The grid is used as an excel/google docs spreadsheet. ClientFormatFunc is set for each column to render a textbox for each cell, and some css to hide the borders of the textbox and make the cell look like one.
    Once the js change event is triggered on the textbox an ajax request is sent to the server to save the value. The Id is not shown and is not editable, but it's used to identify the records when editing them.
    <br />
    <br />
    Try and edit some cells, after switch pages/refresh broswer. Note you have to exit the cell in order for the change to be persisted.
    <br/>
    <button type="button" class="awe-btn" id="addrow">add row</button>
    <%--begin--%>
    <%:Html.Awe().Grid("Spreadsheet")
                .Groupable(false)
                .Sortable(false)
                .Url(Url.Action("GridGetItems"))
                .Columns(
                new Column{ Name = "Name", ClientFormatFunc = "txt"}, 
                new Column{ Name = "Location", ClientFormatFunc = "txt"}, 
                new Column{ Name = "Meal", ClientFormatFunc = "txt"}) %>
    <div id="log" class="log"></div>
    <script>
        function txt(model, name) {
            var val = model[name];
            if (!val) val = ""; //replace null with ""
            return "<input type='text' name='" + name + "' value='" + val + "'/>";
        }

        function add() {
            $.post('<%:Url.Action("Add")%>', function () {
                $('#Spreadsheet').data('api').load({ oparams: { page:1 } });
            });
        }

        $(function () {
            $('#Spreadsheet').on('change', 'input', function () {
                var model = $(this).closest('.awe-row').data('model');
                var prop = $(this).attr("name");
                model[prop] = $(this).val();
                $.post('<%:Url.Action("Save")%>', { id: model.Id, name: prop, value: model[prop] }, function () {
                    $('#log').prepend(model[prop]+' saved <br/>');
                });
            });
            $('#addrow').on('click', add);
        });
    </script><%--end--%>
    <style>
        #Spreadsheet .awe-row {
            background: white;
        }

        #Spreadsheet .awe-row td {
            padding: 0;
            text-align: center;
        }

        #Spreadsheet input[type="text"] {
            width: 98%;
            margin: auto;
            border: 0;
            padding: 2px;
        }
    </style>
    <pre><%:Html.Source("GridSpreadsheetDemo/Index.aspx") %></pre>
    <pre><%:Html.Csource("GridSpreadsheetDemoController.cs") %></pre>
</asp:Content>
