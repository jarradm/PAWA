<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" MasterPageFile="~/Views/Shared/Site.Master" %>
<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent"></asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    
     <%:Html.Awe().Grid("CustomFormat")
                .Height(350)
                .Columns(
                new Column { Name = "Person", ClientFormat = ".Person was at .Location"},
                new Column { ClientFormat=".Person had .Food" },
                new Column { ClientFormatFunc = "formatPrice" },
                new Column { ClientFormatFunc = "makeFunc('£')" },
                new Column { ClientFormatFunc="makeFunc('$')" })
                %>
                <script type="text/javascript">
                    function formatPrice(lunch) {
                        var color = 'blue';
                        if (lunch.Price < 20) color = 'green';
                        if (lunch.Price > 50) color = 'red';
                        return "<div style='color:" + color + ";text-width:bold;'>" + lunch.Price + "£ </div>";
                    }

                    function makeFunc(p) {
                        return function (model, prop) {
                            return model.Price + " " + p;
                        };
                    }
                </script>
</asp:Content>
