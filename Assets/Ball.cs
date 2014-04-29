using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    public float BallSpeed;

    private bool isRunning;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Reset());
    }

    // Update is called once per frame
    void Update()
    {
        normalizeSpeed();
        //Debug.Log(rigidbody.velocity);
    }

    void OnCollisionEnter(Collision collision)
    {

        if(!isRunning)
        {
            return;
        }
        if(collision.gameObject.tag == "EndWall")
        {
            StartCoroutine(Reset());
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if(!isRunning)
        {
            return;
        }
        float rX = Random.Range(-1.0f, 1.0f) + rigidbody.velocity.x;
        float rZ = Random.Range(-1.0f, 1.0f) + rigidbody.velocity.z;
        if (rigidbody.velocity.z < 2f && rigidbody.velocity.z > -2f && collision.gameObject.tag == "Wall")
        {
            Debug.Log("poprawiono");
            rZ += 3f;
            rX -= 3f;
        }
        if(Mathf.Sign(rX) != Mathf.Sign(rigidbody.velocity.x))
        {
            rX = -rX;
        }
        if(Mathf.Sign(rZ) != Mathf.Sign(rigidbody.velocity.z))
        {
            rZ = -rZ;
        }

        rigidbody.velocity = new Vector3(rX, 0, rZ);
            normalizeSpeed();
        //}
    }

    private void normalizeSpeed()
    {
        rigidbody.velocity = Vector3.Normalize(rigidbody.velocity) * BallSpeed;
        rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z);
    }

    private IEnumerator Reset()
    {
        isRunning = false;
        rigidbody.velocity = new Vector3(0, 0, 0);
        rigidbody.position = new Vector3(0, 0.5f, 4);
        yield return new WaitForSeconds(1.2f);
        isRunning = true;
        rigidbody.velocity = new Vector3(Random.Range(-4.0f, 4.0f), 0, (BallSpeed / 2));
        Debug.Log(rigidbody.velocity);
        normalizeSpeed();
    }
}
