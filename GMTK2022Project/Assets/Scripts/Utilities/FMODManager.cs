using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;

public class FMODManager : MonoBehaviour
{

    [SerializeField] private IntVariable TotalMorale;
    [SerializeField] private PatientVariable selectedPatient;
    [SerializeField] private CareProviderVariable currentProvider;

    

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
        currentProvider.ValueUpdated += HandlePickup;
    }
    
    private void OnDisable()
    {
        TotalMorale.ValueUpdated -= UpdateGameplayLayers;
        selectedPatient.ValueUpdated -= UpdateInView;
        currentProvider.ValueUpdated -= HandlePickup;

    }

    private void UpdateInView()
    {
        if (selectedPatient.Value != null)
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("In Patient View", 1);
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("In Patient View", 0);
        }
    }

    private void UpdateGameplayLayers()
    {
        float value;
        int val= ((TotalMorale.Value - 2) / 2) - 1;
        index =  val;
        
        FMOD.RESULT result = FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Morale Level", index);
        FMODUnity.RuntimeManager.StudioSystem.getParameterByName("Morale Level",   out value);
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
        _soundInstance.stop(STOP_MODE.ALLOWFADEOUT);
        _musicInstance.stop(STOP_MODE.ALLOWFADEOUT);
        _musicInstance = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Title");
        _musicInstance.start();

    }
    
    public void PlayDiceRoll()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Dice Roll");
    }
    
    public void PlayButton()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Menu Click");
    }

    public void HandlePickup()
    {
        if (currentProvider.Value == null)
        {
            PlayDrop();
        }
        else
        {
            PlayPickup();
        }
    }

    public void PlayPickup()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Menu Pickup");
    }
    
    public void PlayDrop()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Menu Drop");
    }

    public void StopMusic()
    {
        _musicInstance.stop(STOP_MODE.ALLOWFADEOUT);
    }
    
  
}
