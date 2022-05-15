// MIT License
// 
// Copyright (c) 2021 Pixel Precision, LLC
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The demonstration script for the SampleScene example.
/// </summary>
public class AppTest : MonoBehaviour
{
    /// <summary>
    /// The canvas to create the DropMenus in. Note that this
    /// is also implied to be the Canvas that the RectTransforms
    /// that we build the DropMenus around belong to.
    /// </summary>
    public Canvas canvas;

    /// <summary>
    /// Button for the "Simple Sample" example.
    /// </summary>
    public UnityEngine.UI.Button btn_Sample1;

    /// <summary>
    /// Button for the "Separated Sample" example.
    /// </summary>
    public UnityEngine.UI.Button btn_Sample2;

    /// <summary>
    /// Button for the "SubMenu Sample" example.
    /// </summary>
    public UnityEngine.UI.Button btn_Sample3;

    /// <summary>
    /// Button for the "Deeper SubMenu example.
    /// </summary>
    public UnityEngine.UI.Button btn_Sample4;

    /// <summary>
    /// Button for the "Tall Scrollable" example.
    /// </summary>
    public UnityEngine.UI.Button btn_Sample5;

    /// <summary>
    /// Button for the "README Sample" example.
    /// </summary>
    public UnityEngine.UI.Button btn_Sample6;

    /// <summary>
    /// A green dot used as an example for the style pulldown, to show
    /// decorating a (selected) menu item with a sprite.
    /// </summary>
    public Sprite greenDot;

    /// <summary>
    /// The "Simple" example that can be selected from the style pulldown.
    /// </summary>
    public PxPre.DropMenu.Props prop_Simple;

    /// <summary>
    /// The "Skeuo" example that can be selected from the style pulldown.
    /// </summary>
    public PxPre.DropMenu.Props prop_Skeuo;

    /// <summary>
    /// The button for the style pulldown example. This is a button that 
    /// emulates a pulldown, and allows changing the property style that
    /// the DropMenus will use when invoked.
    /// </summary>
    public UnityEngine.UI.Button btn_StylePulldown;

    /// <summary>
    /// The text field for the style pulldown button.
    /// </summary>
    public UnityEngine.UI.Text txt_StyleName;

    /// <summary>
    /// A sample parameter-less function.
    /// </summary>
    public void FunctionAction()
    {
        Debug.Log("Ran FunctionAction()");
    }

    /// <summary>
    /// Button callback for the "Simple Sample" button.
    /// 
    /// An example of creating a simple dropdown.
    /// </summary>
    public void OnButton_SimpleSample()
    {
        Debug.Log("Called OnButton_SimpleSample()");

        // The button to create a menu dropdown onto
        RectTransform rt = this.btn_Sample1.GetComponent<RectTransform>();

        // This creates a PxPre.DropMenu.Node object, wrapped in a
        // PxPre.DropMenu.StackUtil object that provides API members to
        // easily populate the menu.
        PxPre.DropMenu.StackUtil menuStack = new PxPre.DropMenu.StackUtil("");

        // Add a menu option to the menu.
        menuStack.AddAction("Function Action", this.FunctionAction);

        // Create the popup around the RectTransform of btn_Sample1. 
        PxPre.DropMenu.DropMenuSingleton.MenuInst.CreateDropdownMenu(this.canvas, menuStack.Root, rt);
    }

    /// <summary>
    /// Button callback for the "Separated Sample" button.
    /// 
    /// An example of using the AddSeparator() function to add a 
    /// horizontal rule between menu items.
    /// </summary>
    public void OnButton_SeparatedSample()
    {
        Debug.Log("Called OnButton_SeparatedSample()");

        RectTransform rt = this.btn_Sample2.GetComponent<RectTransform>();
        PxPre.DropMenu.StackUtil menuStack = new PxPre.DropMenu.StackUtil("");

        // Similar to OnButton_SimpleSample() except multiple items are added
        // to menuStack, including a separator in between.
        menuStack.AddAction("Option 1", ()=>{ Debug.Log("Lambda for Option 1"); });
        menuStack.AddSeparator();
        menuStack.AddAction("Below Separator", () => { Debug.Log("Lambda for Below Separator"); });

        PxPre.DropMenu.DropMenuSingleton.MenuInst.CreateDropdownMenu(this.canvas, menuStack.Root, rt);
    }

    /// <summary>
    /// Button callback for the "SubMenu Sample" button.
    /// 
    /// An example of creating cascading submenus.
    /// </summary>
    public void OnButton_SubMenu()
    {
        Debug.Log("Called OnButton_SubMenu()");

        // The button to create a menu dropdown onto
        RectTransform rt = this.btn_Sample3.GetComponent<RectTransform>();
        PxPre.DropMenu.StackUtil menuStack = new PxPre.DropMenu.StackUtil("");

        // Setting the action to lambda buttons
        menuStack.AddAction("Option 1", () => { Debug.Log("Lambda for Option 1"); });
        menuStack.AddAction("Option 2", () => { Debug.Log("Lambda for Option 2"); });

        // Setting the action to parameterless (member) functions
        menuStack.PushMenu("Pushed Sub Menu");
            menuStack.AddAction("Option 3", this.FunctionAction);
            menuStack.AddAction("Option 4", this.FunctionAction);
            menuStack.AddAction("Option 5", this.FunctionAction);
        menuStack.PopMenu();

        menuStack.AddAction("Option 6", () => { });

        PxPre.DropMenu.DropMenuSingleton.MenuInst.CreateDropdownMenu(this.canvas, menuStack.Root, rt);
    }

