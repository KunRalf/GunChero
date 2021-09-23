using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    private PlayerCamera _camera;
    [SerializeField] private Slider _slider;
    private PlayerController _playerController;

    private void Start()
    {
        _camera = FindObjectOfType<PlayerCamera>();
        _playerController = FindObjectOfType<PlayerController>();
        _slider.minValue = 0;
        _slider.maxValue = _playerController.Health;
    }

    private void Update()
    {
        _slider.value = _playerController.Health;
        gameObject.transform.LookAt(_camera.transform);
    }

}
