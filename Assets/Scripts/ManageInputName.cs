using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageInputName : MonoBehaviour
{
    public static ManageInputName instance;

    public string NamePlayer { get;  set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
