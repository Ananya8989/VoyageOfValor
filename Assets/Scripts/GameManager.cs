using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public HighScore re;
    public Image pausedScreen;
    public Image wonScreen;
    public Image moon;
    AudioSource source;
    public AudioClip clip;
    public Image livesImage;
    public bool win = false;
    public int obstacleIndex;
    public TextMeshProUGUI scoreText;
    public Image gameOverScreen;
    public Sprite health1,health2,health3,health4,health5;
    public Button respawnButton;
    public TextMeshProUGUI deathResponse;
    public TextMeshProUGUI gameOverResponse;
    int score;
    int lives;
    bool paused;
    public bool gameOver = false;
    private float startDelay = 2;
   private float repeatRate = 2;
    void Start() {
    if(SceneManager.GetActiveScene().name != "Infinite Level"){
      re = null;
    }
    source = GetComponent<AudioSource>();
    gameOverScreen.gameObject.SetActive(false);
    respawnButton.gameObject.SetActive(false);
    deathResponse.gameObject.SetActive(false);
    gameOverResponse.gameObject.SetActive(false);
     lives = 5;   
     score = 0;
     scoreText.text = "Score: " + score;
     Vector3 spawnPos = new Vector3(Random.Range(-70,70),5,30);
     obstacleIndex = Random.Range(0,obstaclePrefabs.Length);
     GameObject obstaclePrefab = obstaclePrefabs[obstacleIndex];
     
     InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
     Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation); }

    void SpawnObstacle () {
      if(!paused){
     Vector3 spawnPos = new Vector3(Random.Range(-70,70),5,30);
    obstacleIndex = Random.Range(0,obstaclePrefabs.Length);
     GameObject obstaclePrefab = obstaclePrefabs[obstacleIndex];
     Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation); }}

     void Update(){
      if(Input.GetKeyDown(KeyCode.Q)){
         Application.Quit();
      }
      if(paused&&gameOver){
                 livesImage.gameObject.SetActive(false);

      }
      if(paused&&win){
                 livesImage.gameObject.SetActive(false);

      }
      if(gameOver){
        if(SceneManager.GetActiveScene().name == "Infinite Level"){
        re.NewHighScore(score);}
         CancelInvoke();
         updateLives();
         moon.gameObject.SetActive(false);
         livesImage.gameObject.SetActive(false);
         gameOverScreen.gameObject.SetActive(true);
         respawnButton.gameObject.SetActive(true);
         deathResponse.gameObject.SetActive(true);
         gameOverResponse.gameObject.SetActive(true);
      }

      if(Input.GetKeyDown(KeyCode.P)){
        paused = !paused;
      }

      if(paused && !gameOver){
        pausedScreen.gameObject.SetActive(true);
        moon.gameObject.SetActive(false);
        livesImage.gameObject.SetActive(false);
      }

      if(!paused&& !gameOver){
        pausedScreen.gameObject.SetActive(false);
        moon.gameObject.SetActive(true);
        livesImage.gameObject.SetActive(true);

      }
     }


     public void updateScore(){
     score++;
     if(SceneManager.GetActiveScene().name == "Level 1" ||SceneManager.GetActiveScene().name == "Level 2" )
     scoreText.text = "Score: " + score + "/15";
     
     if(SceneManager.GetActiveScene().name == "Level 3" ||SceneManager.GetActiveScene().name == "Level 4" )
     scoreText.text = "Score: " + score + "/20";
     
     if(SceneManager.GetActiveScene().name == "Level 5" )
     scoreText.text = "Score: " + score + "/25";
     
     else{
      scoreText.text = "Score: " + score;
     }
     
     if(score == 15 && SceneManager.GetActiveScene().name == "Level 1" ){
      win = true;
      FinishLevel.SetFinish(SceneManager.GetActiveScene().name);
      Won();
     }
     if(score == 15 && SceneManager.GetActiveScene().name == "Level 2" ){
      win = true;
       FinishLevel.SetFinish(SceneManager.GetActiveScene().name);
      Won();
     }
      if(score == 20 && SceneManager.GetActiveScene().name == "Level 3" ){
      win = true;
       FinishLevel.SetFinish(SceneManager.GetActiveScene().name);
      Won();
     }
     if(score == 20 && SceneManager.GetActiveScene().name == "Level 4" ){
      win = true;
       FinishLevel.SetFinish(SceneManager.GetActiveScene().name);
      Won();
     }
     if(score == 25 && SceneManager.GetActiveScene().name == "Level 5" ){
      win = true;
       FinishLevel.SetFinish(SceneManager.GetActiveScene().name);
      Won();
     }
     }

     public void updateLives(){
        if(lives==0){
        gameOver = true;
        livesImage.gameObject.SetActive(false);
        lives--;}
        else{
         lives --;
        switch(lives) 
        {
         case 5:
            livesImage.sprite = health5;
            break;
         case 4:
            livesImage.sprite = health4;
            break;
         case 3:
            livesImage.sprite = health3;
            break;
         case 2:
            livesImage.sprite = health2;
            break;
         case 1:
            livesImage.sprite = health1;
            livesImage.gameObject.SetActive(false);
            Debug.Log("yyy");
            break;
         default:
            livesImage.gameObject.SetActive(false);
            Debug.Log("ttt");
            paused = true;
            gameOver = true;
           break;}
        }
     }

     public void respawn(){
      source.PlayOneShot(clip);
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
     }
     
     public void Won(){
       CancelInvoke();
       moon.gameObject.SetActive(false);
      livesImage.gameObject.SetActive(false);
      wonScreen.gameObject.SetActive(true);
      if(SceneManager.GetActiveScene().name == "Level 5"){
         SceneManager.LoadScene("Z End Cut Scene");
      }
     }
     public void Home(){
      if(SceneManager.GetActiveScene().name == "Infinite Level Selection"){
      re.NewHighScore(score);}
      SceneManager.LoadScene("Home Level Selection");
     }
     public void NextLevel(){
      if(SceneManager.GetActiveScene().name == "Level 1"){
      SceneManager.LoadScene("Level 2");}
      if(SceneManager.GetActiveScene().name == "Level 2"){
      SceneManager.LoadScene("Level 3");}
      if(SceneManager.GetActiveScene().name == "Level 3"){
      SceneManager.LoadScene("Level 4");}
      if(SceneManager.GetActiveScene().name == "Level 4"){
      SceneManager.LoadScene("Level 5");}
      if(SceneManager.GetActiveScene().name == "Level 5"){
      SceneManager.LoadScene("Home Level Selection");}
     }
}
