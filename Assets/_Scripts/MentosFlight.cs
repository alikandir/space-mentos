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
    private GameObject particles;
    private GameObject reverseParticles;
    bool particleActive = false;
    private Transform trans;
    
    private void Start() {
        rb = GetComponent<Rigidbody>();
        manager = GameManager.instance;
        Invoke("onBoostStart",2);
        particles = GameObject.Find("Particles");
        reverseParticles = GameObject.Find("ReverseParticles");
        particles.SetActive(false);
        reverseParticles.SetActive(false);
        trans = GetComponent<Transform>();
    }
    
    public void OnMove(InputAction.CallbackContext context) {
        input = context.ReadValue<float>()*-1;
    }
    private void Update() {
        if (particleActive) {
            if (rb.velocity.y < 0) {
                particles.SetActive(false);
                particleActive = false;
            }
        }
        if (rb.velocity.y < -1) {
            reverseParticles.SetActive(true);
        } else {
            reverseParticles.SetActive(false);
        }
        float rotationSpeed = 2;
        float targetZRotation = -1*Mathf.Clamp(input * 30, -30, 30);
        Quaternion targetRotation = Quaternion.Euler(trans.rotation.eulerAngles.x, trans.rotation.eulerAngles.y, targetZRotation);
        trans.rotation = Quaternion.Lerp(trans.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }
    private void FixedUpdate() {
        if (manager.isFlying) {
            rb.velocity = new Vector2(input*moveSpeed*Time.fixedDeltaTime, Mathf.Max(rb.velocity.y, -maxFallSpeed));
            
        }
        
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
        Invoke("SetFlightOn", 0.2f);
        particles.SetActive(true);
        particleActive = true;
    }
    public void SetFlightOn() {manager.isFlying = true;}

    
}
