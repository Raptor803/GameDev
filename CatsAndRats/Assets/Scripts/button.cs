using UnityEngine;

/*  idea bottone
*   un bottone deve sbloccare qualcosa
*   Tutto quello che può interagire con un bottone deve implementare l'interfaccia IAction
*/
[AddComponentMenu("Interactable/Button")]
public class button : MonoBehaviour
{
    [SerializeField] public MonoBehaviour smtg;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private IAction iAction;
    private bool isPlayerInside = false;

    void Start()
    {
        iAction = smtg as IAction;

        if (smtg == null)
        {
            Debug.LogError("non posso usare questo oggetto per interagire perchè non implementa l'interfaccia IAction");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInside && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("hai premuto");
            pressButton();
        }
        
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("puoi premere");
        if (other.CompareTag("cat")) // Controlla se è il giocatore
        {
            isPlayerInside = true; 
        }
    }

     void OnTriggerExit(Collider other)
    {
        Debug.Log("ora non più");
        if (other.CompareTag("cat")) 
        {
            isPlayerInside = false; 
        }
    }

    public void pressButton(){
        iAction?.action();
    }
}