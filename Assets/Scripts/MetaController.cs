using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;
public class MetaController : MonoBehaviour
{
    public GameObject car1;
    public CarAIControl car1Component;
    public GameObject car2;
    public CarAIControl car2Component;
    public GameObject player;
    public CarUserControl playerComponent;
    public int conta;
    public bool car1Triggered;
    public bool car2Triggered;
    public bool playerTriggered;
    public Text finishMessage;
    public Text countDown;
    public Text playerTime;
    public float timeRemaining = 4;
    void Start()
    {
        car1Component = car1.GetComponent<CarAIControl>();
        car2Component = car2.GetComponent<CarAIControl>();
        playerComponent = player.GetComponent<CarUserControl>();
        car1Component.disable=true;
        car2Component.disable=true;
        playerComponent.disable=true;

    }


    private void OnTriggerEnter(Collider other)
    {
        //Check to see if the tag on the collider is equal to Enemy
        if (other.tag == "car1" && car1Triggered)
        {
           conta++;
        }
        if (other.tag == "car2" && car2Triggered)
        {
           conta++;
        }
        if (other.tag == "player" && playerTriggered)
        {
           conta++;
           finishMessage.text = "Has Terminado en "+conta+"ª posicion";
        }
    }

    // Update is called once per frame
    void Update()
    {   
         if (timeRemaining > 1)
        {

            timeRemaining -= Time.deltaTime;
            countDown.text=Mathf.FloorToInt(timeRemaining % 60).ToString();
        }else{
            countDown.text="";
            car1Component.disable=false;
            car2Component.disable=false;
            playerComponent.disable=false;
        }
    }
}
