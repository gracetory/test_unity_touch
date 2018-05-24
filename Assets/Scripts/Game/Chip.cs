using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Chip : MonoBehaviour
{
	sbyte _image_type;
	string[] _image_name = {"chip_0", "chip_1"};

	/**
	 * 初期化
	 *
	 * @access public
	 * @param void
	 * @return void
	 */
	public void init()
	{
		// 画像番号
		this._image_type = 0;

		// 画像設定
		SpriteAtlas chip_atlas = Resources.Load<SpriteAtlas>("Sprites/Atlas/Chip");
		this.GetComponent<SpriteRenderer>().sprite = chip_atlas.GetSprite(this._image_name[this._image_type]);

		// ソート順
		this.GetComponent<SpriteRenderer>().sortingOrder = 1;

		// タッチ判定サイズ
		this.GetComponent<BoxCollider2D>().size = this.GetComponent<SpriteRenderer>().size;
	}

	/**
	 * タッチ処理
	 *
	 * @access public
	 * @return void
	 */
	public void touch()
	{
		// チップ画像の反転
		this._image_type ^= 1;

		// 画像切り替え
		this.changeAtlas(_image_name[this._image_type]);
	}

	/**
	 * 画像切り替え
	 *
	 * @access private
	 * @return void
	 */
	public void changeAtlas(string file_name) {
		// 画像設定
		SpriteAtlas chip_atlas = Resources.Load<SpriteAtlas>("Sprites/Atlas/Chip");
		this.GetComponent<SpriteRenderer>().sprite = chip_atlas.GetSprite(file_name);
	}
}
