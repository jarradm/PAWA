 <%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<GridDemoCfgInput>" %>
<%--begin--%>
    <%=Html.Awe().Grid("Grid")
                .Columns(
                    new Column{Name = "Id", Width = 55, Groupable = false},
                    new Column{Name = "Person"},
                    new Column{Name = "Food"},
                    new Column{Name = "Location"},
                    new Column{Name = "Date", PercentWidth = 12},
                    new Column{Name = "Country.Name", ClientFormat = ".CountryName", Header = "Country"},
                    new Column{Name = "Chef.FirstName,Chef.LastName", ClientFormat = ".ChefName", Header="Chef"}
                )
                .Url(Url.Action("GetItems", "LunchGrid"))
                .Persistence(Persistence.Session)
                .Sortable(Model.Sortable)
                .Groupable(Model.Groupable)
                .SingleColumnSort(Model.SingleColumnSorting)
                .ShowGroupedColumn(Model.ShowGroupedColumn)
                .Height(Model.Height)
                .MinHeight(Model.MinHeight)
                .Parent("txtperson","person") /* binds to person */
                .Parent("txtfood","food") /* binds to food */
                .Parent("PageSize","PageSize") /* binds to GridParams.PageSize*/
    %><%--end--%>