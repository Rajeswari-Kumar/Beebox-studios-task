using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_destroy : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Cube"))
        {
            Destroy(transform.gameObject);
        }
    }
}
