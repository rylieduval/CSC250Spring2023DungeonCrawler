using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class centerController : MonoBehaviour
{
    public GameObject thePlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Rigidbody rb = thePlayer.GetComponent<Rigidbody>();
            thePlayer.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity); ;
        }
    }
}
