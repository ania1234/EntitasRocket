using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private RootSystem _rootSystem;
    [SerializeField]
    private List<UIListener> _uiListeners;

    private void Start()
    {
        LevelsContainer.LoadLevel(PersistentScript.instance!=null? PersistentScript.instance.currentLevelNumber : 1);
        var contexts = Contexts.sharedInstance;

        _rootSystem = new RootSystem(contexts);
        _rootSystem.Initialize();
        SubscribeUIListeners();
    }

    private void SubscribeUIListeners()
    {
        foreach (var listener in _uiListeners)
        {
            listener.Subscribe();
        }
    }

    private void Update()
    {
        _rootSystem.Execute();
        _rootSystem.Cleanup();
    }
}
