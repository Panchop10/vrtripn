using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class FirebaseGetScenes
{
    public static void getScenes(LoadScenes TourView) {
          FirebaseDatabase.DefaultInstance
          .GetReference("tours/"+GotoTour.activeTour.slug_name+"/scenes")
          .GetValueAsync().ContinueWith(task => {
              if (task.IsFaulted)
              {
                  Debug.LogError(task.Exception);
                  throw new System.Exception(task.Exception.Message);
              }
              else if (task.IsCompleted)
              {
                  DataSnapshot scenesSnapshot = task.Result;
                  foreach (DataSnapshot scene in scenesSnapshot.Children){


                      Debug.Log(scene);
                      //MenuGetData.tours.Add(tourAux);
                  }

                  //menuView.updated = false;
              }
          });
    }
}
