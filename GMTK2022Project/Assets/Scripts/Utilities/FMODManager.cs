using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;

public class FMODManager : MonoBehaviour
{

    [SerializeField] private IntVariable TotalMorale;
    [SerializeField] private PatientVariable selectedPatient;

    

    private EventInstance _musicInstance;
    private EventInstance _soundInstance;

    [SerializeField] private float index;




    public void Start()
    {
        StartTitle();
    }

    private void OnEnable()
    {
        TotalMorale.ValueUpdated += UpdateGameplayLayers;
        selectedPatient.ValueUpdated += UpdateInView;
    }

    private void UpdateInView()
    {
        if (selectedPatient.Value != null)
        {
            _musicInstance.setParameterByName("In Patient View", 1);
        }
        else
        {
            _musicInstance.setParameterByName("In Patient View", 0);
        }
    }

    private void UpdateGameplayLayers()
    {
        Debug.Log("Checking");
        float value;
        int val= ((TotalMorale.Value - 2) / 2) - 1;
        index =  val;
        FMOD.RESULT result = _musicInstance.setParameterByName("Morale Level", index);
        Debug.Log(result);
        _musicInstance.getParameterByName("Morale Level",   out value);
        Debug.Log("FLOAT: " + value.ToString() );
        
    }


    public void startBackground()
    {
        _soundInstance = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Gameplay Ambience");
        _soundInstance.start();
    }
    
    
    public void startGameplay()
    {
        _musicInstance.stop(STOP_MODE.ALLOWFADEOUT);
        _musicInstance = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Gameplay");
        _musicInstance.start();
    }
    

    public void StartTitle()
    {
        _musicInstance.stop(STOP_MODE.ALLOWFADEOUT);
        _musicInstance = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Title");
        _musicInstance.start();

    }


    public void PlayDiceRoll()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Dice Roll");
        Debug.Log("Play Dice Roll");
    }
    
    public void PlayButton()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Menu Click");
    }
}
