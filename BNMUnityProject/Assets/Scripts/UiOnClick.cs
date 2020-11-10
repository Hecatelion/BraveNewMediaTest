using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiOnClick : MonoBehaviour
{
	[SerializeField] Material selectedMat;
	[SerializeField] Material notSelectedMat;

	public GameObject ui;

	public bool isSelected = false;

    void Start()
    {
		ui = GetComponentInChildren<Canvas>().gameObject;
		UpdateSelection();
	}

    void Update()
    { }

	private void OnMouseDown()
	{
		isSelected = !isSelected;
		UpdateSelection();
	}

	private void UpdateSelection()
	{
		if (isSelected)
		{
			Select();
		}
		else
		{
			Unselect();
		}
	}

	private void Select()
	{
		gameObject.GetComponent<MeshRenderer>().material = selectedMat;
		ui.SetActive(true);
	}
	private void Unselect()
	{
		gameObject.GetComponent<MeshRenderer>().material = notSelectedMat;
		ui.SetActive(false);
	}
}
