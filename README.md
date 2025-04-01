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

**MainScene Overview**:

https://github.com/user-attachments/assets/1c828c2a-1acf-489f-9ef2-54a4e387020c



### 2.3 UI System 📱
- **Main Menu Interface** 🏠: Entry point of the game, featuring an elegant opening animation
> The main menu provides a clean and intuitive interface. I implemented a code-based **opening animation** ✨. Players can enter the game introduction screen by clicking the **PLAY** button and quit the game by clicking the **EXIT** Button.

**Interface Preview**:

https://github.com/user-attachments/assets/6ae4d816-3944-48c2-83f2-01c1ec33e7ac


- **Pause Menu System** ⏸️: Allows players to pause the game and provides various options
> The pause menu allows players to **pause the game at any time by pressing key 'P'** ⌛ during gameplay has Multi-functional menu options 📋. It provides options to continue the game, restart, view help, back to main menu and exit withc a Nested panel design (e.g. help and guide can be opened within the pause menu) 📑. The system controls the game's paused state through time scaling (Time Scale) while ensuring UI animations continue running.

**Interface Preview**:

https://github.com/user-attachments/assets/4afd6518-6b4f-4272-a34d-c0e753ced2c6



- **Game Completion Interface** 🏁: Appears when the player dies, the Game Over Interface offering restart and exit options, when collecting enough cois, the Winning Interface offer restart, back to main menu, and exit options
> When the player's health reaches zero or collect 20 coins, the game over interface appears after a brief delay, providing game result feedback and allowing players to **restart or exit** 🔄 the game.

**Interface Preview**:

https://github.com/user-attachments/assets/db97ff5f-3361-4d31-9ba4-222537e1b721


- **UI System Refine and Scene Switching** ❤️: Intuitively shows the player's current health status
> Implement the logic for the whole game scene switching (Mainmenu -> introduction -> MainGameScene (Demo_01.unity))

### 2.4 Health System ❤️
> The health system manages the player's survival status, including health display, consumption, and recovery mechanisms. When players collide with enemies, the system **reduces health and provides visual feedback** 💔, triggering the game-ending procedure when health is depleted.

- **Player Health Management** 💗: Manages player's health status and related effects
- **Health Display UI** ❤️: Intuitively shows the player's current health status
- **Death Handling** ☠️: Game-ending procedure when health is depleted. Integration with the game over system 🔚

**HP System Preview**:



https://github.com/user-attachments/assets/c9d88d8a-d128-4146-b698-975933f161da



### 2.4 Damage System ❤️
- **Collision Damage Detection** 💥: Detects collisions with enemies and reduces health
- **Damage Effects** ⚡: Implements invincibility time and visual feedback when injured,__Screen red flash effect__ 🔴 when injured
> When the player is grabbed by a ghost, he or she is immediately granted two seconds of invincibility, and the character will blink to visually cue this state. This feature gives the player the opportunity to escape from dangerous areas that

**Damage System Preview**:



https://github.com/user-attachments/assets/af9388b7-7f41-4116-83a0-42e4680e0997


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

## **Implement: Partial Buff Implementation**
### **Increase Size Buff and UI**
- The player's size is changed to 3 times of the original one, so as to cross some rugged places
### **Decrease Size Buff and UI**
- The player's image size is changed to 0.5 times of the original one, so as to pass through some small holes
### **Dash**
- The player's movement speed is changed to 3 times of the original one, so as to get rid of the ghost's pursuit
### **Commit Link**
https://github.com/humb1e1989/GameDevWithUnityGroupProject/commit/cf4f3180b251d2fc8f4ef73224f0437c2f825d97



## **Implement: Buff Duration**
- Set the duration of size change buff and dash buff to 15 seconds
- Ensure that the buff is properly applied and dissolved within the appropriate time
- Balance the game difficulty and player experience
### **Commit Link**
https://github.com/humb1e1989/GameDevWithUnityGroupProject/commit/f5127888e3e2c635a72930423e5566daaa75a782



https://github.com/user-attachments/assets/b83ff433-33b0-49da-8ea8-09465bac8df1




## **Implement: Coin and Scoring System**
### **Coin**
- Implement the coin disappear and scoring logic
### **Scoring System**
- Build an effective scoreboard UI
- Matches the game style to complement the basic rules of the game
### **Commit Link**
https://github.com/humb1e1989/GameDevWithUnityGroupProject/commit/9eceb9b011e60f007c0a9e1e4d8b699c7cc9620d

  

https://github.com/user-attachments/assets/3592582a-919b-4612-bde0-544b81f99dca



## **Optimization: Player Character and Animations**
### **Player Character**
- Using Lowpoly Cowboy RIO V1.1 to optimize the player's image
- Choose a matching visual cowboy image for the player according to the theme of the game
### **Player Animations**
- Using Basic Motions FREE to implement player action animation
- Provide players with a more realistic and attractive movement effect
### **Commit Link**
https://github.com/humb1e1989/GameDevWithUnityGroupProject/commit/5c156c23ebdd011ed1fef94086200b325aaa4e1e



https://github.com/user-attachments/assets/203c4f23-efce-4ab1-ac8b-5e474f2a5f56



## **Optimization: Scoreboard UI**
- Import MISTERY ILAHI.otf to optimize the font display of scoreboard
- Use horror-style fonts to unify the UI style of the game and enhance the immersion of the game
### **Commit Link**
https://github.com/humb1e1989/GameDevWithUnityGroupProject/commit/bdced65e17cbb1971760965a482116c7a3127037



## **Testing: Game Publishing & User Testing**
### **Game Publishing**
- Exported and uploaded to itch.io to test whether there was any conflict
- According to the running results of the online platform, make targeted adjustments in order to obtain the best game effect
### **User Testing**
- Invite volunteers to play the game and collect feedback
- According to the collected feedback, make targeted adjustments in order to provide the best game experience
### **Commit Link**
https://itch.io/game/edit/3423849


<img width="256" alt="Screenshot 2025-03-31 205644" src="https://github.com/user-attachments/assets/bac38575-cbe1-46fa-a373-06ff992a73d2" />



## **Development Challenges**
### **1. The buff removing mechanism can't work correctly after being destroyed (solved)**
The method of implementing and removing is linked to the buff object, so that the effect of the buff can be removed correctly after the buff object is destroyed (with the help of Lucas) 
### **2. Coins are set as a buff, and cannot be scored correctly (solved)**
Separate the codes related to coins and put them in a separate file. Let the buff.cs file refer to the coin methods.
### **3. After the game introduction animation is updated, the connection between the scenes is abnormal (solved)**
All related scenes should be added to the scene list in order (with the help of Lucas) 
### **4. When the game is running on the online platform, it reports useless information (solved)**
Delete the unnecessary detection codes in the main menu, and uncheck the development build when exporting the game (with the help of Lucas and Iverson) 
