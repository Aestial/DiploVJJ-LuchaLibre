using TMPro;
using UnityEngine;

namespace Lucha.Actor
{
    public class ActorAttributeDisplay : MonoBehaviour
    {
        [Header("Display Settings")]
        public Vector3 offset = new(0, 1.5f, 0);
        public string displayFormat = "{0}\nHP: {1}/{2}\nState: {3}";
        
        [Header("UI References")]
        public Canvas canvas;
        public TextMeshProUGUI textDisplay;
        
        [Header("Fallback prefab")]
        public GameObject fallbackPrefab;
    
        private Transform _mainCamera;
        private Transform _target;
        private Actor _actor;
        private string _actorName;
        private float _currentHealth;
        private float _maxHealth;
        private string _currentState;

        private void Start()
        {
            // Get references
            _actor = GetComponent<Actor>();
            if (UnityEngine.Camera.main != null) _mainCamera = UnityEngine.Camera.main.transform;
            _target = _actor.transform;
            
            if (_actor == null)
            {
                Debug.LogError("Actor component not found in parent hierarchy!");
                return;
            }
            
            // Initialize values
            _actorName = _actor.gameObject.name;
            _currentHealth = _actor.CurrentHealth;
            _maxHealth = _actor.maxHealth;
            _currentState = "Unknown";

            // Create canvas if not assigned
            if (canvas == null)
            {
                CreateUI();
            }
            
            // Subscribe to events
            SubscribeToActorEvents();
        
            // Initial update
            UpdateDisplay();
        }

        private void CreateUI()
        {
            var canvasGameObject = Instantiate(fallbackPrefab);
            canvas = canvasGameObject.GetComponent<Canvas>();
            textDisplay = canvasGameObject.GetComponentInChildren<TextMeshProUGUI>();
        }
        
        void SubscribeToActorEvents()
        {
            // You'll need to add these events to your Actor class
            // For now, we'll use polling in Update - see alternative approach below
        }

        private void LateUpdate()
        {
            if (!canvas || !_mainCamera) return;
            // Keep the canvas facing the camera (billboard-ing)
            canvas.transform.LookAt(canvas.transform.position + _mainCamera.forward);
            
            // Optional: Keep the canvas at a fixed position above the character
            canvas.transform.position = _target.position + offset;
            
            _currentHealth = _actor.CurrentHealth;
            _currentState = _actor.CurrentState.ToString();
            
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            if (!textDisplay || !_actor) return;
            var formattedText = string.Format(displayFormat, 
                _actorName, 
                _currentHealth, 
                _maxHealth, 
                _currentState);
            
            textDisplay.text = formattedText;
        }

        private void OnDestroy()
        {
            UnsubscribeFromActorEvents();
        }

        private void UnsubscribeFromActorEvents()
        {
            // Unsubscribe from events when destroyed
        }
    }
}