using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject player;
    public List<GameObject> picContainer;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPicContainers();
        SpawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnPlayer()
    {
        Instantiate(player, new Vector3(0, -2.2f, 0), Quaternion.identity);
    }

    void SpawnPicContainers()
    {
        float xPos = -5.0f;
        for (int i = 0; i < picContainer.Count; i++)
        {
            Instantiate(picContainer[i], new Vector3(xPos, 2.7F, 0), Quaternion.identity);
            xPos += 3.5f;
        }
    }
}
