﻿using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor (typeof (DynamicLight))] 
[CanEditMultipleObjects]

public class DynamicLightEditor : Editor {


	[MenuItem ("GameObject/2D Object/2D Dynamic Light/Add Light Point")]
	static void Create(){
		GameObject gameObject = new GameObject("2DLight");
		DynamicLight s = gameObject.AddComponent<DynamicLight>();
		s.Rebuild();
	}

	[MenuItem ("GameObject/2D Object/2D Dynamic Light/Add Gradient Light Point")]
	static void addGradient(){
		
		Material m = AssetDatabase.LoadAssetAtPath("Assets/2DLightAssets/Materials/StandardLightMaterialGradient.mat", typeof(Material)) as Material;
		GameObject gameObject = new GameObject("2DLight");
		DynamicLight s = gameObject.AddComponent<DynamicLight>();
		s.setMainMaterial(m);
		s.Rebuild();
		
	}


	[MenuItem ("GameObject/2D Object/2D Dynamic Light/Casters/Empty", false, 3)]
	static void addEmpty(){
		
		GameObject empty = new GameObject("empty");
		empty.layer = 8;
		empty.AddComponent<SpriteRenderer>();
		GameObject emptyChild = new GameObject("collider");
		emptyChild.AddComponent<PolygonCollider2D>();
		emptyChild.transform.parent = empty.transform;
		emptyChild.layer = 8;
		empty.transform.position = new Vector3(5,0,0);
		DynamicLight.reloadMeshes = true;
	}

	[MenuItem ("GameObject/2D Object/2D Dynamic Light/Casters/Square")]
	static void addSquare(){
		
		Object prefab = AssetDatabase.LoadAssetAtPath("Assets/2DLightAssets/Prefabs/square.prefab", typeof(GameObject));
		GameObject hex = Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;
		hex.transform.position = new Vector3(5,0,0);
		hex.name = "square";
		DynamicLight.reloadMeshes = true;


		
	}

	[MenuItem ("GameObject/2D Object/2D Dynamic Light/Casters/Circle")]
	static void addCircle(){
		
		Object prefab = AssetDatabase.LoadAssetAtPath("Assets/2DLightAssets/Prefabs/circle.prefab", typeof(GameObject));
		GameObject hex = Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;
		hex.transform.position = new Vector3(5,0,0);
		hex.name = "circle";
		DynamicLight.reloadMeshes = true;
		
	}

	[MenuItem ("GameObject/2D Object/2D Dynamic Light/Casters/Circle (with Intellider)")]
	static void addIntelliderCircle(){
		
		Object prefab = AssetDatabase.LoadAssetAtPath("Assets/2DLightAssets/Prefabs/circleWithintellider.prefab", typeof(GameObject));
		GameObject hex = Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;
		hex.transform.position = new Vector3(5,0,0);
		hex.name = "circle(optimized)";
		DynamicLight.reloadMeshes = true;
		
	}

	[MenuItem ("GameObject/2D Object/2D Dynamic Light/Casters/Hexagon")]
	static void addHexagon(){

		Object prefab = AssetDatabase.LoadAssetAtPath("Assets/2DLightAssets/Prefabs/hexagon.prefab", typeof(GameObject));
		GameObject hex = Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;
		hex.transform.position = new Vector3(5,0,0);
		hex.name = "hexagon";
		DynamicLight.reloadMeshes = true;

	}
	[MenuItem ("GameObject/2D Object/2D Dynamic Light/Casters/Pacman")]
	static void addPacman(){
		
		Object prefab = AssetDatabase.LoadAssetAtPath("Assets/2DLightAssets/Prefabs/pacman.prefab", typeof(GameObject));
		GameObject hex = Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;
		hex.transform.position = new Vector3(5,0,0);
		hex.name = "pacman";
		DynamicLight.reloadMeshes = true;
		
	}
	[MenuItem ("GameObject/2D Object/2D Dynamic Light/Casters/Star")]
	static void addStar(){
		
		Object prefab = AssetDatabase.LoadAssetAtPath("Assets/2DLightAssets/Prefabs/star.prefab", typeof(GameObject));
		GameObject hex = Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;
		hex.transform.position = new Vector3(5,0,0);
		hex.name = "star";
		DynamicLight.reloadMeshes = true;
	}



