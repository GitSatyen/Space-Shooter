using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiSpawner : MonoBehaviour
{
    public GameObject Asteroid;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                for (int k = 0; k < 4; k++)
                {
                    Instantiate(Asteroid, new Vector3(i * 3, j * 1, k * 2), Quaternion.identity);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
