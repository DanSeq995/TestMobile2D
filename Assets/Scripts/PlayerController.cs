using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    public GameObject player;
    public HealthController healthController;
    public ScoreController scoreController;
    public SpawnCoordinator spawnCoordinator;
    public PowerController powerController;
    public float moveSpeed = 15f;
    //Swipe control
    public float maxSwipeTime;
    public float minSwipeDistance;
    public Collider2D last_collider;
    private float swipeStartTime;
    private float swipeEndTime;
    private float swipeTime;

    private Vector2 startSwipePosition;
    private Vector2 endSwipePosition;
    private float swipeLenght;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        healthController = GetComponent<HealthController>();
        scoreController = GameObject.Find("UI").GetComponent<ScoreController>();
        spawnCoordinator = GameObject.Find("SpawnPoints").GetComponent<SpawnCoordinator>();
        powerController = GameObject.Find("UI").GetComponent<PowerController>();

    }

    void Update()
    {
        SwipeTest();
        if(scoreController.multiplier > 1){
            powerController.activatePower();
        }else{
            powerController.deactivatePower();
        }
    }

    //Questa funzione controlla che il movimento a schermo sia effettivamente uno swipe, sia in termini di tempo che di distanza sullo schermo
    void SwipeTest() {
        if(Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began){
                swipeStartTime = Time.time;
                startSwipePosition = touch.position;
            } 
            else if(touch.phase == TouchPhase.Ended) {
                swipeEndTime = Time.time;
                endSwipePosition = touch.position;

                swipeTime = swipeEndTime - swipeStartTime;
                swipeLenght = (endSwipePosition - startSwipePosition).magnitude;

                if(swipeTime < maxSwipeTime && swipeLenght > minSwipeDistance) {
                    SwipeControl();
                }
            }
        }
    }
    void SwipeControl() {
        Vector2 distance = endSwipePosition - startSwipePosition;

        //Mi prendo il valore  assoluto e poi vedo: se x è maggiore di y è uno swipe orizzontale, altrimenti è verticale
        float xDistance = Mathf.Abs(distance.x);
        float yDistance = Mathf.Abs(distance.y);
        
        if(xDistance > yDistance) {
            if(distance.x > 0) {
                RaycastHit2D[] hits = Physics2D.RaycastAll(player.transform.position, Vector2.right, 40f);
                stepMovementWithRaycast(Vector2.right);
            } 
            else if(distance.x < 0) {
                RaycastHit2D[] hits = Physics2D.RaycastAll(player.transform.position, Vector2.left, 40f);
                stepMovementWithRaycast(Vector2.left);                
            }
        } else {
            if(distance.y > 0) {
                RaycastHit2D[] hits = Physics2D.RaycastAll(player.transform.position, Vector2.up, 40f);
                stepMovementWithRaycast(Vector2.up);               
            } 
            else if(distance.y < 0) {
                RaycastHit2D[] hits = Physics2D.RaycastAll(player.transform.position, Vector2.down, 40f);
                stepMovementWithRaycast(Vector2.down);
            }
        }
    }

    void MoveToPosition(Vector2 targetPosition) {
        StartCoroutine(MoveSmoothly(targetPosition));
    }

    //Serve a rendere lo spostamento più fluido. Si basa su moveSpeed.
    IEnumerator MoveSmoothly(Vector2 targetPosition) {
        Vector2 startPosition = player.transform.position;
        float t = 0f;

        while (t < 1f) {
            t += Time.deltaTime * moveSpeed;
            player.transform.position = Vector2.Lerp(startPosition, targetPosition, t);
            yield return null;
        }   
    player.transform.position = targetPosition;
    spawnCoordinator.SetPlayerPosition(targetPosition);
    }

    // Dato un vettore direzione, sposta il player nella direzione indicata verso il primo collider che incontra che
    // non sia l'ultimo collider incontrato
    void stepMovementWithRaycast(Vector2 direction) {
        RaycastHit2D[] hits = Physics2D.RaycastAll(player.transform.position, direction, 40f);
        foreach (var hit in hits)
        {
            if (hit.collider == last_collider){
                continue;
            }
            else if (hit.collider.gameObject.layer == 6) {
                last_collider = hit.collider;
                var hitPosition = hit.collider.bounds.center;
                MoveToPosition(new Vector2(hitPosition.x, hitPosition.y));
                break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy") {
            healthController.damage();
            scoreController.ResetMultiplier();
        }
        if(other.gameObject.tag == "Star"){
            scoreController.RaiseMultiplier();
            Destroy(other.gameObject);
        }
    }
}