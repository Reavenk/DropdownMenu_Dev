using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public UnityEngine.UI.Button btn;
    public Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(this.OnButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnButtonClick()
    { 
        RectTransform rt = btn.GetComponent<RectTransform>();

        Debug.Log("Clicked");

        PxPre.DropMenu.StackUtil menuStack = new PxPre.DropMenu.StackUtil("Test");
        menuStack.AddAction("yo", ()=>{ });
        menuStack.AddAction("muaha", ()=>{ });
        menuStack.AddSeparator();
            menuStack.PushMenu("Testerosa");
            menuStack.AddAction("One thing", null);
            menuStack.AddAction("nother thing", null);
        menuStack.PopMenu();

        PxPre.DropMenu.Singleton.MenuInst.CreateDropdownMenu(
            this.canvas,
            menuStack.Root,
            rt);
    }
}
