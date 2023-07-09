using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicController : MonoBehaviour
{
    [SerializeField] private string createdTag;
    [SerializeField] private AudioSource source;

    [Header("Clips")]
    [SerializeField] private List<AudioClip> _clips;
    private void Awake()
    {
        GameObject obj=GameObject.FindWithTag(createdTag);
        if (obj != null)
            Destroy(gameObject);
        else
        {
            gameObject.tag = createdTag;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        if (!source.isPlaying)
        {
            Debug.Log("Next track");
            source.clip= _clips[Random.Range(0, _clips.Count)];
            source.Play();
        }
            
    }
}
