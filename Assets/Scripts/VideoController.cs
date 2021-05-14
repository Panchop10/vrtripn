using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using RenderHeads.Media.AVProVideo;
using UnityEngine.SceneManagement;

public class VideoController : MonoBehaviour
{
    public MediaPlayer mediaPlayer;
    public MediaPlayer audioMediaPlayer;
    public VideoPlayer test;


    private IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InvokePauseVideo()
    {
        
    }

    public void PauseVideo()
    {
        coroutine = PauseVimeoVideo();
        StartCoroutine(coroutine);
    }
    
    public void PlayVideo()
    {
        coroutine = PlayVimeoVideo();
        StartCoroutine(coroutine);
    }

    public void DisableVideoPause()
    {
        StopCoroutine(coroutine);
    }
    
    public void DisableVideoPlay()
    {
        StopCoroutine(coroutine);
    }

    IEnumerator PauseVimeoVideo()
    {
        yield return new WaitForSeconds(1.5f);

        mediaPlayer.Pause();
        audioMediaPlayer.Pause();
        //vimeoPlayer.Pause();
        Debug.Log("Paused");
    }
    
    IEnumerator PlayVimeoVideo()
    {
        yield return new WaitForSeconds(1.5f);

        mediaPlayer.Play();
        audioMediaPlayer.Play();
        //vimeoPlayer.Play();
        Debug.Log("Played");
    }
}
