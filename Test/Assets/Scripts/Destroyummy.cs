using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyummy : MonoBehaviour
{
        public GameObject Dummy;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Sword Attack")
        {
            Destroy(Dummy);
        }
    }
}
