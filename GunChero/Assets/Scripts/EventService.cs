﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventService : MonoBehaviour
{
    public static EventService Instance { get; private set; }

    private EventService()
    {
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public event Action<EnemyController> OnEnemyCreate;
    public void CallOnEnemyCreate(EnemyController enemy)
    {
        OnEnemyCreate?.Invoke(enemy);
    }
}
