using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCollide : MonoBehaviour
{
    public GameObject player;    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            Debug.Log("I just ran");
            PlayerVariables pv = player.GetComponent<PlayerVariables>();
            pv.Respawn();
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
