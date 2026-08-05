# First-Person Pacman Horror Game 

A 3D first-person horror re-imagining of the classic arcade game *Pac-Man*, built in Unity. The player navigates a dark, maze-like environment, collects points to unlock the chest which contains the key, and attempts to escape while being hunted by AI-controlled ghosts.

---

## 🎮 Game Manual

### Overview & Concept
*Pacman Horror Game* transforms classic 2D arcade gameplay into an immersive 3D First-Person survival horror experience. The goal is to explore the atmospheric maze, locate and interact with required tasks, and successfully survive against patrolling enemy ghosts.

### Controls
| Action | Key / Input |
| :--- | :--- |
| **Move Forward / Backward** | `W` / `S` |
| **Strafe Left / Right** | `A` / `D` |
| **Look Around** | `Mouse` |

### Gameplay & Mechanics
* **Objective Tracking:** Clear instructions and task counters are shown on the UI screen.
* **Ghost AI:** Enemies continuously scan the environment using Unity NavMesh pathfinding to locate, pursue, and corner the player.
* **Win / Lose Conditions:** 
  * **Win:** Collect all required points to open the chest in the safe room. After collecting the key you have to find and reach the exit point.
  * **Lose:** Getting caught by a ghost triggers a game-over state.

---

## ⚙️ Technical Manual

### Engine & Pipeline
* **Game Engine:** Unity (Recommended version: `2022.3 LTS` or higher)
* **Render Pipeline:** Universal Render Pipeline (URP) `17.3.0`
* **Scripting Language:** C#

### Dependencies & Packages
* **TextMeshPro (`com.unity.textmeshpro`):** Used for all crisp, responsive UI texts and HUD elements.
* **AI NavMesh `2.0.11`(`com.unity.ai.navigation`):** Handles 3D pathfinding, baking navigable surface meshes, and enemy ghost navigation.
* **UGUI / Canvas System:** Implements responsive UI scaling (`Scale With Screen Size` at 1920x1080 reference resolution).


### Third-Party Assets (Asset Store)
* **3D Models:** *Dark Big Ghosts Lite*, *Rust Key*, *Stylized Treasure Chest*, *Wooden Entrance Door*.
* **Audio:** *Atmospheric Horror Music*, *8-bit SFX & UI Sounds*.

### Project Architecture & Scenes
The game follows a modular scene management setup:
1. **`0_MainMenu`** – Initial splash screen, game start options, and quit control.
2. **`1_Rules`** – Overview of game rules and instructions.
3. **`2_PacmanGame`** – Main gameplay level containing the 3D maze, player controller, ghost AI logic, and UI overlays.

---

## 🚀 Setup & Installation
### Opening the Project in Unity
1. Clone or download this repository:
   ```bash
    git clone https://github.com/saraRasic/unityGame.git
    ``` 
2. Open Unity Hub.
3. Click Add -> Add project from disk and select the project's root folder.
4. Launch the project (Unity will automatically resolve all package dependencies).
5. In the Project panel at the bottom, navigate to Assets/Scenes/.
6. Double-click 0_MainMenu.unity to open the starting scene.
7. Click the Play ▶️ button at the top of the Unity Editor to start playing.













   
