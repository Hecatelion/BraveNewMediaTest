using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExerciseSwitcher : MonoBehaviour
{
	// [SerializeField] Object sceneToLoad;
	[SerializeField] string sceneToLoadName;
	[SerializeField] Button button;
	[SerializeField] Text curExText;

	Text text;

    void Start()
    {
		/*
		button.GetComponentInChildren<Text>().text = "go to : " + sceneToLoad.name;
		curExText.text = SceneManager.GetActiveScene().name;
		*/

		StartCoroutine(SetUITexts());
    }

    void Update()
    { }

	public void UI_SwichExercise()
	{	
		SceneManager.LoadScene(sceneToLoadName);
	}

	private IEnumerator SetUITexts() 
	{
		yield return new WaitForSeconds(0.01f);
		curExText.text = SceneManager.GetActiveScene().name;
		button.GetComponentInChildren<Text>().text = "go to : " + sceneToLoadName;
	}
}
