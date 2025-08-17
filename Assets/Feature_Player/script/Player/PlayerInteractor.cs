using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    [SerializeField]
    private LayerMask checkpointLayerMask;

    [SerializeField] 
    private UIManager uiManager;

    private int checkpointOverlapCount = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && checkpointOverlapCount > 0)
        {
            uiManager.OpenCheckPointUI();    
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (IsInLayerMask(other.gameObject.layer, checkpointLayerMask))
        {
            checkpointOverlapCount++;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (IsInLayerMask(other.gameObject.layer, checkpointLayerMask))
        {
            checkpointOverlapCount = Mathf.Max(0, checkpointOverlapCount - 1);
        }
    }

    private bool IsInLayerMask(int layer, LayerMask mask)
    {
        return (mask.value & (1 << layer)) != 0;
    }
}
