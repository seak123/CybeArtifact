using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct GameInstanceData
{

}

public class GameInstance
{
    private BattleSession _session;
    public void InitInstanceData()
    {
        // Temp
    }

    public void StartBattle()
    {
        ProcedureManager.Instance.SwitchProcedure(ProcedureType.Battle);
        _session = new BattleSession();
    }
}