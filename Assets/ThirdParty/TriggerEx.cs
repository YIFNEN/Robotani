using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEx : MonoBehaviour
{
    private Renderer rend;
    int colorRandom1; // ·£´ý»ö»ó R
    int colorRandom2; // ·£´ý»ö»ó G
    int colorRandom3; // ·£´ý»ö»ó B

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        
    }
    void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            rend.material.color = Color.red;
        }
        else if (collision.gameObject.CompareTag("Pin"))
        {
            colorRandom1 = Random.Range(0, 255);
            colorRandom2 = Random.Range(0, 255);
            colorRandom3 = Random.Range(0, 255);
            rend.material.color = new Color(colorRandom1 / 255f, colorRandom2 / 255f, colorRandom3 / 255f);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
