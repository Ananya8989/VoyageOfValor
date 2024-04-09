using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.SceneManagement;
public class HighScore : MonoBehaviour
{
    public static int HighestScore = 0;
    [SerializeField]
    private TextMeshProUGUI inputScore;
    [SerializeField]
    private TMP_InputField inputName;

    public UnityEvent<string, int> submitScoreEvent;
     void Start()
    {
        if(SceneManager.GetActiveScene().name != "Home Level Selection"){
          inputScore = null;
          inputName = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
      if(SceneManager.GetActiveScene().name != "Home Level Selection"){
          inputScore = null;
          inputName = null;
        }
        else{
        inputScore.text = "Your High Score: " + HighestScore.ToString();}
    }

    public void SubmitScore(){
      submitScoreEvent.Invoke(inputName.text, HighestScore);
    }

    public void NewHighScore(int score){
      if(score>HighestScore)
      HighestScore = score;
    }
}
