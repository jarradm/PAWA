<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>"
    MasterPageFile="~/Views/Shared/Site.Master" %>

<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">
    Awesome Grid Demo - mail message
</asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    <h3>Grid Demo - Mail messages</h3>
    <input type="button" value="Delete" id="btnDelete" class="awe-btn" />
    <input type="button" value="Mark as read" id="btnMarkRead" class="awe-btn" />
    <input type="button" value="Mark as unread" id="btnMarkUnread" class="awe-btn" />
    <input type="button" value="Select all read" id="btnSelectRead" class="awe-btn"/>
    <input type="button" value="Select all unread" id="btnSelectUnread" class="awe-btn"/>
    <input type="button" value="Deselect all" id="btnDeselectAll" class="awe-btn"/>
    
    <%:Html.Awe().Grid("MessagesGrid")
                .Url(Url.Action("GetItems","MessagesGrid"))
                .ShowHeader(false)
                .ShowGroupBar(false)
                .Selectable(SelectionType.Multicheck)
                .RowClassClientFormat(".RowClass")
                .Columns(new[]
                    {
                        new Column{ Name = "From", Width = 150, ClientFormat = "<span class='awe-nonselect readItem'>.From</span>"},
                        new Column{ Name = "Subject", Width = 150, ClientFormat = "<span class='awe-nonselect readItem'>.Subject</span>"},
                        new Column{ Name = "Body", ClientFormat = "<span class='awe-nonselect readItem'>.Body</span>"},
                        new Column{ Name = "DateReceived", Sort = Sort.Desc, Width = 100},
                    })%>
    
    <input type="hidden" id="toReadId"/>
    
        <script type="text/javascript">
            function getIds() {
                return $.map($('#MessagesGrid').data('api').getSelection(), function (o) { return o.Id; });
            }

            function refreshGrid() {
                $('#MessagesGrid').data('api').load();
            }

            $(function () {
                //buttons
                $('#btnMarkRead').click(function () {
                    $.ajax({
                        type: 'post',
                        url: '<%:Url.Action("MarkRead") %>',
                    data: { ids: getIds() },
                    traditional: true,
                    success: refreshGrid
                });
            });

            $('#btnMarkUnread').click(function () {
                $.ajax({
                    type: 'post',
                    url: '<%:Url.Action("MarkUnread") %>',
                    data: { ids: getIds() },
                    traditional: true,
                    success: refreshGrid
                });
            });

            $('#btnDelete').click(function () {
                $.ajax({
                    type: 'post', url: '<%:Url.Action("Delete") %>', data: { ids: getIds() }, traditional: true,
                    success: refreshGrid
                });
            });

            $('#btnSelectRead').click(function () {
                $('#MessagesGrid .awe-row').removeClass('awe-selected').each(function (ix, item) {
                    if ($(item).data('model').IsRead) {
                        $(item).addClass('awe-selected');
                    }
                }).trigger('aweselect');
            });

            $('#btnSelectUnread').click(function () {
                $('#MessagesGrid .awe-row').removeClass('awe-selected').each(function (ix, item) {
                    if (!$(item).data('model').IsRead) {
                        $(item).addClass('awe-selected');
                    }
                }).trigger('aweselect');
            });

            $('#btnDeselectAll').click(function () {
                $('#MessagesGrid .awe-row').removeClass('awe-selected');
            }).trigger('aweselected');

            // grid row click
            $('#MessagesGrid').on('click', '.readItem', function () {
                var row = $(this).closest('.awe-row');
                var id = row.data('model').Id;
                $('#toReadId').val(id);
                var event = {};// needed for the next line which renders a js function call with event as first parameter
                <%:Url.Awe().PopupAction().Url(Url.Action("ReadMessage")).Parent("toReadId", "id")%>;
                refreshGrid();
            });

            //mantain selection after refresh
            var lastSelectedIds;
            $('#MessagesGrid').on('aweselect', function () {
                lastSelectedIds = $.map($(this).data('api').getSelection(), function (val) { return val.Id; });
            });

            $('#MessagesGrid').on('aweload', function () {
                if (lastSelectedIds) {
                    $(this).find('.awe-row').each(function (i, row) {
                        if ($.inArray($(row).data('model').Id, lastSelectedIds) > -1) {
                            $(row).addClass('awe-selected');
                        }
                    }).trigger('aweselect');
                }
            });
        });
    </script>

    <style>
        .readItem {
            cursor: pointer;
        }

        .notRead .readItem {
            font-weight: bold;
        }
    </style>
</asp:Content>
