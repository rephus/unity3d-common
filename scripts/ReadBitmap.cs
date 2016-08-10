using UnityEngine;
using System.Collections;
 using UnityEditor;

/**
Read a bitmap from a texture and do some conversions (eg: build a scenario)

The image must be provided as argument bitmap, and needs to be in write mode 
To do so, selec the image in UnityEditor, change from Texture to Advanced, and enable read/write
**/
public class ReadBitmap : MonoBehaviour {
	

	public Texture2D bitmap ;

	void CreatePlatform(int x, int y, Color color) {
		GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube.GetComponent<Renderer>().material.color = color;
		cube.transform.position = new Vector3(x, y, 0);
	}

	void ParseColor(Color color, int x, int y){

		/*if (color == Color.black) CreatePlatform(x,y);
		else if (color == Color.white) {}
		else Debug.Log("Unrecognized color at position "+x+"x"+y+": " + 	color); 
*/
		if (color == Color.white) {}
		else  CreatePlatform(x,y, color);

	}

	// DO not modify this method, all actions regarding colors must be done in ParseColors
	void Start () {
		Rect r = new Rect(0,0,bitmap.width,bitmap.height);
		bitmap.ReadPixels(r,0,0);
		for(int x=0; x < bitmap.width; x ++) {
			for(int y=0; y < bitmap.width; y ++) {
				Color color = bitmap.GetPixel(x,y);
				ParseColor(color, x, y);
			}
		}
	}
}
