using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorPlayer : MonoBehaviour
{
    public SpriteRenderer Targetobject;
    public ColorData ColorData;
    public bool isCollidingWithObstacle = false;
    public string currentColor;
    public event Action damagedPlayer;
    public event Action OnPlayerAvoid;
    public void ClickButton(string Color)
    {
        if (isCollidingWithObstacle) return;

        if (Color == "Red")
        {
            Targetobject.color = ColorData.colorRed;
            currentColor = "R";
        }
        else if (Color == "Blue")
        {
            Targetobject.color = ColorData.colorBlue;
            currentColor = "B";
        }else if (Color == "Green")
        {
            Targetobject.color = ColorData.colorGreen;
            currentColor = "G";
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyColor obstacle = collision.gameObject.GetComponent<EnemyColor>();
            if (obstacle != null && obstacle.obstacleColor == currentColor)
            {
                collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
                isCollidingWithObstacle = true;
                OnPlayerAvoid?.Invoke();
                Debug.Log("evitado.");
            }
            else
            {
                damagedPlayer?.Invoke();
                Debug.Log("El jugador ha recibido daño.");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            isCollidingWithObstacle = true;

            EnemyColor obstacle = collision.GetComponent<EnemyColor>();
            if (obstacle != null && obstacle.obstacleColor == currentColor)
            {
                collision.GetComponent<BoxCollider2D>().isTrigger = true; 

                Debug.Log("Evitado.");
            }
            else
            {
                Debug.Log("El jugador ha recibido daño.");
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            isCollidingWithObstacle = false;
            collision.GetComponent<BoxCollider2D>().isTrigger = false;
            Debug.Log("Trigger desactivado.");
        }
    }
}