    /// <summary>
    /// Button callback for the "Deeper SubMenu" button.
    /// 
    /// An extended example of cascading submenus, with multiple 
    /// depths of submenus.
    /// </summary>
    public void OnButton_DeeperSubMenu()
    {
        Debug.Log("Called OnButton_DeeperSubMenu()");

        // The button to create a menu dropdown onto
        RectTransform rt = this.btn_Sample4.GetComponent<RectTransform>();
        PxPre.DropMenu.StackUtil menuStack = new PxPre.DropMenu.StackUtil("");

        menuStack.PushMenu("Pushed Sub Menu (1)");
            menuStack.AddAction("Option 1", () => { });
            menuStack.PushMenu("Pushed Sub Menu (2)");
                menuStack.AddAction("Option 2", () => { });
                menuStack.AddAction("Option 3", () => { });
            menuStack.PopMenu();
            menuStack.AddAction("Option 4", () => { });
        menuStack.PopMenu();

        PxPre.DropMenu.DropMenuSingleton.MenuInst.CreateDropdownMenu(this.canvas, menuStack.Root, rt);
    }

    /// <summary>
    /// Button callback for the "Tall Scrollable" button.
    /// </summary>
    public void OnButton_TallScrollable()
    {
        Debug.Log("Called OnButton_TallScrollable()");

        // The button to create a menu dropdown onto
        RectTransform rt = this.btn_Sample5.GetComponent<RectTransform>();
        PxPre.DropMenu.StackUtil menuStack = new PxPre.DropMenu.StackUtil("");

        // Create a lot of (do nothing) menu items so a vertical scrollbar will be needed.
        for(int i = 0; i < 100; ++i)
            menuStack.AddAction($"Option {i}", () => { }); 

        PxPre.DropMenu.DropMenuSingleton.MenuInst.CreateDropdownMenu(this.canvas, menuStack.Root, rt);
    }

    void OnMenu_Option2()
    { 
        Debug.Log("Called OnMenu_Option2");
    }

    /// <summary>
    /// Button callback for the "README Sample" button.
    /// </summary>
    public void OnButton_READMESample()
    {
        Debug.Log("Called OnButton_READMESample()");

        RectTransform rt = this.btn_Sample6.GetComponent<RectTransform>();

        PxPre.DropMenu.StackUtil menuStack = new PxPre.DropMenu.StackUtil("");

        menuStack.AddAction("Option 1", () => { Debug.Log("Called Option 1"); });
        menuStack.AddAction("Option 2", this.OnMenu_Option2);

        menuStack.AddSeparator();

        menuStack.PushMenu("Submenu");
        for (int i = 0; i < 10; ++i)
        {
            int iCpy = i; // The for loop iterator value cannot be used directly.
            menuStack.AddAction($"SubSubOpt {iCpy}", () => { Debug.Log(iCpy.ToString()); });
        }
        menuStack.PopMenu();

        PxPre.DropMenu.DropMenuSingleton.MenuInst.CreateDropdownMenu(
            this.canvas,
            menuStack.Root,
            rt);
    }

    /// <summary>
    /// Button callback for the style change pulldown button.
    /// </summary>
    public void OnButton_StylePulldown()
    {
        Debug.Log("Called OnButton_StylePulldown()");

        PxPre.DropMenu.Props curProp = PxPre.DropMenu.DropMenuSingleton.MenuInst.props;

        RectTransform rt = this.btn_StylePulldown.GetComponent<RectTransform>();
        PxPre.DropMenu.StackUtil menuStack = new PxPre.DropMenu.StackUtil("");

        menuStack.AddAction(
            curProp == this.prop_Simple,                            // Is menu item selected?
            curProp == this.prop_Simple ? this.greenDot : null,     // If selected, decorate with lead green dot sprite
            "Simple",
            () => { this.SetStyle(this.prop_Simple); });

        menuStack.AddAction(
            curProp == this.prop_Skeuo,                             // Is menu item selected?
            curProp == this.prop_Skeuo ? this.greenDot : null,      // If selected, decorate with lead green dot sprite
            "Skeuo", 
            () => { this.SetStyle(this.prop_Skeuo); });

        PxPre.DropMenu.DropMenuSingleton.MenuInst.CreateDropdownMenu(this.canvas, menuStack.Root, rt);
    }

    /// <summary>
    /// DropMenu callback for the menu items in OnButton_StylePulldown().
    /// 
    /// This will set the stylesheet Prop that all future invoked
    /// DropMenus will use.
    /// </summary>
    /// <param name="p">The property to set.</param>
    public void SetStyle(PxPre.DropMenu.Props p)
    {
        PxPre.DropMenu.DropMenuSingleton.MenuInst.props = p;

        if (p == this.prop_Simple)
            this.txt_StyleName.text = "Style: Simple";
        else
            this.txt_StyleName.text = "Style: Skeuo";
    }
}
