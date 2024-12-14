using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    [SerializeField] private Transform _respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Grabbable") || other.gameObject.TryGetComponent<FPSController>(out FPSController controller))
        {

            other.gameObject.transform.position = _respawnPoint.position;
        }
    }
}
