using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayOverProcedure : MonoBehaviour
{
    [SerializeField] private List<Patient> dayPatients;
    [SerializeField] private List<CareProvider> careProviders;
    [SerializeField] private IntVariable patientDeathCount;

    private void Start()
    {
        PhaseOne();
        PhaseTwo();
        PhaseThree();
    }

    private void PhaseOne()
    {
        foreach (Patient patient in dayPatients)
        {
            patient.GetSurvivalData(out int naturalThrow,
                out List<int> providerThrows, out int survivalThreshold,
                out int throwSum, out bool survived);
            patient.UpdateCareProviderMorales(survived);
            if (!survived)
            {
                patientDeathCount.Value += 1;
            }

            string toPrintString = patient.name + ":\n";
            toPrintString += string.Format("    NaturalThrow: {0}\n", naturalThrow);
            for (int i = 0; i < providerThrows.Count; i++)
            {
                toPrintString += string.Format("    Provider {0} Throw: {1}\n", i, providerThrows[i]);
            }
            toPrintString += string.Format("    Throw Sum: {0}\n", throwSum);
            toPrintString += string.Format("    Survival Threshold: {0}\n", survivalThreshold);
            toPrintString += string.Format("    Survived: {0}\n", survived.ToString());
            Debug.Log(toPrintString);
        }
    }

    private void PhaseTwo()
    {
        string toPrintString = "Provider Morale Changes:\n";
        foreach (CareProvider careProvider in careProviders)
        {
            toPrintString += "    Name: " + careProvider.Name + "\n";
            toPrintString += "        Prev Morale: " + careProvider.CurrentMorale + "\n";
            careProvider.UpdateCurrentMorale();
            toPrintString += "        New Morale: " + careProvider.CurrentMorale + "\n";
        }
        Debug.Log(toPrintString);
        toPrintString = "";
    }

    private void PhaseThree()
    {

    }
}
