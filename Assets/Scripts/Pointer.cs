using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GPG212_04
{
    public class Pointer : MonoBehaviour
    {
        private Rigidbody _rb;

        public bool isSelectingColour = false;

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }
        private void Update()
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetMouseButton(0) && !isSelectingColour)
            {
                transform.position = new Vector3(mousePos.x, mousePos.y, 0);
            }

            if (Input.GetMouseButtonUp(0))
            {
                _rb.velocity = Vector3.zero;
            }
        }

        public void ToggleIsSelectingColor()
        {
            isSelectingColour= !isSelectingColour;
        }
    }
}
