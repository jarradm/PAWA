<%@ Page Title="Title" Language="C#" Inherits="System.Web.Mvc.ViewPage<AwesomeMvcDemo.ViewModels.UnobstrusiveInput>" MasterPageFile="~/Views/Shared/Site.Master" %>
<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent"></asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    <script type="text/javascript">
        function f1() {
            $(this).dialog('close');
        }
    </script>
   
    <% using (Html.BeginForm())
       {%>
       <div class="efield">
        <div class="elabel">
            <%:Html.LabelFor(o => o.Name) %>
        </div>
        <div class="einput">
            <%:Html.Awe().TextBoxFor(o => o.Name).Placeholder("type something...").MaxLength(13)
            .HtmlAttributes(new { style="border:1px solid green;", id = "Nameqwe" })
            .HtmlAttributes(new Dictionary<string, object>{{"data-nr", 1}})%>
        </div>
        <%:Html.ValidationMessageFor(o => o.Name)%>
    </div>
    
    <div class="efield">
        <div class="elabel">
            <%:Html.LabelFor(o => o.Number) %>
        </div>
        <div class="einput">
            <%:Html.Awe().TextBoxFor(o => o.Number).Placeholder("only numbers here").Numeric(true).MaxLength(7)
            .HtmlAttributes(new { style="border:1px solid green;" })
            .HtmlAttributes(new Dictionary<string, object>{{"data-nr", 1}})%>
        </div>
        <%:Html.ValidationMessageFor(o => o.Number)%>
    </div>
    <div class="efield">
        <div class="elabel">
            <%:Html.LabelFor(o => o.MealAuto) %>
        </div>
        <div class="einput">
            <%:Html.Awe().AutocompleteFor(o => o.MealAuto).Placeholder("type Banana or Mango ...").MaxLength(7)
            .HtmlAttributes(new { style="border:1px solid green;", id="MealAutoqwe" })
            .HtmlAttributes(new Dictionary<string, object>{{"data-nr", 1}})
            .Controller<MealAutocompleteController>() %>
        </div>
        <%:Html.ValidationMessageFor(o => o.MealAuto) %>
    </div>
    <div class="efield">
        <div class="elabel">
            <%:Html.LabelFor(o => o.Date) %>
        </div>
        <div class="einput">
            <%:Html.Awe().DatePickerFor(o => o.Date)
            .HtmlAttributes(new { style="border:1px solid green;" }, new { id="Dateqwe" })
            .HtmlAttributes(new Dictionary<string, object>{{"data-nr", 1}}, new Dictionary<string, object>{{"data-nr", 2}})%>
        </div>
        <%:Html.ValidationMessageFor(o => o.Date) %>
    </div>
    <div class="efield">
        <div class="elabel">
            <%:Html.LabelFor(o => o.Categories) %>
        </div>
        <div class="einput">
            <%:Html.Awe().AjaxCheckboxListFor(o => o.Categories)
            .HtmlAttributes(new { style="border:1px solid green;" }, new { id="Categoriesqwe" })
            .HtmlAttributes(new Dictionary<string, object>{{"data-nr", 1}}, new Dictionary<string, object>{{"data-nr", 2}})%>
        </div>
        <%:Html.ValidationMessageFor(o => o.Categories) %>
    </div>
    <div class="efield">
        <div class="elabel">
            <%:Html.LabelFor(o => o.Category2) %>
        </div>
        <div class="einput">
            <%:Html.Awe().AjaxRadioList("Category2")
            .Controller<CategoryAjaxDropdownController>()
            .HtmlAttributes(new { style="border:1px solid green;" }, new { id="Category2zczx" })
            .HtmlAttributes(new Dictionary<string, object>{{"data-nr", 1}}, new Dictionary<string, object>{{"data-nr", 2}})
                         %>
        </div>
        <%:Html.ValidationMessage("Category2") %>
    </div>
    <div class="efield">
        <div class="elabel">
            <%:Html.LabelFor(o => o.CategoryFo) %>
        </div>
        <div class="einput">
            <%:Html.Awe().AjaxDropdownFor(o => o.CategoryFo)
            .HtmlAttributes(new { style="border:1px solid green;" }, new { id="CategoryFoqwe" })
            .HtmlAttributes(new Dictionary<string, object>{{"data-nr", 1}}, new Dictionary<string, object>{{"data-nr", 2}}) %>
        </div>
        <%:Html.ValidationMessageFor(o => o.CategoryFo) %>
    </div>
    <div class="efield">
        <div class="elabel">
            <%:Html.LabelFor(o => o.Meal) %>
        </div>
        <div class="einput">
            <%:Html.Awe().LookupFor(o => o.Meal).ClearButton(true)
            .HtmlAttributes(new { style="border:1px solid green;" }, new { id="Mealqwe" })
            .HtmlAttributes(new Dictionary<string, object>{{"data-nr", 1}}, new Dictionary<string, object>{{"data-nr", 2}})%>
        </div>
        <%:Html.ValidationMessageFor(o => o.Meal)%>
    </div>    
    <div class="efield">
        <div class="elabel">
            <%:Html.LabelFor(o => o.Meals) %>
        </div>
        <div class="einput">
            <%:Html.Awe().MultiLookupFor(o => o.Meals).ClearButton(true).Fullscreen(true).DragAndDrop(true)
            .HtmlAttributes(new { style="border:1px solid green;" }, new { id="Mealsqwe" })
            .HtmlAttributes(new Dictionary<string, object>{{"data-nr", 1}}, new Dictionary<string, object>{{"data-nr", 2}})%>
        </div>
        <%:Html.ValidationMessageFor(o => o.Meals) %>
    </div>
    <div class="esubmit">
        <input type="submit" value="submit" class="awe-btn" />
    </div>
    <%}%>
</asp:Content>
