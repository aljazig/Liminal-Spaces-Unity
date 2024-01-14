using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonActions : MonoBehaviour
{
    public Button tryAgain, mainMenu;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;

        if (tryAgain) { 
            tryAgain.onClick.AddListener(() => SceneManager.LoadScene(1));
        }
        if (mainMenu) {
            mainMenu.onClick.AddListener(() => SceneManager.LoadScene(0));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
