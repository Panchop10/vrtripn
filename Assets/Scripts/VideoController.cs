using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Vimeo.Player;
using RenderHeads.Media.AVProVideo;

public class VideoController : MonoBehaviour
{
    //private VideoPlayer _videoPlayer;

    public VimeoPlayer vimeoPlayer;
    public MediaPlayer mediaPlayer;
    public VideoPlayer test;


    private IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        //_videoPlayer = GetComponent<VideoPlayer>();
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
        //_videoPlayer.Pause();
        /*vimeoPlayer.Pause();
        Debug.Log("Paused");*/
    }
    
    public void PlayVideo()
    {
        coroutine = PlayVimeoVideo();
        StartCoroutine(coroutine);
        //_videoPlayer.Play();
        /*vimeoPlayer.Play();
        Debug.Log("Played");*/
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
        //vimeoPlayer.Pause();
        Debug.Log("Paused");
    }
    
    IEnumerator PlayVimeoVideo()
    {
        yield return new WaitForSeconds(1.5f);

        mediaPlayer.Play();
        //vimeoPlayer.Play();
        Debug.Log("Played");
    }
}
