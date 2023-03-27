Unity Junior Programmer Pathway Mid Project: Data Persistence
===========================================================================
Release v1.1  
by Reev the Chameleon

About
---------------------------------------------------------------------------
This project was a midway project for Unity [Junior Programmer Pathway on Unity Learn](https://learn.unity.com/pathway/junior-programmer),
which is part of my studying of how to make a game by Unity.  In fact,
I have finished it for quite a long time already, but as I learned more
about WebGL, I have come back and revise it a bit to improve user's experience
when playing on browser and also revise the repository.  
I would be happy if you enjoy playing it!

Please view and download the latest release of the game [here](https://github.com/ReevTheChameleon/DataPersistence_Public/releases/latest).  
Or play on WebGL at [Unity Play](https://play.unity.com/mg/other/webgl-builds-223466) or at [itch.io](https://reevthechameleon.itch.io/brickbreaker)

Note: Because the game was originally intended to be a Windows executable,
there is a quit button, but it does not do anything except freezing the game (for now).
You can just close or refresh your browser instead.

Project Error?
---------------------------------------------------------------------------
**Files in this repository represent only the portion of my project that can be
publicly exposed.**

While I have a fully functional project locally and would like to share it with you
in its entirety, I could not do so due to many complications. In short, you can view
most of the source code of the game here, but if you download the project and tries
to open in Unity Editor, it may not work.

Some of the aforemention complications are:

### Dependency
If you download this project and try to open it in Unity Editor, you would be
greeted with an error message box complaining about "Unity Package Manager Error"

This happens because the project uses code from my other package: UsefulScriptPackages v1.19.1,
which exists in my *another* repository, and I feel that it is redundant to duplicate
that entire repository here.

However, this is not very difficult to resolve:
1) Quit Unity first.
2) Go to my [Unity-Useful-Scripts repository](https://github.com/ReevTheChameleon/Unity-Useful-Scripts)
and download [Release v1.19.1](https://github.com/ReevTheChameleon/Unity-Useful-Scripts/releases/tag/v1.19.1) as zip file.
3) Unzip the downloaded package and make note of it location.
4) Open this project again. This time when the message box occurs, choose "Continue".
5) The next message box will appear, asking whether you want to Enter Safe Mode or not.
Choose "Enter Safe Mode".
6) Unity Editor will open in safe mode. Navigate to menu bar: Window -> Package Manager.
7) Click the small + button near the top-left of the Package Manager window
and Select "Add package from disk..."
8) Browse to the location of UsefulScripts Package you just downloaded,
then select "package.json" and click Open.

Unity should then install the package, recompile the scripts, then the error should go away
and you should be able to continue opening the project.

### Missing Assets
I use some third-party audios in this game. However, while being free,
most of them contain licenses or terms of use that prevent redistribution, and
from their point of view, exposing it raw in public git repository can be considered as such.
As a result, I have to exclude them from the repository.

Here are the list of assets that are included in the released game, but are
excluded from this repository. You can obtain them for free,
and view their corresponding licenses from the links below:

#### [Unity Asset Store](https://assetstore.unity.com/)
- Main Menu BGM: Floating in a Brick Bin - [Moody Tunes - LEGO® Microgame Add-ons (Unity Technologies Inc.)](https://assetstore.unity.com/packages/audio/music/moody-tunes-lego-microgame-add-ons-179856)
- Winning SFX: Pickup - Star* - [Danger Zone - LEGO® Microgame Add-ons (Unity Technologies Inc.)](https://assetstore.unity.com/packages/3d/danger-zone-lego-microgame-add-ons-179857)
- Main Gameplay BGM: cron_audio_8-bit_retro01 - [8-bit music free (Cron Audio)](https://assetstore.unity.com/packages/audio/music/electronic/8-bit-music-free-136967)
- Ball hitting Brick SFX: crash3* - [8-Bit Style Sound Effects (cabled_mess)](https://assetstore.unity.com/packages/audio/sound-fx/8-bit-style-sound-effects-68228)
- Pause SFX: jump1* - [8-Bit Style Sound Effects (cabled_mess)](https://assetstore.unity.com/packages/audio/sound-fx/8-bit-style-sound-effects-68228)

Note: crash3, Pickup - Star, and jump1 SFX was brought over from Unity [Junior Programming Unit 3 Lesson](https://learn.unity.com/project/unit-3-sound-and-effects).

About License
---------------------------------------------------------------------------
Unless specified in [THIRDPARTYNOTICE.md](THIRDPARTYNOTICE.md), the content in this project is licensed
under MIT license, one of the most permissive open source license there is!
In short, you can use content in here, both freely and commercially,
and can even modify it to your need, as long as you retain the copyright notice
and the permissive notice text found in [LICENSE.md](LICENSE.md) file.

However, I would also be happy if the code here can somehow help you write 
code that solve your specific problems while making game (making game is hard).
In that case, since you do not use the content here directly, you technically
do not need to give attribution, although a little comment would be
very appreciated.

Buy Me a Coffee
---------------------------------------------------------------------------
If you enjoy playing the game, 
or if you find the code here useful and want to support me,
you may want to "buy me a coffee" at:
 
[<img src="https://storage.ko-fi.com/cdn/brandasset/kofi_button_stroke.png" width="20%"/>](https://ko-fi.com/reevthechameleon)  
[ko-fi.com/reevthechameleon](https://ko-fi.com/reevthechameleon)

Note: Sometimes I may buy an iced-chocolate instead.
