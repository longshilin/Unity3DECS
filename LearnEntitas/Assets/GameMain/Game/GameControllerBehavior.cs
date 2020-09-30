using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerBehavior : MonoBehaviour
{
    private GameController _gameController;


    private void Awake()
    {
        _gameController = new GameController(Contexts.sharedInstance);
    }

    private void Start()
    {
        _gameController.Initialize();
    }

    private void Update()
    {
        _gameController.Execute();
    }
}