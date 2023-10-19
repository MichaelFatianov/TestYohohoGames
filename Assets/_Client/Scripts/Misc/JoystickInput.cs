using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickInput : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private GameObject _knob;
    [SerializeField] private GameObject _joystickBody;

    private Vector3 _startPoint;  
    
    private static Vector3 _input; 
    public static Vector3 JInput => _input; 

    public void OnPointerDown(PointerEventData eventData)
    {
        _joystickBody.transform.position = Input.mousePosition;
        _startPoint = Input.mousePosition;
        _joystickBody.SetActive(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _joystickBody.SetActive(false);
    }

    public void OnDrag(PointerEventData eventData)
    {
        _input = _startPoint + Vector3.ClampMagnitude(Input.mousePosition - _startPoint, 25f);
        _knob.transform.position = _input;        
    }
}
