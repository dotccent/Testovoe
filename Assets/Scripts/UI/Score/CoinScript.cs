using Mono.Cecil;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public ScoreScript ScoreScript;

    bool isCollected = false;
    public int coinScore = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isCollected)
        {
            isCollected = true;
            ScoreScript.instance.AddScore(coinScore);
            Destroy(gameObject);
        }
    }
}
