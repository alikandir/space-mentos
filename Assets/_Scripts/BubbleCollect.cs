
using UnityEngine;


public class BubbleCollect : MonoBehaviour
{
    public AudioClip[] popSounds;
    public float bubbleAmount=1f;
    private GameManager manager;
    public Camera mainCamera;
    private void Start() {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        mainCamera = Camera.main;
    }
    private void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.forward, new Vector3(0, 0, 0));
        

        if (plane.Raycast(ray, out float distance))
        {
            Vector3 point = ray.GetPoint(distance);
            transform.position = point;
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        
        manager.CollectBubble(bubbleAmount);
        var popSound = popSounds[UnityEngine.Random.Range(0, popSounds.Length)];
        var pitch = Random.Range(0.9f, 1.1f); // Slight random pitch variation
        AudioManager.Instance.PlaySound(popSound, transform.position, pitch: pitch);
        }
}
