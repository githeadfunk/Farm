using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour {

    [SerializeField] Tilemap groundTileMap;
    [SerializeField] Tilemap plantTileMap;
    [SerializeField] RuleTile plowedTile;
    [SerializeField] Tile seed;

    float playerWalkSpeed = 20f;
    private SpriteRenderer mySpriteRenderer;
    private Animator myAnimator;
    private Grid grid;

    // Use this for initialization
    void Start () {
        myAnimator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        grid = groundTileMap.GetComponentInParent<Grid>();
    }
	
	// Update is called once per frame
	void Update () {
        Move();
        Fight();
        Plow();
        Plant();

    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.UpArrow)) {
            myAnimator.SetBool("isWalkingUp", true);
            transform.Translate(Vector3.up * Time.deltaTime);
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            myAnimator.SetBool("isWalkingUp", false);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            myAnimator.SetBool("isWalkingDown", true);
            transform.Translate(Vector3.down * Time.deltaTime);
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            myAnimator.SetBool("isWalkingDown", false);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myAnimator.SetBool("isWalkingLeft", true);
            transform.Translate(Vector3.left * Time.deltaTime);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            myAnimator.SetBool("isWalkingLeft", false);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            myAnimator.SetBool("isWalkingRight", true);
            transform.Translate(Vector3.right * Time.deltaTime);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            myAnimator.SetBool("isWalkingRight", false);
        }

        //var tilePos = grid.WorldToCell(transform.position);
        //TileBase tile = map.GetTile(tilePos);
        //tile.

    }

    private void Fight() {
        if (Input.GetKeyDown(KeyCode.LeftControl) && myAnimator.GetBool("isWalkingDown")) {
            myAnimator.SetTrigger("Fight Down");
        }
        if (Input.GetKeyDown(KeyCode.LeftControl) && myAnimator.GetBool("isWalkingLeft"))
        {
            myAnimator.SetTrigger("Fight Left");
        }
    }

    private void Plow() {
        if(Input.GetKeyDown(KeyCode.P)){
            var tilePos = grid.WorldToCell(transform.position);
            groundTileMap.SetTile(tilePos, plowedTile);
        }
    }

    private void Plant() {
        if (Input.GetKeyDown(KeyCode.O))
        {
            var tilePos = grid.WorldToCell(transform.position);
            plantTileMap.SetTile(tilePos, seed);
        }
    }
}
