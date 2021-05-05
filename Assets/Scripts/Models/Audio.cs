using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio
{
    public string id;
    public string audio_link;
    public string language;
    public string tags;

    public Audio(string id, string audio_link, string language, string tags) {
        this.id = id;
        this.audio_link = audio_link;
        this.language = language;
        this.tags = tags;
    }

}
