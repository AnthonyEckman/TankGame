﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Vector2 player1Directions;
    public Vector2 player2Directions;
    public Vector2 Player2Facing;


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
        //Player1
        player1Directions.x = Input.GetAxisRaw("Horizontal1");
        player1Directions.y = Input.GetAxisRaw("Vertical1");

        //Player2
        player2Directions.x = Input.GetAxisRaw("Horizontal2");
        player2Directions.y = Input.GetAxisRaw("Vertical2");
        if (Input.GetAxisRaw("FacingX") > 0.1f || Input.GetAxisRaw("FacingY") > 0.1f ||Input.GetAxisRaw("FacingX") < -0.1f || Input.GetAxisRaw("FacingY") < -0.1f)
        {
            Player2Facing.x = Input.GetAxisRaw("FacingX");
            Player2Facing.y = Input.GetAxisRaw("FacingY");
        }
    }
}
