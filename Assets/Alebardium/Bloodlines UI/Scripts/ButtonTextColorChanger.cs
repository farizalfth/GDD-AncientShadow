using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

namespace BloodlinesUI
{
    public class ButtonTextColorChanger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        public TextMeshProUGUI buttonText;

        [Header("Colors")]
        public Color defaultColor = Color.white;
        public Color highlightedColor = Color.gray;
        public Color pressedColor = Color.red;
        public Color disabledColor = Color.gray;

        private bool isPressed = false;
        private bool isHighlighted = false;
        private bool isDisabled = false;
        private Button button;

        void Start()
        {
            button = GetComponent<Button>();
            if (buttonText != null)
                buttonText.color = defaultColor;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (isDisabled || buttonText == null) return; // Tambahan pengaman

            isHighlighted = true;
            if (!isPressed)
                buttonText.color = highlightedColor;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (isDisabled || buttonText == null) return; // Tambahan pengaman

            isHighlighted = false;
            if (!isPressed)
                buttonText.color = defaultColor;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (isDisabled || buttonText == null) return; // Tambahan pengaman

            isPressed = true;
            buttonText.color = pressedColor;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (isDisabled || buttonText == null) return; // Tambahan pengaman

            isPressed = false;
            buttonText.color = isHighlighted ? highlightedColor : defaultColor;
        }

        private void UpdateTextColor()
        {
            if (buttonText == null) return;

            if (isDisabled)
                buttonText.color = disabledColor;
            else if (isPressed)
                buttonText.color = pressedColor;
            else if (isHighlighted)
                buttonText.color = highlightedColor;
            else
                buttonText.color = defaultColor;
        }

        /// <summary>
        /// Enables button
        /// </summary>
        public void EnableButton()
        {
            if (button != null)
            {
                button.interactable = true;
                isDisabled = false;
                UpdateTextColor();
            }
        }

        /// <summary>
        /// Disables button
        /// </summary>
        public void DisableButton()
        {
            if (button != null)
            {
                button.interactable = false;
                isDisabled = true;
                UpdateTextColor();
            }
        }
    }
}
