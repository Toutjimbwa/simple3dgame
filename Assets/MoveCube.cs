using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveCube : MonoBehaviour
{
    public AudioSource pewAS;
    public AudioSource youWinnAS;
    public Text pointsText;
    int points = 0;
    float speed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update");
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Down Arrow pressed!");
            transform.position = new Vector3(0, 10, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            float newX = transform.position.x - speed;
            float newY = transform.position.y;
            float newZ = transform.position.z;
            transform.position = new Vector3(newX, newY, newZ);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            float newX = transform.position.x + speed;
            float newY = transform.position.y;
            float newZ = transform.position.z;
            transform.position = new Vector3(newX, newY, newZ);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            float newX = transform.position.x;
            float newY = transform.position.y;
            float newZ = transform.position.z + speed;
            transform.position = new Vector3(newX, newY, newZ);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            float newX = transform.position.x;
            float newY = transform.position.y;
            float newZ = transform.position.z - speed;
            transform.position = new Vector3(newX, newY, newZ);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter!");
        points = points + 1;
        Debug.Log(points);
        Destroy(other.gameObject);
        pointsText.text = points.ToString();
        pewAS.Play();
        if(points == 8)
        {
            if (SceneManager.GetActiveScene().name.Equals("Level1"))
            {
                SceneManager.LoadScene("Level2");
            }else if (SceneManager.GetActiveScene().name.Equals("Level2"))
            {
                pointsText.text = "YOU WIN!";
                youWinnAS.Play();
            }
        }
    }
}