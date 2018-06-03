using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Movement : NetworkBehaviour {

    public GameObject basicBlock;

	// Update is called once per frame
	void Update ()
	{
		if (!isLocalPlayer)
		{
		    // exit from update if this is not the local player
		    return;
		}
		//Basic Movement
		if (Input.GetKey(KeyCode.W))
		{
			transform.Translate(Vector3.forward * Time.deltaTime, Space.World);
		}
		if (Input.GetKey(KeyCode.S))
		{
			transform.Translate(-Vector3.forward * Time.deltaTime, Space.World);
		}
		if (Input.GetKey(KeyCode.A))
		{
			transform.Translate(Vector3.left * Time.deltaTime, Space.World);
		}
		if (Input.GetKey(KeyCode.D))
		{
			transform.Translate(Vector3.right * Time.deltaTime, Space.World);
		}
        //Block Placement
		if (Input.GetKeyDown(KeyCode.Space))
		{
            CmdFire();
		}
	}
   
    [Command]
    void CmdFire ()
    {
        GameObject bullet = Instantiate(basicBlock, transform.position + new Vector3(0, 0, 1), transform.rotation);
        NetworkServer.Spawn(bullet);
    }
    
}
