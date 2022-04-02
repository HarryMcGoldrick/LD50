[System.Serializable]
public class KeyValuePairSerialized<TKey, TValue>
{
    public KeyValuePairSerialized()
    {
    }

    public KeyValuePairSerialized(TKey key, TValue value)
    {
        Key = key;
        Value = value;
    }

    public TKey Key;
    public TValue Value;
}