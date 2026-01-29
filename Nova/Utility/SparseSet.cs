using System.Collections;

namespace Nova;


// https://timiskhakov.github.io/posts/sparse-sets-and-where-to-find-them/


public class Item<T> {
    public int key;
    public T? value;
}

public class SparseDictionary<T> : IEnumerable<Item<T>> {
    private readonly Item<T>[] dense;
    private readonly int[] sparse;
    private int position;

    public SparseDictionary(int size) {
        dense = new Item<T>[size];
        sparse = new int[size];
        position = 0;

        for (var i = 0; i < size; i++) {
            dense[i] = new Item<T>();
        }
    }

    public int Capacity => sparse.Length;

    public int Count => position;

    public T this[int key] {
        get {
            if (key < 0 || key >= sparse.Length) {
                throw new IndexOutOfRangeException($"Key {key} is out of range 0..{sparse.Length}");
            }

            if (!TryGetIndex(key, out var index)) {
                throw new KeyNotFoundException($"Key {key} is not found");
            }

            return dense[index].value!;
        }
        set {
            if (key < 0 || key >= sparse.Length) {
                throw new IndexOutOfRangeException($"Key {key} is out of range 0..{sparse.Length}");
            }
            
            // If the value is already in the dense array, just update it
            if (TryGetIndex(key, out var index)) {
                dense[index].value = value;
                return;
            }

            // If not create a new position
            dense[position].key = key;
            dense[position].value = value;
            sparse[key] = position;
            
            position++;
        }
    }

    public IEnumerator<Item<T>> GetEnumerator() {
        for (int i = 0; i < position; i++) {
            yield return dense[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }

    public bool ContainsKey(int key) {
        return key > 0 && key < sparse.Length && TryGetIndex(key, out _);
    }

    public bool TryGetValue(int key, out T? value) {
        if (key < 0 || key >= sparse.Length || !TryGetIndex(key, out int index)) {
            value = default;
            return false;
        }

        value = dense[index].value;
        return true;
    }

    public void Remove(int key) {
        if (!TryGetIndex(key, out int index)) return;

        Item<T> last = dense[position - 1];
        dense[index] = last;
        sparse[last.key] = sparse[key];
        position--;
    }

    private bool TryGetIndex(int key, out int index) {
        index = sparse[key];
        return index < position && dense[index].key == key;
    }
}
