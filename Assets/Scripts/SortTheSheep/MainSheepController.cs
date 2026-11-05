using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SAE.GAD182.Project2.SortTheSheep
{
    /// <summary>
    /// This script covers the drag and drop controls for the Sort The Sheep minigame. 
    /// It also acts as the parent script for the inheriting scripts for each of the different sheep types.
    /// </summary>
    public class MainSheepController : MonoBehaviour
    {
        #region Variables

        [SerializeField] protected Transform mouseCursor;
        [SerializeField] protected Transform sortArea;
        [SerializeField] protected Transform despawnArea;

        protected Vector2 originalPosition;
        protected bool isSortedCorrectly = false;
        protected bool isDragging = false;
        [SerializeField] protected float sheepMoveSpeed = 2f;

        #endregion

        #region Unity Functions (Start & Update)
        protected virtual void Start()
        {
            AssignSceneObjects();

            originalPosition = transform.position;
        }

        protected virtual void Update()
        {
            if (mouseCursor != null) 
            {
                if (isSortedCorrectly == true)
                {
                    transform.position = Vector2.MoveTowards(transform.position, despawnArea.position, sheepMoveSpeed * Time.deltaTime);
                }
            }
        }
        #endregion

        #region Functions

        protected virtual void AssignSceneObjects()
        {
            GameObject cursor = GameObject.Find("Cursor");
            if (cursor != null)
            {
                mouseCursor = cursor.transform;
            }           
        }

        protected virtual void OnMouseDown()
        {
           isDragging = true;
           Debug.Log("Being Dragged");
        }

        protected virtual void OnMouseDrag()
        {
            if (isDragging == true && isSortedCorrectly == false)
            {
                transform.position = mouseCursor.position;
                transform.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 5;
            }
        }

        protected virtual void OnMouseUp()
        {
            if (Vector2.Distance(transform.position, sortArea.position) <= 2f)
            {
                transform.position = sortArea.position;
                GetComponent<AnimalMovement>().enabled = false;

                isSortedCorrectly = true;

                StartCoroutine(DespawnSortedSheep());
            }
            else
            {
                transform.position = originalPosition;
            }

            transform.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
        }
        #endregion

        #region Despawn Sheep Coroutine
        protected IEnumerator DespawnSortedSheep()
        {
            while (isSortedCorrectly == true)
            {
                yield return new WaitForSeconds(5);

                Destroy(gameObject);
                isSortedCorrectly = false;

                yield return null;
            }
        }
        #endregion

    }
}
