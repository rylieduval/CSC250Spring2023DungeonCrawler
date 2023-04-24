using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterTrigger : MonoBehaviour
{
    public Rigidbody rb;
    public static MonsterTrigger m; 


    // Start is called before the first frame update
    void Start()
    {
        this.rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MonsterAttack()
    {
        this.rb.AddForce(Vector3.left * 150.0f);
    }

    
}