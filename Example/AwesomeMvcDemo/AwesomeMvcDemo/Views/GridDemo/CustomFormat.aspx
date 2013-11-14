<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<GridDemoCfgInput>" MasterPageFile="~/Views/Shared/Site.Master" %>
<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">
    ASP.net MVC Awesome Grid Custom Formatting Demo</asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    <h3>Grid Custom Format</h3>
<%--begin--%>
    <%:Html.Awe().Grid("CustomFormat")
                .Persistence(Persistence.Session)
                .Height(350)
                .Columns(
                new Column { Name = "Person", ClientFormat = ".Person was at .Location"},
                new Column { Name = "Food", ClientFormat = "<td style='color:maroon;'>and had .Food</td>" },
                new Column { Name = "Price", ClientFormatFunc = "formatPrice"},
                new Column { Name = "Date"},
                new Column { ClientFormat=".Person had .Food" })
                %>
                <script type="text/javascript">
                    function formatPrice(lunch) {
                        var color = 'blue';
                        if (lunch.Price < 20) color = 'green'; 
                        if (lunch.Price > 50) color = 'red';
                        return "<div style='color:" + color + ";text-width:bold;'>" + lunch.Price + "£ </div>";
                    }
                </script>
<%--end--%>

<pre>
<%:Html.Source("GridDemo/CustomFormat.aspx") %>
</pre>

<pre>
<%:Html.Csource("CustomFormatGridController.cs") %>

</pre>
    <div class="expl">
        <ul>
            <li><code>Column.ClientFormat</code> - Client format for the column defined as a string using .ModelPropertyName for including values of the row model,
        if the ClientFormat starts with &lt;td then grid rendering wont wrap the cell value with td (the ones in format will be used instead),
        this way additional html attributes can be added to the td tag (this attributes can contain .ModelProp)</li>
            <li><code>Column.ClientFormatFunc</code> - Defines the Name of a javascript function that will receive as a parameter the model (or mapped model) of the grid row and must return a string
        which will be used a value for the cell</li>
        </ul>
    </div>
</asp:Content>
