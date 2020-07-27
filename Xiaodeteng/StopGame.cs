using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopGame : MonoBehaviour
{
    public GameObject stopMenu;
    bool isStop;
    void Update()
    {
        Stop();
    }
    void Stop()
    {
           isStop = stopMenu.activeSelf;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isStop = !isStop;
            stopMenu.SetActive(isStop);
        }
        Time.timeScale = isStop == true ? 0 : 1;
        //if (isStop)
        //    Time.timeScale = 0;
        //else
        //    Time.timeScale = 1;
    }
    

}
