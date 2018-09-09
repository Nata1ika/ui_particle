using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWorldPosition : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] RectTransform _target;
    [SerializeField] bool _setPositionOnStart;

    private void Start()
    {
        if (_setPositionOnStart)
        {
            UpdatePosition();
        }
    }

    public void UpdatePosition()
    {
        transform.position = _camera.ScreenToWorldPoint(_target.position);
    }
}
