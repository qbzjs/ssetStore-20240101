using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace com.ggames4u.scifidisplays {
    [RequireComponent(typeof(Animator))]
    public class SciFiTablet03ButtonController : MonoBehaviour {
        #region Variables
        private Animator animator;

        [Header("Button")]

        [SerializeField] private Button topButton01;
        private bool topButton01Down = true;

        [SerializeField] private Button topButton02;
        private bool topButton02Down = true;

        [SerializeField] private Button topButton03;
        private bool topButton03Down = true;

        [SerializeField] private Button bottomLeftButton01;
        private bool bottomLeftButton01Down = true;

        [SerializeField] private Button bottomLeftButton02;
        private bool bottomLeftButton02Down = true;

        [SerializeField] private Button bottomLeftButton03;
        private bool bottomLeftButton03Down = true;

        [SerializeField] private Button leftCenterButton;
        private bool leftCenterButtonDown = true;

        [SerializeField] private Button rightCenterButton;
        private bool rightCenterButtonDown = true;

        [SerializeField] private Button onOffSwitch;
        private bool onOffSwitchIsOn = true;

        [Header("Render Pipeline")]
        [SerializeField] private RENDER_PIPELINES currentRP;

        private enum RENDER_PIPELINES {
            BuiltinRP,
            HDRP,
            URP
        }

        [Header("Material")]

        [SerializeField] private Material displayMaterial;
        [SerializeField] private Material decalMaterial;

        [Header("Colors")]

        [Tooltip("Defines the HDRP emission color in the main material and decal material. You can change the intesity to get brighter or darker emission lights.")]
        [ColorUsageAttribute(false, true)]
        [SerializeField] private Color hdrpEmissionColor;
        #endregion

        #region Builtin Methods
        private void Start() {
            if (GraphicsSettings.currentRenderPipeline) {
                if (GraphicsSettings.currentRenderPipeline.GetType().ToString().Contains("HighDefinition")) {
                    currentRP = RENDER_PIPELINES.HDRP;
                    Debug.Log("HDRP in use.");

                } else {
                    currentRP = RENDER_PIPELINES.URP;
                    Debug.Log("URP in use.");
                }

            } else {
                currentRP = RENDER_PIPELINES.BuiltinRP;
                Debug.Log("Builtin-RP in use.");
            }

            animator = GetComponent<Animator>();

            // Disable material emission
            ToggleEmission(false);
            ToggleDecalEmission(false);

            AddEventHandler();
        }

        /// <summary>
        /// Add event handler to the UI buttons.
        /// </summary>
        private void AddEventHandler() {
            onOffSwitch.onClick.AddListener(delegate {
                if (onOffSwitchIsOn) {
                    OnButtonClicked("SwitchOn", animator.GetLayerIndex("Layer_01"));
                } else {
                    OnButtonClicked("SwitchOff", animator.GetLayerIndex("Layer_01"));
                }

                ToggleEmission(onOffSwitchIsOn);
                onOffSwitchIsOn = !onOffSwitchIsOn;
            });

            topButton01.onClick.AddListener(delegate {
                if (topButton01Down) {
                    OnButtonClicked("TopButton01Down", animator.GetLayerIndex("Layer_02"));
                } else {
                    OnButtonClicked("TopButton01Up", animator.GetLayerIndex("Layer_02"));
                }

                topButton01Down = !topButton01Down;
            });

            topButton02.onClick.AddListener(delegate {
                if (topButton02Down) {
                    OnButtonClicked("TopButton02Down", animator.GetLayerIndex("Layer_03"));
                } else {
                    OnButtonClicked("TopButton02Up", animator.GetLayerIndex("Layer_03"));
                }

                topButton02Down = !topButton02Down;
            });

            topButton03.onClick.AddListener(delegate {
                if (topButton03Down) {
                    OnButtonClicked("TopButton03Down", animator.GetLayerIndex("Layer_04"));
                } else {
                    OnButtonClicked("TopButton03Up", animator.GetLayerIndex("Layer_04"));
                }

                ToggleDecalEmission(topButton03Down);
                topButton03Down = !topButton03Down;
            });

            bottomLeftButton01.onClick.AddListener(delegate {
                if (bottomLeftButton01Down) {
                    OnButtonClicked("BottomLeftButton01Down", animator.GetLayerIndex("Layer_05"));
                } else {
                    OnButtonClicked("BottomLeftButton01Up", animator.GetLayerIndex("Layer_05"));
                }

                bottomLeftButton01Down = !bottomLeftButton01Down;
            });

            bottomLeftButton02.onClick.AddListener(delegate {
                if (bottomLeftButton02Down) {
                    OnButtonClicked("BottomLeftButton02Down", animator.GetLayerIndex("Layer_06"));
                } else {
                    OnButtonClicked("BottomLeftButton02Up", animator.GetLayerIndex("Layer_06"));
                }

                bottomLeftButton02Down = !bottomLeftButton02Down;
            });

            bottomLeftButton03.onClick.AddListener(delegate {
                if (bottomLeftButton03Down) {
                    OnButtonClicked("BottomLeftButton03Down", animator.GetLayerIndex("Layer_07"));
                } else {
                    OnButtonClicked("BottomLeftButton03Up", animator.GetLayerIndex("Layer_07"));
                }

                bottomLeftButton03Down = !bottomLeftButton03Down;
            });

            leftCenterButton.onClick.AddListener(delegate {
                if (leftCenterButtonDown) {
                    OnButtonClicked("LeftCenterButtonDown", animator.GetLayerIndex("Layer_08"));
                } else {
                    OnButtonClicked("LeftCenterButtonUp", animator.GetLayerIndex("Layer_08"));
                }

                leftCenterButtonDown = !leftCenterButtonDown;
            });

            rightCenterButton.onClick.AddListener(delegate {
                if (rightCenterButtonDown) {
                    OnButtonClicked("RightCenterButtonDown", animator.GetLayerIndex("Layer_09"));
                } else {
                    OnButtonClicked("RightCenterButtonUp", animator.GetLayerIndex("Layer_09"));
                }

                rightCenterButtonDown = !rightCenterButtonDown;
            });
        }
        #endregion

        #region Custom Methods
        /// <summary>
        /// Play the given animation state.
        /// </summary>
        /// <param name="stateName"></param>
        private void OnButtonClicked(string stateName, int layer) {
            if (animator) {
                animator.Play(stateName, (int)layer);
            }
        }

        /// <summary>
        /// Toggle emission on and off.
        /// </summary>
        /// <param name="isOn"></param>
        private void ToggleEmission(bool isOn) {
            if (displayMaterial) {
                switch (currentRP) {
                    case RENDER_PIPELINES.BuiltinRP:
                        if (isOn) {
                            displayMaterial.EnableKeyword("_EMISSION");
                        } else {
                            displayMaterial.DisableKeyword("_EMISSION");
                        }
                        break;

                    case RENDER_PIPELINES.HDRP:
                        if (isOn) {
                            displayMaterial.SetColor("_EmissiveColor", hdrpEmissionColor);
                        } else {
                            displayMaterial.SetColor("_EmissiveColor", Color.black);
                        }
                        break;

                    case RENDER_PIPELINES.URP:
                        if (isOn) {
                            displayMaterial.EnableKeyword("_EMISSION");
                        } else {
                            displayMaterial.DisableKeyword("_EMISSION");
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Toggle the decal material on and off.
        /// </summary>
        /// <param name="isOn"></param>
        private void ToggleDecalEmission(bool isOn) {
            if (decalMaterial) {
                switch (currentRP) {
                    case RENDER_PIPELINES.BuiltinRP:
                        if (isOn) {
                            decalMaterial.EnableKeyword("_EMISSION");
                        } else {
                            decalMaterial.DisableKeyword("_EMISSION");
                        }
                        break;

                    case RENDER_PIPELINES.HDRP:
                        if (isOn) {
                            decalMaterial.SetColor("_EmissiveColor", hdrpEmissionColor);
                        } else {
                            decalMaterial.SetColor("_EmissiveColor", Color.black);
                        }
                        break;

                    case RENDER_PIPELINES.URP:
                        if (isOn) {
                            decalMaterial.EnableKeyword("_EMISSION");
                        } else {
                            decalMaterial.DisableKeyword("_EMISSION");
                        }
                        break;
                }
            }
        }
        #endregion
    }
}