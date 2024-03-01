using UnityEngine;

public class GetLadder : MonoBehaviour
{
    public float vitesseGrimpe = 5f;
    private bool estSurEchelle = false;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Vérifier si le personnage est sur une échelle et si la touche de déplacement vertical est enfoncée
        if (estSurEchelle)
        {
            float mouvementVertical = Input.GetAxis("Vertical");
            Vector2 mouvement = new Vector2(0, mouvementVertical) * vitesseGrimpe;

            // Appliquer le mouvement vertical
            rb.velocity = mouvement;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Vérifier si le personnage entre en contact avec une échelle
        if (other.CompareTag("Ladder"))
        {
            estSurEchelle = true;
            rb.gravityScale = 0; // Désactiver la gravité pour permettre la montée
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Vérifier si le personnage quitte l'échelle
        if (other.CompareTag("Ladder"))
        {
            estSurEchelle = false;
            rb.gravityScale = 1; // Réactiver la gravité lorsque le personnage quitte l'échelle
        }
    }
}
