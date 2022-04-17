using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;
using Firebase;
using Firebase.Auth;
using Firebase.Extensions;
using UnityEngine.SceneManagement;


public class StartController : MonoBehaviour
{
    public GameObject startPage, loginPage, signupPage, profilePage, forgetPasswordPage;
    public GameObject errorWindow;
    
    public TMP_InputField loginEmail, loginPassword; // Login page input
    public TMP_InputField signupUsername, signupEmail, signupPassword, signupCPassword; // Sign up page input
    public TMP_InputField forgetPasswordEmail; //Forget password page input
    public TMP_Text errorTitle, errorMessage; // Error window text

    Firebase.Auth.FirebaseAuth auth;
    Firebase.Auth.FirebaseUser user;

    bool isSignIn = false;
    bool isSigned = false;

    private void Start()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                //app = Firebase.FirebaseApp.DefaultInstance;
                InitializeFirebase();

                // Set a flag here to indicate whether Firebase is ready to use by your app.
            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });
    }

    public void OpenLoginPage()
    {
        loginPage.SetActive(true);
        startPage.SetActive(false);
        signupPage.SetActive(false);
        profilePage.SetActive(false);
        forgetPasswordPage.SetActive(false);
    }

    public void OpenStartPage()
    {
        loginPage.SetActive(false);
        startPage.SetActive(true);
        signupPage.SetActive(false);
        profilePage.SetActive(false);
        forgetPasswordPage.SetActive(false);
    }

    public void OpenSignupPage()
    {
        loginPage.SetActive(false);
        startPage.SetActive(false);
        signupPage.SetActive(true);
        profilePage.SetActive(false);
        forgetPasswordPage.SetActive(false);
    }

    public void OpenProfilePage()
    {
        loginPage.SetActive(false);
        startPage.SetActive(false);
        signupPage.SetActive(false);
        profilePage.SetActive(true);
        forgetPasswordPage.SetActive(false);
    }

    public void OpenForgetPasswordPage()
    {
        loginPage.SetActive(false);
        startPage.SetActive(false);
        signupPage.SetActive(false);
        profilePage.SetActive(false);
        forgetPasswordPage.SetActive(true);
    }

    public void LoginUser()
    {
        if (string.IsNullOrEmpty(loginEmail.text) || string.IsNullOrEmpty(loginPassword.text))
        {
            showErrorWindow("Error", "Field(s) empty! Please input details in all fields. ");
            return;
        }

        // Do login
        SignInUser(loginEmail.text, loginPassword.text);
    }

    public void SignupUser()
    {
        if (string.IsNullOrEmpty(signupUsername.text) || string.IsNullOrEmpty(signupEmail.text) || string.IsNullOrEmpty(signupPassword.text) || string.IsNullOrEmpty(signupCPassword.text))
        {
            showErrorWindow("Error", "Field(s) empty! Please input details in all fields. ");
            return;
        }

        // Do signup
        CreateUser(signupEmail.text, signupPassword.text, signupUsername.text);
    }

    public void forgetPassword()
    {
        if (string.IsNullOrEmpty(forgetPasswordEmail.text))
        {
            showErrorWindow("Error", "Field(s) empty! Please input details in all fields. ");
            return;
        }
        // Do reset password
        ResetPassword(forgetPasswordEmail.text);
        OpenStartPage();
    }

    public void showErrorWindow(string title, string message)
    {
        errorTitle.text = "" + title;
        errorMessage.text = "" + message;

        errorWindow.SetActive(true);
    }

    public void closeErrorWindow()
    {
        errorMessage.text = "";
        errorTitle.text = "";

        errorWindow.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    void CreateUser(string email, string password, string username)
    {
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                //Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);

                foreach (Exception exception in task.Exception.Flatten().InnerExceptions)
                {
                    Firebase.FirebaseException firebaseEx = exception as Firebase.FirebaseException;
                    if (firebaseEx != null)
                    {
                        var errorCode = (AuthError)firebaseEx.ErrorCode;
                        showErrorWindow("Error", GetErrorMessage(errorCode));
                    }
                }

                return;
            }

            // Firebase user has been created.
            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                username, newUser.UserId);
            OpenLoginPage();
            //UpdateUserProfile(username);
        });
    }

    public void SignInUser(string email, string password)
    {
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                //Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);

                foreach (Exception exception in task.Exception.Flatten().InnerExceptions)
                {
                    Firebase.FirebaseException firebaseEx = exception as Firebase.FirebaseException;
                    if (firebaseEx != null)
                    {
                        var errorCode = (AuthError)firebaseEx.ErrorCode;
                        showErrorWindow("Error", GetErrorMessage(errorCode));
                    }
                }

                return;
            }

            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
            //profileUserName_Text.text = "" + newUser.DisplayName;
            //profileUserEmail_Text.text = "" + newUser.Email;
            //OpenProfilePage();
            SceneManager.LoadScene("Gameplay");
        });
    }

    public void ResetPassword(string emailAddress)
    {
        if (user != null)
        {
            auth.SendPasswordResetEmailAsync(emailAddress).ContinueWith(task => {
                if (task.IsCanceled)
                {
                    Debug.LogError("SendPasswordResetEmailAsync was canceled.");
                    return;
                }
                if (task.IsFaulted)
                {
                    Debug.LogError("SendPasswordResetEmailAsync encountered an error: " + task.Exception);
                    return;
                }

                Debug.Log("Password reset email sent successfully.");
            });
        }
    }
    

