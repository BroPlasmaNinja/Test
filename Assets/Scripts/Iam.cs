using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iam : MonoBehaviour
{
    [SerializeField] string iam;
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            other.GetComponent<PlayerController>().NumNum(iam);
            Destroy(gameObject);
        }
    }
}
