using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravGun : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float maxGrabDistance = 10f, throwForce = 20f, lerpSpeed = 10f;
    [SerializeField] private Transform objectHolder;

    Rigidbody grabbedRB;

    void Update()
    {
        if (grabbedRB)
        {
            grabbedRB.MovePosition(Vector3.Lerp(grabbedRB.position, objectHolder.transform.position, Time.deltaTime * lerpSpeed));

            if (Input.GetMouseButtonDown(0))
            {
                grabbedRB.isKinematic = false;
                grabbedRB.AddForce(cam.transform.forward * throwForce, ForceMode.VelocityChange);
                grabbedRB = null;
            }
        }


        if (Input.GetKeyDown(KeyCode.E))
        {
            if (grabbedRB)
            {
                grabbedRB.isKinematic = false;
                grabbedRB = null;
            }
            else
            {
                RaycastHit hit;
                Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
                if (Physics.Raycast(ray, out hit, maxGrabDistance) && hit.collider.gameObject.layer == LayerMask.NameToLayer("Grabbable"))
                {
                    grabbedRB = hit.collider.gameObject.GetComponent<Rigidbody>();
                    if (grabbedRB)
                    {
                        grabbedRB.isKinematic = true;
                    }
                }
            }
        }
    }
}
