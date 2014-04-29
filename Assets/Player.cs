using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public KeyCode LeftKey;
    public KeyCode RightKey;

    public float padSpeed;

    void Start()
    {
        renderer.material.color = new Color(0.18f, 0.69f, 0.84f);
    }

    // Update is called once per frame
    void Update () 
    {
        if(Input.GetKey(LeftKey))
        {
            rigidbody.velocity = new Vector3(-padSpeed, 0, 0);
        }
        else if (Input.GetKey(RightKey))
        {
            rigidbody.velocity = new Vector3(padSpeed, 0, 0);
        }
        else
        {
            rigidbody.velocity = new Vector3(0, 0, 0);
        }
        if(rigidbody.position.x > 12.5 && rigidbody.velocity.x > 0)
        {
            rigidbody.velocity = new Vector3(0, 0, 0);
        }
        else if (rigidbody.position.x < -12.5 && rigidbody.velocity.x < 0)
        {
            rigidbody.velocity = new Vector3(0, 0, 0);
        }
    }
}
