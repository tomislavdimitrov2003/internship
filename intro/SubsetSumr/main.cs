using System;

class SubsetSum{

static int subsetSum(int []arr, int arrLenght, int i, int sum, int count){
	if (i == arrLenght){
		if (sum == 0){
			count++;
		}
		return count;
  }
	count = subsetSum(arr, arrLenght, i + 1, sum - arr[i], count);
	count = subsetSum(arr, arrLenght, i + 1, sum, count);
	return count;
}
public static void Main(String[] args){
	int []arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
	int sum = 10;
	int arrLenght = arr.Length;

	Console.Write(subsetSum(arr, arrLenght, 0, sum, 0));
}
}
