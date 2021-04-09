using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginProcess : MonoBehaviour
{
    // status of login for user
    private static bool logged = false;

    // text fields user and password
    public TMP_InputField emailField;
    public TMP_InputField passwordField;
    public TMP_Text errorText;
    public Button loginButton; 

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (logged){
            LoginSucess();
        }
    }

    public async void Login() {
        loginButton.interactable = false;
        try
        {
            await FirebaseLogin.Login(emailField.text, passwordField.text);
        }
        catch (System.Exception)
        {
            setErrorText("Error: The password is invalid or the user does not have a password.");
            loginButton.interactable = true;
        }
        
    }

    // Login Succesfull from Firebase
    public static void executeLogin() {
        logged = true;
    }

    // set error text
    public void setErrorText(string text) {
        errorText.text = text;
    }

    public void LoginSucess(){
        SceneManager.LoadSceneAsync("Menu");
    }
}
