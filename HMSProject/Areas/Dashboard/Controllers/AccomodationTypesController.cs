using HMSProject.Areas.Dashboard.ViewModels;
using HMSProject.Entities;
using HMSProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMSProject.Areas.Dashboard.Controllers
{
    public class AccomodationTypesController : Controller
    {
        // GET: Dashboard/AccomodationTypes
        AccomodationTypesService accomodationTypesService = new AccomodationTypesService();
        public ActionResult Index(string searchTerm)
        {
            AccomodationTypesListingModel model = new AccomodationTypesListingModel();

            model.SearchTerm = searchTerm;

            model.AccomodationTypes = accomodationTypesService.SearchAccomodationTypes(searchTerm);

            return View(model);
        }
        //public ActionResult Listing()
        //{
        //    AccomodationTypesListingModel model = new AccomodationTypesListingModel();
        //    model.AccomodationTypes  = accomodationTypesService.GetAllAccomodationTypes();

        //    return PartialView("_Listing", model);
        //}
        [HttpGet]
        public ActionResult Action(int? ID)
        {
            AccomodationTypesActionModel model = new AccomodationTypesActionModel();

            if (ID.HasValue) //we are trying to edit a record
            {
                var accomodationType = accomodationTypesService.GetAccomodationTypeByID(ID.Value);

                model.ID = accomodationType.ID;
                model.Name = accomodationType.Name;
                model.Description = accomodationType.Description;
            }

            return PartialView("_Action", model);
        }
        [HttpPost]
        public JsonResult Action(AccomodationTypesActionModel modal)
        {
            JsonResult json = new JsonResult();
            var result = false;
            if (modal.ID > 0)
            {
                var accomodationType = accomodationTypesService.GetAccomodationTypeByID(modal.ID);
                accomodationType.Name = modal.Name;
                accomodationType.Description = modal.Description;

                result = accomodationTypesService.UpdateAccomodationType(accomodationType);
            }
            else
            {
                AccomodationType accomodationType = new AccomodationType();
                accomodationType.Name = modal.Name;
                accomodationType.Description = modal.Description;

                 result = accomodationTypesService.SaveAccomodationType(accomodationType);
            }
           

           if(result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Unable to perform action on accomodation Type."};
            }

            return json;
        }
        [HttpGet]
        public ActionResult Delete(int ID)
        {
            AccomodationTypesActionModel model = new AccomodationTypesActionModel();

            var accomodationType = accomodationTypesService.GetAccomodationTypeByID(ID);

            model.ID = accomodationType.ID;

            return PartialView("_Delete", model);
        }

        [HttpPost]
        public JsonResult Delete(AccomodationTypesActionModel model)
        {
            JsonResult json = new JsonResult();

            var result = false;

            var accomodationType = accomodationTypesService.GetAccomodationTypeByID(model.ID);

            result = accomodationTypesService.DeleteAccomodationType(accomodationType);

            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Unable to perform action on Accomodation Types." };
            }

            return json;
        }
    }
    }
