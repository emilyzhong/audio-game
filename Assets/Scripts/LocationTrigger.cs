using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationTrigger : MonoBehaviour
{
    public AudioClip audioFile;

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
        Debug.Log("Updated");
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Entered!");
        source.PlayOneShot(audioFile, 1);
    }
}
