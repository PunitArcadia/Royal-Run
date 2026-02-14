# Royal Run

An endless runner built in **Unity**, focused on procedural level generation, clean game state management, and scalable obstacle spawning.

This project evolved from a basic runner prototype into a structured gameplay systems case study.

---

## 🎮 Gameplay Overview

- Endless forward progression using chunk-based procedural generation
- Randomized fence and coin placement across lanes
- Player movement with lane clamping
- Coin collection and life system
- Game over state with UI transition

---

## 🧠 Case Study: Refactoring Royal Run

### Initial Structure

The original implementation relied on:
- Continuous world movement without state awareness
- Fixed obstacle spawn counts
- Chunk removal during forward list iteration
- Score tied directly to global time
- Systems operating independently without a shared game state

While functional, this approach lacked architectural separation and scalability.

---

### Refactor Goals

The refactor focused on:

- Introducing a centralized `GameState` system
- Making all systems respect game activity
- Improving procedural chunk management
- Ensuring safe list operations during runtime
- Cleaning up responsibility boundaries

---

### Architecture Improvements

#### 🎮 GameManager
- Introduced `GameState` enum (`Playing`, `GameOver`)
- Score increases only while game is active
- Central authority for life, coin, and score logic
- GameOver triggered only once

#### 🏃 Player Movement
- Movement respects `GameManager.IsGameActive`
- Stops instantly on game over
- No state logic inside movement script

#### 🌍 Level Generator
- Safe backward iteration when removing chunks
- Infinite chunk spawning
- Cached camera reference
- Stops movement when game is over

#### 🚧 Obstacle Spawner
- Infinite spawn loop controlled by game state
- Float-based spawn intervals
- Clean separation from player logic

#### 🧱 Chunk System
- Lane-aware spawning logic
- Ensures coins spawn only in available lanes
- Self-contained procedural generation

---

## 🛠 Tech Stack

- Unity
- C#
- Unity Input System
- Procedural generation techniques

---

## 📌 Project Status

✅ Refactored into a state-driven procedural gameplay system.

This project serves as a second gameplay architecture case study alongside Rocket Boost.
