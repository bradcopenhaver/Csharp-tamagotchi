using System.Collections.Generic;
using System;

namespace Tamagotchi.Objects
{
  public class Pet
  {
    private string _petName;
    private int _currentFood;
    private int _currentLove;
    private int _currentRest;
    private int _Id;
    private string _petType;
    private bool _isAlive = true;
    private static List<Pet> _petList = new List<Pet>{};

    public Pet (string PetName, string PetType)
    {
      Random rnd = new Random();
      _currentFood = rnd.Next(55,85);
      _currentLove = rnd.Next(55,85);
      _currentRest = rnd.Next(55,85);
      _petName = PetName;
      _petType = PetType;
      _petList.Add(this);
      _Id = _petList.Count;
    }

    public bool GetAlive() {
      return _isAlive;
    }

    public void SetName(string newName)
    {
      _petName = newName;
    }

    public string GetName()
    {
      return _petName;
    }

    public void SetFood(int newFood)
    {
      _currentFood = newFood;
    }

    public int GetFood()
    {
      return _currentFood;
    }

    public void SetLove(int newLove)
    {
      _currentLove = newLove;
    }

    public int GetLove()
    {
      return _currentLove;
    }

    public void SetRest(int newRest)
    {
      _currentRest = newRest;
    }

    public int GetRest()
    {
      return _currentRest;
    }

    public static List<Pet> GetAll()
    {
      return _petList;
    }

    public static Pet Find(int searchId)
    {
      return _petList[searchId-1];
    }

    public static void CheckDeath() {
      foreach (Pet pet in _petList) {
        if (pet._isAlive == true && pet.GetFood() <= 0) {
          System.Console.WriteLine("Dude, " + pet.GetName() + " died. Wow.");
          pet._isAlive = false;
        }
      }
    }

    public static void PassTime()
    {
      Random rnd1 = new Random();
      foreach(Pet pet in _petList)
      {
        if (pet._isAlive == true) {
          Random rnd = new Random(pet.GetId()+rnd1.Next(1,100));
          pet.SetFood(pet.GetFood() - rnd.Next(2,7));
          pet.SetLove(pet.GetLove() - rnd.Next(8, 15));
          pet.SetRest(pet.GetRest() - rnd.Next(1, 5));
        }
      };
      CheckDeath();
    }



    public int GetId() {
      return _Id;
    }
    public string GetFoodStatus() {
      if (_currentFood > 100)
      {
        return "stuffed!";
      }
      else if (_currentFood > 60)
      {
        return "full.";
      }
      else if (_currentFood > 25)
      {
        return "hungry.";
      }
      else if (_currentFood > 0)
      {
        return "starving!";
      }
      else
      {
        return "dead. :(";
      }
    }
    public string GetLoveStatus() {
      if (_currentLove > 100)
      {
        return "ecstatic!";
      }
      else if (_currentLove > 60)
      {
        return "happy.";
      }
      else if (_currentLove > 25)
      {
        return "sad.";
      }
      else if (_currentLove > 0)
      {
        return "depressed!";
      }
      else
      {
        return "in a very bad place. :(";
      }
    }
    public string GetRestStatus() {
      if (_currentRest > 100)
      {
        return "bouncing off the walls!";
      }
      else if (_currentRest > 60)
      {
        return "awake.";
      }
      else if (_currentRest > 25)
      {
        return "sleepy.";
      }
      else if (_currentRest > 0)
      {
        return "exhausted!";
      }
      else
      {
        return "barely able to stand up. :(";
      }
    }
    public string GetPetType() {
      return _petType;
    }

    public string GetImg() {
      if (_petType == "dog") {
        return "Content/img/dog.gif";
      } else if (_petType == "pig") {
        return "Content/img/gpig.gif";
      } else if (_petType == "panda") {
        return "Content/img/rpanda.gif";
      } else {
        return "Pet Type Invalid";
      }
    }

  }
}
