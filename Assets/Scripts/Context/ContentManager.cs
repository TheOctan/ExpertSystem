using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentManager: MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject ObjectColumnPrefab;
    public GameObject QuestionColumnPrefab;
    public GameObject AddColumnPrefab;
    public GameObject ObjectContainerPrefab;

    [Header("Columns")]
    public RectTransform ObjectColumn;
    public RectTransform AddColumn;
    public RectTransform addRowButton;

    public Vector2 size { get; private set; }

    void Start()
    {
        
    }

    public void OnAddColumnButtonClick()
	{
		var column = Instantiate(QuestionColumnPrefab, transform);
        SwapChildObjects(AddColumn, column.transform);
	}    

    public void OnAddRowButtonClick()
	{
        var objectContainer = Instantiate(ObjectContainerPrefab, ObjectColumn.transform);
        SwapChildObjects(addRowButton, objectContainer.transform);
	}

    public void OnRemoveColumnButtonClick(int index)
	{

	}

    public void OnRemoveRowButtonClick(int index)
	{

	}

    private void SwapChildObjects(Transform first, Transform second)
    {
        var leftIndex = first.transform.GetSiblingIndex();
        second.transform.SetSiblingIndex(leftIndex);
    }
}
