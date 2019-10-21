using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneController : MonoBehaviour
{
    AudioSource PhoneAudio;

    public bool PlayClipOnce;

    //Phone clips
    public AudioClip PhoneRoom1Clue;
    public AudioClip CupRoom1Clue;
    public AudioClip PhoneRoom2Clue;
    public AudioClip PlantRoom2Clue;
    public AudioClip FanRoom2Clue;
    public AudioClip CoolerRoom2Clue;
    public AudioClip PhoneRoom3Clue;
    

    //Phone rooms
    public bool room1;
    public bool room2;
    public bool room3;
    public bool room4;
    public bool room5;

    //Seperate Objects
    public bool plant;
    public bool garbage;
    public bool fan;
    public bool phone;
    public bool cooler;
    public bool cup;

    //Is the phone ringing?
    public bool phoneRinging;

    // Start is called before the first frame update
    void Start()
    {
        PhoneAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Hand")
        {
            TriggerClue();
        }
    }

    private void TriggerClue()
    {
        if (PlayClipOnce == false)
        {
            PhoneAudio.Stop();
            if (room1 && phone)
            {
                PhoneAudio.PlayOneShot(PhoneRoom1Clue);
            }

            if (room1 && cup)
            {
                PhoneAudio.PlayOneShot(CupRoom1Clue);
            }

            if (room2 && plant)
            {
                PhoneAudio.PlayOneShot(PlantRoom2Clue);
            }

            if (room2 && fan)
            {
                PhoneAudio.PlayOneShot(FanRoom2Clue);
            }

            if (room2 && cooler)
            {
                PhoneAudio.PlayOneShot(CoolerRoom2Clue);
            }

            if (room2 && phone && phoneRinging)
            {
                PhoneAudio.PlayOneShot(PhoneRoom2Clue);
            }

            PlayClipOnce = true;
        }
    }

    public void PhoneRingDelay()
    {
        if (phone)
        {
            StartCoroutine(StartDelayedPhoneRing());
        }
    }

    IEnumerator StartDelayedPhoneRing()
    {
        yield return new WaitForSeconds(3);
        PhoneAudio.Play();
        phoneRinging = true;
    }




}
