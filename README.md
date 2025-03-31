# 3D Pac-Man Style Game - UI System and Health System Development Documentation 🎮

## 1. Project Overview 🌟

This project is a **3D version of a Pac-Man style chase game** 🏃‍♂️👻. This documentation details the design and implementation process of the UI system and health system, including menu systems, pause functionality, game over interface, and player health management mechanisms. Through carefully designed user interfaces and health systems, we provide players with a smooth and intuitive gaming experience.

## 2. Implemented Features✨
> ### _**Iverson Yuan**_

## 2.1 Demonstration Video 🎬

[Insert game demonstration video link here]

The video demonstrates the following features:
- Main Game Scene Contruction
- Main menu interface and opening animation 🏠
- Game introduction screen information display 📖
- In-game health UI display ❤️
- Damage handling from enemy collisions 💥
- Pause menu usage ⏸️
- Game over interface and options 🏁

### 2.2 Main Scnee Construction
Add Main Scene Construction Pics and Videos Here

### 2.3 UI System 📱
- **Main Menu Interface** 🏠: Entry point of the game, featuring an elegant opening animation
- **Game Introduction Screen** 📖: Displays game background story and operation guidelines
- **Pause Menu System** ⏸️: Allows players to pause the game and provides various options
- **Game Over Interface** 🏁: Appears when the player dies, offering restart and exit options
- **Health Display UI** ❤️: Intuitively shows the player's current health status

### 2.4 Health System ❤️
- **Player Health Management** 💗: Manages player's health status and related effects
- **Collision Damage Detection** 💥: Detects collisions with enemies and reduces health
- **Damage Effects** ⚡: Implements invincibility time and visual feedback when injured
- **Death Handling** ☠️: Game-ending procedure when health is depleted

### 2.5 Audio Manager System 🎵
- **Scene Music Switching** 🔄: Automatically switches background music based on different scenes
- **Background Music Management** 🎼: Smooth transitions and volume control

## 3. Detailed Implementation 🔍

### 3.1 Main Menu System 🏠

**Feature Description**:
The main menu serves as the entry point of the game, providing a clean and intuitive interface. It features a specially designed **opening animation** ✨ that creates an immersive atmosphere for players. Players can enter the game introduction screen by clicking the Play button.

**Design Philosophy**:
- **Simplicity** 🧩: Minimized interface elements to avoid information overload
- **Intuitive Operation** 👆: Button design that is prominent and easy to understand
- *Visual Consistency* 🎨: Style consistent with the overall artistic style of the game
- *Dynamic Introduction* 🌈: Enhanced player engagement through the opening animation

**Key Features**:
- Engaging opening animation 🎬
- Simple single-page design 📄
- Responsive button interactions 👇
- Smooth scene transitions 🔀

**Interface Preview**:
[Insert main menu interface screenshot here]

### 3.2 Game Introduction Interface 📜

**Feature Description**:
The game introduction interface serves as a __bridge between the main menu and the actual game__ 🌉, presenting the game's background story, rules, and operation guidelines to help new players quickly understand the game.

**Design Philosophy**:
- **Clear Information** 📋: Important information is highlighted
- **Strong Guidance** 🧭: Guides players to understand core gameplay
- *Visual Appeal* 🖼️: Uses interesting graphics and animations to showcase game elements
- *Concise Content* 📝: Avoids information overload while maintaining player interest

**Key Features**:
- Paged display of different types of game information 📑
- Includes background story, character introductions, and operation guidelines 📚
- Intuitive control instructions and game objectives 🎯
- Continue button guiding players to the game scene ▶️

**Interface Preview**:
[Insert game introduction interface screenshot here]

### 3.3 Pause Menu System ⏸️

**Feature Description**:
The pause menu allows players to **pause the game at any time** ⌛ during gameplay, providing options to continue the game, restart, view help, and exit. The system controls the game's paused state through time scaling (Time Scale) while ensuring UI animations continue running.

**Design Philosophy**:
- **Immediate Response** ⚡: Key press immediately triggers pause state
- *Comprehensive Functionality* 🛠️: Provides all necessary game control options
- *Reversibility* 🔙: Ensures players can return to the game without loss

**Key Features**:
- Quick triggering through the __P key__ ⌨️
- UI animations continue running when game is paused ⏯️
- Multi-functional menu options 📋
- Nested panel design (help and guide can be opened within the pause menu) 📑

**Interface Preview**:
[Insert pause menu interface screenshot here]

### 3.4 Health System ❤️

**Feature Description**:
The health system manages the player's survival status, including health display, consumption, and recovery mechanisms. When players collide with enemies, the system **reduces health and provides visual feedback** 💔, triggering the game-ending procedure when health is depleted.

**Design Philosophy**:
- **Intuitive Feedback** 📊: Health changes have clear visual and audio cues
- **Forgiving Design** 🛡️: Provides brief invincibility time after taking damage
- *Risk and Reward* ⚖️: Health can be recovered through collecting items

**Key Features**:
- Heart icon health display ❤️❤️❤️
- __Screen red flash effect__ 🔴 when injured
- Brief invincibility period after injury, with character flashing ✨
- Integration with the game over system 🔚

**Interface Preview**:
[Insert health UI screenshot here]

### 3.5 Game Over Interface 🏁

