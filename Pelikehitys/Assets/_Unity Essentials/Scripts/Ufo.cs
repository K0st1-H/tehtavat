using UnityEngine;

public class Ufo : ActionItem
{
    [SerializeField] private string ufoName = "Zorgon";
    [SerializeField]
    private string[] dialogueLines =
    {
        "Hei maan asukas!",
        "Tulen ulkoavaruudesta.",
        "Haluatko ett‰ s‰det‰n sinut?"
    };

    public override void Interact()
    {
        Debug.Log("UFO aktivoitu! Se lent‰‰ pois!");
        DialogueSystem.Instance.AddNewDialogue(dialogueLines, ufoName);
    }
}
