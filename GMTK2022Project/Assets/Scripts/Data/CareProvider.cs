using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CareProvider : ScriptableObject
{

     public string name; 
     public int currentMorale; 
     public Sprite image;
     public Color indicator;
     public ProviderRole role;
     public bool assigned;
   
}
