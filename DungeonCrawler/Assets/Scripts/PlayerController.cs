using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject northExit, southExit, eastExit, westExit;
    

    public float movementSpeed = 40.0f;

    private bool moveBool = true;
    private bool moveToExit = true;
    private bool centerIsReal = false;
    

    // Start is called before the first frame update
    void Start()
    {
        this.rb = this.GetComponent<Rigidbody>();
        print(MasterData.count);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Exit")
        {
            if (other.gameObject == this.northExit && moveToExit == true)
            {
                moveToExit = false;
                centerIsReal = true;
                MasterData.whereDidIComeFrom = "north";
                this.rb.transform.position = this.southExit.transform.position;
                this.rb.AddForce(this.northExit.transform.position * movementSpeed);

            }
            if (other.gameObject == this.southExit && moveToExit == true)
            {
                moveToExit = false;
                centerIsReal = true;
                MasterData.whereDidIComeFrom = "south";
                this.rb.transform.position = this.northExit.transform.position;
                this.rb.AddForce(this.southExit.transform.position * movementSpeed);
            }
            if (other.gameObject == this.westExit && moveToExit == true)
            {
                moveToExit = false;
                centerIsReal = true;
                MasterData.whereDidIComeFrom = "west";
                this.rb.transform.position = this.eastExit.transform.position;
                this.rb.AddForce(this.westExit.transform.position * movementSpeed);
            }
            if (other.gameObject == this.eastExit && moveToExit == true)
            {
                moveToExit = false;
                centerIsReal = true;
                MasterData.whereDidIComeFrom = "east";
                this.rb.transform.position = this.westExit.transform.position;
                this.rb.AddForce(this.eastExit.transform.position * movementSpeed);
            }
            MasterData.count++;
            moveBool = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Center" && centerIsReal == true)
        {
            SceneManager.LoadScene("SampleScene");
            moveToExit = true;
            centerIsReal = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(moveBool == true)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                this.rb.AddForce(this.northExit.transform.position * movementSpeed);
                moveBool = false;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                this.rb.AddForce(this.southExit.transform.position * movementSpeed);
                moveBool = false;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                this.rb.AddForce(this.westExit.transform.position * movementSpeed);
                moveBool = false;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                this.rb.AddForce(this.eastExit.transform.position * movementSpeed);
                moveBool = false;
            }
        }
    }
}
