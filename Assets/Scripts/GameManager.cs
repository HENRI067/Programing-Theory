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
    public List<RectTransform> Sliders;
    void Start()
    {
        Instance = this;
        mouseIsLocked = true;
        ResetBlockMeter();
    }

    void Update()
    {


        if (boxUnlucked >= 1) Sliders[0].gameObject.SetActive(true);
        else Sliders[0].gameObject.SetActive(false);
        if (boxUnlucked >= 2) Sliders[1].gameObject.SetActive(true);
        else Sliders[1].gameObject.SetActive(false);
        if (boxUnlucked >= 3) Sliders[2].gameObject.SetActive(true);
        else Sliders[2].gameObject.SetActive(false);

        if (GameObject.Find("Player").transform.position.y < -55) RestartScene();
        LockMouse();

    }
    public Slider GetSlider(int s)
    {
        return Sliders[s].GetComponent<Slider>();
    }
    public void ResetBlockMeter()
    {
        foreach(RectTransform rc in Sliders)
        {
            Slider S = rc.GetComponent<Slider>();
            S.value = S.maxValue;
        }
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
