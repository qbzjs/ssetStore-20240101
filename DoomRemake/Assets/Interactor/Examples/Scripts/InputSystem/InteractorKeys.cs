#if ENABLE_INPUT_SYSTEM
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @InteractorKeys: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InteractorKeys()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InteractorKeys"",
    ""maps"": [
        {
            ""name"": ""InteractorExampleSceneControls"",
            ""id"": ""9f5ef7bc-312a-498b-9d86-a1c58135f4ec"",
            ""actions"": [
                {
                    ""name"": ""MouseWheel"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e57c8d58-5bda-4465-a4a8-9d3e9c33cd73"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""032befd1-e1e7-4834-8422-cb4a7382d76e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Brake"",
                    ""type"": ""PassThrough"",
                    ""id"": ""fc472e8d-0be4-4685-9bf9-6aea82639e21"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Vertical"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e6cd8218-4665-4252-a2ca-6102e4153243"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Horizontal"",
                    ""type"": ""PassThrough"",
                    ""id"": ""fa3b53f5-fcba-46e6-9c82-7ae619d0a940"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""fce9b26d-3745-4db7-8275-648693ee2eae"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseWheel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Direction"",
                    ""id"": ""2c6dfb20-9ed0-4045-bf0a-b35d09b40e25"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""50500927-f255-44f0-99b4-1125d891702c"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""3b717f81-c577-403b-ba4e-33105866e3b7"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b44d0940-a50f-4b87-9893-462e9d155090"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b554a21c-e67a-42be-90b9-0ff8deb9b27c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""aae38bed-ffe1-40bc-a301-d7bebd795693"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""843f8f32-660f-4e4a-b2fc-13b93a0e829c"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""7a0a1cf4-8c83-4b75-b6fe-1ac0b6ad5e77"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""df4bb7c1-3ce5-4646-9dac-511d52cdb0c0"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""c0bb4387-2d53-4361-872b-a01816870659"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""c446be3c-2224-4866-9b25-ed25875c5cae"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""f4f10976-628e-42e5-b074-2242eef608ef"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // InteractorExampleSceneControls
        m_InteractorExampleSceneControls = asset.FindActionMap("InteractorExampleSceneControls", throwIfNotFound: true);
        m_InteractorExampleSceneControls_MouseWheel = m_InteractorExampleSceneControls.FindAction("MouseWheel", throwIfNotFound: true);
        m_InteractorExampleSceneControls_Move = m_InteractorExampleSceneControls.FindAction("Move", throwIfNotFound: true);
        m_InteractorExampleSceneControls_Brake = m_InteractorExampleSceneControls.FindAction("Brake", throwIfNotFound: true);
        m_InteractorExampleSceneControls_Vertical = m_InteractorExampleSceneControls.FindAction("Vertical", throwIfNotFound: true);
        m_InteractorExampleSceneControls_Horizontal = m_InteractorExampleSceneControls.FindAction("Horizontal", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // InteractorExampleSceneControls
    private readonly InputActionMap m_InteractorExampleSceneControls;
    private List<IInteractorExampleSceneControlsActions> m_InteractorExampleSceneControlsActionsCallbackInterfaces = new List<IInteractorExampleSceneControlsActions>();
    private readonly InputAction m_InteractorExampleSceneControls_MouseWheel;
    private readonly InputAction m_InteractorExampleSceneControls_Move;
    private readonly InputAction m_InteractorExampleSceneControls_Brake;
    private readonly InputAction m_InteractorExampleSceneControls_Vertical;
    private readonly InputAction m_InteractorExampleSceneControls_Horizontal;
    public struct InteractorExampleSceneControlsActions
    {
        private @InteractorKeys m_Wrapper;
        public InteractorExampleSceneControlsActions(@InteractorKeys wrapper) { m_Wrapper = wrapper; }
        public InputAction @MouseWheel => m_Wrapper.m_InteractorExampleSceneControls_MouseWheel;
        public InputAction @Move => m_Wrapper.m_InteractorExampleSceneControls_Move;
        public InputAction @Brake => m_Wrapper.m_InteractorExampleSceneControls_Brake;
        public InputAction @Vertical => m_Wrapper.m_InteractorExampleSceneControls_Vertical;
        public InputAction @Horizontal => m_Wrapper.m_InteractorExampleSceneControls_Horizontal;
        public InputActionMap Get() { return m_Wrapper.m_InteractorExampleSceneControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InteractorExampleSceneControlsActions set) { return set.Get(); }
        public void AddCallbacks(IInteractorExampleSceneControlsActions instance)
        {
            if (instance == null || m_Wrapper.m_InteractorExampleSceneControlsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_InteractorExampleSceneControlsActionsCallbackInterfaces.Add(instance);
            @MouseWheel.started += instance.OnMouseWheel;
            @MouseWheel.performed += instance.OnMouseWheel;
            @MouseWheel.canceled += instance.OnMouseWheel;
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Brake.started += instance.OnBrake;
            @Brake.performed += instance.OnBrake;
            @Brake.canceled += instance.OnBrake;
            @Vertical.started += instance.OnVertical;
            @Vertical.performed += instance.OnVertical;
            @Vertical.canceled += instance.OnVertical;
            @Horizontal.started += instance.OnHorizontal;
            @Horizontal.performed += instance.OnHorizontal;
            @Horizontal.canceled += instance.OnHorizontal;
        }

        private void UnregisterCallbacks(IInteractorExampleSceneControlsActions instance)
        {
            @MouseWheel.started -= instance.OnMouseWheel;
            @MouseWheel.performed -= instance.OnMouseWheel;
            @MouseWheel.canceled -= instance.OnMouseWheel;
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Brake.started -= instance.OnBrake;
            @Brake.performed -= instance.OnBrake;
            @Brake.canceled -= instance.OnBrake;
            @Vertical.started -= instance.OnVertical;
            @Vertical.performed -= instance.OnVertical;
            @Vertical.canceled -= instance.OnVertical;
            @Horizontal.started -= instance.OnHorizontal;
            @Horizontal.performed -= instance.OnHorizontal;
            @Horizontal.canceled -= instance.OnHorizontal;
        }

        public void RemoveCallbacks(IInteractorExampleSceneControlsActions instance)
        {
            if (m_Wrapper.m_InteractorExampleSceneControlsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IInteractorExampleSceneControlsActions instance)
        {
            foreach (var item in m_Wrapper.m_InteractorExampleSceneControlsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_InteractorExampleSceneControlsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public InteractorExampleSceneControlsActions @InteractorExampleSceneControls => new InteractorExampleSceneControlsActions(this);
    public interface IInteractorExampleSceneControlsActions
    {
        void OnMouseWheel(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnBrake(InputAction.CallbackContext context);
        void OnVertical(InputAction.CallbackContext context);
        void OnHorizontal(InputAction.CallbackContext context);
    }
}
#endif