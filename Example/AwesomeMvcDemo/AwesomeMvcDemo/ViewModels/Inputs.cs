using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AwesomeMvcDemo.ViewModels
{
    public class CategoryInput
    {
        [Required]
        public string Name { get; set; }
    }

    public class LookupCrudInput
    {
        [Required]
        public int? Dinner { get; set; }
    }

    public class UnobstrusiveInput
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        public string MealAuto { get; set; }

        [Required]
        [AdditionalMetadata("Placeholder","pick a date")]
        public DateTime? Date { get; set; }

        [Required]
        public int? Fruit { get; set; }

        [Required]
        public int? Category2 { get; set; }

        [Required]
        [DisplayName("Category")]
        public int? CategoryFo { get; set; }

        [Required]
        public IEnumerable<int> Categories { get; set; }

        [Required]
        public int? Meal { get; set; }

        [Required]
        public IEnumerable<int> Meals { get; set; }
    }

    public class DatePickerDemoInput
    {
        public DateTime? Date { get; set; }

        public DateTime? Date2 { get; set; }

        public DateTime? Date3 { get; set; }

        public DateTime? Date4 { get; set; }
    }

    public class FormDemoInput
    {
        [Required]
        public string FName { get; set; }

        [Required]
        public string LName { get; set; }
    }

    public class SayInput
    {
        public string SaySomething { get; set; }
    }

    public class PurchaseInput
    {
        public int Id { get; set; }

        [Required]
        public string Customer { get; set; }

        [Required]
        public string Product { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime? Date { get; set; }
    }

    public class DinnerInput
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime? Date { get; set; }

        [UIHint("MultiLookup")]
        [Required]
        public IEnumerable<int> Meals { get; set; }

        [UIHint("Lookup")]
        [Required]
        public int? Chef { get; set; }
    }

    public class MealInput
    {
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int? Category { get; set; }

        public string Description { get; set; }
    }

    public class LookupDemoInput
    {
        public int? Meal { get; set; }

        public int? MealCustomSearch { get; set; }

        public int? MealCustomItem { get; set; }

        public int? MealTableLayout { get; set; }

        public int[] CategoriesData { get; set; }

        public int? Category { get; set; }

        public int? ChildOfMany { get; set; }

        public int? Meal1 { get; set; }

        public int? Meal2 { get; set; }
    }

    public class MultiLookupDemoInput
    {
        public int[] Meals { get; set; }
        public int[] MealsCustomSearch { get; set; }
        public int[] MealsCustomItem { get; set; }
        public int[] MealsTableLayout { get; set; }

        public int[] CategoriesData { get; set; }

        public int? Category { get; set; }

        public int[] ChildOfMany { get; set; }

        public int[] Meals1 { get; set; }
        public int[] Meals2 { get; set; }
    }

    public class AjaxDropdownDemoInput
    {
        public int? Category { get; set; }

        public int? ParentCategory { get; set; }

        public int? ChildMeal { get; set; }

        public int[] CategoriesData { get; set; }

        public int? CategoryData { get; set; }

        public int? ChildOfManyMeal { get; set; }

        public int? Meal1 { get; set; }
        public int? Meal2 { get; set; }
        public int? Meal3 { get; set; }

        public int? Category1 { get; set; }
    }

    public class AutocompleteDemoInput
    {
        public string Meal { get; set; }

        public string ParentCategory { get; set; }
        public int? ParentCategoryId { get; set; }

        public int PrimeNumber { get; set; }

        public string ChildMeal { get; set; }

        public int[] CategoriesData { get; set; }

        public int? CategoryData { get; set; }

        public string ChildOfManyMeal { get; set; }

        public string Meal1 { get; set; }
        public string Meal2 { get; set; }
    }

    public class AjaxCheckboxListDemoInput
    {
        public int[] Categories { get; set; }

        public int? ParentCategory { get; set; }

        public int[] ChildMeals { get; set; }

        public int[] CategoriesData { get; set; }

        public int? CategoryData { get; set; }

        public int[] ChildOfManyMeal { get; set; }

        [Required]
        public int[] Meals1 { get; set; }

        [Required]
        public int[] Meals2 { get; set; }
    }
}