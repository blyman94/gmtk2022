using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoraleCalculator : MonoBehaviour
{
 [SerializeField] private List<CareProvider> providers;

 [SerializeField] private IntVariable TotalMorale;


 public void CalculateTotalMorale()
 {
     int morale = 0;

     foreach (CareProvider provider in providers)
     {
         morale += provider.CurrentMorale;
     }
     TotalMorale.Value = morale;
 }
}
