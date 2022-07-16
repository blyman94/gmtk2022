using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayOverProcedure : MonoBehaviour
{
    [SerializeField] private PatientListVariable dayPatients;
    [SerializeField] private CareProviderListVariable careProviders;
    [SerializeField] private IntVariable patientDeathCount;

    public void PhaseOne()
    {
        foreach (Patient patient in dayPatients.Value)
        {
            patient.GetSurvivalData(out int naturalThrow,
                out List<int> providerThrows, out int survivalThreshold,
                out int throwSum, out bool survived);
            patient.UpdateCareProviderMorales(survived);
            if (!survived)
            {
                patientDeathCount.Value += 1;
            }

            string toPrintString = patient.Name + ":\n";
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

    public void PhaseTwo()
    {
        string toPrintString = "Provider Morale Changes:\n";
        foreach (CareProvider careProvider in careProviders.Value)
        {
            toPrintString += "    Name: " + careProvider.Name + "\n";
            toPrintString += "        Prev Morale: " + careProvider.CurrentMorale + "\n";
            careProvider.UpdateCurrentMorale();
            toPrintString += "        New Morale: " + careProvider.CurrentMorale + "\n";
        }
        Debug.Log(toPrintString);
        toPrintString = "";
    }

    public void PhaseThree()
    {

    }
}
