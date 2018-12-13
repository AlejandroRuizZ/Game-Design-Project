using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyummy : MonoBehaviour
{
        public GameObject Dummy;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "Sword Attack")
        {
            Destroy(Dummy);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "Sword Attack")
        {
            Destroy(Dummy);
        }
    }
}
