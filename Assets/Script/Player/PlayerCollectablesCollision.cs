using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectablesCollision : MonoBehaviour
{
    public event Action CollisionPoints;
    public event Action CollisionHeart;
    public event Action CollisionWin;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Points"))
        {
            CollisionPoints?.Invoke();
            Destroy(collision.gameObject);
        }if (collision.gameObject.CompareTag("Heart"))
        {
            CollisionHeart?.Invoke();
            Destroy(collision.gameObject);
        }if (collision.gameObject.CompareTag("Final"))
        {
            CollisionWin?.Invoke();
            Destroy(collision.gameObject);
        }
        
    }
}
