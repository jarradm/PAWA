using System.Collections.Generic;

namespace AwesomeMvcDemo.Controllers
{
    public class MySiteMap
    {
        public static readonly IEnumerable<SiteMapItem> Items = new[]
        {
            new SiteMapItem{Title = "Quick View", Controller = "GridDemo", Action = "Index", GroupId = 1, GroupTitle = "Grid"},
            new SiteMapItem{Title = "Grouping/Aggregates", Controller = "GridDemo", Action = "Grouping", GroupId = 1, GroupTitle = "Grid"},
            new SiteMapItem{Title = "Sorting", Controller = "GridDemo", Action = "Sorting", GroupId = 1, GroupTitle = "Grid"},
            new SiteMapItem{Title = "Client Side API", Controller = "GridDemo", Action = "ClientSideApi", GroupId = 1, GroupTitle = "Grid"},
            new SiteMapItem{Title = "Custom Querying", Controller = "GridDemo", Action = "CustomQuerying", GroupId = 1, GroupTitle = "Grid"},
            new SiteMapItem{Title = "Custom Format", Controller = "GridDemo", Action = "CustomFormat", GroupId = 1, GroupTitle = "Grid"},
            new SiteMapItem{Title = "RTL Support", Controller = "GridDemo", Action = "RTLSupport", GroupId = 1, GroupTitle = "Grid"},
            new SiteMapItem{Title = "Selection", Controller = "GridDemo", Action = "Selection", GroupId = 1, GroupTitle = "Grid"},
            
            new SiteMapItem{Title = "Quick View", Controller = "LookupDemo", Action = "Index", GroupId = 2, GroupTitle = "Lookup"},
            new SiteMapItem{Title = "Custom Search", Controller = "LookupDemo", Action = "CustomSearch", GroupId = 2, GroupTitle = "Lookup"},
            new SiteMapItem{Title = "Misc", Controller = "LookupDemo", Action = "Misc", GroupId = 2, GroupTitle = "Lookup"},

            new SiteMapItem{Title = "Quick View", Controller = "MultiLookupDemo", Action = "Index", GroupId = 3, GroupTitle = "MultiLookup"},
            new SiteMapItem{Title = "Custom Search", Controller = "MultiLookupDemo", Action = "CustomSearch", GroupId = 3, GroupTitle = "MultiLookup"},
            new SiteMapItem{Title = "Misc", Controller = "MultiLookupDemo", Action = "Misc", GroupId = 3, GroupTitle = "MultiLookup"},
            
            new SiteMapItem{Title = "AjaxDropdown", Controller = "AjaxDropdownDemo", Action = "Index", GroupId = 4, GroupTitle = "Awesome"},
            new SiteMapItem{Title = "AjaxRadioList", Controller = "AjaxRadioListDemo", Action = "Index", GroupId = 4, GroupTitle = "Awesome"},
            new SiteMapItem{Title = "AjaxCheckBoxList", Controller = "AjaxCheckBoxListDemo", Action = "Index", GroupId = 4, GroupTitle = "Awesome"},
            new SiteMapItem{Title = "Autocomplete", Controller = "AutocompleteDemo", Action = "Index", GroupId = 4, GroupTitle = "Awesome" },
            new SiteMapItem{Title = "Popup", Controller = "PopupDemo", Action = "Index", GroupId = 4, GroupTitle = "Awesome"},
            new SiteMapItem{Title = "PopupForm", Controller = "PopupFormDemo", Action = "Index", GroupId = 4, GroupTitle = "Awesome"},
            new SiteMapItem{Title = "DatePicker", Controller = "DatePickerDemo", Action = "Index", GroupId = 4, GroupTitle = "Awesome"},
            new SiteMapItem{Title = "TextBox", Controller = "TextBoxDemo", Action = "Index", GroupId = 4, GroupTitle = "Awesome"},
            new SiteMapItem{Title = "Form", Controller = "FormDemo", Action = "Index", GroupId = 4, GroupTitle = "Awesome"},
            new SiteMapItem{Title = "Pager", Controller = "PagerDemo", Action = "Index", GroupId = 4, GroupTitle = "Awesome"},

            new SiteMapItem{Title = "Quick View", Controller = "AjaxListDemo", Action = "Index", GroupId = 5, GroupTitle = "AjaxList"},
            new SiteMapItem{Title = "Custom Item Template", Controller = "AjaxListDemo", Action = "CustomItemTemplate", GroupId = 5, GroupTitle = "AjaxList"},
            new SiteMapItem{Title = "Table Layout", Controller = "AjaxListDemo", Action = "TableLayout", GroupId = 5, GroupTitle = "AjaxList"},
            new SiteMapItem{Title = "Client Side API", Controller = "AjaxListDemo", Action = "ClientSideApi", GroupId = 5, GroupTitle = "AjaxList"},
            
            new SiteMapItem{Title = "Unobtrusive validation", Controller = "Unobtrusive", Action = "Index", GroupId = 100, GroupTitle = "Misc"},
            new SiteMapItem{Title = "List Binding", Controller = "ListBinding", Action = "Index", GroupId = 100, GroupTitle = "Misc"},
            new SiteMapItem{Title = "Attributes Demo", Controller = "AttributesDemo", Action = "Index", GroupId = 100, GroupTitle = "Misc"},
            new SiteMapItem{Title = "Error Handling", Controller = "ErrorHandlingDemo", Action = "Index", GroupId = 100, GroupTitle = "Misc"},
            new SiteMapItem{Title = "CRUD inside Lookup", Controller = "CrudInLookup", Action = "Index", GroupId = 100, GroupTitle = "Misc"},
            new SiteMapItem{Title = "Grid Crud Demo", Controller = "PurchasesCrudDemo", Action = "Index", GroupId = 100, GroupTitle = "Misc"},
            new SiteMapItem{Title = "Grid Mailbox Demo", Controller = "MailboxDemo", Action = "Index", GroupId = 100, GroupTitle = "Misc"},
            new SiteMapItem{Title = "AjaxList Crud Demo", Controller = "Meals", Action = "Index", GroupId = 100, GroupTitle = "Misc"},
            new SiteMapItem{Title = "Wizard Demo", Controller = "WizardDemo", Action = "Index", GroupId = 100, GroupTitle = "Misc"},
            new SiteMapItem{Title = "Cacading Grids", Controller = "CascadingGridDemo", Action = "Index", GroupId = 100, GroupTitle = "Misc"},
            new SiteMapItem{Title = "Spreadsheet Grid", Controller = "GridSpreadsheetDemo", Action = "Index", GroupId = 100, GroupTitle = "Misc"},
            new SiteMapItem{Title = "Grid mantain selection", Controller = "GridMantainSelectionDemo", Action = "Index", GroupId = 100, GroupTitle = "Misc"},
            new SiteMapItem{Title = "Grid export to excel", Controller = "GridExportToExcelDemo", Action = "Index", GroupId = 100, GroupTitle = "Misc"},
            new SiteMapItem{Title = "Grid choose columns", Controller = "GridChooseColumnsDemo", Action = "Index", GroupId = 100, GroupTitle = "Misc"},
            new SiteMapItem{Title = "Grid show hide columns", Controller = "GridShowHideColumnsDemo", Action = "Index", GroupId = 100, GroupTitle = "Misc"},
            new SiteMapItem{Title = "Master Detail demo", Controller = "MasterDetailCrudDemo", Action = "Index", GroupId = 100, GroupTitle = "Misc"},
        };
    }
}