using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlaceholderControl : MonoBehaviour
{
    // Start is called before the first frame update
    public TMPro.TMP_InputField txt;
    void Start()
    {
        TMPro.TMP_InputField input = txt.GetComponent<TMPro.TMP_InputField>();
        txt.onSelect.AddListener(TaskOnSelect);
    }

    public void TaskOnSelect(string ae)
    {
          txt.placeholder.GetComponent<TMPro.TMP_Text>().text = "";
    }
}
