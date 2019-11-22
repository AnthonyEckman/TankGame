using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Vector2 player1Directions;
    public Vector2 player2Directions;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerInputs();
    }

    private void GetPlayerInputs()
    {
        player1Directions.x = Input.GetAxisRaw("Horizontal1");
        player1Directions.y = Input.GetAxisRaw("Vertical1");
        player2Directions.x = Input.GetAxisRaw("Horizontal2");
        player2Directions.y = Input.GetAxisRaw("Vertical2");
    }
}
