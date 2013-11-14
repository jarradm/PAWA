using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

using AwesomeMvcDemo.Models;

namespace AwesomeMvcDemo.Controllers
{
    public class WizardDemoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult StartWizard()
        {
            var wizardModel = new WizardModel { Id = Guid.NewGuid().ToString() };
            wizardModel.Step1 = new Step1Model { WizardId = wizardModel.Id };
            wizardModel.Step2 = new Step2Model { WizardId = wizardModel.Id };

            Session[wizardModel.Id] = wizardModel;

            return RedirectToAction("WizardStep1", new { WizardId = wizardModel.Id });
        }

        public ActionResult WizardStep1(string wizardId)
        {
            var model = (WizardModel)Session[wizardId];

            return View(model.Step1);
        }

        [HttpPost]
        public ActionResult WizardStep1(Step1Model step1Model)
        {
            if (!ModelState.IsValid)
            {
                return View(step1Model);
            }

            //all good
            //set model for step1 and redirect to step2
            var wizardModel = (WizardModel)Session[step1Model.WizardId];
            wizardModel.Step1 = step1Model;

            //set category for next step
            wizardModel.Step2.CategoryId = step1Model.CategoryId;
            
            //clear the meals (for when we go back)
            wizardModel.Step2.MealIds = null;

            //go to next step
            //return Json(new { nextUrl = Url.Action("WizardStep2", new { WizardId = wizardModel.Id }) });
            return RedirectToAction("WizardStep2", new { WizardId = wizardModel.Id });
        }

        public ActionResult WizardStep2(string wizardId)
        {
            var model = (WizardModel)Session[wizardId];

            return View(model.Step2);
        }

        [HttpPost]
        public ActionResult WizardStep2(Step2Model step2Model)
        {
            var wizardModel = (WizardModel)Session[step2Model.WizardId];
            step2Model.CategoryId = wizardModel.Step2.CategoryId;

            if (!ModelState.IsValid)
            {
                return View(step2Model);
            }

            wizardModel.Step2 = step2Model;

            return RedirectToAction("WizardFinish", new { WizardId = wizardModel.Id });
        }

        public ActionResult WizardFinish(string wizardId)
        {
            var model = (WizardModel)Session[wizardId];
            var finishModel = new WizardFinishModel();

            finishModel.WizardId = model.Id;
            finishModel.Name = model.Step1.Name;

            var category = Db.Categories.SingleOrDefault(o => o.Id == model.Step1.CategoryId);
            if (category != null)
            {
                finishModel.Category = category.Name;
            }

            finishModel.Meals = Db.Meals.Where(o => model.Step2.MealIds.Contains(o.Id)).Select(o => o.Name).ToArray();

            return View(finishModel);
        }

        [HttpPost]
        public ActionResult WizardFinish(WizardConfirmModel confirmModel)
        {
            //wizard input confirmed
            var model = (WizardModel)Session[confirmModel.WizardId];

            //do something with model

            //clear session
            Session.Remove(model.Id);
            var meals = Db.Meals.Where(o => model.Step2.MealIds.Contains(o.Id)).Select(o => o.Name).ToArray();

            return Json(new { Message = string.Format("Thank you {0} with meals: {1} was saved", model.Step1.Name, string.Join(",", meals)) });
        }
    }

    public class WizardModel
    {
        public string Id { get; set; }

        public Step1Model Step1 { get; set; }

        public Step2Model Step2 { get; set; }
    }

    public class Step1Model
    {
        public string WizardId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }

    public class Step2Model
    {
        public string WizardId { get; set; }

        public int CategoryId { get; set; }

        [Required]
        public int[] MealIds { get; set; }
    }

    public class WizardFinishModel
    {
        public string WizardId { get; set; }

        public string Category { get; set; }

        public string[] Meals { get; set; }

        public string Name { get; set; }
    }

    public class WizardConfirmModel
    {
        public string WizardId { get; set; }
    }
}