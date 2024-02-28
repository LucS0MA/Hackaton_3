using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakSpot_Vlad : MonoBehaviour
{
    public GameObject objectToDestroy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(objectToDestroy);
        }
    }
}
