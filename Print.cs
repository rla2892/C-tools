//출력1
public static void MyPrint(IEnumerable items)
{
    foreach (object o in items)
    {
        foreach (var prop in o.GetType().GetProperties())
            {
                Console.WriteLine("{0} = {1}", prop.Name, prop.GetValue(o, null));
            }
        Console.WriteLine();
    }
}

//출력2 간단
var list = new List<int>(Enumerable.Range(0, 50));
list.ForEach(Console.WriteLine);


//출력3 string 배열 출력
public static void StringArrayPrint(string[] strs)
{
    foreach(string str in strs)
    {
        Console.WriteLine(str);
    }
}

//출력4 List 
public static void ListPrint<T>(List<T> list)
{
    foreach(T item in list)
    {
        Console.WriteLine(item);
    }
}
