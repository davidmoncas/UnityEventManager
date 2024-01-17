using System;
using System.Collections.Generic;

internal static class EventManager 
{
    private static readonly Dictionary<Enum, Dictionary<Type, Delegate>> events = new Dictionary<Enum, Dictionary<Type, Delegate>>();
    
    public static void Subscribe<T>(Enum eventName, T action) where T:Delegate
    {
        if (!events.ContainsKey(eventName))
            events[eventName] = new Dictionary<Type, Delegate> { [typeof(T)] = action };

        else if (!events[eventName].ContainsKey(typeof(T)))
            events[eventName][typeof(T)] = action;

        else
            events[eventName][typeof(T)] = Delegate.Combine(events[eventName][typeof(T)], action);
    }

    public static void Unsubscribe<T>(Enum eventName, T action) where T:Delegate
    {
        if (!events.ContainsKey(eventName) ||
            !events[eventName].ContainsKey(typeof(T))) return;

        events[eventName][typeof(T)] = Delegate.Remove(events[eventName][typeof(T)], action);
    }


    public static void Trigger(Enum eventName)
    {
        if (!events.ContainsKey(eventName) ||
            !events[eventName].ContainsKey(typeof(Action))) return;

        var genericEvent = events[eventName][typeof(Action)] as Action;
        genericEvent?.Invoke();
    }

    public static void Trigger<T>(Enum eventName, T args)
    {
        if (!events.ContainsKey(eventName) ||
            !events[eventName].ContainsKey(typeof(Action<T>))) return;

        var genericEvent = events[eventName][typeof(Action<T>)] as Action<T>;
        genericEvent?.Invoke(args);
    }

    public static void Trigger<T1,T2>(Enum eventName, T1 arg1 , T2 arg2)
    {
        if (!events.ContainsKey(eventName) ||
            !events[eventName].ContainsKey(typeof(Action<T1,T2>))) return;

        var genericEvent = events[eventName][typeof(Action<T1,T2>)] as Action<T1,T2>;
        genericEvent?.Invoke(arg1, arg2);
    }

    public static void Trigger<T1, T2 , T3>(Enum eventName, T1 arg1, T2 arg2 , T3 arg3)
    {
        if (!events.ContainsKey(eventName) ||
            !events[eventName].ContainsKey(typeof(Action<T1, T2,T3>))) return;

        var genericEvent = events[eventName][typeof(Action<T1, T2, T3>)] as Action<T1, T2,T3>;
        genericEvent?.Invoke(arg1, arg2 , arg3 );
    }


}




