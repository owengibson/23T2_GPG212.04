using System;
using UnityEngine;
using UnityEngine.UI;

namespace GPG212_04
{
    public class ToolManager : MonoBehaviour
    {
        public Tool currentTool = Tool.Clippers;

        [Space]
        [Header("Hair Sprites")]
        [SerializeField] private Sprite hairNormal;
        [SerializeField] private Sprite hairShaved;
        [SerializeField] private Sprite hairLong;

        [Space]
        [Header("Other References")]
        [SerializeField] private RawImage dyeBottle;


        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Hair"))
            {
                SpriteRenderer sr = other.gameObject.GetComponent<SpriteRenderer>();
                switch (currentTool)
                {
                    case Tool.Clippers:
                        sr.sprite = hairShaved;
                        if (sr.color == Color.white) sr.color = Color.black;
                        break;

                    case Tool.Razor:
                        if (sr.sprite == hairShaved)
                        {
                            sr.sprite = null;
                        }
                        break;

                    case Tool.Dye:
                        sr.color = dyeBottle.color;
                        break;

                    case Tool.Formula:
                        if (sr.sprite == hairNormal)
                        {
                            sr.sprite = hairLong;
                            if (sr.color == Color.white) sr.color = Color.black;
                        }
                        else if (sr.sprite == hairShaved)
                        {
                            sr.sprite = hairNormal;
                            if (sr.color == Color.white) sr.color = Color.black;
                        }
                        else if (sr.sprite == null)
                        {
                            sr.sprite = hairShaved;
                            if (sr.color == Color.white) sr.color = Color.black;
                        }
                        break;

                    default:
                        break;
                }
            }
            if (other.CompareTag("Hair"))
            {
                
            }
        }

        public void ChangeCurrentTool(string tool)
        {
            currentTool = (Tool)Enum.Parse(typeof(Tool), tool);
        }
    }
}
