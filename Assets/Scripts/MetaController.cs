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
    private int conta;
    public static bool car1Triggered;
    public static bool car2Triggered;
    public static bool playerTriggered;
    public Text finishMessage;
    public Text countDown;
    public Text playerTime;
    private float timeRemaining = 4;
    private float timer = 0;
    private float minutes = 0;
    private float seconds = 0;
    private float miliseconds = 0;
    private bool finished = false;

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
        
        if (other.tag == "car1" && car1Triggered)
        {
           conta++;
           Debug.Log("Triggered by AI1" );
        }

        if (other.tag == "car2"  && car2Triggered)
        {
           conta++;
           Debug.Log("Triggered by AI2");
        }

        if (other.tag == "Player" && playerTriggered)
        {
           conta++;
           Debug.Log("Triggered by Player");
           finished=true;
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


            if(!finished){
                if(miliseconds >= 999){
                    if(seconds >= 59){
                        minutes++;
                        seconds = 0;
                    }
                    else if(seconds < 59){
                        seconds++;
                    }
                    
                    miliseconds = 0;
                }
                
                miliseconds += Time.deltaTime * 1000;
                
                
                playerTime.text = string.Format("{0}:{1}:{2}", minutes.ToString("00"), seconds.ToString("00"), miliseconds.ToString("000"));
                //timer+= Time.deltaTime;
                //playerTime.text=Mathf.FloorToInt(timer % 60).ToString();
                //playerTime.text=timeText
                countDown.text="";
                car1Component.disable=false;
                car2Component.disable=false;
                playerComponent.disable=false;
            }
        }
    }
}
