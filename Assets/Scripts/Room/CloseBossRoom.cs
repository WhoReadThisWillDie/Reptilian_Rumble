using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CloseBossRoom : MonoBehaviour
{
    [SerializeField] private List<GameObject> doors;
    public BossBody bossBody;
    private bool doorsClosed = false;
    private AudioSource audioSource;
    public AudioSource lvlMusic;
    public VideoPlayer videoPlayer;
    public GameObject miniMap;
    public GameObject skipText;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            if (!doorsClosed)
            {
                ActivateDoors();
            }
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            bossBody.isFreezed = false;
            Destroy(videoPlayer);
            skipText.SetActive(false);
        }
    }

    private void ActivateDoors()
    {
        skipText.SetActive(true);
        PlayAudio();
        foreach (GameObject door in doors)
        {
            door.SetActive(true);
        }
        miniMap.SetActive(false);
        PlayVideo();
        StartCoroutine(DelayVideo());
    }

    void PlayAudio()
    {
        lvlMusic.Stop();
        audioSource.Play();
    }
    void PlayVideo()
    {
        videoPlayer.Play();
    }
    private IEnumerator DelayVideo()
    {
        yield return new WaitForSeconds(10.0f);
        bossBody.isFreezed = false;
        Destroy(videoPlayer);
    }
}
