using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSea : MonoBehaviour
{
    public GameManager manager;
    private float speed = 20;
    private Vector3 startPos;
    
    void Start() {
     startPos = transform.position;
}
    void Update() {
         if (transform.position.z > 111) {
         transform.position = startPos; }
         if(!manager.gameOver)
         transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
