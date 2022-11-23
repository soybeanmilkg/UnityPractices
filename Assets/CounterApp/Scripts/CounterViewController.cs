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
            CounterModel.count.mOnValueChanged += OnCountChanged;
            OnCountChanged(CounterModel.count.Value);
            transform.Find("ButtonAdd").GetComponent<Button>().onClick.AddListener(() => { CounterModel.count.Value++; });
            transform.Find("ButtonSub").GetComponent<Button>().onClick.AddListener((() => { CounterModel.count.Value--; }));
        }

        private void OnDestroy()
        {
            CounterModel.count.mOnValueChanged -= OnCountChanged;
        }

        private void OnCountChanged(int value)
        {
            transform.Find("Count").GetComponent<TMP_Text>().text = value.ToString();
        }
    }
}