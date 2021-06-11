using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;


public class BattleProcedure : IProcedure
{
    private MLogger _logger = new MLogger("BattleProcedure");

    
    public void OnEnter()
    {
        _logger.Log("enter battle");

        ScenesManager
            .Instance
            .LoadScene("TestScene1",
            () =>
            {
                // Init Presentation layer first
                _logger.Log("init session");

            });

    }

    public void OnUpdate()
    {

    }

    public void OnLeave()
    {

    }
}
