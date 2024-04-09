using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level1 : MonoBehaviour
{
    public Image notif2;
    public Image notif3;
    public Image notif4;
    public Image notif5;

     void Start()
    {
        if(FinishLevel.finishLev1){
            notif2.gameObject.SetActive(false);
        }
        if(FinishLevel.finishLev2){
            notif3.gameObject.SetActive(false);
        }
        if(FinishLevel.finishLev3){
            notif4.gameObject.SetActive(false);
        }
        if(FinishLevel.finishLev4){
            notif5.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadLevel1(){
        SceneManager.LoadScene("Level 1");
    }
    public void loadLevel2(){
        if(FinishLevel.finishLev1)
        SceneManager.LoadScene("Level 2");
    }
    public void loadLevel3(){
        if(FinishLevel.finishLev2)
        SceneManager.LoadScene("Level 3");
    }
    public void loadLevel4(){
        if(FinishLevel.finishLev3)
        SceneManager.LoadScene("Level 4");
    }
    public void loadLevel5(){
        if(FinishLevel.finishLev4)
        SceneManager.LoadScene("Level 5");
    }
    public void infinite(){
        SceneManager.LoadScene("Infinite Level");
    }
}
