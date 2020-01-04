using System;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(DevManager))]
public class DevEditor : Editor
{

  public override void OnInspectorGUI()
  {
    base.OnInspectorGUI();
    DevManager devManager = (DevManager)target;
    if (GUILayout.Button("appendRow"))
    {
      appendRow(devManager);
    }
    if (GUILayout.Button("appendColumn"))
    {
      appendColumn(devManager);
    }
    if (GUILayout.Button("rename"))
    {
      rename(devManager);
    }


  }
  // public GameObject cube;
  // public GameObject column;

  private void appendRow(DevManager devManager)
  {
    GameObject row = devManager.row;
    // cube.GetComponent<TouchCube>().collisionEnabled = true;
    foreach (Transform cube in row.transform)
    {
      string name = cube.name;
      name = name.Split('(')[1];
      name = name.Split(')')[0];
      int no = Int32.Parse(name);
      cube.localPosition = new Vector3(no - 50, 0, 0);
    }
  }
  private void appendColumn(DevManager devManager)
  {
    GameObject column = devManager.column;
    foreach (Transform cube in column.transform)
    {
      string name = cube.name;
      name = name.Split('(')[1];
      name = name.Split(')')[0];
      int no = Int32.Parse(name);
      cube.localPosition = new Vector3(0, 0, 50 - no);
    }
  }

  private void rename(DevManager devManager)
  {
    GameObject column = devManager.column;
    foreach (Transform row in column.transform)
    {
      string rowName = row.name.Replace(" ", string.Empty);
      foreach (Transform cube in row)
      {
        string[] splitName = cube.name.Split(' ');
        cube.name = rowName + " " + splitName[1];
      }
    }

  }

}
