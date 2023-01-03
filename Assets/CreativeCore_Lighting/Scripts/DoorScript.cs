using UnityEngine;


public class DoorScript : MonoBehaviour
{
    // L'état de la porte (ouverte ou fermée)
    public bool isOpen = false;

    // La vitesse à laquelle la porte s'ouvre et se ferme
    public float doorSpeed = 1.0f;

    // La position de la porte lorsqu'elle est ouverte
    public Vector3 openPosition;

    // La position de la porte lorsqu'elle est fermée
    public Vector3 closedPosition;

    void Update()
    {
        // Si la porte est ouverte et qu'elle n'a pas atteint sa position ouverte, déplacez-la vers sa position ouverte
        if (isOpen && transform.position != openPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, openPosition, doorSpeed * Time.deltaTime);
        }
        // Si la porte est fermée et qu'elle n'a pas atteint sa position fermée, déplacez-la vers sa position fermée
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
