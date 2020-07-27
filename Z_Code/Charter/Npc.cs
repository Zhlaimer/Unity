using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Npc : MonoBehaviour
{
    public Image F;
    public DialogUI UI;
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Start");
        if (other.gameObject.tag == "Player")
        {
            F.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                UI.StartGame();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            F.gameObject.SetActive(false);
        }
    }
}
