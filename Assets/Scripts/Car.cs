using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float speedGain = 0.2f;
    [SerializeField] private float turnSpeed = 200f;

    public int steerValue;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle")) {
            speed = 0;
            SceneManager.LoadScene(0);
        }
    }

    void Update() {
        speed += speedGain * Time.deltaTime;
        
        transform.Rotate(0f, steerValue * turnSpeed * Time.deltaTime, 0f);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    
    public void Steer(int value) {
        steerValue = value;
    }
}
