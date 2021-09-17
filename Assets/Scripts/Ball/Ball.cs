using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidBody2D = null;

    //TODO: Add code to move ball along with code to delete pieces upon colliding with one
    //Ball should only move once its been launched
    [SerializeField] private float speed = 4.0f;
    [SerializeField] public bool hasFired;
    [SerializeField] public GameObject Player;

    private Vector3 currentDirection = Vector3.zero;

    private void Start()
    {
        Player = GameObject.Find("Paddle");
    }

    private void fire()
    {
        currentDirection = new Vector3(Random(), Random(), 0).normalized;
    }

    void FixedUpdate()
    {
        if (hasFired)
        {
            var newDelta = currentDirection * Time.deltaTime * speed;
            GetComponent<Rigidbody2D>().MovePosition(transform.position + newDelta);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        currentDirection = Vector2.Reflect(currentDirection, collision.contacts[0].normal);
        if (collision.gameObject.CompareTag("Piece"))
        {
            Debug.Log("brick hit!");
            Destroy(collision.gameObject);
        }
    }

    private int Random()
    {
        return UnityEngine.Random.Range(0, 2) == 0 ? -1 : 1;
    }

    private void Update()
    {
        if (hasFired == false)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                hasFired = true;
                fire();
            }
            transform.position = new Vector3(Player.transform.position.x, (Player.transform.position.y+.4f), Player.transform.position.z);
        }
    }


}
