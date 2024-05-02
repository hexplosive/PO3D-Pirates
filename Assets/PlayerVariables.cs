using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVariables : MonoBehaviour
{
    public Vector3 spawnPoint = new Vector3(1, 3, 1);

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn()
    {
        player.transform.position = spawnPoint;
    }


}
