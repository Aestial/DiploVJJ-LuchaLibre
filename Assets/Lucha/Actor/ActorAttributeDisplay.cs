using TMPro;
using UnityEngine;

namespace Lucha.Actor
{
    public class ActorAttributeDisplay : MonoBehaviour
    {
        [Header("Display Settings")]
        public Vector3 offset = new Vector3(0, 1.5f, 0); // Height above character head
        public string displayText = "Character Name\nHP: 100/100";
    
        [Header("UI References")]
        public Canvas canvas;
        public TextMeshProUGUI textDisplay;
        
        [Header("Fallback prefab")]
        public GameObject fallbackPrefab;
    
        private Transform _mainCamera;
        private Transform _characterTransform;

        private void Start()
        {
            // Get references
            _characterTransform = transform;
            if (UnityEngine.Camera.main != null) _mainCamera = UnityEngine.Camera.main.transform;

            // Create canvas if not assigned
            if (canvas == null)
            {
                CreateUI();
            }
        }

        private void CreateUI()
        {
            var canvasGameObject = Instantiate(fallbackPrefab);
            canvas = canvasGameObject.GetComponent<Canvas>();
            textDisplay = canvasGameObject.GetComponentInChildren<TextMeshProUGUI>();
            textDisplay.text = displayText;
        }

        private void LateUpdate()
        {
            if (!canvas || !_mainCamera) return;
            // Keep the canvas facing the camera (billboard-ing)
            canvas.transform.LookAt(canvas.transform.position + _mainCamera.forward);
            
            // Optional: Keep the canvas at a fixed position above the character
            canvas.transform.position = _characterTransform.position + offset;
        }

        // Public method to update the displayed text
        public void UpdateDisplayText(string newText)
        {
            if (textDisplay != null)
            {
                textDisplay.text = newText;
            }
            else
            {
                displayText = newText;
            }
        }
    }
}