using UnityEngine;
using System.Collections;

public class ChaseState : FSMState
{

	private Animator Anim;
	private float h = 0.0f;
	private float v = 0.0f;


    public ChaseState(Transform[] wp) 
    { 
        waypoints = wp;
        stateID = FSMStateID.Chasing;

        curRotSpeed = 1.0f;
        curSpeed = 5.0f;

        //find next Waypoint position
        FindNextPoint();
    }

    public override void Reason(Transform player, Transform npc)
    {
        //Set the target position as the player position
        destPos = player.position;

        //Check the distance with player tank
        //When the distance is near, transition to attack state
        float dist = Vector3.Distance(npc.position, destPos);
        if (dist <= 10.0f)
        {
            Debug.Log("Switch to Attack state");
            npc.GetComponent<NPCTankController>().SetTransition(Transition.ReachPlayer);
        }
        //Go back to patrol is it become too far
        else if (dist >= 20.0f)
        {
            Debug.Log("Switch to Patrol state");
            npc.GetComponent<NPCTankController>().SetTransition(Transition.LostPlayer);
        }
    }

    public override void Act(Transform player, Transform npc)
    {
        //Rotate to the target point
        destPos = player.position;

        Quaternion targetRotation = Quaternion.LookRotation(destPos - npc.position);
        npc.rotation = Quaternion.Slerp(npc.rotation, targetRotation, Time.deltaTime * curRotSpeed);

        //Go Forward
        npc.Translate(Vector3.forward * Time.deltaTime * curSpeed);


    }
}
