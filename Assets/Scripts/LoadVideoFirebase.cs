using RenderHeads.Media.AVProVideo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadVideoFirebase : MonoBehaviour
{

    public MediaPlayer _mediaplayer;
    public MediaPlayer _mediaplayeraudio;

    // Start is called before the first frame update
    void Start()
    {
        MediaPathType mpt = new MediaPathType();
        _mediaplayer.OpenMedia(new MediaPath("https://player.vimeo.com/external/548171631.hd.mp4?s=6372b5843dfb4dd17d093978ffca9c94b5ab13d4&profile_id=175", mpt));
        _mediaplayer.AudioMuted = true;
        _mediaplayeraudio.OpenMedia(new MediaPath("https://cdn.civitatis.com/audioguias/roma/FontanadiTrevi.mp3", mpt));
        //_mediaplayer.Loop = false;
        _mediaplayer.Events.AddListener(OnMediaPlayerEvent);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMediaPlayerEvent(MediaPlayer mp, MediaPlayerEvent.EventType et, ErrorCode errorCode)
    {
        switch (et)
        {
            //            case MediaPlayerEvent.EventType.Started:
            //              Print("startedEvent start event trigger");
            //            OnMediaPlayerStarted(mp);
            //          break;
            case MediaPlayerEvent.EventType.FinishedPlaying:
                Debug.Log("VIDEO FINISHED");
                _mediaplayeraudio.Stop();
                //OnMediaPlayerFinished(mp);
                break;
        }


    }

//    void OnMediaPlayerFinished(MediaPlayer mp)
//  {
//    Print("Follow-up of the end event trigger");
//   isPlaying = false;
// }

}

