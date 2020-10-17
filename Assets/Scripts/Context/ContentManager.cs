using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentManager: MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject ObjectColumnPrefab;
    public GameObject QuestionColumnPrefab;
    public GameObject AddColumnPrefab;

    [Header("Columns")]
    public RectTransform ObjectColumn;
    public RectTransform AddColumn;

    void Start()
    {
        
    }

    public void OnAddColumnButtonClick()
	{
		var column = Instantiate(QuestionColumnPrefab, transform);
        SwapChildObjects(AddColumn, column.transform);
	}

    private void SwapChildObjects(Transform left, Transform right)
	{
        var leftIndex = left.transform.GetSiblingIndex();
		right.transform.SetSiblingIndex(leftIndex);
	}

    public void OnAddRowButtonClick()
	{

	}

    public void OnRemoveColumnButtonClick(int index)
	{

	}

    public void OnRemoveRowButtonClick(int index)
	{

	}
}
