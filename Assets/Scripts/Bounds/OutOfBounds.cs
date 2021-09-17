using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    [SerializeField] public GameObject Player;
    private void Start()
    {
        Player = GameObject.Find("Paddle");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.gameObject.CompareTag("Ball"))
            {
            Debug.Log("Resetting...");
            Destroy(collision.gameObject);
            //check for ball, destroy ball, then tell paddle to make a new one
            Player.GetComponent<Paddle>().ballSpawn = true;
        }
        //TODO: Implement functionality to reset the game somehow.
        // Resetting the game includes destroying the out of bounds ball and creating a new one ready to be launched from the paddle
    }   
}
