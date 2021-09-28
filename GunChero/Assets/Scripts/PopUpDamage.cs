using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUpDamage : MonoBehaviour
{
    [SerializeField] private GameObject _popUpDamage, _tager;
    

    public void CreatePopUpDamage(int damage)
    {
        GameObject popUpDamageInstance = Instantiate(_popUpDamage, _tager.transform) as GameObject;
        popUpDamageInstance.transform.GetChild(0).GetComponent<TextMeshPro>().SetText($"{damage}");
    }

}
