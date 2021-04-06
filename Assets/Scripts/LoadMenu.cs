using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using UnityEngine.UI;

public class LoadMenu : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        // Get the root reference location of the database.
        //DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

        FirebaseDatabase.DefaultInstance
          .GetReference("tours")
          .GetValueAsync().ContinueWith(task => {
              if (task.IsFaulted)
              {
                      // Handle the error...
              }
              else if (task.IsCompleted)
              {
                  DataSnapshot toursSnapshot = task.Result;
                  foreach (DataSnapshot tour in toursSnapshot.Children)
                  {
                      Debug.Log(tour.Child("description").Value.ToString());
                      foreach (DataSnapshot scene in tour.Child("scenes").Children)
                      {
                          Debug.Log(scene.Child("link").Value.ToString());

                      }

                  }
                      // Do something with snapshot...
              }
          });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
