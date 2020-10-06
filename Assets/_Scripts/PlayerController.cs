using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameController gameController;
    public float horizontalSpeed;
    public float horizontalBoundary;
    public float maximumVelocityX;
    public Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // touch support
        foreach (var touch in Input.touches)
        {
            if (Camera.main.ScreenToWorldPoint(touch.position).x > transform.position.x)
            {
                // move right
                rigidBody.velocity = _Move(1.0f) * 0.9f;
            }

            if (Camera.main.ScreenToWorldPoint(touch.position).x < transform.position.x)
            {
                // move left
                rigidBody.velocity = _Move(-1.0f) * 0.9f;
            }

            Debug.Log(Camera.main.ScreenToWorldPoint(touch.position));
        }


        // keyboard support
        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            // move right
            rigidBody.velocity = _Move(1.0f) * 0.9f;
        }

        if (Input.GetAxis("Horizontal") < -0.1f)
        {
            // move left
            rigidBody.velocity = _Move(-1.0f) * 0.9f;
        }

        _CheckBounds();

        if (Time.frameCount % 40 == 0)
        {
            gameController.GetBullet(transform.position);
        }
    }

    private void _CheckBounds()
    {
        // check left boundary
        if (transform.position.x <= -horizontalBoundary)
        {
            transform.position = new Vector3(-horizontalBoundary, transform.position.y, transform.position.z);
        }

        // check right boundary
        if (transform.position.x >= horizontalBoundary)
        {
            transform.position = new Vector3(horizontalBoundary, transform.position.y, transform.position.z);
        }
    }

    private Vector2 _Move(float direction)
    {
        var newVelocity = new Vector2(horizontalSpeed * direction, 0.0f);
        return Vector2.ClampMagnitude(rigidBody.velocity + newVelocity, maximumVelocityX);
    }
}
