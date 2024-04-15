using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    public GameObject dialogueBox; //整个对话窗口
    public Text dialogueText, nameText;
    public Image talkerImage;

    public Sprite playerSprite;
    public Sprite npc1Sprite;

    private bool isScrolling;
    public float textSpeed;

    [TextArea(1, 3)]
    public string[] dialogueLines;
    [SerializeField] private int currentLine; //实时追踪当前对话窗口正在进行数组的哪一行哪一个元素文字内容输出

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        dialogueText.text = dialogueLines[currentLine];
    }
    private void Update()
    {
        if (dialogueBox.activeInHierarchy)
        {
            if (Input.GetMouseButtonUp(0))
            {
                if(isScrolling ==  false)
                {
                    currentLine++;
                    if (currentLine < dialogueLines.Length)
                    {
                        CheckName();
                        //dialogueText.text = dialogueLines[currentLine];
                        StartCoroutine(ScrollingText()); //逐个字符显示
                    }
                    else
                    {
                        dialogueBox.SetActive(false);
                        currentLine = 0;
                    }
                }
            }
        }
    }
    public void ShowDialogue(string[] _newLines)
    {
        dialogueLines = _newLines;
        currentLine = 0;
        CheckName();
        dialogueText.text = dialogueLines[currentLine];
        //StartCoroutine(ScrollingText());
        dialogueBox.SetActive(true);
    }
    private void CheckName()
    {
        if (dialogueLines[currentLine].StartsWith("-"))
        {
            nameText.text = dialogueLines[currentLine].Replace("-","");
            if (nameText.text == "你")
            {
                talkerImage.sprite = playerSprite;
            }
            else talkerImage.sprite = npc1Sprite;
            currentLine++;
        }
    }

    private IEnumerator ScrollingText()
    {
        isScrolling = true;
        dialogueText.text = "";

        foreach(char letter in dialogueLines[currentLine].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }

        isScrolling = false;
    }
}
