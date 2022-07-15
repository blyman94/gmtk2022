using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Injury : ScriptableObject
{
    public string Name;
    public string Description;
    public InjurySeverity Severity;
}
