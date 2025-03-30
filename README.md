# GameDevWithUnityGroupProject
This is for COSC416/516

# **Game Development Report - Lucas Xu**

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

