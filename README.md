# Doofus Adventure

Doofus Adventure is a 3D platform survival game where you guide Doofus across disappearing pulpits while trying to score as high as possible. Each pulpit exists only for a short time and a new one spawns adjacent to the previous one. If the player falls, the game ends and the game over screen appears.

---

## Gameplay Preview 🎮

<video src="https://github.com/user-attachments/assets/b89cec7b-0880-4541-bee3-34728daed6b3" width="300" height="150" controls>
</video>
<img width="691" height="300" alt="image" src="https://github.com/user-attachments/assets/3dab90ae-8419-4ae8-9367-8804ece40749" />
<img width="691" height="300" alt="image" src="https://github.com/user-attachments/assets/1328fe57-375c-4fc6-9df1-05f50adc4893" />
<img width="691" height="300" alt="image" src="https://github.com/user-attachments/assets/036c4e5c-2bba-4dc6-b670-c67bc5323e38" />

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
