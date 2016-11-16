using Nancy;
using System.Collections.Generic;
using Tamagotchi.Objects;

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
        Pet newPet = new Pet(Request.Form["petName"]);
        List<Pet> allPets = Pet.GetAll();
        return View["pets.cshtml", allPets];
      };
      Get["/pet/{id}"] = parameters =>
      {
        Pet currentPet = Pet.Find(parameters.id);
        return View["pet.cshtml", currentPet];
      };
    }
  }
}
