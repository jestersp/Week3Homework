using UnityEngine;

public class Paddle : MonoBehaviour
{
    //TODO
    // Move paddle left and right using keyboard keys, mapping is up to you
    // Paddle should be able to launch the ball upon space bar being pressed
    // A launched ball will then bounce around, changing its direction upon any collision
    [SerializeField] private float speed = 5f;
    [SerializeField] private Ball ballPrefab;
    [SerializeField] public bool ballSpawn;


    // Update is called once per frame
    private void Start()
    {
        ballSpawn = true;
    }

    void Update()
    {
            if (ballSpawn)
            {
                Instantiate(ballPrefab);
            ballSpawn = false;
            }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed, Space.World);
        }

        var xPosition = Mathf.Clamp(transform.position.x, -8f, 8f);
        transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);
    }
}
