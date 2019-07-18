using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Protocol;

public enum GameState
{
    wait,
    start,
    playing
}
public class GameManager :MonoBehaviour
{

    public static GameManager instance = null;
    public GameState gameState = GameState.wait;
   
    void Awake()
    {
        if(instance== null)
        {
            instance = this;
        }
        else
        {
            DestroyImmediate(this);
        }
        DontDestroyOnLoad(instance);
    }
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            gameState = GameState.start;
        }      
    }
}
