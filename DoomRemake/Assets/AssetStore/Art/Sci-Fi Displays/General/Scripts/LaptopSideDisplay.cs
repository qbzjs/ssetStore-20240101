using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.ggames4u.scifidisplays {
    [RequireComponent(typeof(Transform))]
    public class LaptopSideDisplay : MonoBehaviour {
        #region Variables
        [SerializeField] private float speed = 1.0f;
        [SerializeField] private float startPosition = 0.1587f;
        [SerializeField] private float endPosition = 0.235f;
        [SerializeField] private float delay = 5.0f;
        [SerializeField] private bool enable = true;

        private Transform m_Transform;
        private bool canMove = false;
        #endregion

        #region Properties
        public static bool MoveOut { get; set; }
        #endregion

        #region Builtin Methods
        private void Start() {
            m_Transform = transform;
            MoveOut = true;

            // Delay before the side displays start to move
            if (delay > 0f) {
                StartCoroutine(Delay());
            }
        }

        // Update is called once per frame
        private void LateUpdate() {
            if (enable && canMove) {
                if (MoveOut && Mathf.Floor(transform.localPosition.x * 1000) != Mathf.Floor(endPosition * 1000)) {
                    float newXPos = Mathf.Lerp(m_Transform.localPosition.x, endPosition, Time.deltaTime * speed);
                    m_Transform.localPosition = new Vector3(newXPos, m_Transform.localPosition.y, m_Transform.localPosition.z);
                }

                if (!MoveOut && Mathf.Floor(transform.localPosition.x * 1000) != Mathf.Floor(startPosition * 1000)) {
                    float newXPos = Mathf.Lerp(m_Transform.localPosition.x, startPosition, Time.deltaTime * speed);
                    m_Transform.localPosition = new Vector3(newXPos, m_Transform.localPosition.y, m_Transform.localPosition.z);
                }
            }
        }
        #endregion

        #region Custom Methods
        private IEnumerator Delay() {
            yield return new WaitForSeconds(delay);
            canMove = true;
        }
        #endregion
    }
}