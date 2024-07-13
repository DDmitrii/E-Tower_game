using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

            // ��������� �������� � ������� ��� EasyButton
            RectTransform rectTransformEasy = EasyButton.GetComponent<RectTransform>();
            SetButtonSizeAndPosition(rectTransformEasy, width / 3f, height, width / 6f, 0);

            // ��������� �������� � ������� ��� MediumButton
            RectTransform rectTransformMedium = MediumButton.GetComponent<RectTransform>();
            SetButtonSizeAndPosition(rectTransformMedium, width / 3f, height, width / 2f, 0);

            // ��������� �������� � ������� ��� HardButton
            RectTransform rectTransformHard = HardButton.GetComponent<RectTransform>();
            SetButtonSizeAndPosition(rectTransformHard, width / 3f, height, width * 5f / 6f, 0);
        }
    }

    void SetButtonSizeAndPosition(RectTransform rectTransform, float width, float height, float posX, float posY)
    {
        RectTransform rectTransformCanvas = Canvas.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(width, height);
        Vector3 position = rectTransform.localPosition;
        position.x = posX - (float)rectTransformCanvas.rect.width / 2f; // ������������� ������� ������������ ������ �������
        position.y = posY; // ������������� ������� ������������ ������ �������
        rectTransform.localPosition = position;
    }
}
