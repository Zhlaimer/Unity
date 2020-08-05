using Cinemachine.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManger : MonoBehaviour
{
    private Animator anim;
   // public CharacterMovement AC;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag=="Enemy"&&anim)
        {
            
            Debug.Log("打中了"+anim.GetCurrentAnimatorStateInfo(0));
        }
    }
}
