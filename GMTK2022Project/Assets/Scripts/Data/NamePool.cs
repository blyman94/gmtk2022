using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "FILENAME", menuName = "MENUNAME", order = 0)]
public class NamePool : ScriptableObject
{
    public List<string> names;

    public string PickRandomName()
    {
        return names[Random.Range(0, names.Count)];
    }
}