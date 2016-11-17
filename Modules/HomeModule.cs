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
          currentPet.SetFood(currentPet.GetFood() + 30);
          currentPet.SetLove(currentPet.GetLove() + 25);
        }
        else if (parameters.action == "love")
        {
          currentPet.SetLove(currentPet.GetLove() + 18);
          currentPet.SetRest(currentPet.GetRest() - 4);
        }
        else if (parameters.action == "rest")
        {
          currentPet.SetRest(currentPet.GetRest() + 60);
          currentPet.SetLove(currentPet.GetLove() + 30);
        }
        return View["pet.cshtml", currentPet];
      };
    }
  }
}
