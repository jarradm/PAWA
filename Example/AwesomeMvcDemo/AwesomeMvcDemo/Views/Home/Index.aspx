<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="AwesomeMvcDemo.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ASP.net MVC Awesome Demo Application - Overview
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        select { width: 100px; }
    </style>

    <h3>Overview of the awesome helpers</h3>
    awesome helpers are built for rapid development of highly responsive ajax web applications, this is a quick overview of the awesome helpers:
    <br />
    <br />
    Cascading components:<br/>
    <div style="display: inline-block;width: 220px;">
    <%:Html.Awe().AjaxDropdown("ParentCategory")
                 .Url(Url.Action("GetItems","CategoryAjaxDropdown")) %>
    
    <%:Html.Awe().AjaxDropdown("ChildMeal")
                    .Parent("ParentCategory")
                    .Url(Url.Action("GetItems","MealAjaxDropdown")) %>
    </div>
    <div style="display:inline-block;width: 200px;">
         <%:Html.Awe().AjaxRadioList("ParentCategory2")
                 .Url(Url.Action("GetItems","CategoryAjaxDropdown"))
                 .Value(Db.Categories.First().Id)%>

            <%:Html.Awe().AjaxCheckboxList("Meals2")
                 .Parent("ParentCategory2")
                 .Controller<MealOfManyController>()%>
    </div>
    <div style="display:inline-block;">
    <%:Html.Awe().AjaxCheckboxList("Categories").Value(Db.Categories.First().Id) %>
                
    <%:Html.Awe().AjaxRadioList("ChildOfManyMealRadioList")
                        .Controller<MealBoundToManyController>()
                        .Parent("Categories")
                        .Parent("txtMealName","mealName")%>
        </div>
    <br />
    <br />
    <div class="efield">
        <div class="elabel">
            Lookup:</div>
        <%:Html.Awe().Lookup("Meal")
        .HighlightChange(true)
        %>
    </div>
    <div class="efield">
        <div class="elabel">
            Multilookup:</div>
        <%:Html.Awe().MultiLookup("Meals").HighlightChange(true).Prefix("page") %>
    </div>
    <div class="efield">
        <div class="elabel">
            DatePicker:</div>
        <%=Html.Awe().DatePicker("Date1").ChangeMonth(true).ChangeYear(true) %>
    </div>
    
    <br />
    <br />
    awesome Grid bound to 2 textboxes for search, persistence set to session (try grouping, collapse some groups and hit refresh or go to another page and come back), 
    columns are bound to properties of the model (Model.Food), subproperties (Model.Country.Name) and to multiple properties/subproperties (Model.Chef.FirstName, Model.Chef.LastName) :<br />
    <br/>  
        Person:<%:Html.Awe().TextBox("txtperson").Placeholder("search for person ...") %>
        Food:<%:Html.Awe().TextBox("txtfood").Placeholder("search for food ...")%>        
        <button type="button" class="awe-btn">search</button>

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
                .PersistenceKey("mainDemo")
                .Height(300)
                .PageSize(10)
                .Parent("txtperson","person")
                .Parent("txtfood","food")
    %>
    <br />
    <br />
    ajaxlist with table layout and custom item template, 
    inside the template PopupForm is used for the Edit button, 
    Form with confirm option is used for the Delete button
    <br />
    <br />

    <script type="text/javascript">
        function create(o) {
            $('#Dinners').parent().find('tbody').prepend(o.Content);
        }
        function edit(o) {
            $('#dinner' + o.Id).fadeOut(300, function () { $(this).after(o.Content).remove(); });
        }
        function del(o) {
            $('#dinner' + o.Id).fadeOut(300, function () { $(this).remove(); });
        }
    </script>
    <div style="margin-bottom: 3px;">
    <%:Html.Awe().TextBox("sname").Placeholder("search...").HtmlAttributes(new{style="float:right;"}) %>
        
    <button class="awe-btn" type="button" onclick="<%:Url.Awe().PopupFormAction().Url(Url.Action("Create","Dinners")).Success("create").Title("create dinner") %>">
        Create</button>
        </div>
    <div style="min-height: 300px;">
        <%:Html.Awe().AjaxList("Dinners").TableLayout(true).Parent("sname", "search").Parameter("pageSize",5) %>
    </div>
    <%:Html.Awe()
            .Form()
            .FormClass("confirm")
            .Confirm(true)
            .Success("del") %>
</asp:Content>
