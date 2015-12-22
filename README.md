# XxDragonslayersxX
<b>December 9, 2015</b>"Sometimes there will be problems with scenes, where you make a scene change and those files are really convoluted and hard to tell what changed.

But you don't wanna get these conflicts where somebody made a scene change and sombody else did a scene change and they don't combind together and it's a mess. So somebody's changes are gonna be thrown out, and you will have to redo."

Jobba <b><i>INTE</i></b> i samma scen! ok? ok.

----------------

funkar inte pac skriptet på pacman, byt det till sphere skriptet eller ngt lmaO....

<b>i unity:</b>

objekt som <i>ska</i> användas ligger i <b>prefab-mappen</b> i <i>asset</i>

markera ett objekt & tryck på <i>v</i> för att vertexsnappa ihop väggarna
ctrl + d = duplicera

ändrar man ett material måste man <b><i>duplicera</b></i> det, annars ändras <i>alla</i> objekt som har det materialet

<b>när banan är färdig:</b> skapa ett empty gameobject (namnge det också) & lägg in allt i hierarchy i det. (lägg det prefab:et i mappen Levels under Prefabs också) man <i>borde</i> kunna jobba i scener (asset -> scenes -> levels) direkt i mastern utan att det blir några problem (så länge de inte heter samma/är samma scen), men ha ett säkerhetsprefab också.

exportera prefaben genom att högerklicka & välj export package

<b>navmesh</b>: i unity, markera ett objekt, tryck på <i>navigation</i> bredvid <i>inspector</i>, tryck på bake och sedan bake igen i nedre högra hörnet. markerar den inte alla gångytor: byt agent radius

vid banbygge kan man göra en fjärdedel/halva banan, sedan lägga alla delar i ett empty gameobject & copypaste det(duplicera) & bara ändra rotationen på den för att få en hel bana.

----------------

<b>skript - objekt</b>

BonusPointSpawn - PacManUpToDate

CollisionEvents -

CollisionEventsWithPoints - PacManUpToDate

Detect - PacManUpToDate -> Detectors

DisplayHighscore - <i>(GameOver scene)</i> Highscore, <i>(WinScreen)</i> Highscore

<strike>DisplayScore - <i>(GameOver scene)</i> ScoreText, <i>(WinScreen)</i> ScoreText</strike> (se DisplayHighscore)

Exit - PacManUpToDate -> Main Camera

Flicker - Lights -> Fire_Flickeringlight

GameOver - <i>(Scene: GameOver)</i> GameOver

GhostAI - GhostYY

LifeCounter - ScoreCounter -> tex_life

LoadStart - <i>(LoadStart scene)</i> Main Camera

PacManControl - PacManUpToDate

RotatinCoins - mod_coin

RotationDiamonds - mod_stone

StartScreen - <i>(StartScreen scene)</i> StartScreen

StatsManager - <i>(LoadStart scene)</i> _statsManager

<strike>StatsReset - <i>(StartScreen scene)</i> StatsReset</strike> (Se StartScreen)

Teleportation - mod_wall_gate

TimeDisplay - gameTime

WinScreen - <i>(WinScreen)</i> WinScreen
