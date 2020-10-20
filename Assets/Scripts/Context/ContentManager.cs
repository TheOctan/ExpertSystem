using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentManager : MonoBehaviour
{
	[Header("Prefabs")]
	public RectTransform objectColumnPrefab;
	public RectTransform questionColumnPrefab;
	public RectTransform addColumnPrefab;
	public RectTransform objectContainerPrefab;
	public RectTransform toggleContainerPrefab;

	[Header("Columns")]
	public RectTransform objectColumn;
	public RectTransform addColumn;
	public RectTransform addRowButton;

	public uint Width { get; private set; }
	public uint Height { get; private set; }

	private void Awake()
	{
		Width = 1;
		Height = 1;
	}

	public void AddColumn()
	{
		var column = Instantiate(questionColumnPrefab, transform);
		SwapChildObjects(addColumn, column);
		var minusButton = column.GetComponentInChildren<Button>();
		minusButton.onClick.AddListener(() => { RemoveColumn(column.GetSiblingIndex()); });

		Width++;
		for (int i = 1; i < Height; i++)
		{
			var toggleContainer = Instantiate(toggleContainerPrefab, column);
		}
	}

	public void AddRow()
	{
		var objectContainer = Instantiate(objectContainerPrefab, objectColumn);
		SwapChildObjects(addRowButton, objectContainer);
		var minusButton = objectContainer.GetComponentInChildren<Button>();
		minusButton.onClick.AddListener(() => { RemoveRow(objectContainer.GetSiblingIndex()); });

		Height++;
		for (int x = 2; x < transform.childCount - 1; x++)
		{
			var column = transform.GetChild(x);
			Instantiate(toggleContainerPrefab, column);
		}
	}

	public void RemoveColumn(int index)
	{
		if (Width > 1)
		{
			var destroyedColumn = transform.GetChild(index);
			var button = destroyedColumn.GetComponentInChildren<Button>();
			button.onClick.RemoveAllListeners();
			Destroy(destroyedColumn.gameObject);
			Width--;
		}
	}

	public void RemoveRow(int index)
	{
		if (Height > 1)
		{
			var destroyedRow = objectColumn.GetChild(index);
			var button = destroyedRow.GetComponentInChildren<Button>();
			button.onClick.RemoveAllListeners();

			for (int x = 1; x < transform.childCount - 1; x++)
			{
				var column = transform.GetChild(x);
				var destroyedRowElement = column.GetChild(index);
				Destroy(destroyedRowElement.gameObject);
			}
			Height--;
		}
	}

	private void SwapChildObjects(Transform first, Transform second)
	{
		var leftIndex = first.transform.GetSiblingIndex();
		second.transform.SetSiblingIndex(leftIndex);
	}
}
