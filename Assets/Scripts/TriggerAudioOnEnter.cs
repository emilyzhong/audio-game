using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAudioOnEnter : MonoBehaviour
{
    public GameObject nextActiveObject;
    private GameObject child;
    private AudioSource source;
    private AudioSource nextSource;
    private AudioClip clip;
    private double timeOffset = 0;
    private double startTime;

    void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator OnTriggerEnter(Collider collision)
    {
        Debug.Log("Entered " + gameObject.name);
        startTime = AudioSettings.dspTime;
        
        for (int i = 0; i < transform.childCount; i++)
        {
            child = transform.GetChild(i).gameObject;
            source = child.GetComponent<AudioSource>();
            clip = child.GetComponent<AudioSource>().clip;

            source.PlayScheduled(startTime + timeOffset);
            timeOffset += clip.length;

            if (i == transform.childCount - 1) 
            {
                while (source.isPlaying) 
                {
                    yield return null;
                }
                if (nextActiveObject != null)
                {
                    nextActiveObject.SetActive(true);
                }
                gameObject.SetActive(false);
                Debug.Log("Deactivate");
            } 
            else 
            {
                yield return new WaitForSeconds(clip.length);
            }
        }
    }
}
