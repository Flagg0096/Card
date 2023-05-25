using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UINumberBar : MonoBehaviour
{
    public TMP_InputField inputField;
    public int value;
    // Start is called before the first frame update
    void OnEnable()
    {
        inputField.onValueChanged.AddListener(delegate { ChangeValue(); });
    }
    void OnDisable()
    {
        inputField.onValueChanged.AddListener(delegate { ChangeValue(); });
    }

    private void ChangeValue()
    {
        int result;
        if (int.TryParse(inputField.text, out result))
        {
            value = result;
        }
    }

    public void SetValue(int value)
    {
        this.value = value;
        UpdateValue();
    }

    public void Plus()
    {
        value++;
        UpdateValue();
    }

    private void UpdateValue()
    {
        inputField.text = value.ToString();
    }

    public void Minus()
    {
        value--;
        UpdateValue();
    }
}
