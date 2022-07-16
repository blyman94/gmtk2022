using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ProviderDisplayItem : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    [SerializeField] private CareProvider observedProvider;

    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI rollDisplay;
    [SerializeField] private TextMeshProUGUI roleText;
    [SerializeField] private Image colorBackground;
    [SerializeField] private Image diceImage;
    [SerializeField] private Slider moraleSlider;
    [SerializeField] private Image moraleColor;
    private LayoutElement _layoutElement;

    [SerializeField] private CareProviderVariable currentCareProvider;
    
    public CareProvider ObservedProvider
    {
        get
        {
            return observedProvider;
        }
        set
        {
            observedProvider = value;
            UpdateDisplay();
        }
    }

    public void UpdateDisplay()
    {
        nameText.text = observedProvider.name.ToUpper();
        rollDisplay.text = observedProvider.currentMorale + " - " + observedProvider.role.MaxRoll;
        roleText.text = observedProvider.role.roleName.ToString().ToUpper();
        colorBackground.color = observedProvider.indicator;
        diceImage.sprite = observedProvider.role.DiceSprite;
        
        moraleSlider.maxValue = observedProvider.role.MaxMorale;
        moraleSlider.minValue = 1;
        moraleSlider.value = observedProvider.currentMorale;
        moraleColor.color = Color.Lerp(Color.green, Color.red, 
            (observedProvider.role.MaxRoll - observedProvider.currentMorale)/observedProvider.role.MaxRoll );


    }

    // Start is called before the first frame update
    void Start()
    {
        if (observedProvider != null)
        {
            observedProvider.currentMorale = observedProvider.role.MaxMorale;
            UpdateDisplay();
        }

        _layoutElement = GetComponent<LayoutElement>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _layoutElement.ignoreLayout = false;

        
        PointerEventData pointer = new PointerEventData(EventSystem.current);
        pointer.position = Input.mousePosition;

        List<RaycastResult> raycastResults = new List<RaycastResult>();
        
        EventSystem.current.RaycastAll(pointer, raycastResults);

        if(raycastResults.Count > 0)
        {
            foreach(var go in raycastResults)
            {
                Debug.Log(go.gameObject.name,go.gameObject);
                BreakRoomDisplay breakroomDisplay = go.gameObject.GetComponent<BreakRoomDisplay>();
                Debug.Log(breakroomDisplay == null);
                if ( breakroomDisplay != null)
                {
                    breakroomDisplay.ObservedProvider =
                        currentCareProvider.Value;
                }
            }
        }
        
        currentCareProvider.Value = null;

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _layoutElement.ignoreLayout = true;
        currentCareProvider.Value = observedProvider;
    }
}
