using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Secret : MonoBehaviour
{
    [SerializeField] GameObject text;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Hero")
        text.GetComponent<Text>().color = new Vector4(0, 0, 0, 1);
    }
    private void OnTriggerExit(Collider other)
    {
        text.GetComponent<Text>().color = new Vector4(0, 0, 0, 0);
    }
}

