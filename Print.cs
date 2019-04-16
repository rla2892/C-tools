//출력1
public void MyPrint(IEnumerable items)
{
    foreach (object o in items)
    {
        Console.WriteLine(o);
    }
}

//출력2 간단
var list = new List<int>(Enumerable.Range(0, 50));
list.ForEach(Console.WriteLine);