**Feature Description**:
When the player's health reaches zero, the game over interface appears after a brief delay, providing game result feedback and allowing players to **restart or exit** 🔄 the game.

**Design Philosophy**:
- *Achievement Display* 🏆: Shows the player's final score
- **Clear Choices** 🔀: Provides clear follow-up options
- *Emotional Resonance* 😢: Conveys game over mood through visuals and text

**Key Features**:
- Delayed display, giving players time to perceive death ⏱️
- Display of final game score 🔢
- Restart and exit game options 🔁
- Smooth interface transition effects 🌊

**Interface Preview**:
[Insert game over interface screenshot here]

### 3.6 Audio Management System 🎵

**Feature Description**:
The audio management system controls the background music in the game, **automatically switching music** 🔄 according to different scenes, and implementing smooth fade-in and fade-out transition effects.

**Design Philosophy**:
- **Scene Consistency** 🏞️: Music matches the scene atmosphere
- **Seamless Experience** 🧵: Smooth music transitions
- *Intuitive Control* 🎚️: Simple volume management

**Key Features**:
- Automatic music switching when loading scenes 🔄
- __Fade-in and fade-out effects__ 📉📈 between music tracks
- Singleton pattern ensuring a global unique instance 🔒
- Volume adjustment functionality 🔊

  ---

  # GameDevWithUnityGroupProject
This is for COSC416/516

# **Lucas Xu**

## **Implement: Ghost Implementation**
### **Tracking Ghost (NavMesh)**
- Utilizes **NavMeshAgent** to enable **real-time player tracking**.

### **Patrolling Ghost**
- Moves **back and forth along a fixed route** within a set range.

### **Sound Effects**
- **Tracking Ghost Sound**: Volume changes dynamically **based on the distance** from the player.  
- **Collision Sound**: Plays when the ghost touches the player.

**Link：https://github.com/humb1e1989/GameDevWithUnityGroupProject/commit/a3c539de225f141b29357e8d99c2efded1af8a13**

https://github.com/user-attachments/assets/87074db4-5d73-450d-bbdb-78edd5a9ef00

---

## **Implement: partial Buff Implementation**
### **Freeze Buff**
- Freezes **tracking ghosts**.

### **Invisible Wall Buff**
- Turns certain walls **semi-transparent** and reveals **the optimal path**.

### **Teleport Buff**
- Instantly **teleports the player to a random coin nearby**.

**Link：https://github.com/humb1e1989/GameDevWithUnityGroupProject/commit/eff61e1b904093335b1ff59ee70636f4de02d3b4**

https://github.com/user-attachments/assets/81fa8842-2984-4e77-b39f-690d665e975c

---

## **Implement: Initial UI Implementation**
- **Menu UI** (already be replaced).  
- **Help and Game Rules Interface** added.


https://github.com/user-attachments/assets/1cefa2a1-aba2-48bb-a284-8be8c4fa5bfc


**Link：https://github.com/humb1e1989/GameDevWithUnityGroupProject/commit/fbf814d8b7065f12f6c51a4b1ecca523a378c682**
**Link：https://github.com/humb1e1989/GameDevWithUnityGroupProject/commit/af2a13d4dd73a783d4fb3b03a2fa776190dfe43b**



---

## **Implement: Final Scene Adjustments**
1. **Optimized Ghost UI**.  
2. **Improved Coin UI** for better visibility.  
3. **Placed buffs, ghosts, and coins**, refining the invisible wall buff’s path.  
4. **Adjusted NavMesh pathfinding**, resolving walkable areas marked as non-walkable.  
5. **Added Game Finish Menu** that triggers upon collecting **20 coins**.  
6. **Fixed Bug**: **Coin count now resets upon restart after player death**.  

---

## **Optimization: freelook Camera**
- Implemented **Cinemachine Deoccluder** to prevent obstacles from blocking the **FreeLook Camera**.
- Adjusted **minimum distance from the target** to ensure the player is always visible.

---

## **Optimization: partial Buff Duration**
- **Freeze Buff** and **Invisible Wall Buff** duration extended to **15 seconds**.

---

### **Ootimization: partial Buff Duration Adjustment**
- **Extended Freeze Buff and Invisible Wall Buff duration to 15 seconds**.

---

## **Optimization: Final Testing**
- Ensured **gameplay balance, playability, and overall stability**.


---

# **Ming Xu**
---

## Buff Duration
- Define and implement the duration of the buff.  
- Ensure that the buff is properly applied and dissolved within the appropriate time.  
- Balance the game difficulty and player experience.

  

https://github.com/user-attachments/assets/b83ff433-33b0-49da-8ea8-09465bac8df1



## Player Character Textures and Animations
- Choose a matching visual image for the player according to the theme of the game.  
- Combine it with animation effects to provide players with a more realistic and attractive movement effect.



https://github.com/user-attachments/assets/203c4f23-efce-4ab1-ac8b-5e474f2a5f56


  
## Coin and Scoring System
- Design the coin disappearance and scoring logic.  
- Create a scoreboard UI that matches the game style to complement the basic rules of the game.

  

https://github.com/user-attachments/assets/3592582a-919b-4612-bde0-544b81f99dca



## Game Export & User Testing
- Export and upload the game version multiple times during the development process for user testing.  
- Optimize the project based on user feedback.  




