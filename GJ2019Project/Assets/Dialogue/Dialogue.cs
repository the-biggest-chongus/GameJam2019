using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue {

	public string name;

	[TextArea(3, 10)]
	public string[] sentences;

    public bool hasChoice;
    public int questionSentence = 0;
    public string choice1;
    public string choice2;
    public int correctChoice;

    [TextArea(3, 10)]
    public string[] resolve;

    [TextArea(3, 10)]
    public string[] notresolve;

    public bool isresolved = false;

}
