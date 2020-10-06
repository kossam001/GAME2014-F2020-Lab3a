using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float verticalSpeed;
    public GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0.0f, verticalSpeed, 0.0f);
        _CheckBounds();
    }

    private void _CheckBounds()
    {
        if (transform.position.y > 10.0f)
        {
            gameController.ReturnBullet(gameObject);
        }
    }
}
