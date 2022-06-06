using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int boxUnlucked = 0;
    private bool mouseIsLocked;
    [SerializeField] private Transform slider1;
    [SerializeField] private Transform slider2;
    [SerializeField] private Transform slider3;
    public List<Transform> Sliders { get; private set; }
    void Start()
    {
        Sliders.Add(slider1); Sliders.Add(slider2); Sliders.Add(slider3);


        Instance = this;
        mouseIsLocked = true;
    }

    void Update()
    {
        if (boxUnlucked >= 1) slider1.gameObject.SetActive(true);
        else slider1.gameObject.SetActive(false);
        if (boxUnlucked >= 2) slider2.gameObject.SetActive(true);
        else slider2.gameObject.SetActive(false);
        if (boxUnlucked >= 3) slider3.gameObject.SetActive(true);
        else slider3.gameObject.SetActive(false);

        if (GameObject.Find("Player").transform.position.y < -55) RestartScene();
        LockMouse();

    }







    public void ResetSliders()
    {

    }
    public void RemoveBlock(int slider)
    {
        Slider S = Sliders[slider].GetComponent<Slider>();
        S.value--;
    }

    public void UnlockBlock(int i)
    {
        boxUnlucked = (boxUnlucked < i) ? i : boxUnlucked;
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
