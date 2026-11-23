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
        protected bool amIBeingDragged = false; // Checks if the object tied to the script is being dragged
        [SerializeField] protected float sheepMoveSpeed = 2f;
        public SpriteRenderer sheepSpriteRenderer;

        [SerializeField] protected AudioClip[] animalSounds;
        protected AudioSource animalSoundSource;

        protected AudioSource correctSortSFX;

        protected static bool anyObjectBeingDragged = false;

        #endregion

        #region Unity Functions (Start & Update)
        protected virtual void Start()
        {
            AssignSceneObjects();

            originalPosition = transform.position;
            PlayRandomAnimalSound();
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

            sheepSpriteRenderer = GetComponent<SpriteRenderer>();

            animalSoundSource = GetComponent<AudioSource>();
            correctSortSFX = GameObject.Find("CorrectSheepSortSound").GetComponent<AudioSource>();
        }

        protected virtual void OnMouseDown()
        {
           if(anyObjectBeingDragged) return;

           anyObjectBeingDragged = true;
           amIBeingDragged = true;

           Debug.Log("Being Dragged");
        }

        protected virtual void OnMouseDrag()
        {
            if (!amIBeingDragged) return; // Only attach to mouse and move around IF this was the first object clicked on.

            if (amIBeingDragged == true && isSortedCorrectly == false)
            {
                transform.position = mouseCursor.position;
                transform.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 10;
            }
        }

        protected virtual void OnMouseUp()
        {
            if (!amIBeingDragged) return;
            
                amIBeingDragged = false;
                anyObjectBeingDragged = false;
                

            if (Vector2.Distance(transform.position, sortArea.position) <= 2f)
            {
                transform.position = sortArea.position;
                GetComponent<AnimalMovement>().enabled = false;

                isSortedCorrectly = true;
                PlayRandomAnimalSound();
                correctSortSFX.Play();

                StartCoroutine(DespawnSortedSheep());
            }
            else
            {
                transform.position = originalPosition;
            }

            transform.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 5;
        }

        protected void PlayRandomAnimalSound()
        {
            if (animalSounds.Length == 0) return;

            int randomTrack = Random.Range(0, animalSounds.Length);
            animalSoundSource.PlayOneShot(animalSounds[randomTrack]);
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
