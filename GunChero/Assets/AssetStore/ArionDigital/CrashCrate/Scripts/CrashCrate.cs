using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashCrate : MonoBehaviour
{

    public MeshRenderer wholeCrate;
    public BoxCollider boxCollider;
    public GameObject fracturedCrate;

    private void OnCollisionEnter(Collision other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            DestroyBox();
            StartCoroutine(DestroyObjects());
        }
    }

    private void DestroyBox()
    {
        wholeCrate.enabled = false;
        boxCollider.enabled = false;
        fracturedCrate.SetActive(true);
    }

    private IEnumerator DestroyObjects()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}






