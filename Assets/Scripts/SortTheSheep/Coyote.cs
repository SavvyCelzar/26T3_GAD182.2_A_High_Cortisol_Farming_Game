using System.Collections;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

namespace SAE.GAD182.Project2.SortTheSheep
{
    public class Coyote : MainSheepController
    {
        [SerializeField] private Transform[] sheepSortZones = new Transform[4];
        private Sprite[] coyoteSprites; // Array to store all possible coyote sprites
        private bool isSortedIncorrectly = false;

        #region Unity Functions (Start and Update)
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        protected override void Start()
        {
            base.Start();
        }

        // Update is called once per frame
        protected override void Update()
        {
            base.Update();
        }

        #endregion

        #region Polymorphed Functions
        protected override void AssignSceneObjects()
        {
            base.AssignSceneObjects();

            GameObject coyoteZone = GameObject.Find("Coyote Sort Zone");
            if(coyoteZone != null)
            {
                sortArea = coyoteZone.transform;
            }

            sheepSortZones[0] = GameObject.Find("BS Sort Zone")?.transform;
            sheepSortZones[1] = GameObject.Find("BR Sort Zone")?.transform;
            sheepSortZones[2] = GameObject.Find("WS Sort Zone")?.transform;
            sheepSortZones[3] = GameObject.Find("WR Sort Zone")?.transform;

        }

        protected override void OnMouseDown()
        {
            base.OnMouseDown();
        }
        protected override void OnMouseDrag()
        {
            base.OnMouseDrag();
        }
        protected override void OnMouseUp()
        {
            var closestSortZone = sheepSortZones.Where(sortZone => sortZone != null).OrderBy(sortZone => Vector2.Distance(transform.position, sortZone.position)).FirstOrDefault(); // Get the closest sheep sort zone 

            if (Vector2.Distance(transform.position, sortArea.position) <= 2f) // If the coyote is correctly sorted into the disposal chute
            {
                transform.position = sortArea.position;
                isSortedCorrectly = true;

                Destroy(gameObject);
            }
            else if(sheepSortZones.Any(sortZone => sortZone != null && Vector2.Distance(transform.position, closestSortZone.position) <= 5f)) // if the coyote is sorted into any of the sheep's pens
            {
                transform.position = closestSortZone.position;
                isSortedIncorrectly = true;

                OnSortingFailure();
            }
            else // if the coyote was dragged anywhere else in the scene.
            {
                transform.position = originalPosition;
            }

            transform.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;

        }
        #endregion

        #region Coyote Specific Functions
        private void OnSortingFailure()
        {
            // Display game over scene after an animation plays and all instances of sheep are despawned.
        }
        #endregion
    }
}
