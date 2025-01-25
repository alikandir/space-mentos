using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MentosFlight : MonoBehaviour
{
    public GameManager manager;
    public float bubbleMultiplier = 1;
    private Rigidbody rb;
    float input;
    public float moveSpeed = 5f;
    public float maxFallSpeed = 10f;
    private void Start() {
        rb = GetComponent<Rigidbody>();
        manager = GameManager.instance;
    }
    
    public void OnMove(InputAction.CallbackContext context) {
        input = context.ReadValue<float>();
        
        
    }
    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            onBoostStart();
        }
    }
    private void FixedUpdate() {
        rb.velocity = new Vector2(input*moveSpeed*Time.fixedDeltaTime, Mathf.Max(rb.velocity.y, -maxFallSpeed));
        Debug.Log(rb.velocity);
    }

    

    private Vector2 GetBoostAmount() {
        return new Vector2(0, 1*manager.GetBubbleCollected()*bubbleMultiplier);
    }
    
    public void onBoostStart() {
        rb.velocity = GetBoostAmount();
        bubbleMultiplier = 1;
        manager.ResetBubbleCount();
    }
}
