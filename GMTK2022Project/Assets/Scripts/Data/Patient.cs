using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Patient
{
    public string Name;
    public Injury Injury;
    public List<CareProvider> AssignedProviders;
    public PatientBackground Background;

    public Patient(string name, PatientBackground background, Injury injury)
    {
        AssignedProviders = new List<CareProvider>();
        Background = background;
        Name = name;
        Injury = injury;
    }

    public int GetDiceThrow()
    {
        return Random.Range(1, 21);
    }

    public Throw GetThrow()
    {
        return new Throw(1, 20, GetDiceThrow());
    }

    public void GetSurvivalData(out Throw naturalThrow,
        out List<Throw> providerThrows, out int survivalThreshold,
        out int throwSum, out bool survived)
    {
        naturalThrow = GetThrow();
        throwSum = naturalThrow.GetThrow();

        providerThrows = new List<Throw>();
        foreach (CareProvider careProvider in AssignedProviders)
        {
            int provThrow = careProvider.GetDiceThrow();
            providerThrows.Add(new Throw(careProvider.CurrentMorale, careProvider.Role.MaxDiceValue, provThrow));
            throwSum += provThrow;
        }

        survivalThreshold = Injury.SurvivalThreshold;

        survived = throwSum >= survivalThreshold;
    }

    public void UpdateCareProviderMorales(bool survived)
    {
        foreach (CareProvider careProvider in AssignedProviders)
        {
            careProvider.MoraleChangeFromPatientOutcome = survived ? 0 :
                -Background.Rank.PrestigeLevel;
        }
    }
}
