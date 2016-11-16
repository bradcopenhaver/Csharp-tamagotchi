using System.Collections.Generic;

namespace Tamagotchi.Objects
{
  public class Pets
  {
    private string _petName;
    private int _currentFood = 100;
    private int _currentLove = 100;
    private int _currentRest = 100;
    private int _Id;
    private static List<Pet> _petList = new List<Pet>{};

    public Pet (string PetName)
    {
      _petName = PetName;
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

    public static Task Find(int searchId)
    {
      return _petList[searchId-1];
    }
  }
}
