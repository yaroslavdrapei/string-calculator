namespace TestProjectApp;

public class CustomArrayList<T>
{
    private T[] _array = new T[8];

    private int _pointer = 0;

    public int Count => _pointer;
    private void Resize()
    {
        Array.Resize(ref _array, _array.Length*2);
    }
    
    public void Add(T item)
    {
        if (_pointer >= _array.Length) Resize();
        _array[_pointer] = item;
        _pointer++;
    }

    public T Remove()
    {
        var value = _array[_pointer-1];
        _array[_pointer-1] = default(T);
        _pointer--;
        return value;
    }

    public void AddStart(T item)
    {
        if (_pointer >= _array.Length) Resize();
        for (int i = _pointer; i > 0; i--)
        {
            _array[i] = _array[i - 1];
        }
        _array[0] = item;
        _pointer++;
    }

    public T RemoveStart()
    {
        var value = _array[0];
        for (int i = 0; i < _array.Length-1; i++)
        {
            _array[i] = _array[i + 1];
        } 
        _pointer--;
        return value;
    }

    public T ShowFirst()
    {
        return _array[0];
    }

    public T ShowLast()
    {
        if (_pointer - 1 < 0) return default(T);
        return _array[_pointer - 1];
    }

    public void Print()
    {
        Console.WriteLine(string.Join(" ", _array) + $" Length: {_array.Length}, {_pointer}");
    }
}