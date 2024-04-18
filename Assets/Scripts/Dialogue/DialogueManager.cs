using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    public GameObject NPC;
    public GameObject dialogueBox; //�����Ի�����
    public Text dialogueText, nameText;
    public Image talkerImage;

    public Sprite playerSprite;
    public Sprite npc1Sprite;

    private bool isScrolling;
    public float textSpeed;

    [TextArea(1, 3)]
    public string[] dialogueLines;
    [SerializeField] private int currentLine; //ʵʱ׷�ٵ�ǰ�Ի��������ڽ����������һ����һ��Ԫ�������������

    //public bool isTalking;

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
                        StartCoroutine(ScrollingText()); //����ַ���ʾ
                    }
                    else
                    {
                        NPC.SetActive(false);
                        dialogueBox.SetActive(false);
                        currentLine = 0;
                        GameDriver.instance.StartGameInitialize();
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
        //isTalking = true;
    }
    private void CheckName()
    {
        if (dialogueLines[currentLine].StartsWith("-"))
        {
            nameText.text = dialogueLines[currentLine].Replace("-","");
            if (nameText.text == "��")
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
