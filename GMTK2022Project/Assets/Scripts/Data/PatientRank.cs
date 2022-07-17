using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PrestigeGroup { A, B, C, D };
[CreateAssetMenu]
public class PatientRank : ScriptableObject
{
    public int PrestigeLevel;
    public string Abbreviation;
    public string Title;

    [TextArea(5, 5)]
    public string Description;

    [TextArea(5, 5)]
    public string PrestigeDescription;

    public PrestigeGroup GetPrestigeGroup()
    {
        if (PrestigeLevel == 1)
        {
            return PrestigeGroup.D;
        }
        else if (PrestigeLevel == 2)
        {
            return PrestigeGroup.C;
        }
        else if (PrestigeLevel == 3)
        {
            return PrestigeGroup.B;
        }
        else
        {
            return PrestigeGroup.A;
        }
    }
}
