using UnityEngine;

public class InteractionTest : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Vasen hiiren klikkaus
        {
            if (Camera.main == null)
            {
                Debug.LogError("Camera.main is null! Varmista, että sinulla on kamera, jossa on 'MainCamera' tagi.");
                return;
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider == null)
                {
                    Debug.LogWarning("Raycast osui, mutta collider on null.");
                    return;
                }

                Interactable interactable = hit.collider.GetComponent<Interactable>();

                if (interactable != null)
                {
                    interactable.Interact(); // Kutsutaan kohteen Interact()-metodia
                }
                else
                {
                    Debug.LogWarning($"Ei löydetty Interactable-komponenttia kohteessa: {hit.collider.gameObject.name}");
                }
            }
            else
            {
                Debug.LogWarning("Raycast ei osunut mihinkään.");
            }
        }
    }
}
