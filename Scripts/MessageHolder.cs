using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="ReadyTexts/Messages",fileName="Message")]
public class MessageHolder : ScriptableObject
{
	public string[] messages;
	public Color messageColor;
}
