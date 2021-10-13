using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Slider _hpSlider;
    [SerializeField] private PlayerController _playerController;
    private PlayerCamera _camera;
    
    private void Start()
    {
        _camera = FindObjectOfType<PlayerCamera>();
        _hpSlider.minValue = 0;
        _hpSlider.maxValue = _playerController.Health;
    }

    private void Update()
    {
        _hpSlider.value = _playerController.Health;
        gameObject.transform.LookAt(_camera.transform);
    }

}
