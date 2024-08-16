using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class MainMenuUIHandler : MonoBehaviour
{
    public TMP_InputField inputField;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {

    }

    // Function for startnew
    public void StartNew(){
        // Store name
        MenuDataManager.Instance.playerName = inputField.text;
        Debug.Log(MenuDataManager.Instance.playerName);
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        #if UNITY_EDITOR
                EditorApplication.ExitPlaymode();
        #else
                Application.Quit(); // original code to quit Unity player
        #endif
        MenuDataManager.Instance.saveGame();
    }
}
