using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    public static bool finishLev1;
    public static bool finishLev2;
    public static bool finishLev3;
    public static bool finishLev4;
    public static void SetFinish(string name){
       if(name == "Level 1"){
        finishLev1 = true;
       }
       if(name == "Level 2"){
        finishLev2 = true;
       }
       if(name == "Level 3"){
        finishLev3 = true;
       }
       if(name == "Level 4"){
        finishLev4 = true;
       }
       
    }

}
