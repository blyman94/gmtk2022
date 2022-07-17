using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InjuryLevel { Mild, Moderate, Severe, Critical }

[CreateAssetMenu]
public class Injury : ScriptableObject
{
    public int SurvivalThreshold;
    public string Description;

    public InjuryLevel GetInjuryLevel()
    {
        if (SurvivalThreshold <= 12)
        {
            return InjuryLevel.Mild;
        }
        else if (SurvivalThreshold > 12 && SurvivalThreshold <= 15)
        {
            return InjuryLevel.Moderate;
        }
        else if (SurvivalThreshold > 15 && SurvivalThreshold <= 20)
        {
            return InjuryLevel.Severe;
        }
        else
        {
            return InjuryLevel.Critical;
        }
    }
}
