using System.Collections.Generic;
using System.Linq;
using Lucha.Actor.Enemy;
using TMPro;
using UnityEngine;
using UnityProgressBar;

namespace Lucha.Actor
{
    public class ActorAttributeDisplay : MonoBehaviour
    {
        [Header("Display Settings")]
        public Vector3 offset = new(0, 1.5f, 0);
        public string displayFormat = "{0}\nState: {3}\nHP: {1}/{2}";
        
        [Header("UI References")]
        public Canvas canvas;
        public TextMeshProUGUI textDisplay;
        public ProgressBar  progressBar;
        
        [Header("Fallback prefab")]
        public GameObject fallbackPrefab;
    
        private Transform _mainCamera;
        private Transform _target;
        private Actor _actor;
        
        private string _actorName;
        private float _currentHealth;
        private string _currentState;
        private float _maxHealth;
        
        private readonly Dictionary<System.Type, string> _stateNames = new()
        {
            { typeof(IdleState), "Idle" },
            { typeof(MoveState), "Moving" },
            { typeof(AttackState), "Attacking" },
            { typeof(DeadState), "Dead" }
            // Add more state mappings as needed
        };
        
        private void Start()
        {
            // Get references
            _actor = GetComponent<Actor>();
            if (UnityEngine.Camera.main != null) _mainCamera = UnityEngine.Camera.main.transform;
            _target = _actor.transform;
            
            if (!_actor)
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
            progressBar = canvasGameObject.GetComponentInChildren<ProgressBar>();
        }
        
        private void SubscribeToActorEvents()
        {
            // For now, we'll use polling in Update - see alternative approach below
            _actor.OnStateChanged += HandleStateChanged;
            _actor.OnHealthChanged += HandleHealthChanged;
            _actor.OnActorDied += HandleActorDied;
        }
        
        private void HandleStateChanged(System.Type newStateType)
        {
            _currentState = _stateNames.TryGetValue(newStateType, out var stateName) 
                ? stateName : newStateType.Name.Split('.').Last().Replace("State", "");
            UpdateDisplay();
        }
        
        private void HandleHealthChanged(float newCurrentHealth, float newMaxHealth)
        {
            _currentHealth = newCurrentHealth;
            _maxHealth = newMaxHealth;
            UpdateDisplay();
        }

        private void HandleActorDied(string objName)
        {
            _actorName = $"{objName}[DEAD]";
            progressBar.gameObject.SetActive(false);
            UpdateDisplay();
        }
        
        private void LateUpdate()
        {
            if (!canvas || !_mainCamera) return;
            
            canvas.transform.LookAt(canvas.transform.position + _mainCamera.forward);
            canvas.transform.position = _target.position + offset;
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
            progressBar.Value = _currentHealth;
        }

        private void OnDestroy()
        {
            UnsubscribeFromActorEvents();
        }

        private void UnsubscribeFromActorEvents()
        {
            if (_actor == null) return;
            _actor.OnStateChanged -= HandleStateChanged;
            _actor.OnHealthChanged -= HandleHealthChanged;
            _actor.OnActorDied -= HandleActorDied;
        }
    }
}