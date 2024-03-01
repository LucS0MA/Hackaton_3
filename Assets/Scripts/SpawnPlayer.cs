using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    private void Awake()
    {
        GameObject.FindWithTag("Player").transform.position = transform.position;
    }
}
