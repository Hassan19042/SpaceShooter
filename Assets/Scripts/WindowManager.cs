using UnityEngine;
using System.Collections;

public class WindowManager : MonoBehaviour
{

    public GameObject scoreBoard;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
