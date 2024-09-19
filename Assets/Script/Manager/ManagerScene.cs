using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{
    public HealtController controller;
    public PlayerCollectablesCollision Collision;
    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void Salir()
    {
        Application.Quit();
    }
    private void OnEnable()
    {
        controller.DeathPlayer += death;
        Collision.CollisionWin += Win;
    }
    private void OnDisable()
    {
        controller.DeathPlayer -= death;
        Collision.CollisionWin -= Win;
    }
    public void death()
    {
        SceneManager.LoadScene("Defeat");
    }public void Win()
    {
        SceneManager.LoadScene("Win");
    }
}
