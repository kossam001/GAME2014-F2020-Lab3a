using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameController : MonoBehaviour
{
    public GameObject bullet;
    public Queue<GameObject> bullets;
    public int MaxBullets;

    // Start is called before the first frame update
    void Start()
    {
        _BuildBulletPool();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void _BuildBulletPool()
    {
        bullets = new Queue<GameObject>();
        for (int count = 0; count < MaxBullets; count++)
        {
            var tempBullet = Instantiate(bullet);
            tempBullet.SetActive(false);
            bullets.Enqueue(tempBullet);
        }
    }

    public GameObject GetBullet(Vector3 position)
    {
        var newBullet = bullets.Dequeue();
        newBullet.SetActive(true);
        newBullet.transform.position = position;
        return newBullet;
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        bullets.Enqueue(bullet);
    }
}
