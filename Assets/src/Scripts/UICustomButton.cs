using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICustomButton : MonoBehaviour
{
    [field: SerializeField] public Button Button { get; private set; }
    [field: SerializeField] public UIPanel CorrespondingPanel { get; private set; }
    [field: SerializeField] public Sprite SpriteOff { get; private set; }
    [field: SerializeField] public Sprite SpriteOn { get; private set; }
    [field: SerializeField] public bool IsActive { get; set; } = false;

    public void Start()
    {
        if (Button == null) Button = GetComponent<Button>();
    }

    public UICustomButton GetActiveButton()
    {
        foreach (var button in FindObjectsOfType<UICustomButton>())
            if (button.IsActive) return button;
        return null;
    }

    public void ToggleActive()
    {
        if (IsActive) return;
        
        CorrespondingPanel.TogglePanel();

        var activeButt = GetActiveButton();
        if (activeButt != null)
        {
            activeButt.IsActive = false;
            activeButt.GetComponent<Image>().sprite = activeButt.SpriteOff;
        }

        this.IsActive = true;
        this.GetComponent<Image>().sprite = SpriteOn;
    }

    public static void GlobalEnable(bool enable)
    {
        foreach (var button in FindObjectsOfType<UICustomButton>())
            button.GetComponent<Button>().enabled = enable;
    }
}
