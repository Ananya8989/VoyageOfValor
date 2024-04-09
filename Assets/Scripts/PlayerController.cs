using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int speed;
    private IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
       if(SceneManager.GetActiveScene().name == "Infinite Level" ){
        speed = 15;
        coroutine = WaitAndSet(100.0f);
        StartCoroutine(coroutine);
        }
     }

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * hInput * Time.deltaTime * speed);

       if (transform.position.x > 65)
       {
        transform.position = new Vector3(65, transform.position.y, transform.position.z);
       }
      if (transform.position.x < -62)
      {
      transform.position = new Vector3(-62, transform.position.y, transform.position.z);
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
   
}
