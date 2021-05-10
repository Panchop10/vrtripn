using RenderHeads.Media.AVProVideo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScenes : MonoBehaviour
{
    public MediaPlayer _mediaplayer;
    public MediaPlayer _mediaplayeraudio;

    public static ArrayList scenes = new ArrayList();
    public bool updated;
    private bool isVideoPlaying;
    private bool isAudioPlaying;
    private int counterScene = 0;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            FirebaseGetScenes.getScenes(this);
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }

        // add listeners
        _mediaplayer.Events.AddListener(OnMediaPlayerEvent);
        _mediaplayeraudio.Events.AddListener(OnAudioPlayerEvent);

        // mute video
        _mediaplayer.AudioMuted = true;
    }

    // Update is called once per frame
    void Update()
    {
        if ( updated ) {
            MediaPathType mpt = new MediaPathType();

            Scene newScene = scenes[counterScene] as Scene;
            counterScene++;

            _mediaplayer.OpenMedia(new MediaPath(newScene.link, mpt));
            //_mediaplayeraudio.OpenMedia(new MediaPath("https://cdn.civitatis.com/audioguias/roma/FontanadiTrevi.mp3", mpt));
        }
    }

    // Listener for the video player
    public void OnMediaPlayerEvent(MediaPlayer mp, MediaPlayerEvent.EventType et, ErrorCode errorCode)
    {
        switch (et)
        {
            case MediaPlayerEvent.EventType.FinishedPlaying:
                Debug.Log("VIDEO FINISHED");
                isVideoPlaying = false;
                //OnMediaPlayerFinished(mp);
                break;
        }
    }

    // Listener for the audio player
    public void OnAudioPlayerEvent(MediaPlayer mp, MediaPlayerEvent.EventType et, ErrorCode errorCode)
    {
        switch (et)
        {
            case MediaPlayerEvent.EventType.FinishedPlaying:
                Debug.Log("AUDIO FINISHED");
                isAudioPlaying = false;
                //OnMediaPlayerFinished(mp);
                break;
        }
    }
}
