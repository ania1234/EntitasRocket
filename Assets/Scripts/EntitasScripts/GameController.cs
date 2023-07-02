using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private RootSystem _rootSystem;

    private void Start()
    {
        var contexts = Contexts.sharedInstance;

        _rootSystem = new RootSystem(contexts);
        _rootSystem.Initialize();

    }

    private void Update()
    {
        _rootSystem.Execute();
        _rootSystem.Cleanup();
    }
}
