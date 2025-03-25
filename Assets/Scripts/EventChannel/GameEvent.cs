using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent<T> : ScriptableObject
{
    readonly List<IGameEventListener<T>> eventListeners = new();

    public void Raise(T data) => eventListeners.ForEach(c => c.OnEventRaised(data));

    public void RegisterListener(IGameEventListener<T> listener) => eventListeners.Add(listener);
    public void DeregisterListener(IGameEventListener<T> listener) => eventListeners.Remove(listener);
}

public class GameEvent : GameEvent<Mock>
{
    public void Raise() => Raise(Mock.Default);
}

public struct Mock
{
    public static Mock Default => default;
}
