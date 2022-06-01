using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private bool mouseIsLocked;

    void Start()
    {
        mouseIsLocked = true;
    }

    void Update()
    {
        if (GameObject.Find("Player").transform.position.y < -55) RestartScene();
        LockMouse();

    }


    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
    void LockMouse()
    {
        Cursor.lockState = mouseIsLocked ? CursorLockMode.Locked : CursorLockMode.None;
    }

}
