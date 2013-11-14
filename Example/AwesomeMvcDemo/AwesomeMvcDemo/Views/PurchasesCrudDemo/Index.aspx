<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>"
    MasterPageFile="~/Views/Shared/Site.Master" %>

<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">
    Awesome Grid Crud Demo
</asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    <%--begin--%>
    <h3>Grid crud Demo</h3>

    <button type="button" onclick="<%:Url.Awe().PopupFormAction()
                .Url(Url.Action("Create"))
                .Success("refreshGrid")%>"
        class="awe-btn">
        Create</button>

    <%
        // these will be used for the grid actions
        var deleteFormat =
        string.Format("<form action='{0}' class='deleteForm'><button class='awe-btn' type='submit'><span class='ico-del'></span></button></form>",
        Url.Action("Delete", new { Id = ".Id" }));

        var editFormat = string.Format("<button type='button' class='awe-btn' onclick=\"{0}\"><span class='ico-edit'></span></button>",
            Url.Awe().PopupFormAction()
                .Url(Url.Action("Edit", new { Id = ".Id" }))
                .Success("refreshGrid"));
    %>

    <%--this will make the forms with class 'deleteForm' to be confirmed, submitted via ajax, 
        and the result will be sent to the refreshGrid js function--%>
    <%:Html.Awe().Form().FormClass("deleteForm").Confirm(true).Success("refreshGrid") %>

    <script type="text/javascript">
        function refreshGrid() {
            $('#PurchasesGrid').data('api').load({});
        }
    </script>
    <div style="float: right;">
    <%:Html.Awe().TextBox("txtSearch").Placeholder("search...") %>
    <button type="button" class="awe-btn">search</button>
        </div>
    <%:Html.Awe().Grid("PurchasesGrid")
                .Url(Url.Action("GetItems","PurchasesGrid"))
                .Columns(
                        new Column{Name = "Id", Width = 55},
                        new Column{Name="Customer", },
                        new Column{Name="Product", PercentWidth = 30},
                        new Column{Name="Quantity",Width = 100},
                        new Column{Name="Date", Width = 100},
                        new Column{ClientFormat = editFormat, Width = 50},
                        new Column{ClientFormat = deleteFormat, Width = 50 }
                    )
                    .Parent("txtSearch","search")
    %>

    <%--end--%>
    <div class="code">
        <pre><%:Html.Source("PurchasesCrudDemo/Index.aspx") %></pre>
        <pre><%:Html.Csource("PurchasesGridController.cs") %></pre>
    </div>
</asp:Content>
