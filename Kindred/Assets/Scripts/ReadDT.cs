using UnityEngine;
using UnityEngine.UI;
using System;

public class ReadDT : MonoBehaviour {
	[SerializeField] Text datetimeText;

	void Update ( ) {
		if (WorldTimeAPI.Instance.IsTimeLoaded ) {
			DateTime currentDateTime = WorldTimeAPI.Instance.GetCurrentDateTime ( );

			datetimeText.text = currentDateTime.ToString ( );
		}
	}
}
