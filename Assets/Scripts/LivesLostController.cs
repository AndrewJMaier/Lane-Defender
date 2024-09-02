using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesLostController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            //Destroys enemy when they enter killbox
            Destroy(other.gameObject);

        }
    }
}
