//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Inputs/MobileInputs.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @MobileInputs: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @MobileInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MobileInputs"",
    ""maps"": [
        {
            ""name"": ""Input"",
            ""id"": ""0c883fef-b117-43f4-9d56-6e3cd4f1b79b"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""c23b23af-bb0c-4c52-98ce-af1a37b6a40d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)"",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""4ef76250-dc35-4251-a31f-2e2b434cd6f8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""WeakAttack"",
                    ""type"": ""Button"",
                    ""id"": ""833337a5-5fa4-4963-892a-252faff9d624"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""StrongAttack"",
                    ""type"": ""Button"",
                    ""id"": ""6df8316d-38af-43b2-9be2-6d4679b78544"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""5f823516-9115-4989-b842-ce9e24ec0dd7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Potion"",
                    ""type"": ""Button"",
                    ""id"": ""e8f05f89-b4b8-4775-89ee-1b4c9f8256b4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4fc84d6f-bfd5-4086-8014-bd9f778c994f"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""4419f97a-e447-4dc1-980d-857f7b60e198"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""5d1715b5-f234-4da8-b828-2276443b4349"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""9385e217-b99e-437c-a32a-1b6d3f7f80a9"",
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
                    ""id"": ""fed8184c-8a6d-4572-9c19-76e6f96e71e3"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2ce6dee5-48e0-43af-a926-263b0a27c330"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WeakAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6776c854-22ae-47c8-86ac-56a64b02496b"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StrongAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a6ba1469-0f6e-4059-9d79-c71a67e793c1"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8e5501d0-a017-4597-b425-2a58fc44da0f"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Potion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Input
        m_Input = asset.FindActionMap("Input", throwIfNotFound: true);
        m_Input_Move = m_Input.FindAction("Move", throwIfNotFound: true);
        m_Input_Jump = m_Input.FindAction("Jump", throwIfNotFound: true);
        m_Input_WeakAttack = m_Input.FindAction("WeakAttack", throwIfNotFound: true);
        m_Input_StrongAttack = m_Input.FindAction("StrongAttack", throwIfNotFound: true);
        m_Input_Interact = m_Input.FindAction("Interact", throwIfNotFound: true);
        m_Input_Potion = m_Input.FindAction("Potion", throwIfNotFound: true);
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

    // Input
    private readonly InputActionMap m_Input;
    private List<IInputActions> m_InputActionsCallbackInterfaces = new List<IInputActions>();
    private readonly InputAction m_Input_Move;
    private readonly InputAction m_Input_Jump;
    private readonly InputAction m_Input_WeakAttack;
    private readonly InputAction m_Input_StrongAttack;
    private readonly InputAction m_Input_Interact;
    private readonly InputAction m_Input_Potion;
    public struct InputActions
    {
        private @MobileInputs m_Wrapper;
        public InputActions(@MobileInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Input_Move;
        public InputAction @Jump => m_Wrapper.m_Input_Jump;
        public InputAction @WeakAttack => m_Wrapper.m_Input_WeakAttack;
        public InputAction @StrongAttack => m_Wrapper.m_Input_StrongAttack;
        public InputAction @Interact => m_Wrapper.m_Input_Interact;
        public InputAction @Potion => m_Wrapper.m_Input_Potion;
        public InputActionMap Get() { return m_Wrapper.m_Input; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InputActions set) { return set.Get(); }
        public void AddCallbacks(IInputActions instance)
        {
            if (instance == null || m_Wrapper.m_InputActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_InputActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @WeakAttack.started += instance.OnWeakAttack;
            @WeakAttack.performed += instance.OnWeakAttack;
            @WeakAttack.canceled += instance.OnWeakAttack;
            @StrongAttack.started += instance.OnStrongAttack;
            @StrongAttack.performed += instance.OnStrongAttack;
            @StrongAttack.canceled += instance.OnStrongAttack;
            @Interact.started += instance.OnInteract;
            @Interact.performed += instance.OnInteract;
            @Interact.canceled += instance.OnInteract;
            @Potion.started += instance.OnPotion;
            @Potion.performed += instance.OnPotion;
            @Potion.canceled += instance.OnPotion;
        }

        private void UnregisterCallbacks(IInputActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @WeakAttack.started -= instance.OnWeakAttack;
            @WeakAttack.performed -= instance.OnWeakAttack;
            @WeakAttack.canceled -= instance.OnWeakAttack;
            @StrongAttack.started -= instance.OnStrongAttack;
            @StrongAttack.performed -= instance.OnStrongAttack;
            @StrongAttack.canceled -= instance.OnStrongAttack;
            @Interact.started -= instance.OnInteract;
            @Interact.performed -= instance.OnInteract;
            @Interact.canceled -= instance.OnInteract;
            @Potion.started -= instance.OnPotion;
            @Potion.performed -= instance.OnPotion;
            @Potion.canceled -= instance.OnPotion;
        }

        public void RemoveCallbacks(IInputActions instance)
        {
            if (m_Wrapper.m_InputActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IInputActions instance)
        {
            foreach (var item in m_Wrapper.m_InputActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_InputActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public InputActions @Input => new InputActions(this);
    public interface IInputActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnWeakAttack(InputAction.CallbackContext context);
        void OnStrongAttack(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnPotion(InputAction.CallbackContext context);
    }
}
