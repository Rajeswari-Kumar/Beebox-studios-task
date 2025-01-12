using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cube_revolve : MonoBehaviour
{
    public Vector3 direction;
    public float rotate_speed;
    public float lifeline = 0;
    public TMP_Text lifeline_text;
    private void Start()
    {
        lifeline_text.text = lifeline.ToString();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            transform.Rotate(direction * rotate_speed * Time.deltaTime, Space.Self);
            lifeline--;
            lifeline_text.text = lifeline.ToString();
        }
    }

    private void Update()
    {
        if(lifeline == 0)
        {
            Destroy(transform.gameObject);
        }
    }
}
