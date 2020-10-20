using System;
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
	
	[Header("Buttons")]
	public RectTransform addRowButton;

	public int Width { get; private set; }
	public int Height { get; private set; }

	private void Awake()
	{
		Width = 1;
		Height = 1;
	}

	public void AddColumn()
	{
		var column = InstantieteCell(questionColumnPrefab, transform, addColumn, RemoveColumn);

		Width++;
		for (int i = 1; i < Height; i++)
		{
			Instantiate(toggleContainerPrefab, column);
		}
	}
	public void AddRow()
	{
		InstantieteCell(objectContainerPrefab, objectColumn, addRowButton, RemoveRow);

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
	public void UpdateColumnsCount(int count)
	{
		if (count > 1 && Width != count)
		{
			while (Width != count)
			{
				if (count > Width)
				{
					AddColumn();
				}
				else
				{
					RemoveColumn(Width - 1);
				}
			}
		}
	}
	public void UpdateRowsCount(int count)
	{
		if (count > 1 && Height != count)
		{
			while (Height != count)
			{
				if (count > Height)
				{
					AddRow();
				}
				else
				{
					RemoveRow(Height - 1);
				}
			}
		}
	}
	public void UpdateSize(int width, int height)
	{
		UpdateColumnsCount(width);
		UpdateRowsCount(height);
	}
	private Transform InstantieteCell(Transform prefab, Transform parent, Transform swappedCell, Action<int> action)
	{
		var cell = Instantiate(prefab, parent);
		SwapChildObjects(swappedCell, cell);
		var button = cell.GetComponentInChildren<Button>();
		button.onClick.AddListener(() => { action(cell.GetSiblingIndex()); });

		return cell;
	}
	private void SwapChildObjects(Transform first, Transform second)
	{
		var leftIndex = first.transform.GetSiblingIndex();
		second.transform.SetSiblingIndex(leftIndex);
	}
}
