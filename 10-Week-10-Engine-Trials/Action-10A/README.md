# CS077 / 10A / Engine Trials

## recap
>We used GitHub to be able to save things instantly between members.
>JSON can be used as a way to save things.
>Slowly professor becomes more hands off.
>Read ahead to be prepared.
>Everything is familiar between game engines. 
>C# is used between many game engines.


## compare
1. Godot, 2D/3D, C#, download and install, https://godotengine.org/
2. Unity, 2D/3D, C#, download and install, https://unity.com/
3. Unreal Engine, C++, download and install, https://www.unrealengine.com/

## test
Unity 6.6
Sphere starting position: X: -1.23673, Y: 1.58, Z: 0.7
Increase Y position: X: -1.23673, Y: 2.58, Z: 0.7
Expected Result: The sphere will be higher up.
Observed Result: The sphere is higher up.

## explain
Unity 6.6
Sphere starting position: X: -1.23673, Y: 1.58, Z: 0.7
Increase Y position: X: -1.23673, Y: 2.58, Z: 0.7
Expected Result: The sphere will be higher up.
Observed Result: The sphere is higher up.

Question: I am comparing game engines for a beginner C# class. My tool and version are unity 6.6. My smallest test is increasing a sphere's y axis. Explain one relevant class/object/component relationship in plain language. Give an official documentation link. Mark any uncertain API names. I will check the link and compare the explanation with my test; do not generate a whole game.
Answer point: Every GameObject has a Transform component. It stores the object's position, rotation, and scale. Your test changes its position along the Y axis to move the sphere upward.
Link: https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Transform.html?utm_source=chatgpt.com


## Source and evidence
Tool/version: Unity
Editable trial: Trial/
Whiteboard + before/after evidence: Evidence/
Contribution:
Pascual: Receipt, readme, and whiteboard work.
Kevin: Whiteboard work.
Luisa: Whiteboard work.
Vinh: Whiteboard work.
Roman: Game test, AI prompt and whiteboard work.
Repository: (https://github.com/saines007/CS077-Fall-2026-Team/tree/main/10-Week-10-Engine-Trials/Action-10A)
Receipt: Evidence/CS077-10A-Receipt.txt
