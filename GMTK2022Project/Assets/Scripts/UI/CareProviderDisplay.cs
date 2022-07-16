using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CareProviderDisplay : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private CareProvider provider;

    [SerializeField] private TextMeshProUGUI NameField;
    [SerializeField] private TextMeshProUGUI RoleField;
    [SerializeField] private TextMeshProUGUI DiceField;
    [SerializeField] private Slider moraleSlider;
    [SerializeField] private Image backgroundTint;
    [SerializeField] private Image moraleColor;

    [SerializeField] private CareProviderVariable currentProvider;

    [SerializeField]
    private CareProviderListVariable breakroomProvider;
    private LayoutElement _layoutElement;

    

    public CareProvider Provider
    {
        get
        {
            return provider;
        }
        set
        {
            provider = value;
            UpdateDisplay();
        }
    }

    public void UpdateDisplay()
    {
        NameField.text = provider.Name;
        RoleField.text = provider.Role.RoleName;
        DiceField.text = provider.CurrentMorale + " - " + provider.Role.MaxDiceValue;

        backgroundTint.color = provider.indicatorColor;
        moraleSlider.maxValue = provider.Role.MaxMorale;
        moraleSlider.minValue = 1;
        moraleSlider.value = provider.CurrentMorale;
        moraleColor.color = Color.Lerp(Color.green, Color.red,
            (provider.Role.MaxMorale - provider.CurrentMorale) / provider.Role.MaxMorale);

    }
    
    // Start is called before the first frame update
    void Start()
    {
        if (provider != null)
        {
            provider.CurrentMorale= provider.Role.MaxMorale;
            UpdateDisplay();
        }
        
        _layoutElement = GetComponent<LayoutElement>();

    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _layoutElement.ignoreLayout = true;
        currentProvider.Value = provider;


    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _layoutElement.ignoreLayout = false;
      
        PointerEventData pointer = new PointerEventData(EventSystem.current);
        pointer.position = Input.mousePosition;

        List<RaycastResult> raycastResults = new List<RaycastResult>();

        EventSystem.current.RaycastAll(pointer, raycastResults);

        if (raycastResults.Count > 0)
        {
            foreach (var go in raycastResults)
            {
                BreakroomDisplay breakroomDisplay =
                    go.gameObject.GetComponent<BreakroomDisplay>();
                if (breakroomDisplay != null)
                {
                    int breakroomDisplayIndex = breakroomDisplay.index;
                    breakroomProvider.AddAtIndex(currentProvider.Value, breakroomDisplayIndex);
                }
            }
            currentProvider.Value = null;
        }
        }
         
    }

