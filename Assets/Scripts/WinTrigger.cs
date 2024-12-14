using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    [SerializeField] private TMP_Text _winText;

    private void OnTriggerEnter(Collider other)
    {
        _winText.gameObject.SetActive(true);
    }
}
