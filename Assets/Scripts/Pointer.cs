using EasyAudioSystem;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GPG212_04
{
    public class Pointer : MonoBehaviour
    {
        private Rigidbody _rb;

        public bool canInteractWithHair = true;

        [SerializeField] private EventSystem eventSystem;

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }
        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && canInteractWithHair)
            {
                AudioManager.PlayAudio(ToolManager.currentTool.ToString());
            }

            // Move pointer with mouse/finger
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetMouseButton(0) && canInteractWithHair)
            {
                transform.position = new Vector3(mousePos.x, mousePos.y, 0);
            }

            if (Input.GetMouseButtonUp(0))
            {
                _rb.velocity = Vector3.zero;
                AudioManager.StopAllAudioWithTag("Tool");
            }
        }

        public void ToggleCanInteractWithHair()
        {
            canInteractWithHair= !canInteractWithHair;
        }

        private void OnEnable()
        {
            GameManager.OnGameOver += ToggleCanInteractWithHair;
        }
        private void OnDisable()
        {
            GameManager.OnGameOver -= ToggleCanInteractWithHair;
        }
    }
}
