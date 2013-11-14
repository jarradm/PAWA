<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<GridDemoGroupingCfgInput>" %>
<%--begin--%>
<%=Html.Awe().Grid("Lunches")
    .Columns(new[]{
        new Column{Name = "Id", Width = 55},
        new Column{Name = "Person", PercentWidth = 19, Group = Model.PersonGrouped, 
            GroupRemovable = Model.PersonRem, Groupable = Model.PersonGroupable, GroupRank = Model.PersonRank},
        new Column{Name = "Food", PercentWidth = 19, Group = Model.FoodGrouped, 
            GroupRemovable = Model.FoodRem, Groupable = Model.FoodGroupable, GroupRank = Model.FoodRank},
        new Column{Name = "Date", Width = 150},
        new Column{Name = "Price", Width = 80},
        new Column{Name = "Location", Width = 150}
    })
    .Height(450)
    .ShowGroupBar(Model.ShowGroupBar)
    .Groupable(Model.Groupable)
    .ShowGroupedColumn(Model.ShowGroupedColumn)
    .PageSize(Model.PageSize) // binds to GridParams.PageSize
    .Parameter("collapsed", Model.Collapsed)
    .Persistence(Persistence.Session)
    .PersistenceKey("p1")
    .Url(Url.Action("GetItems","GroupingGrid"))
%>
<%--end--%>
