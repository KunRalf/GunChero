using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyUI : MonoBehaviour
{
    [SerializeField] private Slider _hpSlider;
    [SerializeField] private EnemyController _enemyController;
    private PlayerCamera _camera;
   
    private void Start()
    {
        _camera = FindObjectOfType<PlayerCamera>();
        _hpSlider.minValue = 0;
        _hpSlider.maxValue = _enemyController.Health;
    }

    private void Update()
    {
        _hpSlider.value = _enemyController.Health;
        gameObject.transform.LookAt(_camera.transform);
    }

}
