<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<GridDemoCfgInput>" %>
<%--begin--%>
<%=Html.Awe().Grid("Lunches")
                .Columns(new[]{
                    new Column{Name = "Id", Width = 55},
                    new Column{Name = "Person", PercentWidth = 19},
                    new Column{Name = "Food", PercentWidth = 19},
                    new Column{Name = "Location", Width = 150, Group = true},
                    new Column{Name = "Price", Width = 80},
                    new Column{Name = "Date", Width = 100},
                    new Column{ClientFormat=".Person had .Food"}
                })
                .PersistenceKey("c1")
                .Url(Url.Action("GetItems","LunchGrid"))
%>
<%--end--%>