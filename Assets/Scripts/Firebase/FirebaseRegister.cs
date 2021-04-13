using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class FirebaseRegister
{
    public static async Task Register(string firstName, string lastName, string email, string password) {
        Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;

        await auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                throw new System.Exception(task.Exception.Message);
            }
            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                throw new System.Exception(task.Exception.Message);
            }

            // Firebase user has been created.
            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);

            // Create the user in the database based on the User object.
            User user = new User(newUser.UserId, firstName, lastName, email);
            string json = JsonUtility.ToJson(user);

            DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
            reference.Child("users").Child(newUser.UserId).SetRawJsonValueAsync(json);

            // activate the button register and show a succesfull message
            RegisterUser.registered = true;

        });
    }
}