	public override void OnInspectorGUI () {
		DynamicLight obj;
		obj = target as DynamicLight;
		if (obj == null)
		{
			return;
		}
		
		//serializedObject.Update();
		
		SerializedProperty
			version = serializedObject.FindProperty("version"),
			lmaterial = serializedObject.FindProperty ("lightMaterial"),
			radius = serializedObject.FindProperty ("lightRadius"),
			segments = serializedObject.FindProperty ("lightSegments"),
			range = serializedObject.FindProperty ("RangeAngle"),
			layerm = serializedObject.FindProperty ("Layer"),
			enableNotifyGameObjectsReached = serializedObject.FindProperty("notifyGameObjectsReached"),
			intelliderConvex = serializedObject.FindProperty("intelliderConvex"),
			staticScene = serializedObject.FindProperty("staticScene"),
			recalcNorms = serializedObject.FindProperty("recalculateNormals"),
			debugLines = serializedObject.FindProperty("debugLines");


		EditorGUILayout.IntSlider(segments, 3, 20);
		int nSeg = segments.intValue;
		if (nSeg <= 3) {
			EditorGUILayout.HelpBox("Segments must be 3 o Higher", MessageType.Warning);
		}
		EditorGUILayout.PropertyField(radius);
		EditorGUILayout.PropertyField(range);
		//EditorGUILayout.IntSlider(range, 1, 360);
		EditorGUILayout.PropertyField(lmaterial);
		EditorGUILayout.PropertyField(layerm);

		float fRange = range.floatValue;
		if(fRange > 360.001f)
			fRange = 360f;
		if(fRange < .999f)
			fRange = 1f;

		if(range.floatValue != fRange){
			range.floatValue = fRange;
		}

		string v = version.stringValue;

		EditorGUILayout.HelpBox("Optimizations:", MessageType.None);
		EditorGUILayout.PropertyField(enableNotifyGameObjectsReached);
		EditorGUILayout.PropertyField(intelliderConvex);
		EditorGUILayout.PropertyField(staticScene);

		EditorGUILayout.HelpBox("Rendering Options", MessageType.None);
		EditorGUILayout.PropertyField(recalcNorms);
		EditorGUILayout.PropertyField(debugLines);

		EditorGUILayout.HelpBox("2D Light Package PRO version: " + v, MessageType.None);



		if (GUILayout.Button("Refresh")){
			obj.Rebuild();
		}

		if (serializedObject.ApplyModifiedProperties()||
		    (Event.current.type == EventType.ValidateCommand &&
		 Event.current.commandName == "UndoRedoPerformed")) {
			foreach (DynamicLight s in targets) {
				s.Rebuild();
			}
		}

	}



	private static Vector3 pointSnap =  Vector3.one * 0.1f;
	
	void OnSceneGUI () {
		DynamicLight light = target as DynamicLight;
		if(light){
			Transform lTransform = light.transform;
			Vector3 oldPoint = lTransform.TransformPoint(new Vector3(light.lightRadius,0,0));
			float size = HandleUtility.GetHandleSize(oldPoint);
			Vector3 newPoint = Handles.FreeMoveHandle(
				oldPoint, Quaternion.identity,size * 0.05f, pointSnap, Handles.DotHandleCap);
				if (oldPoint != newPoint) {
					Undo.RecordObject(light, "resize radiusLight");
					light.lightRadius = (lTransform.InverseTransformPoint(newPoint).magnitude);
				}
				
			Handles.color = Color.yellow;
			Handles.DrawWireDisc(lTransform.position,new Vector3(0,0,-1), light.lightRadius);

		}
		
	}


	void OnDrawGizmos() {
		DynamicLight obj;
		obj = target as DynamicLight;
		if (obj == null)
		{
			return;
		}
		Gizmos.DrawIcon(obj.gameObject.transform.position, "Light Gizmo.tiff", true);
	}


}
