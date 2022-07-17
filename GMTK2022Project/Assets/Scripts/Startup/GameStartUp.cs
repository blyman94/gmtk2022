using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartUp : MonoBehaviour
{
    [SerializeField] private List<CareProvider> careProviders;
    [SerializeField] private IntVariable PatientDeathCount;
    [SerializeField] private IntVariable DayCount;

    [SerializeField] private GameEvent OnStartNewDayEvent;

    private void Awake()
    {
        PatientDeathCount.Value = 0;
        DayCount.Value = 0;

        foreach (CareProvider careProvider in careProviders)
        {
            careProvider.CurrentMorale = careProvider.Role.MaxMorale;
        }
    }

}
