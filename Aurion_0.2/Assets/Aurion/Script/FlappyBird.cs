using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FlappyBird : MonoBehaviour
{
    /*public Button MyButton;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = MyButton.GetComponent<Button>();
        MyButton.onClick.AddListener(TaskOnClick);
    }*/

    public void TaskOnClick()
    {
        SceneManager.LoadScene("FlappyBird");
    }
}
