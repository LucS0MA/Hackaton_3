
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    private Text interactUI;
    private bool isInRange;

    public Animator animator;

    void Awake()
    {
        interactUI = GameObject.FindWithTag("InteractUI").GetComponent<Text>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && isInRange) 
        {
            OpenChest();
        }
        
    }

    void OpenChest()
    {
        animator.SetTrigger("OpenChest");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = true;
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = false;
            isInRange = false;
        }
    }

}
