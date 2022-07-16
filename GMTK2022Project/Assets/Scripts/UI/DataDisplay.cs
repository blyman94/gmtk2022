using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DataDisplay : MonoBehaviour
{
    [SerializeField] private IntVariable variable;

    [SerializeField] private TextMeshProUGUI field;

    [SerializeField] private string textLabel;
    private void OnEnable()
    {
        variable.ValueUpdated += UpdateDisplay;
    }

    private void Start()
    {
        UpdateDisplay();
    }

    private void OnDisable()
    {
        variable.ValueUpdated -= UpdateDisplay;
    }

    private void UpdateDisplay()
    {
        field.text = textLabel + variable.Value;
    }
}
