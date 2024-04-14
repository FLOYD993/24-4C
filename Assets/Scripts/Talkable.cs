using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talkable : MonoBehaviour
{
    [TextArea(1, 3)]
    public string[] lines;

    private void Start()
    {
        DialogueManager.instance.ShowDialogue(lines);
    }
}
