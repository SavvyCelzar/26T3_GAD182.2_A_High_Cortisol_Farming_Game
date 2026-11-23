using UnityEngine;
using UnityEngine.InputSystem;

namespace SAE.GAD182.Project2.SortTheSheep
{
    /// <summary>   
    /// This script tracks a custom sprite image to the cursor with intent of stylising the cursor visuals appropriately with the game's visual style.
    /// </summary>
    public class CustomCursor : MonoBehaviour
    {
        [SerializeField] private Texture2D hoverCursor;
        [SerializeField] private Texture2D clickCursor;

        private Vector2 cursorOffset = Vector2.zero;

        #region Cursor Code

        private void Start()
        {
            Cursor.SetCursor(hoverCursor, cursorOffset, CursorMode.Auto);
        }

        private void Update()
        {
            Vector3 mousePosition;

            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;

            transform.position = mousePosition;

            if (Input.GetMouseButtonDown(0))
            {
                Cursor.SetCursor(clickCursor, cursorOffset, CursorMode.Auto);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                Cursor.SetCursor(hoverCursor, cursorOffset, CursorMode.Auto);
            }
        }

        #endregion
    }
}

