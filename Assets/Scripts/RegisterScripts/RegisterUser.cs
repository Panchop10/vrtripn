using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RegisterUser : MonoBehaviour
{
    // status of login for user
    public static bool registered = false;

    // text fields user and password
    public TMP_InputField firstNameField;
    public TMP_InputField lastNameField;
    public TMP_InputField emailField;
    public TMP_InputField pwdField;
    public TMP_InputField pwdConfirmationField;
    public TMP_Text successText;
    public TMP_Text errorText;
    public Button registerButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Clear input values and show a successfull message when register succesfully
        if ( registered ) {
            // show successfull message
            errorText.text = "";
            successText.text = "User created successfully";
            registerButton.interactable = true;

            // clean inputs
            firstNameField.text = "";
            lastNameField.text = "";
            emailField.text = "";
            pwdField.text = "";
            pwdConfirmationField.text = "";

            // clean registered variable
            registered = false;
        }
        
    }

    // Validation of input fields and Registration in Firebase
    public async void Register() {
        registerButton.interactable = false;

        if (firstNameField.text == "" || lastNameField.text == "" || emailField.text == "" || pwdField.text == "") {
            successText.text = "";
            errorText.text = "Please fill all the fields.";
            registerButton.interactable = true;
        }
        else if (pwdField.text != pwdConfirmationField.text)
        {
            successText.text = "";
            errorText.text = "Passwords do no match.";
            registerButton.interactable = true;
        }
        else if (pwdField.text.Length < 6)
        {
            successText.text = "";
            errorText.text = "Passwords must have at least 6 characters";
            registerButton.interactable = true;
        }
        else {
            try
            {
                await FirebaseRegister.Register(firstNameField.text, lastNameField.text, emailField.text, pwdField.text);
            }
            catch (System.Exception)
            {
                errorText.text = "Email already registered.";
                registerButton.interactable = true;
            }
        }
    }
}
