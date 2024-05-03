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

    public GameObject interactui;
    public GameObject scurvyui;

    public GameObject island;

    // Start is called before the first frame update
    void Start()
    {

        screen1.SetActive(true);
        screen2.SetActive(false);

        interactui.SetActive(false);
        scurvyui.SetActive(false);

    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject == player)
        {
            canRun = true;
            interactui.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            interactui.SetActive(false);
        }
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
            Debug.Log("Island Moved");
            island.transform.Translate(0, 0, -300);
        }
        else
        {
            audio.clip = errorClip;
            Debug.Log("L");
        }

        scurvyui.SetActive(true);
        StartCoroutine(gotScurvy());

        canRun = false;
        
        

        audio.volume = 0.1f;

        audio.Play();

        runcount++;
    }

    IEnumerator gotScurvy()
    {
        yield return new WaitForSeconds(5.0f);

        scurvyui.SetActive(false);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
