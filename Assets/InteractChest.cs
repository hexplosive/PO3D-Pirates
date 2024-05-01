using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractChest : MonoBehaviour
{
    public GameObject player;

    private bool isRunning = false;

    public GameObject chest;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E) && other.gameObject == player && !isRunning) 
        {
            OnInteract();
        }
    }

    void OnInteract() 
    {
        isRunning = true;
        chest.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
