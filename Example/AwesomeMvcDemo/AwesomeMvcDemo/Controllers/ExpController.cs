using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using AwesomeMvcDemo.ViewModels;

namespace AwesomeMvcDemo.Controllers
{
    public class ExpController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TestErrorHandling()
        {
            return View();
        }

        public ActionResult TestEmptyGrid()
        {
            return View();
        }

        public ActionResult TestWaitParentLoad()
        {
            return View();
        }

        public ActionResult Test3()
        {
            return View();
        }

        public ActionResult Test4()
        {
            return View();
        }

        public ActionResult TestUnobtrusive()
        {
            return View(new UnobstrusiveInput());
        }

        [HttpPost]
        public ActionResult TestUnobtrusive(UnobstrusiveInput input)
        {
            return View(input);
        }

        public ActionResult ParentNestedProp()
        {
            return View();
        }

        public ActionResult MultiTest()
        {
            return View(new MultiTestInput());
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult MultiTest(MultiTestInput input)
        {
            return View(input);
        }

        public ActionResult GridClientFunc()
        {
            return View();
        }

        public ActionResult Cios()
        {
            return View(new CreateAssignmentInput
                            {
                                Id = 3,
                                Scenario = "hi",
                                Tasks = new List<TaskInput>
                                            {
                                                new TaskInput
                                                    {
                                                        Id = 2, 
                                                        Title = "task1", 
                                                        Evidences = new List<EvidenceInput>
                                                                        {
                                                                            new EvidenceInput{Id = 1, Evidence = "evidence1"},
                                                                            new EvidenceInput{Id = 2, Evidence = "evidence2"},
                                                                            new EvidenceInput{Id = 3, Evidence = "evidence3"},
                                                                        }
                                               
                                                    }
                                            }
                            });

        }

        [HttpPost]
        public ActionResult Cios(CreateAssignmentInput input)
        {
            if (!ModelState.IsValid)
            {
                return View(input);
            }
            return View(input);
        }

        public ActionResult AddEvidence(int task, int index, int? id, string evidence)
        {
            ViewData["task"] = task;
            ViewData["index"] = index;
            ViewData["id"] = id;
            ViewData["Evidence"] = evidence;
            return View("ev");
        }

        public ActionResult AddTask(int task)
        {
            ViewData["ti"] = task;
            return View();
        }
    }

    public class EvidenceInput
    {
        public int Id { get; set; }

        public string Evidence { get; set; }
    }

    public class TaskInput
    {
        public TaskInput()
        {
            Evidences = new List<EvidenceInput>();
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public IList<EvidenceInput> Evidences { get; set; }
    }

    public class CreateAssignmentInput
    {
        public CreateAssignmentInput()
        {
            Tasks = new List<TaskInput>();
        }

        public int Id { get; set; }

        [Required]
        public string Scenario { get; set; }

        public IList<TaskInput> Tasks { get; set; }
    }

    public class ParentNestedPropInput
    {
        public InternTest1 Intern { get; set; }
    }

    public class InternTest1
    {
        public string Prop1 { get; set; }

        public string Prop2 { get; set; }
    }

    public class MultiTestInput
    {
        public string[] Foos { get; set; }

        public string[] FoosChk { get; set; }

        public string FoosRadio { get; set; }

        public string FoosDd { get; set; }

        public string FooLookup { get; set; }

        public string FooTxt { get; set; }

        public string FooAuto { get; set; }
    }
}