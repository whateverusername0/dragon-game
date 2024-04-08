using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICustomButton : MonoBehaviour
{
    [field: SerializeField] public UIPanel CorrespondingPanel { get; private set; }
    [field: SerializeField] public Sprite SpriteOff { get; private set; }
    [field: SerializeField] public Sprite SpriteOn { get; private set; }
    [field: SerializeField] public bool IsActive { get; set; }

    public UICustomButton GetActiveButton()
    {
        foreach (var button in FindObjectsOfType<UICustomButton>())
            if (button.IsActive) return button;
        return null;
    }

    public void ToggleActive()
    {
        if (!IsActive)
        {
            CorrespondingPanel.TogglePanel();

            var activeButt = GetActiveButton();
            activeButt.IsActive = false;
            activeButt.GetComponent<Image>().sprite = activeButt.SpriteOff;

            this.IsActive = true;
            this.GetComponent<Image>().sprite = SpriteOn;
        }
    }
}
