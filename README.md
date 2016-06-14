# UnityCameraLesson
## 概要
- UnityのCameraの基本的な使い方について記載する

```
- Cameraはプレイヤーへのゲームの見せ方
- Cameraコンポーネントの設定に注意 (特にProjection)
- Cameraの演出を工夫すると「おっ」と思うゲームが出来る
```

## Camraとはなんぞや
- プレイヤーへ実際にどのように見せるかはCameraによって決まる
- 被写体への距離/画面効果などをこのConponentによって調整可能

## Cameraの作り方
- 基本的にはScene作成時にMainCameraというゲームオブジェクトが作成される
- 消してしまった場合やSubCamera(後述)を作成したい場合には以下の手順を踏む

```
[Hierarchy] => [Create] => [Camera]
```

## CameraComponent
- マニュアル/リファレンス
  - http://docs.unity3d.com/ja/current/Manual/class-Camera.html
  - http://docs.unity3d.com/jp/current/ScriptReference/Camera.html

### ClearFlag
- カメラで描画されるゲーム画面はフレーム毎にClearFlagの設定に基づいてクリアされる
- 背景描画、および複数のカメラを重ね合わせる際に使用する
  - Skybox: 空の背景画像によるクリア
  - Solid Color: 単色によるクリア
  - Depth only: Depth値のみクリア
    - 複数のカメラの画像を合成する場合、前面のカメラについてはこの値を指定する
  - Don't clear: 前フレームの描画内容がクリアされずに残り続ける
- SkyBoxは特に使用目的が無ければ避けよう
  - http://screenpocket.hateblo.jp/entry/2015/09/05/025030

### Background
- 主にSolid Color時に設定する背景色

### Culling Mask
- 描画するレイヤーを制御する
- 特定のレイヤーだけ描画するCameraの作成も可能
  - e.g) UIだけを描画する / 背景だけを描画して、エフェクトを掛ける / サブカメラ

### Projection
- Cameraの投影方法の指定
  - Perspective (透視投影): 遠近感のある描画  (主に3Dゲームに使用)
  - Orthographic (平行投影/正投影): 遠近感のない描画 (主に2Dゲームに使用)

### Field of view/Size
- Field of view (視野角)
  - Perspective時のみ設定可能
  - 正面から上下左右にどれだけずれた角度から見ても正常に映る角度(度単位)
  - http://udasankoubou.blogspot.jp/2014/02/unity.html
- Size
  - Orthographic時のみ指定可能
  - スクリーンの縦半分に何Unit入るか
  - Spriteの場合、PixelsToUnits も合わせて調整する必要がある
    - http://albatrus.com/main/unity/7468
  - dot by dot (1pixelをディスプレイの1dotに適応)する場合
    - http://naochang.me/?p=191

### ClippingPlanes
- カメラの描画奥行きの領域
  - 近い物を移さない時は Near 値を変更する
  - 遠い物を移さない時は Far 値を変更する
- 3Dゲームを作る時には負荷を考慮する関係でFar値を減らすアプローチを取る事がある

### ViewportRect
- カメラ自体の大きさと配置を設定する
  -  マリオカートの複数人プレイみたいな画面分割
  - 小さい地図を右下に表示
- 基本的には 0〜1 の範囲で指定する

### Depth
- カメラの深度 (描画順序) を設定する

### RenderingPath
- http://docs.unity3d.com/ja/current/Manual/RenderingPaths.html
- レンダリング方法
  - ライトや影の見え方、およびパフォーマンスに影響する
- defaultでは各プラットフォーム毎の設定を参照している
  - `[Edit] > [Project Settings] > [Player]`
- モバイルアプリに関しては Forward Rendering で良さそう

### TargetTexture
- カメラの描画を画面ではなく特定のオブジェクトに描画する時に使用する
  - テレビの3Dオブジェクトの画面にゲームを映したりするとき

### OcculusionCulling
- http://tsubakit1.hateblo.jp/entry/2015/04/22/235923
- カメラの描画に映らない部分を描画しない機能
  - 背後や他のオブジェクトに書かれている部分
- 使用方法によっては DrawCall 数が減少してパフォーマンス向上につながる

### HDR (High Dynamic Range)
- http://docs.unity3d.com/ja/current/Manual/HDR.html
- ダイナミックレンジを幅広くする撮影技術

### TargetDisplay
- 複数のDisplayに描画する時に使用する
  - マルチプレイ
  - 最近はVR用のCameraと観客にどのように見えているか見せるCameraへの割り当て

## Cameraを使った演出
### SampleProject
- FIXME

### SubCamera
- アクション/レースゲームの右下に表示される俯瞰図
- 特定の形へのくり抜きの実装はステンシルバッファを使用する
  - http://tsubakit1.hateblo.jp/entry/2015/11/22/065743

### ImageEffect (ポストエフェクト)
- 画面に対して様々な演出を追加する
- UnityではStanderdAssetを使用する事で様々なImageEffectの使用が可能
  - `[Assets] > [ImportPackage] > [Effects]` よりインポート
  - 下記にあるスクリプトを Camera がアタッチされている GameObject にアタッチ
    - `[StanderdAssets] > [ImageEffects] > [Scripts]`
  - 効果: http://kikikiroku.session.jp/unity-5-imageeffect-check/ 
- 独自にスクリプトを組む事で自作も可能
  - http://fspace.hatenablog.com/entry/2015/08/11/185815

### CameraShake
- ダメージエフェクト等のFB演出に使用
- CameraComponentがアタッチされているGameObject自体を揺らす事で実現可能
- Tween系のアセットを使えば実装が楽

## 参考
- http://www.wisdomsoft.jp/643.html
- http://d.hatena.ne.jp/nakamura001/20120706/1341589197
- http://tsubakit1.hateblo.jp/entry/2016/02/17/003047

## Lisence
<div><img src="http://unity-chan.com/images/imageLicenseLogo.png" alt="ユニティちゃんライセンス"><p>この作品は<a href="http://unity-chan.com/contents/license_jp/" target="_blank">ユニティちゃんライセンス条項</a>の元に提供されています</p></div>
