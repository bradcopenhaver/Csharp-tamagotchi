using Nancy;
using System.Collections.Generic;
using Tamagotchi.Objects;
using System;

namespace Tamagotchi
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => View["index.cshtml"];
      Get["/pets"] = _ =>
      {
        List<Pet> allPets = Pet.GetAll();
        return View["pets.cshtml", allPets];
      };
      Post["/pets"] = _ =>
      {
        Pet newPet = new Pet(Request.Form["petName"], Request.Form["petType"]);
        List<Pet> allPets = Pet.GetAll();
        return View["pets.cshtml", allPets];
      };
      Get["/pet/{id}"] = parameters =>
      {
        Pet currentPet = Pet.Find(parameters.id);
        return View["pet.cshtml", currentPet];
      };
      Post["/{action}/{id}"] = parameters =>
      {
        Pet.PassTime();
        Pet currentPet = Pet.Find(parameters.id);
        if (parameters.action == "feed")
        {
          if (currentPet.GetFood() >= 5 && currentPet.GetLove() >= 5 && currentPet.GetRest() >= 5) {
          currentPet.SetFood(currentPet.GetFood() + 10);
          }
        }
        else if (parameters.action == "love")
        {
          if (currentPet.GetFood() >= 5 && currentPet.GetLove() >= 5 && currentPet.GetRest() >= 5) {
          currentPet.SetLove(currentPet.GetLove() + 10);
          }
        }
        else if (parameters.action == "rest")
        {
          if (currentPet.GetFood() >= 5 && currentPet.GetLove() >= 5 && currentPet.GetRest() >= 5) {
          currentPet.SetRest(currentPet.GetRest() + 10);
          }
        }
        return View["pet.cshtml", currentPet];
      };
    }
  }
}
