using System;

public static class EventManager
{
    static public event Action<Item> OnItemReceived;
    static public void ItemReceived(Item item) => OnItemReceived?.Invoke(item);
}
