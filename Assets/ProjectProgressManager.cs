using UnityEngine;
using TMPro;

public class ProjectProgressManager : MonoBehaviour 
{
    public ProjectProgress projectProgress;
    public TextMeshProUGUI text;


    private void Start() 
    {
        projectProgress.Value = 0;
    }

    private void Update()
    {
        text.text = $"进度： {projectProgress.Value}";
    }
}

