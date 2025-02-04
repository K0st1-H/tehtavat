using System.Collections.Generic;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    public static DialogueSystem Instance { get; private set; }

    private Queue<string> dialogueQueue = new Queue<string>();
    private string speakerName;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddNewDialogue(string[] lines, string name)
    {
        dialogueQueue.Clear();
        speakerName = name;

        foreach (string line in lines)
        {
            dialogueQueue.Enqueue(line);
        }

        CreateDialogue();
    }

    private void CreateDialogue()
    {
        Debug.Log($"<b>{speakerName}:</b>");  // Näyttää keskustelijan nimen
        while (dialogueQueue.Count > 0)
        {
            Debug.Log(dialogueQueue.Dequeue());
        }
    }
}
