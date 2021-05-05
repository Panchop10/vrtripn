using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Scene
{
    public string id;
    public string title;
    public string description;
    public string link;
    public string image_link;
    public string tags;
    public ArrayList audios;

    public Scene(string id, string title, string description, string link, string image_link, string tags) {
        this.id = id;
        this.title = title;
        this.description = description;
        this.link = link;
        this.image_link = image_link;
        this.tags = tags;
    }

    public ArrayList getAudios() {
        return this.audios;
    }

    public void addAudio(Audio audio) {
        this.audios.Add(audio);
    }

    public string toString() {
        return "" + this.id + " " + this.title;
    }
}
