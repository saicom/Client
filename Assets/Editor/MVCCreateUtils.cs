using UnityEngine;
using System.Collections;
using UnityEditor;

public static class LuaCreateUtils
{

    [MenuItem("Assets/Create/Template/View.cs")]
    static void CreateView()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Templates\view.cs.txt", "View.cs");
    }
	
	[MenuItem("Assets/Create/Template/Control.cs")]
    static void CreateControl()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Templates\controller.cs.txt", "Control.cs");
    }
	
	[MenuItem("Assets/Create/Template/Model.cs")]
    static void CreateModel()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Templates\model.cs.txt", "Model.cs");
    }
}
