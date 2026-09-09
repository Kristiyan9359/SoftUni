internal class Program
{
    static void Main()
    {

        List<int> list1 = Console.ReadLine()
        .Split(' ')
        .Select(int.Parse)
        .ToList();


        List<int> list2 = Console.ReadLine()
        .Split(' ')
        .Select(int.Parse)
        .ToList();

        List<int> mergedList = new();

        int maxCount = list1.Count > list2.Count ? list1.Count : list2.Count;

        NewMethod(maxCount, list1, mergedList, list2);

        Console.WriteLine(string.Join(" ", mergedList));
    }

    static void NewMethod(int maxCount, List<int> list1, List<int> mergedList, List<int> list2)
    {
        for (int i = 0; i < maxCount; i++)
        {
            if (list1.Count > i)
            {
                mergedList.Add(list1[i]);
            }

            if (list2.Count > i)
            {
                mergedList.Add(list2[i]);
            }
        }
    }
}