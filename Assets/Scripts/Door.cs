using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Transform _initialPos;
    [SerializeField] private Transform _activePos;
    private bool _active = false;
    void Start()
    {
        _initialPos = transform;
    }

    public void Activate()
    {
        if (!_active)
        {
        transform.position = _activePos.position;
        _active = true;
        }
        
    }

    public void Deactivate()
    {
        if (_active)
        {
            transform.position = _initialPos.position;
            _active = false;
        }
    }
}
