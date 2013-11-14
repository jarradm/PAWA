<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<GridDemoSortingCfgInput>" %>
<%--begin--%>
<%=Html.Awe().Grid("Fe")
    .Columns(new[]{
        new Column{Name = "Id", Width = 55},
        new Column{Name = "Person", PercentWidth = 18, 
            Sortable = Model.PersonSortable, SortRank = Model.PersonRank, Sort = Model.PersonSort},
        new Column{Name = "Food", PercentWidth = 18, 
            Sortable = Model.FoodSortable, SortRank = Model.FoodRank, Sort = Model.FoodSort},
        new Column{Name = "Date", Width = 100},
        new Column{Name = "Price", Width = 80, ClientFormat = ".Price£"},
        new Column{Name = "Location", Width = 150}
    })
    .Height(350)
    .SingleColumnSort(Model.SingleColumnSort)
    .Sortable(Model.Sortable)
    .Parameter("pageSize", Model.PageSize)
    .PersistenceKey("gridSorting")
    .Url(Url.Action("GetItems","LunchGrid"))
%>
<%--end--%>
