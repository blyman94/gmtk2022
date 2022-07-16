using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PatientBackground
{
    public PatientRank Rank;
    public bool IsMarried;
    public int ChildCount;
    public int Age;
    public int DaysUntilDischarge;

    public PatientBackground(PatientRank rank, bool isMarried, int childCount, 
        int age, int daysUntilDischarge)
    {
        Rank = rank;
        IsMarried = isMarried;
        ChildCount = childCount;
        Age = age;
        DaysUntilDischarge = daysUntilDischarge;
    }
}
