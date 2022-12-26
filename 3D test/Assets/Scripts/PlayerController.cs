using Photon.Pun;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    PhotonView PV;
    private InputAction _pickUpAction;
    private InputAction _moveAction;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Transform selector;
    [SerializeField] private Transform slot;
    private IPickable _currentPickable;
    private Vector3 _inputDirection;
    private bool _isActive;
    private bool _hasSubscribedControllerEvents;
    private InteractableController _interactableController;

    void Awake()
    {
        PV = GetComponent<PhotonView>();
        _moveAction = playerInput.currentActionMap["Move"];
        _pickUpAction = playerInput.currentActionMap["PickUp"];
    }
    public void ActivatePlayer()
    {
        _isActive = true;
        SubscribeControllerEvents();
        selector.gameObject.SetActive(true);
    }

    private void SubscribeControllerEvents()
    {
        if (_hasSubscribedControllerEvents) return;
        _moveAction.performed += HandleMove;
        _pickUpAction.performed += HandlePickUp;
    }

    private void HandlePickUp(InputAction.CallbackContext context)
    {
        var interactable = _interactableController.CurrentInteractable;

        // empty hands, try to pick
        if (_currentPickable == null)
        {
            _currentPickable = interactable as IPickable;
            if (_currentPickable != null)
            {
                _currentPickable.Pick();
                _interactableController.Remove(_currentPickable as Interactable);
                _currentPickable.gameObject.transform.SetPositionAndRotation(slot.transform.position,
                    Quaternion.identity);
                _currentPickable.gameObject.transform.SetParent(slot);
                return;
            }

            // Interactable only (not a IPickable)
            _currentPickable = interactable?.TryToPickUpFromSlot(_currentPickable);

            _currentPickable?.gameObject.transform.SetPositionAndRotation(
                slot.position, Quaternion.identity);
            _currentPickable?.gameObject.transform.SetParent(slot);
            return;
        }

        // we carry a pickable, let's try to drop it (we may fail)

        // no interactable in range or at most a Pickable in range (we ignore it)
        if (interactable == null || interactable is IPickable)
        {
            _currentPickable.Drop();
            _currentPickable = null;
            return;
        }

        // we carry a pickable and we have an interactable in range
        // we may drop into the interactable

        // Try to drop on the interactable. It may refuse it, e.g. dropping a plate into the CuttingBoard,
        // or simply it already have something on it
        //Debug.Log($"[PlayerController] {_currentPickable.gameObject.name} trying to drop into {interactable.gameObject.name} ");

        bool dropSuccess = interactable.TryToDropIntoSlot(_currentPickable);
        if (!dropSuccess) return;

        _currentPickable = null;
    }

    private void HandleMove(InputAction.CallbackContext context)
    {
        // TODO: Processors on input binding not working for analogical stick. Investigate it.
        Vector2 inputMovement = context.ReadValue<Vector2>();
        if (inputMovement.x > 0.3f)
        {
            inputMovement.x = 1f;
        }
        else if (inputMovement.x < -0.3)
        {
            inputMovement.x = -1f;
        }
        else
        {
            inputMovement.x = 0f;
        }

        if (inputMovement.y > 0.3f)
        {
            inputMovement.y = 1f;
        }
        else if (inputMovement.y < -0.3f)
        {
            inputMovement.y = -1f;
        }
        else
        {
            inputMovement.y = 0f;
        }

        _inputDirection = new Vector3(inputMovement.x, 0, inputMovement.y);
    }
    void Start()
    {
        if (!PV.IsMine)
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
        }    
    }
    void Update()
    {
        if (!PV.IsMine)
            return;
    }
    void FixedUpdate()
    {
        if (!PV.IsMine)
            return;
    }
}
