using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewIntEventChannel", menuName = "Events/Int Event Channel")]
public class IntEventChannelSO : ScriptableObject
{
    public IntEventAction OnEventRaised;

    public void RaiseEvent(int value, int value2)
    {
        if(OnEventRaised != null)
        {
            OnEventRaised.Invoke(value, value2);
        }
    }
}
public delegate void IntEventAction(int value, int value2);
