using Firebase.Auth;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class FirebaseLogin
{
    private static string userID = null;

    // Execute login process in firebase
    public static async Task Login(string email, string password) {
        FirebaseAuth auth = FirebaseAuth.DefaultInstance;

        await auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
            if (task.IsCanceled) {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                throw new System.Exception(task.Exception.Message);
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                throw new System.Exception(task.Exception.Message);
            }
            
            FirebaseUser User = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                User.DisplayName, User.UserId);

            userID = User.UserId;
            LoginProcess.executeLogin();
        });

    }

    // Get User ID from Firebase
    public static string getUserID() {
        return userID;
    }

}
