using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputName : MonoBehaviour
{
   public TMP_InputField inputFields;

   public void UpdateName(string name)
    {
        inputFields.text = name;
    }
}
