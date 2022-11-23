// /**
//  * File Name: EditorCounterApp.cs
//  * Create By: soybeanmilk
//  * Create Time: 2022/11/23 22:59
//  * Descrption:
//  *
//  */

using System;
using CounterApp.Game.Command;
using CounterApp.Game.Model;
using UnityEditor;
using UnityEngine;

namespace CounterApp.Editor
{
    public class EditorCounterApp : EditorWindow
    {
        [MenuItem("EditorCounterApp/Open")]
        static void Open()
        {
            var window = GetWindow<EditorCounterApp>();
            window.position = new Rect(100, 100, 400, 600);
            window.titleContent = new GUIContent("EditorCounterApp");
            window.Show();
        }

        private void OnGUI()
        {
            if (GUILayout.Button("+"))
            {
                new AddCountCommand().Execute();
            }

            GUILayout.Label(CounterModel.count.Value.ToString());

            if (GUILayout.Button("+"))
            {
                new SubCountCommand().Execute();
            }
        }
    }
}