using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ContentManager))]
public class ContextManager : MonoBehaviour
{
	private ContentManager contentManager;

	private List<string> objects;
	private List<string> questions;
	private List<List<bool>> matrix;

	private void Awake()
	{
		contentManager = GetComponent<ContentManager>();
	}

	private void Start()
	{

	}

	public void Updatecontext()
	{
		
	}

	public void ResdContext()
	{

	}
}
