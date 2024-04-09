using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dan.Main;

public class LeaderBoard : MonoBehaviour
{
    [SerializeField]
    private List<TextMeshProUGUI> names;
    [SerializeField]
    private List<TextMeshProUGUI> scores;

    private string plkey = "0fd8720047fc48835987483e818076372eefafacbd650444d617bdb7ed04aa2f";
    
    void Start(){
        GetLeaderboard();
    }

    public void GetLeaderboard(){
      LeaderboardCreator.GetLeaderboard(plkey,((msg) =>{
        int loopLength = (msg.Length < names.Count) ? msg.Length :names.Count;
        for(int i = 0; i < loopLength; ++i){
            names[i].text = msg[i].Username;
            scores[i].text = msg[i].Score.ToString();
        }
      }));
    }

    public void SetLeaderboardEntry(string username, int score){
        if(username.Length > 10){
            username = username.Substring(0,10);
        }
        
        LeaderboardCreator.UploadNewEntry(plkey,username,score,((msg) =>{
            
            GetLeaderboard();
        }));
    }
}
