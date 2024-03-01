
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            collision.transform.position = GameObject.FindWithTag("PlayerSpawn").transform.position;
        }
    }
}
