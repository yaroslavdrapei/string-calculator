namespace Assignment1;

public class CustomQueue<T>
{
    private CustomArrayList<T> _list = new();

    public int Count => _list.Count;

    public void Enqueue(T item) { _list.Add(item); }

    public T Dequeue() { return _list.RemoveStart(); }

    public T Peek() { return _list.ShowFirst(); }
    public T PeekLast() { return _list.ShowLast(); }

    public void Print() { _list.Print(); }

    public void Clear() { _list = new CustomArrayList<T>(); }

    public override string ToString() { return _list.ToString(); }
}