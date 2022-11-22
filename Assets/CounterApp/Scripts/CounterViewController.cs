// /**
//  * File Name: CounterViewController.cs
//  * Create By: soybeanmilk
//  * Create Time: 2022/11/23 1:02
//  * Descrption:
//  *
//  */

using System;
using CounterApp.Model;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CounterApp
{
    public class CounterViewController : MonoBehaviour
    {
        private void Start()
        {
            UpdateView();
            transform.Find("ButtonAdd").GetComponent<Button>().onClick.AddListener(() =>
            {
                CounterModel.Count++;
                UpdateView();
            });

            transform.Find("ButtonSub").GetComponent<Button>().onClick.AddListener((() =>
            {
                CounterModel.Count--;
                UpdateView();
            }));
        }

        private void UpdateView()
        {
            transform.Find("Count").GetComponent<TMP_Text>().text = CounterModel.Count.ToString();
        }
    }
}