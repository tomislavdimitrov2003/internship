using System;
class Factorial{
  public static long calcFac(int n){
   long fac=1;  
   for(int i = 1; i <= n; i++){
     fac *= i;
   }
    return fac;
  }
}
class MainClass {
  public static void Main (string[] args) {
    int n = int.Parse(Console.ReadLine());
    for(int i = 1; i <= n; i++){
        Console.WriteLine(Factorial.calcFac(i));
    }
  }
}