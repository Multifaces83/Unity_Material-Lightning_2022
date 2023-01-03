using UnityEngine;


public class DoorScript : MonoBehaviour
{
    // L'�tat de la porte (ouverte ou ferm�e)
    public bool isOpen = false;

    // La vitesse � laquelle la porte s'ouvre et se ferme
    public float doorSpeed = 1.0f;

    // La position de la porte lorsqu'elle est ouverte
    public Vector3 openPosition;

    // La position de la porte lorsqu'elle est ferm�e
    public Vector3 closedPosition;

    void Update()
    {
        // Si la porte est ouverte et qu'elle n'a pas atteint sa position ouverte, d�placez-la vers sa position ouverte
        if (isOpen && transform.position != openPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, openPosition, doorSpeed * Time.deltaTime);
        }
        // Si la porte est ferm�e et qu'elle n'a pas atteint sa position ferm�e, d�placez-la vers sa position ferm�e
        else if (!isOpen && transform.position != closedPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, closedPosition, doorSpeed * Time.deltaTime);
        }
    }

    // Fonction pour ouvrir la porte
    public void OpenDoor()
    {
        isOpen = true;
    }

    // Fonction pour fermer la porte
    public void CloseDoor()
    {
        isOpen = false;
    }
}
