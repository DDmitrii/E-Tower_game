using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonScript : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject EasyButton;
    public GameObject MediumButton;
    public GameObject HardButton;

    void Update()
    {
        SetButtonSizes();
    }

    void SetButtonSizes()
    {
        RectTransform rectTransformCanvas = Canvas.GetComponent<RectTransform>();

        if (rectTransformCanvas != null)
        {
            float width = rectTransformCanvas.sizeDelta.x;
            float height = rectTransformCanvas.sizeDelta.y;

            // Установка размеров и позиций для EasyButton
            RectTransform rectTransformEasy = EasyButton.GetComponent<RectTransform>();
            SetButtonSizeAndPosition(rectTransformEasy, width / 3f, height, width / 6f, 0);
            SetTextSizeAndPosition(EasyButton);

            // Установка размеров и позиций для MediumButton
            RectTransform rectTransformMedium = MediumButton.GetComponent<RectTransform>();
            SetButtonSizeAndPosition(rectTransformMedium, width / 3f, height, width / 2f, 0);
            SetTextSizeAndPosition(MediumButton);

            // Установка размеров и позиций для HardButton
            RectTransform rectTransformHard = HardButton.GetComponent<RectTransform>();
            SetButtonSizeAndPosition(rectTransformHard, width / 3f, height, width * 5f / 6f, 0);
            SetTextSizeAndPosition(HardButton);
        }
    }

    void SetButtonSizeAndPosition(RectTransform rectTransform, float width, float height, float posX, float posY)
    {
        RectTransform rectTransformCanvas = Canvas.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(width, height);
        Vector3 position = rectTransform.localPosition;
        position.x = posX - (float)rectTransformCanvas.rect.width / 2f; // Корректировка позиции относительно центра канваса
        position.y = posY; // Корректировка позиции относительно центра канваса
        rectTransform.localPosition = position;
    }

    void SetTextSizeAndPosition(GameObject button)
    {
        RectTransform rectTransformCanvas = Canvas.GetComponent<RectTransform>();
        float width = rectTransformCanvas.sizeDelta.x;
        float height = rectTransformCanvas.sizeDelta.y;
        TextMeshProUGUI textComponent = button.GetComponentInChildren<TextMeshProUGUI>();
        if (textComponent != null)
        {
            textComponent.alignment = TextAlignmentOptions.Center;
            textComponent.enableAutoSizing = true;
            textComponent.fontSizeMin = 50;
            textComponent.fontSizeMax = 100;
        }
    }
}
