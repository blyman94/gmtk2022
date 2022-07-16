using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Patient 
{
    public string Name;
    public PatientRank Rank;
    public Injury Injury;
    public bool IsMarried;
    public int ChildCount;
    public int Age;
    public string CivOccupation;
    public int DaysUntilDischarge;
}
