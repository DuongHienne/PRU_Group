using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public TMP_InputField namePlayer;

    
    public void Playgame()
    {
        SceneManager.LoadSceneAsync(1);
        ManageInputName.instance.NamePlayer = namePlayer.text;
        Debug.Log("NAME:" + ManageInputName.instance.NamePlayer);
    }
    public void Quit() 
    {
        Application.Quit();
    }
    public void ExitLevel()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
