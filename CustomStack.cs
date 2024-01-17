namespace TestProjectApp;

public class CustomStack<T>
{
    private CustomArrayList<T> _list = new();

    public int Count => _list.Count;
    public void Push(T item) {_list.Add(item); }

    public T Pop()
    {
        return _list.Remove();
    }

    public T Peek()
    {
        return _list.ShowLast();
    }
    
    public void Print()
    {
        _list.Print();
    }
}