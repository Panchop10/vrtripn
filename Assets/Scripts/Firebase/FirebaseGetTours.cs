using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class FirebaseGetTours
{
    public static void getTours(MenuGetData menuView) {
          FirebaseDatabase.DefaultInstance
          .GetReference("tours")
          .GetValueAsync().ContinueWith(task => {
              if (task.IsFaulted)
              {
                  Debug.LogError(task.Exception);
                  throw new System.Exception(task.Exception.Message);
              }
              else if (task.IsCompleted)
              {
                  DataSnapshot toursSnapshot = task.Result;
                  foreach (DataSnapshot tour in toursSnapshot.Children){
                      Tour tourAux = new Tour(
                          tour.Child("title").Value.ToString(),
                          tour.Child("description").Value.ToString(),
                          tour.Child("city").Value.ToString(),
                          tour.Child("country").Value.ToString(),
                          tour.Child("image_link").Value.ToString(),
                          tour.Child("is_daytime").Value.ToString(),
                          tour.Child("is_outdoor").Value.ToString(),
                          tour.Child("type").Value.ToString(),
                          tour.Child("duration").Value.ToString(),
                          tour.Child("slug_name").Value.ToString()
                          );

                      //Debug.Log(tour);
                      MenuGetData.tours.Add(tourAux);
                  }

                  menuView.updated = false;
              }
          });
    }
}
