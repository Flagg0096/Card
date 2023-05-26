using UnityEngine;
using TMPro;

public class ProjectProgressManager : MonoBehaviour 
{
    public UINumberBar numberBar;
    public ProjectProgress projectProgress;
    
    private void OnEnable()
    {
        numberBar.inputField.onValueChanged.AddListener(delegate { SetProgress(numberBar.value); });
    }

    private void OnDisable()
    {
        numberBar.inputField.onValueChanged.RemoveListener(delegate { SetProgress(numberBar.value); });
    }

    private void Start() 
    {
        projectProgress.ResetProgress();
    }

    private void Update()
    {
        numberBar.SetValue(projectProgress.Value);
    }

    void SetProgress(int value)
    {
        // projectProgress.Value = value;
    }
}

