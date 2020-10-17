using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public RectTransform[] childs;

    void Start()
    {
		foreach (var item in childs)
		{
            Debug.Log(item.GetSiblingIndex());
		}
    }

}
