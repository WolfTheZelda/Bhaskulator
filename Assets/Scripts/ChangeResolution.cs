using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeResolution : MonoBehaviour {

	public int[] ResolutionWidth; //Coloque aqui as resoluções "Width" no "Element" equivalente a "Height" que você determinou abaixo.
	public int[] ResolutionHeight; //Coloque aqui as resoluções "Height" no "Element" equivalente a "Width" que você determinou acima.

	private int ResolutionNumber = 0; //Esse é o número que indica a sua resolução atual.

	public Text ResolutionInformationText; //Coloque, quaso queira, uma UI Text indicando a resolução atual.
	public Button NextResolutionButton, BackResolutionButton; //Coloque dois UI Buttons, um para avançar e outro para retornar a resolução. 

	void Start () {

		NextResolutionButton.onClick = new Button.ButtonClickedEvent();
		NextResolutionButton.onClick.AddListener(() => NextResolution());

		BackResolutionButton.onClick = new Button.ButtonClickedEvent();
		BackResolutionButton.onClick.AddListener(() => BackResolution());

		ResolutionInformationText.text = (Screen.width + "X" + Screen.height);

	}

	void NextResolution () {

		if (ResolutionNumber < ResolutionWidth.Length && ResolutionNumber < ResolutionWidth.Length) {
			ResolutionNumber = ResolutionNumber + 1; //Ou ResolutionNumber++ se preferir :)
			SetResolution ();
		}

	}
	
	void BackResolution () {

		if (ResolutionNumber > 0) {
			ResolutionNumber = ResolutionNumber - 1;
			SetResolution ();
		}

	}

	void SetResolution () {
		Screen.SetResolution (ResolutionWidth [ResolutionNumber], ResolutionHeight [ResolutionNumber], false);
		ResolutionInformationText.text = ((ResolutionWidth [ResolutionNumber].ToString()) + "X" + (ResolutionHeight [ResolutionNumber].ToString()));
	}
}
