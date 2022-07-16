using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PatientRank : ScriptableObject
{
    public int PrestigeLevel;
    public string Abbreviation;
    public string Title;
    [TextArea (5,5)]
    public string Description;
}
