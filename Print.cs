//출력1
public static void MyPrint(IEnumerable items)
{
    foreach (object o in items)
    {
        foreach (var prop in o.GetType().GetProperties())
            {
                Console.WriteLine("{0}={1}", prop.Name, prop.GetValue(o, null));
            }
        Console.WriteLine();
    }
}

//출력2 간단
var list = new List<int>(Enumerable.Range(0, 50));
list.ForEach(Console.WriteLine);
