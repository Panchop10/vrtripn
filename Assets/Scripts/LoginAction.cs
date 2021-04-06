using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginAction : MonoBehaviour
{
    // status of login for user
    private bool logged = false;

    // text fields user and password
    public TMP_InputField username_field;
    public TMP_InputField password_field;
    //public Text textObject;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(username_field.text);

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(username_field.text);
        //Debug.Log(password_field.text);
        if (logged) {
            LoginSucess();
        }
    }

    public void LoginProcess()
    {
        Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;

        auth.SignInWithEmailAndPasswordAsync("pancho1990@live.cl", "123456").ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
            Debug.Log("Entering menu");
            logged = true;


        });
        //Debug.Log(textObject.text);
        //SceneManager.LoadSceneAsync("Menu");


    }

    public void LoginSucess() {
        SceneManager.LoadSceneAsync("Menu");
    }
}