void InitializeFirebase()
    {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        auth.StateChanged += AuthStateChanged;
        AuthStateChanged(this, null);
    }

    void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        if (auth.CurrentUser != user)
        {
            bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;
            if (!signedIn && user != null)
            {
                Debug.Log("Signed out " + user.UserId);
            }
            user = auth.CurrentUser;
            if (signedIn)
            {
                Debug.Log("Signed in " + user.UserId);
                isSignIn = true;
            }
        }
    }

    //void OnDestroy()
    //{
    //    auth.StateChanged -= authStateChanged;
    //    auth = null;
    //}

    void UpdateUserProfile(string Username)
    {
        Firebase.Auth.FirebaseUser user = auth.CurrentUser;
        if (user != null)
        {
            Firebase.Auth.UserProfile profile = new Firebase.Auth.UserProfile
            {
                DisplayName = Username
                //PhotoUrl = new System.Uri("https://example.com/jane-q-user/profile.jpg"),
            };
            user.UpdateUserProfileAsync(profile).ContinueWith(task => {
                if (task.IsCanceled)
                {
                    Debug.LogError("UpdateUserProfileAsync was canceled.");
                    return;
                }
                if (task.IsFaulted)
                {
                    Debug.LogError("UpdateUserProfileAsync encountered an error: " + task.Exception);
                    return;
                }

                Debug.Log("User profile updated successfully.");

                showErrorWindow("Alert", "Account Successfully Created");
            });
        }
    }

    private void Update()
    {
        if (isSignIn)
        {
            if (!isSigned)
            {
                isSigned = true;
                //profileUserName_Text.text = "" + user.DisplayName;
                //profileUserEmail_Text.text = "" + user.Email;
                //OpenProfilePage();
            }
        }
    }

    private static string GetErrorMessage(AuthError errorCode)
    {
        var message = "";
        switch (errorCode)
        {
            case AuthError.AccountExistsWithDifferentCredentials:
                message = "Account Exists With Different Credentials";
                break;
            case AuthError.MissingPassword:
                message = "Missing Password";
                break;
            case AuthError.WeakPassword:
                message = "Weak Password";
                break;
            case AuthError.WrongPassword:
                message = "Wrong Password";
                break;
            case AuthError.EmailAlreadyInUse:
                message = "Email Already In Use";
                break;
            case AuthError.InvalidEmail:
                message = "Invalid Email";
                break;
            case AuthError.MissingEmail:
                message = "Missing Email";
                break;
            default:
                message = "An Error Occured";
                break;
        }
        return message;
    }

}
