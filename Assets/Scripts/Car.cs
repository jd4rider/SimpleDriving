using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float speedGain = 0.2f;
    [SerializeField] private float turnSpeed = 200f;

    public int steerValue;
    
    void Start() {}

    void Update() {
        speed += speedGain * Time.deltaTime;
        
        transform.Rotate(0f, steerValue * turnSpeed * Time.deltaTime, 0f);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    
    public void Steer(int value) {
        steerValue = value;
    }
}
