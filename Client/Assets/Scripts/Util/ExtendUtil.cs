/*======================
作者:Phsycop
时间:Thursday, June 27, 2019
======================*/
using System;
using System.Collections;
using System.Collections.Generic;
using Const;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Util
{
    public static class ExtendUtil {

        /// <summary>
        /// 拓展方法工具类
        /// </summary>
        /// <param name="go"></param>
        /// <param name="active"></param>
        public static void SetActive(GameObject go, bool active)
        {
            go.SetActive(active);
        }
        public static void AddBtnListener(this RectTransform rect,Action action)
        {
            Button button = rect.GetComponent<Button>();
            if (button == null)
            {
                button = rect.gameObject.AddComponent<Button>();
            }
            button.onClick.AddListener(()=>action());
        }
        public static void AddBtnListener(this Transform rect, Action action)
        {
            Button button = rect.GetComponent<Button>();
            if (button == null)
            {
                button = rect.gameObject.AddComponent<Button>();
            }
            button.onClick.AddListener(() => action());
        }
        public static RectTransform RectTransform(this Transform transform)
        {
            RectTransform rect = transform.GetComponent<RectTransform>();
            if (rect != null)
            {
                return rect;
            }
            else
            {
                Debug.LogError("该物体没有RectTransform");
                return null;
            }
        }

        public static Image Image(this Transform transform)
        {
            var image = transform.GetComponent<Image>();
            if (image == null)
            {
                Debug.LogError("can not find Image");
                return null;
            }
            else
            {
                return image;
            }
        }

        public static Button Button(this Transform transform)
        {
            var t = transform.GetComponent<Button>();
            if (t == null)
            {
                Debug.LogError("can not find Button");
                return null;
            }
            else
            {
                return t;
            }
        }
    }
}

