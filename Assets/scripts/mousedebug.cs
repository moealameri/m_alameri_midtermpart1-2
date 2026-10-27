using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonDebugger : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("SUCCESS: Mouse click physically touched the button!");
    }
}