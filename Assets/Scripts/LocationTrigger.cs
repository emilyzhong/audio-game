using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationTrigger : MonoBehaviour
{
    public AudioClip audio;

    private AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Active");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Entered!");
        source.PlayOneShot(audio, 1);
    }
}
