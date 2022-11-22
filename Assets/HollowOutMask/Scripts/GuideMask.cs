// /**
//  * File Name: GuideMask.cs
//  * Create By: soybeanmilk
//  * Create Time: 2022/11/22
//  * Descrption:
//  *
//  */

using System;
using UnityEngine.UI;
using UnityEngine;

/// <summary>
/// 镂空遮罩
/// </summary>
public class GuideMask : MonoBehaviour, ICanvasRaycastFilter
{
    [SerializeField] private Material outMaskMat;
    [SerializeField] private RectTransform target;
    [SerializeField] private Transform target3d;
    [SerializeField] private RectTransform hollowTar;
    [SerializeField] private RectTransform canvas;
    [SerializeField] private float offsetX = 10;
    [SerializeField] private float offsetY = 10;
    [SerializeField, Range(0, 1)] private float radius = 0.5f;

    private Camera uiCamera;

    private Image outMask;

    private Vector3 center;
    private Vector3[] targetCorners = new Vector3[4];
    private float width;
    private float height;

    #region Scale变化相关

    private float scaleTimer;
    private float scaleTime;
    private bool isScaling;

    private float scaleWidth;
    private float scaleHeight;

    #endregion

    #region 属性

    public Vector3 Center
    {
        get
        {
            if (outMaskMat == null)
            {
                return Vector3.zero;
            }

            return outMaskMat.GetVector("_Center");
        }
    }

    public float OffsetX
    {
        get { return offsetX; }
        set { offsetX = value; }
    }

    public float OffsetY
    {
        get { return offsetY; }
        set { offsetY = value; }
    }

    public float Radius
    {
        get { return radius; }
        set { radius = value; }
    }

    #endregion

    private void Awake()
    {
        uiCamera = GameObject.FindWithTag("UICamera").GetComponent<Camera>();
        outMask = transform.GetComponent<Image>();

        if (outMask == null)
        {
            throw new System.Exception("mask 初始化失败!");
        }

        if (outMaskMat == null)
        {
            throw new System.Exception("材质未赋值!");
        }

        outMask.material = outMaskMat;
    }

    private void Update()
    {
        Guide3d(target3d);
        if (isScaling)
        {
            scaleTimer += Time.deltaTime * 1 / scaleTime;
            if (scaleTimer >= 1)
            {
                scaleTimer = 0;
                isScaling = false;
                return;
            }

            outMaskMat.SetFloat("_SliderX", Mathf.Lerp(scaleWidth, width, scaleTimer) / 2 + offsetX);
            outMaskMat.SetFloat("_SliderY", Mathf.Lerp(scaleHeight, height, scaleTimer) / 2 + OffsetY);
        }
    }

    #region UI锚定

    public void Guide(RectTransform target)
    {
        this.target = target;

        if (target != null)
        {
            // 获取中心点 
            target.GetWorldCorners(targetCorners);
            // 把世界坐标 转成屏幕坐标
            for (int i = 0; i < targetCorners.Length; i++)
            {
                //targetCorners[i] = WorldToScreenPoint(canvas, targetCorners[i]);
                targetCorners[i] = WorldToScreenPoint(Camera.main, targetCorners[i]);
            }

            // 计算中心点
            center.x = targetCorners[0].x + (targetCorners[3].x - targetCorners[0].x) / 2;
            center.y = targetCorners[0].y + (targetCorners[1].y - targetCorners[0].y) / 2;

            // 设置中心点
            outMaskMat.SetVector("_Center", center);

            // 设置镂空区域宽高以及圆角率
            var sizeDelta = target.sizeDelta;
            width = sizeDelta.x;
            height = sizeDelta.y;
            outMaskMat.SetFloat("_SliderX", width / 2 + offsetX);
            outMaskMat.SetFloat("_SliderY", height / 2 + offsetY);
            outMaskMat.SetFloat("Radius", radius);
        }
    }

    public void Guide(RectTransform target, float scale, float time = 0.5f)
    {
        if (target != null)
        {
            Guide(target, scale, scale, time);
        }
    }

    public void Guide(RectTransform target, float scaleX, float scaleY, float time = 0.5f)
    {
        if (time <= 0) throw new ArgumentOutOfRangeException(nameof(time));
        if (target == null) return;
        Guide(target);
        var sizeDelta = target.sizeDelta;
        scaleWidth = sizeDelta.x * scaleX;
        scaleHeight = sizeDelta.y * scaleY;
        scaleTime = time;
        scaleTimer = 0;
        isScaling = true;
    }

    #endregion

    #region 3D游戏对象锚定

    public void Guide3d(Transform target)
    {
        Vector2 screenPos = uiCamera.WorldToScreenPoint(target.transform.position);

        // Debug.Log($"screenPos:({screenPos.x}, {screenPos.y})");

        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, screenPos, uiCamera,
            out var localPos);

        // Debug.Log($"localPos:({localPos.x}, {localPos.y})");
        hollowTar.anchoredPosition = localPos;

        Guide(hollowTar);
    }

    #endregion


    private Vector2 WorldToScreenPoint(Camera camera, Vector3 world)
    {
        // 把世界坐标转成 屏幕坐标
        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(camera, world);
        Vector2 localPoint;
        // 把屏幕坐标 转成 局部坐标
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(),
            screenPoint, camera, out localPoint);
        return localPoint;
    }

    bool ICanvasRaycastFilter.IsRaycastLocationValid(Vector2 screenPos, Camera eventCamera)
    {
        if (null == target) return true;
        // 将目标对象范围内的事件镂空（使其穿过）
        return !RectTransformUtility.RectangleContainsScreenPoint(target, screenPos, eventCamera);
    }
}