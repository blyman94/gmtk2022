using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNameGenerator : MonoBehaviour
{
    [SerializeField]
    public string filePathFN;
    public string filePathLN;

    private List<string> firstNames;
    private List<string> lastNames;

    // Reads File of List of Strings with \n between each entry
    private List<string> ReadNamesFromFile(string filePath) {
        List<string> newList = new List<string>();
        StreamReader inpStm = new StreamReader(filePath);

        while(!inpStm.EndOfStream)
        {
            string inpLn = inpStm.ReadLine();
            newList.Add(inpLn);
        }
        inpStm.Close(); 
        return newList;
    }

    public string GetRandomFirstName() {
        return firstNames[Random.Range(0,firstNames.Count)];
    }

    public string GetRandomLastName() {
        return lastNames[Random.Range(0, lastNames.Count)];
    }


    // Start is called before the first frame update
    void Start()
    {
        firstNames = ReadNamesFromFile(filePathFN);
        lastNames = ReadNamesFromFile(filePathLN);
        Debug.Log("Random Name Test: " + GetRandomFirstName() + " " + GetRandomLastName());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
