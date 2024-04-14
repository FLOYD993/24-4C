using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//´«µÝFLOATÖµ
[CreateAssetMenu(menuName = "Event/FloatEventSO")]
public class FloatEventSO : ScriptableObject
{
    public UnityAction<float> OnEventRaised;
    public void RaisedEvent(float amount)
    {
        OnEventRaised?.Invoke(amount);
    }
}
