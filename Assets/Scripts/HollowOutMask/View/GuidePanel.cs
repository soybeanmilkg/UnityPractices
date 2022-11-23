using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidePanel : MonoBehaviour
{

    GuideController guideController;

    Canvas canvas;

    private void Awake()
    {
        canvas = transform.GetComponentInParent<Canvas>();
    }

    // Start is called before the first frame update
    void Start()
    {
        guideController = transform.GetComponent<GuideController>();
        //guideController.Guide(canvas, GameObject.Find("Button").GetComponent<RectTransform>(), GuideType.Rect);

        //Invoke("Test",2);
    }

    void Test() {
        guideController.Guide(canvas, GameObject.Find("Button (1)").GetComponent<RectTransform>(), GuideType.Circle , TranslateType.Slow,0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        guideController.Guide(canvas, GameObject.Find("Button (1)").GetComponent<RectTransform>(), GuideType.Rect);
    }
}
