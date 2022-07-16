using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakroomDisplayParent : MonoBehaviour
{

    [SerializeField] private CareProviderListVariable BreakRoomProviders;

    [SerializeField] private List<BreakroomDisplay> displays;
    
    
    // Start is called before the first frame update
    void OnEnable()
    {
        BreakRoomProviders.ValueUpdated += UpdateDisplay;
    }
    void OnDisable()
    {
        BreakRoomProviders.ValueUpdated -= UpdateDisplay;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateDisplay()
    {
        for(int i = 0; i < displays.Count; i++)
        {
            displays[i].Provider = BreakRoomProviders.Value[i];
        }
        
        
    }
}
