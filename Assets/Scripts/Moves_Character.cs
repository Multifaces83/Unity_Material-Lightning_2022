using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moves_Character : MonoBehaviour

{
    public float speed = 5.0f;

    void Update()
    {
        // R�cup�re l'input horizontal et vertical
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        // R�cup�re l'input horizontal et vertical de la souris
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // D�place le personnage sur l'axe horizontal et vertical
        transform.position = transform.position + new Vector3(horizontalInput * speed * Time.deltaTime, 0,verticalInput * speed * Time.deltaTime);
        

        // D�place la cam�ra sur l'axe horizontal et vertical
        transform.position = transform.position + new Vector3(mouseX * speed * Time.deltaTime, mouseY * speed * Time.deltaTime, 0);
    }
}







