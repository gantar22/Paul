using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof(Renderer))]
public class fade : MonoBehaviour {

	float alpha = 1;
	float tarA = 1;
	bool back = true;
	Color[] _colors;
	Renderer r;

	// Use this for initialization
	void Start () {
		r = GetComponent<Renderer>();
		_colors = new Color[r.materials.Length];
		for(int i = 0; i < _colors.Length; i++){
			_colors[i] = r.materials[i].color;
			r.materials[i].SetFloat("_Mode",3);
		}
		
	}
	
	// Update is called once per frame
	void Update () { //Optimize This!!!!!
		if(back) alpha = Mathf.Lerp(alpha,1,Time.deltaTime * 2f);
		else     alpha = Mathf.Lerp(alpha,.5f,Time.deltaTime * 5f);
		for(int i = 0; i < r.materials.Length; i++){
			if(alpha > .9f) {
				r.materials[i].SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                r.materials[i].SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                r.materials[i].SetInt("_ZWrite", 1);
                r.materials[i].DisableKeyword("_ALPHATEST_ON");
                r.materials[i].DisableKeyword("_ALPHABLEND_ON");
                r.materials[i].DisableKeyword("_ALPHAPREMULTIPLY_ON");
                r.materials[i].renderQueue = -1;
			}
			else {
				r.materials[i].SetFloat("_Mode", 2);
                r.materials[i].SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                r.materials[i].SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                r.materials[i].SetInt("_ZWrite", 0);
                r.materials[i].DisableKeyword("_ALPHATEST_ON");
                r.materials[i].EnableKeyword("_ALPHABLEND_ON");
                r.materials[i].DisableKeyword("_ALPHAPREMULTIPLY_ON");
                r.materials[i].renderQueue = 3000;
			}
			r.materials[i].color = new Color(_colors[i].r,_colors[i].g,_colors[i].b,alpha);
		}
		

	}


	public void fadeOut(){
		back = false;
		CancelInvoke("fadeBack");
		Invoke("fadeBack",.5f);
	}

	void fadeBack(){
		back = true;
	}
}
