using System;
using System.Collections;

namespace One_Point_List_Crossover
{
    class Program
    {
        public static int GetRandom(int minValue = 5, int maxValue = 100) 
        {
            Random rnd = new Random();
            int value = rnd.Next(minValue, maxValue);

            return value;
        }

        public static ArrayList CreateList()
        {
            int size = GetRandom(maxValue: 15); 
            ArrayList list = new ArrayList();
            while (size-- > 0)
                list.Add(GetRandom());
            return list;
        }

        public static int RandomPoint(ArrayList list)
        {
            return GetRandom() % (list.Count - 1);
        }

        public static void PrintList(ArrayList list) 
        {
            foreach (int item in list)
                Console.Write(item + " ");

            Console.WriteLine();
        }

        public static (ArrayList, ArrayList) ListCrossover(ArrayList list_1, ArrayList list_2)
        {
            int point_1 = RandomPoint(list_1);
            int point_2 = RandomPoint(list_2);

            Console.WriteLine($"{point_1} {point_2}");

            ArrayList new_list_1 = new ArrayList();
            ArrayList new_list_2 = new ArrayList();

            new_list_1.InsertRange(0, list_2.GetRange(0, point_2 + 1));
            new_list_2.InsertRange(0, list_1.GetRange(0, point_1 + 1));
            
            list_1.RemoveRange(0, point_1 + 1);
            list_2.RemoveRange(0, point_2 + 1);

            new_list_1.AddRange(list_1);
            new_list_2.AddRange(list_2);

            return (new_list_1, new_list_2);
        }

        static void Main(string[] args)
        {
            ArrayList list_1 = CreateList();
            ArrayList list_2 = CreateList();
            PrintList(list_1);
            PrintList(list_2);

            (list_1, list_2) = ListCrossover(list_1, list_2);

            PrintList(list_1);
            PrintList(list_2);

        }
    }
}
