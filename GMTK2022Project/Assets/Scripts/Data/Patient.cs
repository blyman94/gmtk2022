using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Patient")]
public class Patient : ScriptableObject
{
    public Injury Injury;
    public List<CareProvider> AssignedProviders;
    public int PotentialMoraleDelta = 0;

    public int GetDiceThrow()
    {
        return Random.Range(1, 21);
    }

    public void GetSurvivalData(out int naturalThrow,
        out List<int> providerThrows, out int survivalThreshold,
        out int throwSum, out bool survived)
    {
        naturalThrow = GetDiceThrow();
        throwSum = naturalThrow;

        providerThrows = new List<int>();
        foreach (CareProvider careProvider in AssignedProviders)
        {
            int provThrow = careProvider.GetDiceThrow();
            providerThrows.Add(provThrow);
            throwSum += provThrow;
        }

        survivalThreshold = Injury.SurvivalThreshold;

        survived = throwSum >= survivalThreshold;
    }

    public void UpdateCareProviderMorales(bool survived)
    {
        foreach (CareProvider careProvider in AssignedProviders)
        {
            careProvider.MoraleChangeFromPatientOutcome = survived ? 0 : -PotentialMoraleDelta;
        }
    }
}
