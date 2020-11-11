using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExerciseSwitcher : MonoBehaviour
{
	[SerializeField] string sceneToLoadName;
	[SerializeField] Button button;
	[SerializeField] Text curExText;

	Text text;

    void Start()
    {
		StartCoroutine(SetUITexts());
    }

    void Update()
    { }

	public void UI_SwichExercise()
	{	
		SceneManager.LoadScene(sceneToLoadName);
	}

	// work around of a unity known bug making UI not refresh when set on MonoBehaviour.Start()
	private IEnumerator SetUITexts() 
	{
		yield return new WaitForSeconds(0.01f);
		curExText.text = SceneManager.GetActiveScene().name;
		button.GetComponentInChildren<Text>().text = "go to : " + sceneToLoadName;
	}
}
