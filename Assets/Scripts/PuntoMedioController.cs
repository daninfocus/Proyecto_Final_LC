using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntoMedioController : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "car1")
        {
           MetaController.car1Triggered=true;
           Debug.Log("Triggered midpoint by AI1");
        }
        if (other.tag == "car2")
        {
           MetaController.car2Triggered=true;
           Debug.Log("Triggered midpoint by AI2");
        }
        if (other.tag == "Player")//&& playerTriggered
        {
           MetaController.playerTriggered=true;
           Debug.Log("Triggered midpoint by Player");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
