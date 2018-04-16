using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

	public GameObject shopPanal;
	public GameObject mainPanel;
	public Renderer player;
	public Material[] materials;
	public int[] priceList = {1, 2, 3, 4, 5};
	int materialsAmount = 0;
	public TapToPlay getCoin;
	public Text coinTest;
	public Text priceText;
	public Animator entryExit;
	public Animator mainPanelAnim;



	public void Start() {
		player.material = materials[PlayerPrefs.GetInt("Amount")];
	}

	private void LateUpdate() {
		Test();
	}

	void Test()
	{
		coinTest.text = getCoin.maxTime.ToString();
	}

	public void ComeShop()
	{
		shopPanal.SetActive(true);
		mainPanelAnim.SetBool("StartGame", true);
		entryExit.SetBool("OnOff", false);

		if(!PlayerPrefs.HasKey("Amount"))
		{
			materialsAmount = 0;
			priceText.text = priceList[0].ToString();
		}
		else
		{
			materialsAmount = PlayerPrefs.GetInt("Amount");
			priceText.text = priceList[PlayerPrefs.GetInt("Amount")].ToString();
		}
	}

	public void BackMenu()
	{
		mainPanelAnim.SetBool("StartGame", false);
		entryExit.SetBool("OnOff", true);
		PlayerPrefs.SetInt("Amount", materialsAmount);
	}

	public void RightBt()
	{
		if(materialsAmount > 4)
		{
			materialsAmount = 0;
			player.material = materials[materialsAmount];
		}
		else
		{
			materialsAmount++;
			player.material = materials[materialsAmount];
		}
	}

	public void LeftBt()
	{
		if(materialsAmount < 1)
		{
			materialsAmount = materials.Length-1;
			player.material = materials[materialsAmount];
		}
		else
		{
			materialsAmount--;
			player.material = materials[materialsAmount];
		}
	}
}
