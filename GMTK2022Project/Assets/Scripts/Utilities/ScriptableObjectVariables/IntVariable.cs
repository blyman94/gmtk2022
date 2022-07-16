using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variable.../Int Variable")]
public class IntVariable : ScriptableObject
{
    public VariableUpdated ValueUpdated;

    [SerializeField] private int value;

    public int Value
    {
        get
        {
            return value;
        }
        set
        {
            this.value = value;
            ValueUpdated?.Invoke();
        }
    }
}
