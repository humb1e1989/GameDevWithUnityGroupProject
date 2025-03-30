# GameDevWithUnityGroupProject
This is for COSC416/516

# **Game Development Report - Lucas Xu**

## **Implementation**
### **Ghost System**
#### **Tracking Ghost (NavMesh)**
- Utilizes **NavMeshAgent** to enable **real-time player tracking**.

#### **Patrolling Ghost**
- Moves **back and forth along a fixed route** within a set range.

#### **Sound Effects**
- **Tracking Ghost Sound**: Volume changes dynamically **based on the distance** from the player.  
- **Collision Sound**: Plays when the ghost touches the player.

### **Buff System**
#### **Freeze Buff**
- Freezes **tracking ghosts for 15 seconds**.

#### **Invisible Wall Buff**
- Turns certain walls **semi-transparent** and reveals **the optimal path** for 15 seconds.

#### **Teleport Buff**
- Instantly **teleports the player to a random coin nearby**.

### **UI System**
- **Updated Menu UI**.  
- **Added Help and Game Rules Interface**.  
- **Added Game Finish Menu** that triggers upon collecting **20 coins**.  

### **Scene Setup**
- **Placed buffs, ghosts, and coins**, refining the invisible wall buff’s path.  
- **Adjusted NavMesh pathfinding**, resolving walkable areas marked as non-walkable.  

---

## **Optimization**
### **Ghost UI and Coin Visibility**
- **Optimized Ghost UI** for better clarity.  
- **Improved Coin UI** to enhance visibility.  

### **Camera System**
- Implemented **Cinemachine Deoccluder** to prevent obstacles from blocking the **FreeLook Camera**.
- Adjusted **minimum distance from the target** to ensure the player is always visible.

### **Buff Duration Adjustment**
- **Freeze Buff** and **Invisible Wall Buff** duration extended to **15 seconds**.

### **Bug Fixes**
- **Fixed Coin Count Reset Issue**: Coin count now resets upon restart after player death.  

### **Final Testing**
- Ensured **gameplay balance, playability, and overall stability**.
