using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    public float speed = 10.0f;
    public float xRange = 20.0f;
    //public GameObject projectilePrefab;

    public float scoreIncrease = 100;
    private float highScore;
    private float score;
    private float startDelay = 2;
    private float scoreInterval = 1.0f;

    //Health Tracking
    public float health = 100;
    public float foodHealth = 10;
    public float animalDamage = 25;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CountScore", startDelay, scoreInterval);
    }

    // Update is called once per frame
    void Update()
    {
         if(health <= 0){
            //END GAME CONDTIONS
            Debug.Log("GAME OVER!!  Final Score:" + score);
            Destroy(gameObject);
        }
        horizontalInput = Input.GetAxis("Horizontal");

        if(transform.position.x < -xRange){
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        } else if(transform.position.x > xRange){
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

    }

     private void OnTriggerEnter(Collider other){
        //Debug.Log(other.tag);
        if(other.tag == "animal"){
            if(health > animalDamage){
                health = health - animalDamage;
                Debug.Log("Health: " + health);
            } else{
                health = 0;
                Debug.Log("Health: " + health);
            }
            
        } else if(other.tag == "food"){
            if(health <= 100 - foodHealth){
                health = health + foodHealth;
                Debug.Log("Health: " + health);
            } 
        }    
    }

    void CountScore(){
        score = score + scoreIncrease;
        //Debug.Log("Score:" + score);
    }
}
