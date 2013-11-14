using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Omu.AwesomeMvc;

namespace AwesomeMvcDemo.ViewModels
{
    /*begin*/
    public class AttributesDemoInput
    {
        [UIHint("AjaxDropdown")]
        [AjaxDropdown(Controller = "CategoryFoAjaxdropdown")]
        [AwesomeParameters("{ foText: '- select -'}")]
        [Required]
        public int? Category1 { get; set; }

        [UIHint("AjaxDropdown")]
        [AdditionalMetadata("Controller", "CategoryAjaxDropdown")]
        [Required]
        public int? ParentCategory { get; set; }

        [UIHint("AjaxDropdown")]
        [AdditionalMetadata("Controller", "MealAjaxDropdown")]
        [AwesomeParents("{ parent: 'ParentCategory' }")]
        [Required]
        public int? ChildMeal { get; set; }

        [UIHint("AjaxRadioList")]
        [AwesomeParents("{ parent: 'ParentCategory' }")]
        [AdditionalMetadata("Controller", "MealAjaxDropdown")]
        [AjaxRadioList]
        [Required]
        public int? Meal1 { get; set; }

        [UIHint("Lookup")]
        [Lookup(ClearButton = true, Title = "this is a lookup with custom search", CustomSearch = true, Fullscreen = true)]
        [AdditionalMetadata("HighlightChange", true)]
        [Required]
        public int? MealCustomSearch { get; set; }

        [Required]
        [UIHint("MultiLookup")]
        [MultiLookup(ClearButton = true, Controller = "MealsMultiLookup", DragAndDrop = true, Title = "select some stuff", Fullscreen = true)]
        public IEnumerable<int> SomeMeals { get; set; }

        [Required]
        [UIHint("AjaxCheckboxList")]
        [AjaxCheckBoxList(Controller = "CategoriesAjaxCheckBoxList")]
        public IEnumerable<int> SomeCategories { get; set; }

        public int? MealId { get; set; }

        [UIHint("Autocomplete")]
        [Autocomplete(Controller = "MealAutocomplete", Prefix = "eg", MinLength = 2, Delay = 500, PropId = "MealId")]
        [AdditionalMetadata("Placeholder", "try Ma Ap")]
        [Required]
        public string MealAuto { get; set; }

        [AdditionalMetadata("Placeholder", "please pick date")]
        public DateTime? Date { get; set; }
    }
    /*end*/
}