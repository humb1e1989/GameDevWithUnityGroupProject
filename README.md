# 3D Pac-Man Style Game - UI System and Health System Development Documentation 🎮

## 1. Project Overview 🌟

This project is a **3D version of a Pac-Man style chase game** 🏃‍♂️👻. This documentation details the design and implementation process of the UI system and health system, including menu systems, pause functionality, game over interface, and player health management mechanisms. Through carefully designed user interfaces and health systems, we provide players with a smooth and intuitive gaming experience.

## 2. Implemented Features✨

## 2.1 Demonstration Video 🎬 (Iverson Yuan)

 Implemented the following features:
1. Main Game Scene Contruction
2. Main menu interface and Loading Animation 🏠
3. In-game health system and UI display ❤️
4. Damage handling from enemy collisions 💥
5. Pause Game menu usage ⏸️
6. Game over interface and options 🏁
7. In Game Audio Control 


### 2.2 Main Scnee Construction
> The scenery for this 3D Pac-Man game combines classic maze elements with modern ambient design. Two maze structures with different asymmetrical layouts is placed and a multi-story haunted house is in the center of the map, all set in a mist-shrouded forest area.

I implemented the following key elements based on the original _**Poly Horror Mansion Asset**_  in the scene:

- Built two complex mazes, each with a unique layout that the player would need to navigate through
- Designed a central haunted house with multiple rooms and floors that served as both a challenge and a refuge
- Scattered collectibles Placement Location is reserved throughout the environment (visible as glowing dots in the image)
- Created a foggy, moody environment to add tension to the game by using the _**Unity's Wind Zone Function**_

Details are showed as following:

**Interface Preview**:
[Insert main menu interface screenshot here]


### 2.3 UI System 📱
- **Main Menu Interface** 🏠: Entry point of the game, featuring an elegant opening animation
> The main menu serves as the entry point of the game, providing a clean and intuitive interface. It features a specially designed **opening animation** ✨ that creates an immersive atmosphere for players. Players can enter the game introduction screen by clicking the Play button and quit the game by clicking the EXIT Button.

**Interface Preview**:
[Insert main menu interface screenshot here]

- **Pause Menu System** ⏸️: Allows players to pause the game and provides various options
> The pause menu allows players to **pause the game at any time by pressing key 'P'** ⌛ during gameplay has Multi-functional menu options 📋. It provides options to continue the game, restart, view help, back to main menu and exi withc a Nested panel design (e.g. help and guide can be opened within the pause menu) 📑. The system controls the game's paused state through time scaling (Time Scale) while ensuring UI animations continue running.

**Interface Preview**:
[Insert main menu interface screenshot here]

- **Game Completion Interface** 🏁: Appears when the player dies, the Game Over Interface offering restart and exit options, when collecting enough cois, the Winning Interface offer restart, back to main menu, and exit options
> When the player's health reaches zero or collect 20 coins, the game over interface appears after a brief delay, providing game result feedback and allowing players to **restart or exit** 🔄 the game.

**Interface Preview**:
[Insert main menu interface screenshot here]

- **UI System Refine and Scene Switching** ❤️: Intuitively shows the player's current health status
> Implement the logic for the whole game scene switching (Mainmenu -> introduction -> MainGameScene (Demo_01.unity))

### 2.4 Health System ❤️
> The health system manages the player's survival status, including health display, consumption, and recovery mechanisms. When players collide with enemies, the system **reduces health and provides visual feedback** 💔, triggering the game-ending procedure when health is depleted.

- **Player Health Management** 💗: Manages player's health status and related effects
- **Health Display UI** ❤️: Intuitively shows the player's current health status
- **Collision Damage Detection** 💥: Detects collisions with enemies and reduces health
- **Damage Effects** ⚡: Implements invincibility time and visual feedback when injured,__Screen red flash effect__ 🔴 when injured
- **Death Handling** ☠️: Game-ending procedure when health is depleted. Integration with the game over system 🔚

**Interface Preview**:
[Insert health UI screenshot here]

### 2.5 Audio Manager System 🎵
- **Scene Music Switching**🔄 and **Music Management** 🎼 : Implemented a code-based automated management of multi-scene music systems. & The game switches background music based on different scenes with Fade-in Fade-out effect
> The audio management system controls the background music in the game, **automatically switching music** 🔄 according to different scenes, and implementing smooth fade-in and fade-out transition effects. It has a singleton pattern ensuring a global unique instance 🔒 and Volume adjustment functionality 🔊

**Interface Preview**:
[Insert health UI screenshot here]

  ---

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




