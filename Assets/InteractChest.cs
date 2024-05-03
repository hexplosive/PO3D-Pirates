using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractChest : MonoBehaviour
{
    public GameObject player;

    private bool isRunning = false;

    public GameObject chest;

    public GameObject chestlid;

    public GameObject ui;

    public GameObject orange;

    public Animator chestanimator;

    public Animator orangeanimator;

    private bool hasOpened = false;
    private bool boxbool = true;

    private bool hasOranged = false;
    private bool orangebool = true;

    float xpos = 0.0f;
    float ypos = 0.0f;
    float zpos = 0.0f;

    private int runcount = 0;

    public AudioClip fanfare;
    public AudioClip munch;

    public GameObject winimage;

    // Start is called before the first frame update
    void Start()
    {
        

        ui.SetActive(false);
        winimage.SetActive(false);
    }


    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E) && other.gameObject == player && !isRunning) 
        {
            OnInteract();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            ui.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            ui.SetActive(false);
        }
    }

    void OnInteract() 
    {
        AudioSource audio = player.GetComponent<AudioSource>();

        if (runcount == 0)
        {
            xpos = orange.transform.position.x;
            ypos = orange.transform.position.y;
            zpos = orange.transform.position.z;
            isRunning = true;
            StartCoroutine(OpenBox());
            chestanimator.SetTrigger("Open");
            orangeanimator.SetTrigger("Appear");
            StartCoroutine(Orange());
            audio.clip = fanfare;
            runcount++;
            audio.volume = 0.1f;
            audio.Play();
        }
        else if (runcount == 1)
        {
            Debug.Log("running");
            audio.clip = munch;
            orange.SetActive(false);
            runcount++;
            audio.volume = 0.1f;
            audio.Play();
            StartCoroutine(Win());
        }

        


    }

    IEnumerator OpenBox()
    {
        yield return new WaitForSeconds(1.25f);
        hasOpened = true;

    }

    IEnumerator Orange()
    {
        yield return new WaitForSeconds(4.25f);
        hasOranged = true;
        isRunning = false;
    }    

    IEnumerator Win()
    {
        yield return new WaitForSeconds(5f);
        winimage.SetActive(true);

    }


    // Update is called once per frame
    void Update()
    {
        if (hasOpened && boxbool)
        {
            chestanimator.enabled = false;
            chestlid.transform.rotation = Quaternion.Euler(-120, 165, 0);
            boxbool = false;
            
        }
        if (hasOranged && orangebool)
        {
            ypos = ypos + 0.65f;
            Vector3 newPos = new Vector3(xpos, ypos, zpos);

            orangeanimator.enabled = false;

            orange.transform.position = newPos;
            orangebool = false;

        }
        else if (hasOranged && runcount > 1)
        {
            Vector3 newPos = new Vector3(xpos, ypos, zpos);
            orange.transform.position = newPos;

            orange.transform.Rotate(0, 0.05f, 0);
        }

        if (winimage.activeSelf)
        {
            ui.SetActive(false);
        }


    }
}
