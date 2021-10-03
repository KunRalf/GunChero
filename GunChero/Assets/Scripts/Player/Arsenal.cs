using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Arsenal : MonoBehaviour
{
    [SerializeField] private int _weaponIndex;
    [SerializeField] private TextMeshPro _textMesh;
    [SerializeField] private int _cost;
    [SerializeField] private PlayerCamera _camera;
    [SerializeField] Transform _ui;
    private WeaponConroller _weaponConroller;
    
    public int WeaponIndex => _weaponIndex;

    private void Start()
    {
        if (_cost <= 0)
        {
            _textMesh.text += $"\n COST: FREE";
        }
        else
        {
            _textMesh.text += $"\n COST: {_cost}";
        }
        _weaponConroller = FindObjectOfType<WeaponConroller>();
        _camera = FindObjectOfType<PlayerCamera>();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if(player != null)
        { 
            _ui.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            _ui.gameObject.SetActive(false);
        }
    }

    private void Update()
    { 
        _ui.LookAt(_camera.transform);
    }

    public void BuyWeapon()
    {
        _weaponConroller.ChangeWeapon(_weaponIndex);
    }
    
}
