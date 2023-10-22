using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickInput : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private GameObject _knob;
    [SerializeField] private GameObject _joystickBody;

    private Vector3 _startPoint;  
    
    private static Vector3 _input; 
    public static Vector3 Input => _input; 

    public void OnPointerDown(PointerEventData eventData)
    {
        _joystickBody.transform.position = UnityEngine.Input.mousePosition;
        _startPoint = UnityEngine.Input.mousePosition;
        _joystickBody.SetActive(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _joystickBody.SetActive(false);
        _input = Vector3.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _input = UnityEngine.Input.mousePosition - _startPoint;
        _knob.transform.position = _startPoint + Vector3.ClampMagnitude(_input, 25f);    
    }
}
