using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class JoysticController : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public RectTransform _background;
    public RectTransform _handle;

    Vector2 _joystickCenter;
    PointerEventData _eventData;

    public void OnDrag(PointerEventData eventData)
    {
        if (_eventData.pointerId != eventData.pointerId)
        {
            return;
        }

        var radius = _background.sizeDelta.x / 2f - _handle.sizeDelta.x * 0.25f;
        var direction = eventData.position - _joystickCenter;
        var inputVector = (direction.magnitude > radius)
            ? direction.normalized
            : direction / (radius);
        _handle.anchoredPosition = inputVector * radius;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (_eventData.pointerId == eventData.pointerId)
        {
            _eventData = null;
            _handle.position = _joystickCenter;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _eventData = eventData;
        OnDrag(eventData);
    }


    void Start()
    {
        _joystickCenter = _handle.position;
    }
}
