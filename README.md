# Doofus Adventure

Doofus Adventure is a 3D platform survival game where you guide Doofus across disappearing pulpits while trying to score as high as possible. Each pulpit exists only for a short time and a new one spawns adjacent to the previous one. If the player falls, the game ends and the game over screen appears.

---

## Gameplay Preview 🎮

<img width="1919" height="833" alt="image" src="https://github.com/user-attachments/assets/3dab90ae-8419-4ae8-9367-8804ece40749" />
<img width="1919" height="828" alt="image" src="https://github.com/user-attachments/assets/42069b37-52a3-4dec-8395-201bf7fce715" />
<img width="1919" height="833" alt="image" src="https://github.com/user-attachments/assets/81e566e4-388e-41ff-9dde-9561b139bc24" />
<img width="1919" height="824" alt="image" src="https://github.com/user-attachments/assets/45f207fc-d56d-417c-9072-3d91d3d1a1e0" />

---

## Game Rules 📋

### Objective
Stay alive by moving onto new pulpits before they disappear.

### Core Rules
- Only two pulpits can exist at any time
- Each pulpit has a random lifetime
- A new pulpit spawns when the time for the previous one reaches the spawn threshold
- Score increases when the player steps onto a new pulpit
- Falling results in game over and the game over scene appears
- High score is tracked across attempts

---

## How to Play ✅

### Controls
- Move using W A S D keys or arrow keys
- The character moves using Third Person Starter Assets controller
- Try to reach as many pulpits as possible
- Do not fall off the platform
- Click Retry to play again
- 
---

## Project Structure 🧱

```text
Assets/
├── Scripts/
│   ├── Core/
│   │   ├── CameraFollow
│   │   ├── ConfigLoader
│   │   ├── GameOverScoreDisplay
│   │   ├── MainMenu
│   │   ├── ScoreManager
│   │   ├── ScoreStorage
│   │   ├── GameOverMenu
│   │   └── GameOverHandler
│   ├── Data/
│       └── DoofusConfig
│   ├── Player/
│   │   ├── PlayerSpawnSetter
│   │   ├── PlayerSpeedSetter
│   │   └── PlayerPulpitDetector
│   └── Pulpits/
│       ├── PulpitManager
│       └── PulpitDissolve
├── Prefabs/
│   └── PulpitTemplate
├── Scenes/
│   ├── StartScene
│   ├── MainScene
│   └── GameOverScene
├── Animations/
├── Sprites/
│   ├── Materials
│   └── UI
├── StarterAssets/
└── UI/
```

### Key Systems
- Dynamic config loading from API using UnityWebRequest
- Scoring and high score management
- Scene based flow management
- Custom pulpit spawning and destruction timing
- Pulpit dissolve effect with voxel style breakup
- Character controller based movement using Starter Assets
- Minecraft inspired art style and UI

---

## Levels Implemented 🚀

### Level 1
- Player movement
- Platform spawning logic based on config JSON
- Config read from API

### Level 2
- Score updates when stepping onto a new pulpit
- High score tracking

### Level 3
- Start Scene
- Game Over Scene
- Retry and Play button flow
- Improved visuals and character

---

## Running the Project 🛠️

### Requirements
- Unity version 6 or newer
- Windows recommended

### Steps
1. Clone the repository
2. Open Unity Hub
3. Add the project folder
4. Open the project in Unity 6
5. Open the StartScene
6. Press Play to begin

Optionally
- Replace the API URL in ConfigLoader with your own endpoint

---

## About the Developer 👤

<b>Tashadur Rahman</b>, B Tech CSE, VIT 

Project submitted for  
HitWicket Game Developer Assignment 2025  
