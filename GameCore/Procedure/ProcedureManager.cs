using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ProcedureType
{
    Login,
    Menu,
    Battle,
}

public class ProcedureManager : MonoSingleton<ProcedureManager>, IManager
{
    private MLogger _logger = new MLogger("ProcedureManager");
    private IProcedure _curProcedure;
    private static GameInstance _gameInstance;
    private Dictionary<ProcedureType, IProcedure> _procedures;
    
    public static GameInstance GameInst{
        get{
            if(_gameInstance==null)
            {
                _gameInstance = new GameInstance();
            }
            return _gameInstance;
        }
    }

    public void Init()
    {
        _logger.Log("start init");
        _procedures = new Dictionary<ProcedureType, IProcedure>();

        RegisterProcedures();
        RegisterManagers();

        SwitchProcedure(ProcedureType.Prepare);
    }

    private void Update()
    {
        if (_curProcedure != null)
        {
            _curProcedure.OnUpdate();
        }
    }

    public void Release()
    {

    }


    public void SwitchProcedure(ProcedureType pType)
    {
        if (!_procedures.ContainsKey(pType)) return;
        if (_curProcedure != null)
        {
            _curProcedure.OnLeave();
        }

        _curProcedure = _procedures[pType];

        _logger.Log("enter procedure ", pType);
        _curProcedure.OnEnter();
    }

    private void RegisterProcedures()
    {
        _procedures.Add(ProcedureType.Login, new LoginProcedure());
        _procedures.Add(ProcedureType.Menu, new MenuProcedure());
        _procedures.Add(ProcedureType.Battle, new BattleProcedure());
    }

    private void RegisterManagers()
    {
        EventManager.Instance.Init();
        ResourceManager.Instance.Init();
        LuaManager.Instance.Init();
        LuaBehaviourManager.Instance.Init();
        GestureManager.Instance.Init();
        CameraManager.Instance.Init();
        ScenesManager.Instance.Init();
    }

    private void UnRegisterManagers()
    {
        EventManager.Instance.Release();
        ResourceManager.Instance.Release();
        LuaManager.Instance.Release();
        LuaBehaviourManager.Instance.Release();
        GestureManager.Instance.Release();
        CameraManager.Instance.Release();
        ScenesManager.Instance.Release();
    }
}
