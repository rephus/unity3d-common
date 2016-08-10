using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Terminal : MonoBehaviour {

	private const float TextSpeed = 0.05f;
	public int maxLines = 5;

	private string text;
	private Text uiText;
	private string newText = "";
	
	private const float StandBySpeed = 0.5f;
	private bool standBy = false;
	
	void Start () {
		uiText = this.GetComponent<Text>();
		InvokeRepeating("Write", 0, TextSpeed);
		InvokeRepeating("StandBy", 0, StandBySpeed);
		
	}
	
	public void Add(string t) {
		newText = newText + t +"\n";
	}
	// Update is called once per frame
	void Update () {
		
	}
	private void StandBy(){
		if (newText == "") {
			if (standBy) {
				uiText.text = text;
			} else {
				uiText.text = text+"_";
			}
			standBy = !standBy;
		}
	}
	private void Write(){
		if (newText != "") {
			char c = newText[0]; 
			text = text + c;
			RemoveOldLine();
			
			uiText.text = text;
			newText = newText.Substring(1);
		}
	}
	private void RemoveOldLine(){
		int lines = text.Split('\n').Length;
		if (lines > maxLines) {
			int indexN = text.Substring(1).IndexOf('\n');
			text = text.Substring(indexN+2);
		}
	}
}
