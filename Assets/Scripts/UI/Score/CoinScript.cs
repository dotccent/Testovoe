using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public ScoreScript ScoreScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ScoreScript.instance.AddScore();
            Destroy(gameObject);
        }
    }
}
