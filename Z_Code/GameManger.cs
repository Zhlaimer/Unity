using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    [Header("== Parameters Settings ==")]
    [Range(0, 10f)]
    public float i = 0.1f;
    [Space(10)]
    [Header("== String Settings ==")]
    public string name;

    [Space(10)]
    [Header("== ActorController Settings ==")]
    public CharacterController ac1;
    public CharacterController ac2;

    public enum STATE { 
    IDlE,
    Hit
    }
    [Header("== Game State ==")]
    public STATE state;


    void Update()
    {
        
    }
}
