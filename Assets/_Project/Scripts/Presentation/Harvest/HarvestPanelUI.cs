using UnityEngine;
using UnityEngine.UIElements;
using VContainer;

namespace Game.Presentation.HarvestScope
{
    public class HarvestPanelUI : MonoBehaviour
    {
        private UIDocument _uiDocument;

        private Label _fruitLabel;
        private Label _deadSproutLabel;

        [Inject]
        public void Construct(UIDocument uiDocument)
        {
            _uiDocument = uiDocument;
        }

        void OnEnable()
        {
            VisualElement root = _uiDocument.rootVisualElement;
            _fruitLabel = root.Q<Label>("fruit-label");
            _deadSproutLabel = root.Q<Label>("dead-sprout-label");
        }

        public void UpdateFruitsLabel(int quantity) => _fruitLabel.text = $"Fruits: {quantity}";

        public void UpdateDeadSproutsLabel(int quantity) => _deadSproutLabel.text = $"Dead Sprouts: {quantity}";
    }
}