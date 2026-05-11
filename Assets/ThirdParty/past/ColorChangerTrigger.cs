using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangerTrigger : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Renderer rend = other.GetComponent<Renderer>();
            if (rend != null)
            {
                rend.material.color = Color.green;
            }


        }

    }


    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            Debug.Log("exit");
            Renderer rend = other.GetComponent<Renderer>();
            if (rend != null)
            {
                rend.material.color = Color.white;
            }


        }

    }
}
