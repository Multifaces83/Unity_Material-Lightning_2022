using UnityEngine;
using TMPro;

public class ActorController : MonoBehaviour
{
    // La distance maximale � laquelle le raycast peut d�tecter des objets
    public float raycastDistance = 10.0f;

    // La balise de la porte
    public string doorTag = "Door";

    // La touche � appuyer pour ouvrir et fermer la porte
    public KeyCode openCloseKey = KeyCode.E;

    // Le texte qui affiche les messages � l'utilisateur
    public TextMeshProUGUI messageText;

    // La vitesse de d�placement du joueur
    public float movementSpeed = 5.0f;

    // La vitesse � laquelle le joueur peut regarder autour de lui
    public float mouseSensitivity = 2.0f;

    void Update()
    {
        //***************DEPLACMENT***************
        // R�cup�re les entr�es du clavier et de la souris
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float mouseXInput = Input.GetAxis("Mouse X");
        float mouseYInput = Input.GetAxis("Mouse Y");

        // Applique les entr�es de mouvement au personnage
        transform.position += transform.right * horizontalInput * movementSpeed * Time.deltaTime;
        transform.position += transform.forward * verticalInput * movementSpeed * Time.deltaTime;

        // Applique les entr�es de souris pour regarder autour de soi
        transform.Rotate(Vector3.up, mouseXInput * mouseSensitivity);
        transform.GetChild(0).Rotate(Vector3.right, -mouseYInput * mouseSensitivity);

        //***************DETECTION***************
        // Cr�ez un rayon depuis la cam�ra du joueur
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        // Initialisez les variables de sortie de Raycast
        RaycastHit hitInfo;
        bool hit = Physics.Raycast(ray, out hitInfo, raycastDistance);

        // Si le raycast a frapp� un objet...
        if (hit)
        {
            // ... et si cet objet a la balise de la porte...
            if (hitInfo.collider.tag == doorTag)
            {
                // ... obtenez une r�f�rence au script de la porte attach� � la porte...
                DoorScript doorScript = hitInfo.collider.GetComponent<DoorScript>();

                // ... v�rifiez si l'utilisateur a appuy� sur la touche pour ouvrir ou fermer la porte...
                if (Input.GetKeyDown(openCloseKey))
                {
                    // ... et appelez la fonction appropri�e du script de la porte pour ouvrir ou fermer la porte.
                    if (doorScript.isOpen)
                    {
                        doorScript.CloseDoor();
                    }
                    else
                    {
                        doorScript.OpenDoor();
                    }
                }

                // Mettez � jour le message � afficher � l'utilisateur en fonction de l'�tat de la porte
                if (doorScript.isOpen)
                {
                    messageText.text = "Appuyez sur " + openCloseKey + " pour fermer la porte";
                }
                else
                {
                    messageText.text = "Appuyez sur " + openCloseKey + " pour ouvrir la porte";
                }
            }
        }
    }
}
    