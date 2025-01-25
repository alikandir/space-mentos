using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MentosFlight : MonoBehaviour
{
    private GameManager manager;
    public float bubbleMultiplier = 1;
    public float collectedBubbleScaler = 1;
    public float boostScaler;
    private Rigidbody rb;
    float input;
    public float moveSpeed = 5f;
    public float maxFallSpeed = 10f;
    
    private void Start() {
        rb = GetComponent<Rigidbody>();
        manager = GameManager.instance;
        Invoke("onBoostStart",2);
    }
    
    public void OnMove(InputAction.CallbackContext context) {
        input = context.ReadValue<float>();
        
        
    }
    
    private void FixedUpdate() {
        rb.velocity = new Vector2(input*moveSpeed*Time.fixedDeltaTime, Mathf.Max(rb.velocity.y, -maxFallSpeed));
    }

    

    private Vector2 GetBoostAmount() {
        float collectedBubbles = manager.GetBubbleCollected()*collectedBubbleScaler;
        float diminishingMultiplier = Mathf.Log(collectedBubbles + 1) / Mathf.Log(2); // Logarithmic diminishing returns
   
        return new Vector2(0, 1 * collectedBubbles * diminishingMultiplier * boostScaler);
    }
    
    public void onBoostStart() {
        rb.velocity = GetBoostAmount();
        bubbleMultiplier = 1;
        manager.ResetBubbleCount();
        Invoke("SetFlightOn", 0.5f);
    }
    public void SetFlightOn() {manager.isFlying = true;}
    
    
}
