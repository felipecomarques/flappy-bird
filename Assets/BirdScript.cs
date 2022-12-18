using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour {
    public Rigidbody2D myRigidBody;
    public float flapForca;
    public LogicScript logic;
    public bool birdAlive = true;

    // Start is called before the first frame update
    void Start() {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && birdAlive) {
            myRigidBody.velocity = Vector2.up * flapForca;
        }
        if (transform.position.y > 17 || transform.position.y < -17) {
            death();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        death();
    }

    void death() {
        logic.gameOver();
        birdAlive = false;
    }
}
