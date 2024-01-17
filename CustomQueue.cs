namespace Assignment1;

public class CustomQueue<T>
{
    private CustomArrayList<T> _list = new();

    public int Count => _list.Count;

    public void Enqueue(T item) { _list.Add(item); }

    public T Dequeue() { return _list.RemoveStart(); }

    public T Peek() { return _list.ShowFirst(); }

    public void Print()
    {
        _list.Print();
    }
}