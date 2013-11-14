<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<GridHideColumnsDemoInput>" %>
<%--begin--%>
    <%
        var columns = new List<Column>
                          {
                              new Column {Name = "Id", Width = 70, Groupable = false}, 
                              new Column {Name = "Person"}
                          };

        if(Model.ShowFood)
        columns.Add(new Column { Name = "Food"});
        
        if(Model.ShowLocation)
        columns.Add(new Column { Name = "Location" });
        
        if(Model.ShowDate)
        columns.Add(new Column { Name = "Date" });
    %>

    <%:Html.Awe().Grid("HideColumnsDemoGrid")
                .Url(Url.Action("GetItems","LunchGrid"))
                .Columns(columns.ToArray())
    %>
<%--end--%>