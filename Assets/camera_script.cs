using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_script : MonoBehaviour {


	public GameObject player;
	public Texture2D[] arrowImages;

	private bool direct_control;

	Vector3 vel;
	Vector3 center;

	Vector3 targetPos;

	
	// Update is called once per frame
	void Update () {
		if(in_view(player)){
			Invoke("transfer_control",5);
		}

		if(edge_pan()){
			direct_control = true;
			CancelInvoke("transfer_control");
		}
		
		if(Input.GetKey(KeyCode.Space)){//HOTS didn't inspire me
			transfer_control();
		}

		if(!direct_control){
			center = Vector3.SmoothDamp(center, player.transform.position, ref vel, .25f, 40, Time.deltaTime);
			transform.position = center - transform.forward * 20;
		} else {
			center = Vector3.SmoothDamp(center, targetPos, ref vel, .4f, 15, Time.deltaTime);
			transform.position = center - transform.forward * 20;
		}


		
	}

	void transfer_control(){
		center = transform.position + transform.forward * 20;		
		vel = Vector3.zero;
		direct_control = false;
	}


	bool in_view(GameObject go){
		Vector3 vp = Camera.main.WorldToViewportPoint(go.transform.position);
		return 0 < vp.x && vp.x < 1 && 0 < vp.y && vp.y < 1;
	}

	bool edge_pan(){
		float m = .08f; //margin
		float cam_speed = 7;


		Vector3 mp = Input.mousePosition;
		mp.x /= Screen.width;
		mp.y /= Screen.height;
		if(mp.x > 1.1f || -.1f > mp.x || mp.y > 1.1f || -.1f > mp.y) return false;
		bool left = mp.x < m;
		bool right = (1-m) < mp.x;
		bool up = (1-m) < mp.y;
		bool down = mp.y < m;

		Cursor.SetCursor(null,Vector2.zero, CursorMode.Auto);

		/*if(left && up){

			Cursor.SetCursor(arrowImages[0],Vector2.zero,CursorMode.Auto);
			transform.position += Vector3.forward * Time.deltaTime * cam_speed;


		} else if (left && down){
			Cursor.SetCursor(arrowImages[1],Vector2.zero,CursorMode.Auto);
			transform.position += Vector3.left * Time.deltaTime * cam_speed;

		} else if(right && up){	

			Cursor.SetCursor(arrowImages[2],Vector2.zero,CursorMode.Auto);
			transform.position += Vector3.right * Time.deltaTime * cam_speed;


		} else if(right && down){
			Cursor.SetCursor(arrowImages[3],Vector2.zero,CursorMode.Auto);
			transform.position += Vector3.back * Time.deltaTime * cam_speed;


		} else if(left){
			Cursor.SetCursor(arrowImages[4],Vector2.zero,CursorMode.Auto);
			transform.position += Vector3.forward * Time.deltaTime * cam_speed;
			transform.position += Vector3.left * Time.deltaTime * cam_speed;


		} else if(right){
			Cursor.SetCursor(arrowImages[5],Vector2.zero,CursorMode.Auto);
			transform.position += Vector3.back * Time.deltaTime * cam_speed;
			transform.position += Vector3.right * Time.deltaTime * cam_speed;


		} else if(up){
			Cursor.SetCursor(arrowImages[6],Vector2.zero,CursorMode.Auto);
			transform.position += Vector3.forward * Time.deltaTime * cam_speed;
			transform.position += Vector3.right * Time.deltaTime * cam_speed;

		} else if(down) {
			Cursor.SetCursor(arrowImages[7],Vector2.zero,CursorMode.Auto);
			transform.position += Vector3.back * Time.deltaTime * cam_speed;
			transform.position += Vector3.left * Time.deltaTime * cam_speed;
		}*/
		targetPos = center;
		if(left && up){

			Cursor.SetCursor(arrowImages[0],Vector2.zero,CursorMode.Auto);
			targetPos += Vector3.forward * cam_speed;


		} else if (left && down){
			Cursor.SetCursor(arrowImages[1],Vector2.zero,CursorMode.Auto);
			targetPos += Vector3.left * cam_speed;

		} else if(right && up){	

			Cursor.SetCursor(arrowImages[2],Vector2.zero,CursorMode.Auto);
			targetPos += Vector3.right * cam_speed;


		} else if(right && down){
			Cursor.SetCursor(arrowImages[3],Vector2.zero,CursorMode.Auto);
			targetPos += Vector3.back * cam_speed;


		} else if(left){
			Cursor.SetCursor(arrowImages[4],Vector2.zero,CursorMode.Auto);
			targetPos += Vector3.forward * cam_speed;
			targetPos += Vector3.left * cam_speed;


		} else if(right){
			Cursor.SetCursor(arrowImages[5],Vector2.zero,CursorMode.Auto);
			targetPos += Vector3.back * cam_speed;
			targetPos += Vector3.right * cam_speed;


		} else if(up){
			Cursor.SetCursor(arrowImages[6],Vector2.zero,CursorMode.Auto);
			targetPos += Vector3.forward * cam_speed;
			targetPos += Vector3.right * cam_speed;

		} else if(down) {
			Cursor.SetCursor(arrowImages[7],Vector2.zero,CursorMode.Auto);
			targetPos += Vector3.back * cam_speed;
			targetPos += Vector3.left * cam_speed;
		}

		return (left || right || up || down);

	}
}
