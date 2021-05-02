using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Tour
{
    public string title;
    public string description;
    public string city;
    public string country;
    public string image_link;
    public string is_daytime;
    public string is_outdoor;
    public string type;
    public string duration;
    public string slug_name;

    public Tour(string title,
            string description,
            string city,
            string country,
            string image_link,
            string is_daytime,
            string is_outdoor,
            string type,
            string duration,
            string slug_name
        )
    {
        this.title = title;
        this.description = description;
        this.city = city;
        this.country = country;
        this.image_link = image_link;
        this.is_daytime = is_daytime;
        this.is_outdoor = is_outdoor;
        this.type = type;
        this.duration = duration;
        this.slug_name = slug_name;
    }

    public string toString() {
        return "" + this.title + " " + this.description;
    }

}
