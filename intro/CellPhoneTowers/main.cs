using System;
public class TowerSolution
{
  const int unassignedFreq = 0;
  public static bool solve(int [,]coords, int numTowers, int currFreq, int numFreq, int minDist)
  {
    //Console.WriteLine(n);
    for (int towerID = 0; towerID < numTowers; towerID++)
    {
      //Console.WriteLine(towerID+" "+numTowers);
      if (coords[towerID,2] == 0)
      {
        //Console.WriteLine("1 "+towerID);
        for (currFreq = 1; currFreq <= numFreq; currFreq++)
        {
          if (isValid(coords, numTowers, towerID, currFreq, minDist))
          {
            coords[towerID, 2] = currFreq;
            if (solve(coords, numTowers, currFreq, numFreq, minDist))
            {
              //Console.WriteLine("2 "+towerID);
              return true;
            } else
            {
              //Console.WriteLine("3 "+towerID);
              coords[towerID, 2] = unassignedFreq;
            }        
          }
        }
      return false;
      }
    }
    return true;
  }
  private static bool isValid(int [,]coords, int numTowers, int currTower, int currFreq, int minDist)
  {
    for (int towerID = 0; towerID < numTowers; towerID++)
    {
      double distance = Math.Sqrt(Math.Pow((Math.Abs(coords[towerID,0]-coords[currTower,0])),2)+Math.Pow((Math.Abs(coords[towerID,1]-coords[currTower,1])),2));
      //Console.WriteLine(towerID+" "+coords[towerID,2]+" "+currTower+" "+coords[currTower,2]+" "+distance);
      //Console.WriteLine(towerID);
      if (distance < minDist && towerID!=currTower)
      {
        //Console.WriteLine(towerID);
        bool sameFreq = currFreq == coords[towerID,2];
        if (sameFreq)
        {
          //Console.WriteLine(currTower + " " + towerID);
          return false;
        }
      }
    }
    return true;
  }
}
class MainClass {
  public static void Main (string[] args) {
    int numTowers = int.Parse(Console.ReadLine());
    int numFreq = int.Parse(Console.ReadLine());
    int minDist = int.Parse(Console.ReadLine());
    int [,]towerCoords = new int [numTowers,3];
    const int unassignedFreq = 0;
    for (int towerID = 0; towerID < numTowers; towerID++)
    {
      towerCoords[towerID,0] = int.Parse(Console.ReadLine());
      towerCoords[towerID,1] = int.Parse(Console.ReadLine());
      towerCoords[towerID,2] = unassignedFreq;//initial value const
    }
    //Console.WriteLine(n);
    TowerSolution.solve(towerCoords, numTowers, unassignedFreq, numFreq, minDist);
    for (int towerID = 0; towerID < numTowers; towerID++)
    {
      Console.WriteLine(towerCoords[towerID,0]+" "+towerCoords[towerID,1]+" "+towerCoords[towerID,2]);
    }
  }
}