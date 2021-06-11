using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginProcedure : IProcedure
{
    private MLogger _logger = new MLogger("LoginProcedure");
    
    public void OnEnter()
    {
        _logger.Log("enter LoginProcedure");

        // No login yet

        ProcedureManager.GameInst.InitInstanceData();

        ProcedureManager.Instance.SwitchProcedure(ProcedureType.Menu);
    }

    public void OnUpdate()
    {

    }

    public void OnLeave()
    {

    }
}
