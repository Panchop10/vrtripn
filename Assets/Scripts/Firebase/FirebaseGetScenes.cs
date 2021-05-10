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
                      Scene sceneAux = new Scene(
                        scene.Child("id").Value.ToString(),
                        scene.Child("title").Value.ToString(),
                        scene.Child("description").Value.ToString(),
                        scene.Child("link").Value.ToString(),
                        scene.Child("image_link").Value.ToString(),
                        scene.Child("tags").Value.ToString()
                        );

                      Debug.Log(sceneAux.toString());
                      LoadScenes.scenes.Add(sceneAux);

                  }

                  TourView.updated = false;
              }
          });
    }
}
