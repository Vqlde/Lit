using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBrick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collidedObject = collision.gameObject;

        if (collidedObject.transform.name == "Player")
        {
            Debug.Log("Du døde til en killbrick!");
        }

    }
}
