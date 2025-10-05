using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionWithObjects : MonoBehaviour
{
    private bool ObjectInRange = false;

    ObjectGame objectGame;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ObjectGame"))
        {
            ObjectInRange = true;
            objectGame = other.GetComponent<ObjectGame>();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ObjectGame"))
        {
            ObjectInRange = false;
            objectGame = null;
        }
    }

    public void OnUse(InputAction.CallbackContext button)
    {
        if (button.performed)
        {
            if (ObjectInRange == true)
            {
                MineResource();
                DropResource();
            }
            else Debug.Log("Объект не найден");
        }
    }

    void MineResource()
    {
        objectGame.currentHits++;
        Debug.Log($"Добыча {objectGame.resourceName} {objectGame.currentHits}/{objectGame.hitsToBreak}");

        if (objectGame.currentHits >= objectGame.hitsToBreak)
        {
            Destroy(objectGame.gameObject);
            objectGame = null;
        }
    }

    void DropResource()
    {
        for (int i = 0; i < objectGame.dropAmount; i++)
        {
            Vector3 randomOffset = new Vector3(
                Random.Range(-0.7f, 0.7f),
                0.5f,
                Random.Range(-0.7f, 0.7f)
            );

            Vector3 spawnPosition = transform.position + randomOffset;

            Instantiate(objectGame.resourceDrop, spawnPosition, Quaternion.Euler(270, 0, 0));
        }
    }
}
