using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FDEventFactor.AddListener(FDEvent.Match_Succeed, MatchSucceed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MatchSucceed()
    {
        Debug.Log("匹配成功");
    }
}
