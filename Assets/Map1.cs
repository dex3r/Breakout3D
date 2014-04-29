using UnityEngine;
using System.Collections;

public class Map1 : MonoBehaviour 
{
    public Object BlockCube;
    public Object BlockWide;

    public float MapCenterZ;

    // Use this for initialization
    void Start () 
    {
        for (int i = -9; i < 10; i++ )
        {
            for(int j = 0; j < 4; j++)
            {
                Instantiate(BlockCube, new Vector3(i * 1.5f, 0.5f, MapCenterZ + (j * 1.5f)), Quaternion.identity);
            }
        }
        for(float i = -3.5f; i < 4.5f; i++)
        {
            Instantiate(BlockWide, new Vector3(i * 3.5f, 0.5f, MapCenterZ - 1.5f), Quaternion.identity);
        }

    }
    
    // Update is called once per frame
    void Update () {
    
    }
}
