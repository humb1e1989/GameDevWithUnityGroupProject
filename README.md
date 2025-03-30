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

---

## **Implement: partial Buff Implementation**
### **Freeze Buff**
- Freezes **tracking ghosts**.

### **Invisible Wall Buff**
- Turns certain walls **semi-transparent** and reveals **the optimal path**.

### **Teleport Buff**
- Instantly **teleports the player to a random coin nearby**.

---

## **Implement: Initial UI Implementation**
- **Menu UI** (already be replaced).  
- **Help and Game Rules Interface** added.

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

