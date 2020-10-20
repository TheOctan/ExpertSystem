using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ContentManager))]
public class ContextManager: MonoBehaviour
{
    private ContentManager contentManager;

	private void Awake()
	{
        contentManager = GetComponent<ContentManager>();
	}


}
