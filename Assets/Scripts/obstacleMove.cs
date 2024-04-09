using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class obstacleMove : MonoBehaviour
{
    GameManager manager;
    private IEnumerator coroutine;
    int n = 0;
    AudioSource source;
    public AudioClip clip;
    public ParticleSystem crash;
    public int speed;
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Level 1" ){
        speed = 15;
        }
        if(SceneManager.GetActiveScene().name == "Level 2" ){
        speed = 25;
        }
        if(SceneManager.GetActiveScene().name == "Level 3" ){
        speed = 35;
        }
        if(SceneManager.GetActiveScene().name == "Level 4" ){
        speed = 45;
        }
        if(SceneManager.GetActiveScene().name == "Level 5" ){
        speed = 55;
        }
         if(SceneManager.GetActiveScene().name == "Infinite Level" ){
        speed = 15;
        coroutine = WaitAndSet(100.0f);
        StartCoroutine(coroutine);
        }
        source = GetComponent<AudioSource>();
        manager =FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {   if(!manager.gameOver)
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if(transform.position.z>120){
            Destroy(gameObject);
        }
        
    }
    private IEnumerator WaitAndSet(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            speed += 5;
            Debug.Log(speed);
        }
    }

     void OnCollisionEnter(Collision collision){
        if(collision.gameObject.name.Contains("Mesh")){
        if(gameObject.tag == "treasure"){
           if(n==0) {
            manager.updateScore();
            n++;}
            Instantiate(crash, transform.position, transform.rotation);
            crash.Play();
            source.PlayOneShot(clip);
            Destroy(gameObject,1f);
        }
        if(gameObject.tag == "enemy"){
            if(n==0){
            manager.updateLives();
            n++;}
            Instantiate(crash, transform.position, transform.rotation);
            crash.Play();
            source.PlayOneShot(clip);
            Destroy(gameObject,1f);
        }
        source.PlayOneShot(clip);

        }
    }
}
