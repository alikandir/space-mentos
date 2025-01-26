using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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
        float targetZRotation;
        float rotationSpeed = 2;
        if (rb.velocity.y < -0.5f) {
            targetZRotation = Mathf.Clamp(input * 30, -30, 30);
        }
        else {targetZRotation = -1*Mathf.Clamp(input * 30, -30, 30);}
            
        Quaternion targetRotation = Quaternion.Euler(trans.rotation.eulerAngles.x, trans.rotation.eulerAngles.y, targetZRotation);
        trans.rotation = Quaternion.Lerp(trans.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        SaveMaxHeight();
    }
    public void SaveMaxHeight() {
        if (transform.position.y > GameManager.instance.maxHeightReached) {
            GameManager.instance.maxHeightReached = transform.position.y;
        }
    }
    private void FixedUpdate() {
        if (manager.isFlying) {
            rb.velocity = new Vector2(input*moveSpeed*Time.fixedDeltaTime, Mathf.Max(rb.velocity.y, -maxFallSpeed));
            
        }
        
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Finish")) {
            SceneManager.LoadScene("GameWonScene");
        }
        else if (other.CompareTag("Ground")){
            SceneManager.LoadScene("GameOverScene");
        }
    }

    

    private Vector2 GetBoostAmount() {
        float collectedBubbles = manager.GetBubbleCollected();
        float maxVelocity = 14;
        var totalBubble = collectedBubbles * GameManager.instance.bubbleMultiplierActual;
        print(GameManager.instance.bubbleMultiplierActual);
        var normalizedTotal = totalBubble/600; 
        var boostAmount=normalizedTotal*maxVelocity;
        if (boostAmount >= maxVelocity) {
            return new Vector2(0, maxVelocity);
        }
        else {
            return new Vector2(0, boostAmount);
        }
        
    }
    
    public void onBoostStart() {
        rb.velocity = GetBoostAmount();
        GameManager.instance.ResetMultiplier();
        manager.ResetBubbleCount();
        Invoke("SetFlightOn", 0.2f);
        particles.SetActive(true);
        particleActive = true;
    }
    public void SetFlightOn() {manager.isFlying = true;}

    
}
