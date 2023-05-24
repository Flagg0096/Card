using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPopUpMenu : MonoBehaviour
{
    public void ShowMenu()
    {
        transform.eulerAngles = new Vector3(0f, 0f, 0f);
    }

    public void HideMenu()
    {
        transform.eulerAngles = new Vector3(0f, 90f, 0f);
    }
}
