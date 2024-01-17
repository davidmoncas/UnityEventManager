using UnityEngine;

public class Implementation_triggerer : MonoBehaviour
{

    // Trigger all the events. Be careful to send the right arguments
    public void TriggerAllEvents() {
        EventManager.Trigger(Events.Gameplay.Event1);
        EventManager.Trigger(Events.Gameplay.Event2 , 0);
        EventManager.Trigger(Events.Gameplay.Event3 , 0, "some string");
    
    }



}
