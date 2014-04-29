using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour
{
    public int Health;

    private bool updateHp;

    void Start()
    {
        renderer.material.color = getColor(Health);
    }

    void Update ()
    {
        if(updateHp)
        {
            renderer.material.color = getColor(Health);
            if (Health == 0)
            {
                Destroy(gameObject);
            }
            updateHp = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Health--;
            updateHp = true;
        }
    }

    private Color getColor(int hp)
    {
        if(hp == 1)
        {
            return new Color(1, 0.2f, 0.2f);
        }
        else if(hp == 2)
        {
            return new Color(0.2f, 1, 0.2f);
        }
        else
        {
            return new Color(0.2f, 0.2f, 1);
        }
    }
}
