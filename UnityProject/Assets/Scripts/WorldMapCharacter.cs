using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMapCharacter : MonoBehaviour
{

    // the target level that this character 
    // is moving too, or is currenly located at
    public WorldMapLevel target;
    // how long the movement from level to level is
    public float lerpDuration;

    // variables for smooth movement
    private Vector3 lerpStartPosition;
    private Vector3 lerpEndPosition;
    private float lerpTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if the character is at their target
        // and the player clicks a backoround object
        if (transform.position == target.transform.position && Input.GetMouseButtonDown(0)) {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            WorldMapLevel level = GameUtils.GetComponentAt<WorldMapLevel>(mousePos, "Background");
            // if they clicked a level they cant travel too, move there 
            if (level != null && CanTravelHere(level)) {
                target = level;
                setUpLerpMovement();
            }
        }  

        // if the character is not at their target level, smoothly 
        // move towards the target
        if (transform.position != target.transform.position) {
            if (lerpTimer < lerpDuration) {
                float t = lerpTimer / lerpDuration;
                t = t * t * (3f - 2f * t);
                transform.position = Vector3.Lerp(lerpStartPosition, lerpEndPosition, t);
                lerpTimer += Time.deltaTime;
            } else {
                transform.position = target.transform.position;
            }
        }
    }

    // returns true if the character can travel to the given level
    bool CanTravelHere(WorldMapLevel newTarget) {
        return newTarget.levelNumber > target.levelNumber && target.isAdjacentTo(newTarget);
    }

    // sets up the variables needed for smooth movement
    void setUpLerpMovement() {
        lerpStartPosition = transform.position;
        lerpEndPosition = target.transform.position;
        lerpTimer = 0;
    }
}
