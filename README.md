# UnityEventManager
Event Manager for Unity using C# only

The main script is EventManager.cs, containing the logic for the event manager. 
Events.cs is just a static class with enum as an example. The event manager uses enum values to identify the events, but they can be any enum and don't have to be in the Events.cs file.

Implementation_triggerer and Implementation_listener are just examples on how to use the event manager

## USAGE 
to subscribe to an event use:
```EventManager.Subscribe(Events.YourEnum.YourValue, (System.Action)SomeMethod);```
if the method you want to pass has arguments, you need to explicitly say its type, for instance:

```private void SomeMethod2(int a, string b){//...}```
then the subscription to the event should be
```EventManager.Subscribe(Events.YourEnum.YourValue, (System.Action<int , string>)SomeMethod);```

To unsubscribe from the event you use the same but with ```EventManager.Unsubscribe(yourEvent, yourMethod)```

Finally, to trigger  the events, you use:
```EventManager.Trigger(Events.YourEnum.YourValue , arg1, arg2, ...);```

[!NOTE]
- If the triggering doesn't have the right arguments (number and type) of the subscribing methods, the event will not be triggered
- currently, the eventManager only accept events with up to 3 arguments of any type. Adding more  should not be difficult.
