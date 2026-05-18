using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionWithObjects : MonoBehaviour
{


    private ObjectGame objectGame;

    [SerializeField] private Hero hero;

    [SerializeField] private DriveBox drivebox;

    private DriveBox currentCar;

    private bool isInCar = false;

    public void OnUse(InputAction.CallbackContext button)
    {
        if (button.performed)
        {
            if (isInCar && Time.timeScale == 1f) 
            {
                ExitCar();
                return;
            }

            Vector3 newforward = new Vector3(transform.forward.x, transform.forward.y + 0.3f, transform.forward.z);

            Ray ray = new Ray(transform.position, transform.forward);

            if (Physics.Raycast(ray, out RaycastHit hit, 1, 1, QueryTriggerInteraction.Ignore) && Time.timeScale == 1f)
                {
                if (hit.collider.CompareTag("StoneTag") || hit.collider.CompareTag("TreeTag") || hit.collider.CompareTag("IronTag") || hit.collider.CompareTag("CrystalTag"))
                {
                    objectGame = hit.collider.GetComponent<ObjectGame>();
                    DropResource();
                    MineResource();
                }
                if (hit.collider.CompareTag("Car"))
                {
                    hero = gameObject.GetComponent<Hero>();

                    currentCar = hit.collider.GetComponentInParent<DriveBox>();

                    hero.transform.SetParent(currentCar.seatPoint);
                    hero.transform.localPosition = Vector3.zero;
                    hero.transform.localRotation = Quaternion.identity;

                    currentCar.TryGoCar(hero);

                    hero.GetComponent<HeroMover>().enabled = false;
                    hero.GetComponent<HeroRotator>().enabled = false;
                    hero.GetComponentInChildren<Camera>().enabled = false;

                    hero.GetComponent<Rigidbody>().isKinematic = true;
                    hero.GetComponent<Collider>().enabled = false;

                    isInCar = true;

                }
                if (hit.collider.CompareTag("Tower"))
                {
                    TowerFire tower = hit.collider.GetComponent<TowerFire>();
                    if (tower != null && tower.towerItem != null)
                    {
                        if (hero.inventory.AddToInventory(tower.towerItem))
                        {
                            Destroy(tower.gameObject);
                        }
                        else
                        {
                            Debug.Log("Нет места в инвентаре, нельзя поднять башню");
                        }
                    }
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
        //Debug.Log($"Добыча {objectGame.resourceName} {objectGame.currentHits}/{objectGame.hitsToBreak}");

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
                0.2f,
                Random.Range(-0.7f, 0.7f)
            );

            Vector3 spawnPosition = objectGame.transform.position + randomOffset;

            Instantiate(objectGame.resourceDrop, spawnPosition, Quaternion.Euler(270, 0, 0));
        }
    }

    void ExitCar()
    {
        Vector3 exitPos = currentCar.transform.position + currentCar.transform.up * 1.5f;

        hero.transform.SetParent(null);
        hero.transform.position = exitPos;

        hero.GetComponent<HeroMover>().enabled = true;
        hero.GetComponent<HeroRotator>().enabled = true;
        hero.GetComponentInChildren<Camera>().enabled = true;

        hero.GetComponent<Rigidbody>().isKinematic = false;
        hero.GetComponent<Collider>().enabled = true;

        currentCar.RemoveDriver();

        currentCar = null;
        isInCar = false;
    }
}
