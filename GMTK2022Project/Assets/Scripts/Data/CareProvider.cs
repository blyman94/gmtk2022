using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Care Provider")]
public class CareProvider : ScriptableObject
{
    public string Name;
    public Color indicatorColor = Color.white;
    public CareProviderRole Role;
    public int CurrentMorale { get; set; }

    public int PreviousMorale { get; set; }

    public int MoraleChangeFromBreakroom = 0;
    public int MoraleChangeFromPatientOutcome = 0;
    public int MoraleChangeFromGlobalEvent = 0;

    public int GetDiceThrow()
    {
        return Random.Range(CurrentMorale, Role.MaxDiceValue + 1);
    }

    public void UpdateCurrentMorale(out int previousMorale, 
        out int patientMorale, out int breakroomMorale, 
        out int hospitalMorale, out int finalMorale)
    {
        previousMorale = CurrentMorale;

        patientMorale = MoraleChangeFromPatientOutcome;
        breakroomMorale = MoraleChangeFromBreakroom;
        hospitalMorale = MoraleChangeFromGlobalEvent;

        int totalMoraleDelta = MoraleChangeFromBreakroom +
            MoraleChangeFromPatientOutcome + MoraleChangeFromGlobalEvent;
        CurrentMorale =
            Mathf.Clamp(CurrentMorale + totalMoraleDelta, 1, Role.MaxMorale);

        finalMorale = CurrentMorale;
        
        // Reset morale changes
        MoraleChangeFromPatientOutcome = 0;
        MoraleChangeFromBreakroom = 0;
        MoraleChangeFromGlobalEvent = 0;
    }
}
