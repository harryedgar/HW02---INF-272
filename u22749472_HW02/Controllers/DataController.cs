using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Configuration;
using u22749472_HW02.Models;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Net;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;
using System.Data.Common;
using System.Web.UI;


namespace u22749472_HW02.Controllers
{
    public class DataController : Controller
    {
        PetDBEntities db = new PetDBEntities();

        public static string ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=PetDB;Integrated Security=True";

        SqlConnection myConnection = new SqlConnection(DataController.ConnectionString);


        // GET: Data
        public ActionResult HomePage()
        {
            var listdone = new DataViewModel()
            {
                PetList = db.Pets.ToList(),
                UserList = db.Users.ToList()
            };
            return View(listdone);
        }
    

        public ActionResult Pet(int? pettype, int? petbreed, int? location, int? petid , int? petname)
        {
            ViewBag.petid = petid;
            ViewBag.petname = petname;

            var result = db.Pets.Include(p => p.TypeID)
                                .Include(p => p.BreedID)
                                .Include(p => p.LocationID);

            //filter and confirm each parameter has a value and comapre it to the attributes included in our results
            if (pettype.HasValue)
            {
                result = result.Where(p => p.TypeID == pettype);
            }
            if (petbreed.HasValue)
            {
                result = result.Where(p => p.BreedID == petbreed);
            }
            if (location.HasValue)
            {
                result = result.Where(p => p.LocationID == location);
            }

            var petstodisplay = new DataViewModel()
            {
                PetTypeList = db.PetTypes.ToList(),
                BreedList = db.Breeds.ToList(),
                LocationList = db.Locations.ToList(),
                PetList = db.Pets.ToList()
            };
            return View(petstodisplay);

        }

        [HttpGet]
        public ActionResult Adopt(int? petid)
        {
            if (petid.HasValue)
            {
                var adoptedpet = new DataViewModel()
                {
                    PetList = db.Pets.ToList(),
                    UserList = db.Users.ToList(),
                    GenderList = db.Genders.ToList(),   
                };

                if (petid.HasValue)
                {
                    adoptedpet.selectedpet = db.Pets
                                            .FirstOrDefault(a => a.PetID == petid.Value);
                }
                return View(adoptedpet);
            }
            return RedirectToAction("Pet");
        }

        [HttpPost]
        public ActionResult Adopt()
        {

            return View();
        }


        public ActionResult PostaPet(string FullName, int? Phone, string PetName, string TypeDescription, string BreedDescription, string LocationDescription, string PetImage,
                                       int? PetAge, decimal? PetWeight, string GenderDescription)
        {
            try
            {
                SqlCommand myInsertCommand = new SqlCommand("Insert into Pets Values('" + FullName + "','" + Phone + "','" + PetName + "','" + TypeDescription + "', '" + BreedDescription + "'" +
                    "'" + LocationDescription + "','" + PetAge + "','" + PetWeight + "','" + GenderDescription + "','" + GenderDescription + "' )", myConnection);

                myConnection.Open();

                int rowsAffected = myInsertCommand.ExecuteNonQuery();
                ViewBag.Message = "Success: Pet added.";
            }
            catch (Exception err)
            {
                ViewBag.Message = "Error: " + err.Message;
            }
            finally
            {
                myConnection.Close();
            }

            var newpet = new DataViewModel()
            {
                UserList  = db.Users.ToList(),
                PetList = db.Pets.ToList(),
                PetTypeList = db.PetTypes.ToList(),
                BreedList = db.Breeds.ToList(),
                LocationList = db.Locations.ToList(),
                GenderList = db.Genders.ToList()
            };
            return View(newpet);
        }       

        public ActionResult Donations()
        {
                var username = db.Users.Select(u => u.FullName).ToList();
                var phonenumber = db.Users.Select(p => p.Phone).ToList();
                var donationamount = db.Donations.Select(d => d.DonationAmount).ToList();

                var donatedamount = new Donation();
                var model = new DataViewModel()
                {
                    UserList = db.Users.ToList(),
                    DonationsList = db.Donations.ToList(),
                };
            return View(model);
        }
    }
}
