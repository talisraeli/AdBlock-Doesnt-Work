using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class CreditsScore : MonoBehaviour
{

	private void Start()
	{
        GetComponent<TextMeshProUGUI>().SetText(GameManager.Score.ToString("000000"));
	}
}
