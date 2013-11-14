<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" MasterPageFile="~/Views/Shared/Site.Master" %>
<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent"></asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    
<%:Html.Awe().AjaxRadioList("Category")
.Controller<CategoryAjaxRadioListController>()
.HtmlAttributes(new { style="border:1px solid green;"}, new {id = "abc1", name="xyz1"}) %>

<%:Html.Awe().AjaxDropdown("Category").CssClass("tst").HtmlAttributes(new{ style="color:blue;", @class="tst1"}).Prefix("Cp") %>
<br/>
<br/>
<%:Html.Awe().Autocomplete("Meal").CssClass("test").HtmlAttributes(new { style = "color:blue;", @class = "tst1" })%><br/>
<br/>
<br/>
    <%
        var x = Html.Awe().PopupActionLink().LinkText("ya").Content("hi <b> aaaa </b>").Name("aaa").Position("bottom");
         %>
    <%:Html.Awe().PopupActionLink()
    .Title("hi there ' \" <div> hi there </div> <button>asd</button> "+x)
    .LinkText("hi there ' \" good <span>zzz</span>"+x)
    .Content("hi content <hr/> <br/> <b> hi </b>"+x)
    .HtmlAttributes(new {style="color:green;font-weight:bold;"})%>
    
    <br/>
    <br/>
    <%:Html.Awe().TextBox("FName")
                    .HtmlAttributes(new { atr1 = "fo", data_bar = "fo1"})
                    .HtmlAttributes(new Dictionary<string, object> {{"data-bar3",123}, {"data-bar2","bar2"}}) %>
    <br/>

    <%:Html.Awe().PopupFormActionLink()
                .Title("hi ' \" <b>assd</b>")
                .LinkText("popupform <b>aaa</b> ' \" aa")
                .OkText("Ok ' \" <b>aa<b/>")
                .CancelText("Cancel ' \"<b> aa</b>")
                .Url(Url.Action("Create","Meals"))
                .HtmlAttributes(new{style="color:purple;"})%>
                <br/>
                <br/>
                <%=Html.Awe().Grid("Grid")
                .CssClass("c1")
                .HtmlAttributes(new {style="border:1px solid green;"})
                .GroupBarText("hi <button type='button'>hi</button>, asdf ' \" a")
                .Columns(
                    new Column{Name = "Id", Width = 50},
                    new Column{Name = "Person", PercentWidth = 17, Header = "hi' there\""},
                    new Column{Name = "Food", PercentWidth = 17, },
                    new Column{Name = "Location", Width = 150},
                    new Column{Name = "Date", Width = 150},
                    new Column{Name = "Country.Name", ClientFormat = ".CountryName", Header = "Country"},
                    new Column{Name = "Chef.FirstName,Chef.LastName", ClientFormat = ".ChefName", Header="Chef"}
                )
                .Url(Url.Action("GetItems", "LunchGrid"))
    %>

    <br/>
    <br/>
    <br/>
    <%:Html.Awe().AjaxList("Meals").HtmlAttributes(new { style = "width:50%; border:1px solid blue;", data_role = "listview", data_inset = "true", data_divider_theme = "h" })%>
    <br />
    <br />
</asp:Content>
