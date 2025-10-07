using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.RuleTile.TilingRuleOutput;
using static UnityEngine.UI.Image;

public class InteractionWithObjects : MonoBehaviour
{
    private bool ObjectInRange = false;

    private ObjectGame objectGame;


    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("ObjectGame"))
    //    {
    //        ObjectInRange = true;
    //        objectGame = other.GetComponent<ObjectGame>();
    //    }
    //}

    //void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("ObjectGame"))
    //    {
    //        ObjectInRange = false;
    //        objectGame = null;
    //    }
    //}

    public void OnUse(InputAction.CallbackContext button)
    {
        if (button.performed)
        {
            Vector3 newforward = new Vector3(transform.forward.x, transform.forward.y + 0.3f, transform.forward.z);

            Ray ray = new Ray(transform.position, transform.forward);

            //return defaultPhysicsScene.Raycast(origin, direction, out hitInfo);
            if (Physics.Raycast(ray, out RaycastHit hit) == true)
            {
                if (hit.collider.CompareTag("ObjectGame"))
                {
                    objectGame = hit.collider.GetComponent<ObjectGame>();
                    Debug.DrawRay(transform.position, transform.forward, Color.red);
                    DropResource();
                    MineResource();
                }
            }
            else
            {
                Debug.Log("Из тебя явно не выйдет хороший стрелок...");
            }
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

            Vector3 spawnPosition = objectGame.transform.position + randomOffset;

            Instantiate(objectGame.resourceDrop, spawnPosition, Quaternion.Euler(270, 0, 0));
        }
    }
}
