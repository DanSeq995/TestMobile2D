using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    float dir = 1f;
    public float speed;
    public float jumpHeight;

    //private Rigidbody2D rb;

    bool facingRight = true;

    //Swipe control
    public float maxSwipeTime;
    public float minSwipeDistance;

    private float swipeStartTime;
    private float swipeEndTime;
    private float swipeTime;

    private Vector2 startSwipePosition;
    private Vector2 endSwipePosition;
    private float swipeLenght;

    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //rb.velocity = new Vector2(dir * speed * Time.deltaTime, rb.velocity.y);
        SwipeTest();
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

        print("xDistance: " + xDistance);
        print("yDistance: " + yDistance);

        if(xDistance > yDistance) {
            if(distance.x > 0) {
                print("Swipe destro");
            } else if(distance.x < 0) {
                print("Swipe sinistro");
            }
        } else {
            if(distance.y > 0) {
                print("Swipe alto");
            } else if(distance.y < 0) {
                print("Swipe basso");
            }
        }
    }

    /*
    void FlipAndMove() {
        dir = -dir;
        transform.Rotate(0, 180, 0);
        facingRight = !facingRight;
    }*/
}