using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuRacingButton : MonoBehaviour
{
   public void SwitchScene(int sceneNum)
   {
       SceneManager.LoadScene(sceneNum);
   }
}
