using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class ItemSwitch : MonoBehaviour
{
    [SerializeField] private GameObject _neededItem;
    [SerializeField] private Door _door;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == _neededItem)
        {
            _door.Activate();
        }
    }
}
