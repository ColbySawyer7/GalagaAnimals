using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    public float speed = 10.0f;
    public float xRange = 20.0f;
    public GameObject projectilePrefab;

    public float scoreIncrease = 100;
    private float highScore;
    private float score;
    private float startDelay = 2;
    private float scoreInterval = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CountScore", startDelay, scoreInterval);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if(transform.position.x < -xRange){
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        } else if(transform.position.x > xRange){
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        if(Input.GetKeyDown(KeyCode.Space)){
            //Launch projective from the player
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }

    void CountScore(){
        score = score + scoreIncrease;
        Debug.Log("Score:" + score);
    }
}
