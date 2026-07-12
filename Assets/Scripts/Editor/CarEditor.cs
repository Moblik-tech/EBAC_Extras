using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Car))]
public class CarEditor : Editor
{
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        Car myTarget = (Car)target;

        myTarget.carPrefab = (GameObject)EditorGUILayout.ObjectField(myTarget.carPrefab, typeof(GameObject), true);
        myTarget.speed = EditorGUILayout.IntField("Velocity", myTarget.speed);
        myTarget.gearAmount = EditorGUILayout.IntField("Amount of gears", myTarget.gearAmount);

        EditorGUILayout.LabelField("Total velocity", myTarget.TotalSpeed.ToString());
        EditorGUILayout.HelpBox("Calculate the vehicle's maximum velocity.", MessageType.Info);

        if (myTarget.TotalSpeed > 200)
        {
            EditorGUILayout.HelpBox("This maximum velocity is too high! Please reduce it.", MessageType.Error);
        }

        GUI.color = Color.cyan;
        if (GUILayout.Button("Create Car"))
        {
            myTarget.CreateCar();
        }
    }
}