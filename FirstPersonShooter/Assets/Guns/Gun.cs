using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using TMPro;

public class Gun : MonoBehaviour
{
 
        public GunData gun_data;
        public Camera cam;
        protected Ray ray;
        protected int ammo_in_clip;

        //debug
        public TMP_Text debug_text;

        //Shooting
        private bool primary_fire_is_shooting = false;
        private bool primary_fire_hold = false;
        private float shoot_delay_timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        ammo_in_clip = gun_data.ammo_per_clip;
    }

    // Update is called once per frame
    void Update()
    {
        debug_text.text = "Ammo In Clip: " + ammo_in_clip.ToString();
        PrimaryFire();

        //subtract from shoot timer
        if (shoot_delay_timer > 0) shoot_delay_timer -= Time.deltaTime;
    }

    public void GetPrimaryFireInput(InputAction.CallbackContext context)
    {
        //checks for button press
        if (context.phase == InputActionPhase.Started)
        {
            primary_fire_is_shooting = true;
        }
        //checks if gun is auto
        if (gun_data.automatic)
        {
            //check if hold action is complete
            if (context.interaction is HoldInteraction && context.phase == InputActionPhase.Performed)
            {
                primary_fire_hold = true;
            }
        }
        //checks if button was released vvv
        if (context.phase == InputActionPhase.Canceled)
        {
            primary_fire_hold = false;
            primary_fire_is_shooting = false;
        }


    }
    public void GetSecondaryFireInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started) SecondaryFire();
    }

    protected virtual void PrimaryFire()
    {

    }

    protected virtual void SecondaryFire()
    {

    }

}
