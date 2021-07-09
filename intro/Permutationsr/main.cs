using System;

public class FindAllPerms
{
  public static void permute(int []list, int i, int numElements)
  {
    int k;
    if (i == numElements)
    {
      for(int j = 0; j < numElements + 1; j++)
      {
        Console.Write(list[j]);
      }
      Console.WriteLine("");
    } else
    {
      for (k = i; k <= numElements; k++){
        int temp = 0;
        temp = list[i];
        list[i] = list[k];
        list[k] = temp;
        permute(list, i+1, numElements);
        temp = list[i];
        list[i] = list[k];
        list[k] = temp;
      }
    }
  } 
}
class MainClass {
  public static void Main (string[] args) {
    int numElements=int.Parse(Console.ReadLine());
    int []list=new int [numElements];
    for(int i = 0; i < numElements; i++){
      list[i] = int.Parse(Console.ReadLine());
    }
    FindAllPerms.permute(list, 0, numElements - 1);
  }
}