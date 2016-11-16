using System.Collections.Generic;

namespace Tamagotchi.Objects
{
  public class Pet
  {
    private string _petName;
    private int _currentFood = 100;
    private int _currentLove = 100;
    private int _currentRest = 100;
    private int _Id;
    private string _petType;
    private static List<Pet> _petList = new List<Pet>{};

    public Pet (string PetName, string PetType)
    {
      _petName = PetName;
      _petType = PetType;
      _petList.Add(this);
      _Id = _petList.Count;
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
    public int GetId() {
      return _Id;
    }
    public string GetFoodStatus() {
      return "hungry";
    }
    public string GetLoveStatus() {
      return "lonely";
    }
    public string GetRestStatus() {
      return "tired";
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
