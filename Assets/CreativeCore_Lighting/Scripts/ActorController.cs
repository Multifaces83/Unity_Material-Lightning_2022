using UnityEngine;
using TMPro;

public class ActorController : MonoBehaviour
{
    // La distance maximale à laquelle le raycast peut détecter des objets
    public float raycastDistance = 10.0f;

    // La balise de la porte
    public string doorTag = "Door";

    // La touche à appuyer pour ouvrir et fermer la porte
    public KeyCode openCloseKey = KeyCode.E;

    // Le texte qui affiche les messages à l'utilisateur
    public TextMeshProUGUI messageText;

    // La vitesse de déplacement du joueur
    public float movementSpeed = 5.0f;

    // La vitesse à laquelle le joueur peut regarder autour de lui
    public float mouseSensitivity = 2.0f;

    void Update()
    {
        //***************DEPLACMENT***************
        // Récupère les entrées du clavier et de la souris
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float mouseXInput = Input.GetAxis("Mouse X");
        float mouseYInput = Input.GetAxis("Mouse Y");

        // Applique les entrées de mouvement au personnage
        transform.position += transform.right * horizontalInput * movementSpeed * Time.deltaTime;
        transform.position += transform.forward * verticalInput * movementSpeed * Time.deltaTime;

        // Applique les entrées de souris pour regarder autour de soi
        transform.Rotate(Vector3.up, mouseXInput * mouseSensitivity);
        transform.GetChild(0).Rotate(Vector3.right, -mouseYInput * mouseSensitivity);

        //***************DETECTION***************
        // Créez un rayon depuis la caméra du joueur
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        // Initialisez les variables de sortie de Raycast
        RaycastHit hitInfo;
        bool hit = Physics.Raycast(ray, out hitInfo, raycastDistance);

        // Si le raycast a frappé un objet...
        if (hit)
        {
            // ... et si cet objet a la balise de la porte...
            if (hitInfo.collider.tag == doorTag)
            {
                // ... obtenez une référence au script de la porte attaché à la porte...
                DoorScript doorScript = hitInfo.collider.GetComponent<DoorScript>();

                // ... vérifiez si l'utilisateur a appuyé sur la touche pour ouvrir ou fermer la porte...
                if (Input.GetKeyDown(openCloseKey))
                {
                    // ... et appelez la fonction appropriée du script de la porte pour ouvrir ou fermer la porte.
                    if (doorScript.isOpen)
                    {
                        doorScript.CloseDoor();
                    }
                    else
                    {
                        doorScript.OpenDoor();
                    }
                }

                // Mettez à jour le message à afficher à l'utilisateur en fonction de l'état de la porte
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
    