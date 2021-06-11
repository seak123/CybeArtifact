using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuProcedure : IProcedure
{
    GameObject MainUI;
    private MLogger _logger = new MLogger("MenuProcedure");
    public void OnEnter()
    {
         _logger.Log("enter MenuProcedure");
        MainUI = ResourceManager.Instance.LoadUIPrefab(UIConst.UI_MAIN_MENU, UILayer.Normal_1);
    }

    public void OnUpdate()
    {

    }

    public void OnLeave()
    {
        GameObject.Destroy(MainUI);
    }
}
