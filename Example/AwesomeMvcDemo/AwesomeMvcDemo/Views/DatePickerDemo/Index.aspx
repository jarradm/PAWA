<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<AwesomeMvcDemo.ViewModels.DatePickerDemoInput>"
    MasterPageFile="~/Views/Shared/Site.Master" %>

<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">
    DatePicker Demo
</asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    <h3>
        Simple DatePicker</h3>
    <div class="efield">
        <div class="elabel">
            Date:</div>
        <div class="einput">
            <%--begin--%>
            <%=Html.Awe().DatePickerFor(o => o.Date) %>
            <%--end--%>
        </div>
        <pre>
<%:Html.Source("DatePickerDemo/Index.aspx") %></pre>
    </div>
    <h3>
        With ChangeMonth and ChangeYear</h3>
    <div class="efield">
        <div class="elabel">
            Date:</div>
        <div class="einput">
            <%--begin1--%>
            <%=Html.Awe().DatePickerFor(o =>o.Date2).ChangeMonth(true).ChangeYear(true) %>
            <%--end1--%>
        </div>
        <pre>
<%:Html.Source("DatePickerDemo/Index.aspx","1") %>
</pre>
    </div>
    <h3>
        Min, max, default date, clear button </h3>
    <div class="efield">
        <div class="elabel">
            Date:</div>
        <div class="einput">
            <%--begin2--%>
            <%=Html.Awe().DatePickerFor(o =>o.Date3)
                        .MinDate(DateTime.Now.AddDays(1))
                        .MaxDate(DateTime.Now.AddDays(7))
                        .DefaultDate(DateTime.Now.AddDays(4))
                        .ClearButton(true) %>
            <%--end2--%>
        </div>
        <pre>
<%:Html.Source("DatePickerDemo/Index.aspx","2") %></pre>
    </div>
    
    <h3>
        Right to left </h3>
    <div class="efield">
        <div class="elabel">
            Date:</div>
        <div class="einput">
            <%--begin3--%>
            <%=Html.Awe().DatePickerFor(o =>o.Date4)
                        .IsRtl(true) %>
            <%--end3--%>
        </div>
        <pre>
<%:Html.Source("DatePickerDemo/Index.aspx","3") %></pre>
    </div>
</asp:Content>
