using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProjectProgress", menuName = "Game/ProjectProgress", order = 0)]
public class ProjectProgress : ScriptableObject 
{

    [field: SerializeField] public int Value { get; private set; }

    public ProjectProgressHandler handler;

    public void AddProgress(int value) 
    {
        if (handler != null)
        {
            handler.Handle(ref value);
        }

        Value += value;
    }

    public void ResetProgress() 
    {
        Value = 0;
    }
}

