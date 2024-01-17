using UnityEngine;

public class Implementation_listener : MonoBehaviour
{
    // example with different methods with different signatures
    private void SomeMethod() { }
    private void SomeMethod2(int a) { }
    private void SomeMethod3(int a, string b) { }

    private void OnEnable()
    {
        // Subscribe to the desired events, remember to specify the signature of the method
        EventManager.Subscribe(Events.Gameplay.Event1, (System.Action)SomeMethod);
        EventManager.Subscribe(Events.Gameplay.Event2, (System.Action<int>)SomeMethod2);
        EventManager.Subscribe(Events.Gameplay.Event3, (System.Action<int , string>)SomeMethod3);
    }

    private void OnDisable()
    {
        // Remember to unsubscribe to the events 
        EventManager.Unsubscribe(Events.Gameplay.Event1, (System.Action)SomeMethod);
        EventManager.Unsubscribe(Events.Gameplay.Event2, (System.Action<int>)SomeMethod2);
        EventManager.Unsubscribe(Events.Gameplay.Event3, (System.Action<int, string>)SomeMethod3);
    }
}
