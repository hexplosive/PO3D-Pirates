using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractLaptop : MonoBehaviour
{
    public GameObject player;
    public bool canRun = false;
    private int runcount = 0;
    public AudioClip laughClip;
    public AudioClip errorClip;

    public GameObject screen1;
    public GameObject screen2;

    // Start is called before the first frame update
    void Start()
    {

        screen1.SetActive(true);
        screen2.SetActive(false);

    }

    private void OnTriggerEnter(Collider other)
    {
        canRun = true;
    }



    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E) && other.gameObject == player && canRun)
        {
            OnInteract();
        }
    }

    void OnInteract()
    {
        AudioSource audio = player.GetComponent<AudioSource>();

        if (runcount == 0)
        {
            audio.clip = laughClip;
            screen1.SetActive(false);
            screen2.SetActive(true);
            Debug.Log("YOU GOT SCURVY!");
        }
        else
        {
            audio.clip = errorClip;
            Debug.Log("L");
        }
        

        canRun = false;
        
        

        audio.volume = 0.1f;

        audio.Play();

        runcount++;
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
