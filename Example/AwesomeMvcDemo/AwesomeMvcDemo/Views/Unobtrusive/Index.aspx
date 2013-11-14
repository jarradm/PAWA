<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AwesomeMvcDemo.ViewModels.UnobstrusiveInput>" %>
<asp:Content ID="aboutTitle" ContentPlaceHolderID="TitleContent" runat="server">
    ASP.net MVC Awesome Unobtrusive validation demo
</asp:Content>
<asp:Content ID="aboutContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>
        Unobtrusive Validation Demo</h3>    
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
            <%:Html.Awe().TextBoxFor(o => o.Name).Placeholder("type something...").MaxLength(13) %>
        </div>
        <%:Html.ValidationMessageFor(o => o.Name)%>
    </div>
    
    <div class="efield">
        <div class="elabel">
            <%:Html.LabelFor(o => o.Number) %>
        </div>
        <div class="einput">
            <%:Html.Awe().TextBoxFor(o => o.Number).Placeholder("only numbers here").Numeric(true).MaxLength(7) %>
        </div>
        <%:Html.ValidationMessageFor(o => o.Number)%>
    </div>
    <div class="efield">
        <div class="elabel">
            <%:Html.LabelFor(o => o.MealAuto) %>
        </div>
        <div class="einput">
            <%:Html.Awe().AutocompleteFor(o => o.MealAuto).Placeholder("type Banana or Mango ...").MaxLength(7)
            .Controller<MealAutocompleteController>() %>
        </div>
        <%:Html.ValidationMessageFor(o => o.MealAuto) %>
    </div>
    <div class="efield">
        <div class="elabel">
            <%:Html.LabelFor(o => o.Date) %>
        </div>
        <div class="einput">
            <%:Html.EditorFor(o => o.Date)%>
        </div>
        <%:Html.ValidationMessageFor(o => o.Date) %>
    </div>
    <div class="efield">
        <div class="elabel">
            <%:Html.LabelFor(o => o.Categories) %>
        </div>
        <div class="einput">
            <%:Html.Awe().AjaxCheckboxListFor(o => o.Categories) %>
        </div>
        <%:Html.ValidationMessageFor(o => o.Categories) %>
    </div>
    <div class="efield">
        <div class="elabel">
            <%:Html.LabelFor(o => o.Category2) %>
        </div>
        <div class="einput">
            <%:Html.Awe().AjaxRadioListFor(o => o.Category2)
                        .Controller<CategoryAjaxDropdownController>() %>
        </div>
        <%:Html.ValidationMessageFor(o => o.Category2) %>
    </div>
    <div class="efield">
        <div class="elabel">
            <%:Html.LabelFor(o => o.CategoryFo) %>
        </div>
        <div class="einput">
            <%:Html.Awe().AjaxDropdownFor(o => o.CategoryFo) %>
        </div>
        <%:Html.ValidationMessageFor(o => o.CategoryFo) %>
    </div>
    <div class="efield">
        <div class="elabel">
            <%:Html.LabelFor(o => o.Meal) %>
        </div>
        <div class="einput">
            <%:Html.Awe().LookupFor(o => o.Meal).ClearButton(true)%>
        </div>
        <%:Html.ValidationMessageFor(o => o.Meal)%>
    </div>    
    <div class="efield">
        <div class="elabel">
            <%:Html.LabelFor(o => o.Meals) %>
        </div>
        <div class="einput">
            <%:Html.Awe().MultiLookupFor(o => o.Meals).ClearButton(true).Fullscreen(true).DragAndDrop(true) %>
        </div>
        <%:Html.ValidationMessageFor(o => o.Meals) %>
    </div>
    <div class="esubmit">
        <input type="submit" value="submit" class="awe-btn" />
    </div>
    <%}%>
    <h4>click the submit button to see the validation</h4>
    
</asp:Content>
