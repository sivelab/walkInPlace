using UnityEngine; using UnityEditor;

public static class DebugMenu 
{ 
	[MenuItem("Debug/Print Global Position")] public static void PrintGlobalPosition() 
	{ 
		if (Selection.activeGameObject != null) 
		{ 
			Debug.Log(Selection.activeGameObject.name + " is at (" + Selection.activeGameObject.transform.position.x + " " + Selection.activeGameObject.transform.position.y + " "  + Selection.activeGameObject.transform.position.z + ")"); 
		} 
	} 
}