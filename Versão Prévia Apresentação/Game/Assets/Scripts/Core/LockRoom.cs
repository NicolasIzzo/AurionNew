using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockRoom : MonoBehaviour
{
    public InputField passwd;
    public Button lockpick;
    public Sprite locker;
    public Sprite locker_open;
    int cont = 0;
    public void changeLock()
    {
        cont++;
        if (cont % 2 == 0)
        {
            lockpick.image.overrideSprite = locker;
            lockpick.transform.localScale = new Vector3(1.32F, 1.09F, 1);
            passwd.gameObject.SetActive(true);
        }
        else
        {
            lockpick.image.overrideSprite = locker_open;
            lockpick.transform.localScale = new Vector3(1F, 1F, 1);
            passwd.gameObject.SetActive(false);
        }
    }
}
