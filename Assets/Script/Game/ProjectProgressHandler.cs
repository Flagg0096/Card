using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ProjectProgressHandler", menuName = "Game/ProjectProgressHandler", order = 0)]
public class ProjectProgressHandler : ScriptableObject, IProjectProgressHandler
{
    private bool _nextDouble;

    public void Handle(ref int value)
    {
        if (_nextDouble)
        {
            _nextDouble = false;
            value *= 2;
        }
    }

    internal void AddDoubleBuff()
    {
        _nextDouble = true;
    }
}
