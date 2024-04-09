using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSky : MonoBehaviour
{
     public GameManager manager;
    private float speed = 5;
    private Vector3 startPos;
    
    void Start() {
     startPos = transform.position;
}
    void Update() {
         if (transform.position.x > 70) {
         transform.position = startPos; }
         if(!manager.gameOver)
         transform.Translate(Vector3.right * Time.deltaTime * speed);
    }
}
