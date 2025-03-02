using Mono.Cecil;
using UnityEngine;

public class GoalItemScript : MonoBehaviour
{
    public ScoreScript ScoreScript;
    public WinScreenScript winScreenScript;
    public PlayerMovement playerMove;

    bool isCollected = false;
    public int goalItemScore = 1000;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isCollected)
        {
            isCollected = true;
            ScoreScript.instance.AddScore(goalItemScore);
            playerMove.enabled = false;
            winScreenScript.WinScreenSetup();
            Destroy(gameObject);

        }
    }
}
