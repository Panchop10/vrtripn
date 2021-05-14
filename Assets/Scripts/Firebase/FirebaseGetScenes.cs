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

                      foreach (DataSnapshot audio in scene.Child("audios").Children){
                          Debug.Log(audio);
                          Audio audioAux = new Audio(
                              audio.Child("id").Value.ToString(),
                              audio.Child("audio_link").Value.ToString(),
                              audio.Child("language").Value.ToString(),
                              audio.Child("tags").Value.ToString()
                              );
                          sceneAux.addAudio(audioAux);
                      }


                      Debug.Log(sceneAux.toString());
                      LoadScenes.scenes.Add(sceneAux);

                  }

                  TourView.updated = false;
              }
          });
    }
}
