using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace u22749472_HW02.Models
{
    public class DataViewModel
    {
        public List<Adoption> AdoptionList { get; set; }    
        public List<AdoptionStatu> AdoptionStatuList { get;set; }
        public List<Breed> BreedList { get; set; }
        public List<Donation> DonationsList { get; set;}
        public List<Gender> GenderList { get; set; }
        public List<Location> LocationList { get; set; }
        public List<Pet> PetList { get; set; }  
        public List<PetType> PetTypeList { get; set; }
        public List<User> UserList { get; set; }
        public Pet selectedpet { get; set; }
    }



    //public class postpetview
    //{
    //    public List<Pet> PetList { get; set; }

    //    public int userid { get; set; }
    //    public int typeid { get; set; }
    //    public string name { get; set; }
    //    public int age { get; set; }
    //    public decimal weight { get; set; }
    //    public int genderid { get; set; }
    //    public string story { get; set; }
    //    public int statusid { get; set; }
    //    public HttpPostedFileBase PostedFile { get; set; }

    //    [Display(Name = "Pet Type")]
    //    [Required(ErrorMessage = "PLease select pet type")]
    //    public int selectedtype { get; set; }

    //    [Display(Name = "Pet Breed")]
    //    [Required(ErrorMessage = "PLease select pet breed")]
    //    public int selectedbreed { get; set; }

    //    [Display(Name = "Pet Location")]
    //    [Required(ErrorMessage = "PLease select pet location")]
    //    public int selectedlocation { get; set; }


    //}

    //public class AdoptViewModel
    //{
    //    public string selectedpet { get; set; }
    //    public int slecteduserid { get; set; }
    //    public string selecteduser { get; set; }
    //    public string selectedphone { get; set; }

    //}
}