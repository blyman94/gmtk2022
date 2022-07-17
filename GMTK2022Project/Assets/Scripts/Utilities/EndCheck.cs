using System;
using UnityEngine;

public class EndCheck : MonoBehaviour
{
    [SerializeField] private IntVariable dayCount;

    [SerializeField] private int endDayCount;

    [SerializeField] private GameEvent OnGameEnd;

    private void OnEnable()
    {
        dayCount.ValueUpdated += CheckEndCondition;
    }

    private void OnDisable()
    {
        dayCount.ValueUpdated -= CheckEndCondition;
    }
    public void CheckEndCondition()
    {
        if(dayCount.Value > endDayCount){
            OnGameEnd.Raise();   
        }
    }
}
