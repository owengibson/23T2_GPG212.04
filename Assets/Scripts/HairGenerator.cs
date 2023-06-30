using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GPG212_04
{
    public class HairGenerator : MonoBehaviour
    {
        [Header("Parameters")]
        [Range(0, 4000)]
        [SerializeField] private int generalHairCount;
        [SerializeField] private Vector2 generalMinBounds = new Vector2(-3f, -2.6f);
        [SerializeField] private Vector2 generalMaxBounds = new Vector2(3f, 3f);
        [Space]
        [Range(0, 4000)]
        [SerializeField] private int extraHairCount;
        [SerializeField] private Vector2 extraMinBounds = new Vector2(-1.2f, -2.3f);
        [SerializeField] private Vector2 extraMaxBounds = new Vector2(1.5f, 2.5f);

        [Space]
        [Header("References")]
        [SerializeField] private GameObject hairPrefab;

        private PolygonCollider2D _polygonCollider2D;

        private void Awake()
        {
            _polygonCollider2D = GetComponent<PolygonCollider2D>();
        }

        private void Start()
        {
            // General hair creation
            for (int i = 0; i < generalHairCount; i++)
            {
                Vector2 hairPos = Vector2RandomRange(generalMinBounds, generalMaxBounds);

                if (_polygonCollider2D.OverlapPoint(hairPos))
                {
                    Instantiate(hairPrefab, hairPos, Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)), transform);
                    continue;
                }
                else i--;
            }

            // Extra (focused) hair creation
            for (int i = 0;i < extraHairCount; i++)
            {
                Vector2 hairPos = Vector2RandomRange(extraMinBounds, extraMaxBounds);
                Instantiate(hairPrefab, hairPos, Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)), transform);
            }
        }

        private Vector2 Vector2RandomRange(Vector2 min, Vector2 max)
        {
            Vector2 result = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));
            return result;
        }
    }
}
