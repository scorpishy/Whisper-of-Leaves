# Whisper of Leaves

Whisper of Leaves is a peaceful garden simulation game where players grow, water, and harvest plants in a relaxing environment.

## Features
- **Dynamic Plant Growth**: Plants transition through different states (seed → sprout → fruit | withered).
- **Reactive Event System**: Uses UniRx for managing game events.
- **Clean Architecture**: Clean separation of concerns using Domain, Application, Infrastructure, and Presentation layers.
- **Inventory System**: Interact with gardening tools and manage harvested items.
- **Stylized UI**: Built with Unity UI Toolkit (UIElements).

## Project Structure
_Project/ 
├── Artwork/ # Sprites and textures
├── Audio/ # Music and sound effects
├── Configs/ # ScriptableObject configurations
├── Prefabs/ # Prefabs for game objects
├── Scripts/ # Main game logic
│ ├── Application/ # Interactors and use cases
│ ├── Domain/ # Core business logic
│ ├── EntryPoint/ # Dependency injection and initialization
│ ├── Infrastructure/ # Services and system implementations
│ ├── Presentation/ # UI components

## Technologies Used
- **Unity 6**
- **VContainer** (Dependency Injection)
- **UniRx** (Reactive Programming)
- **New Input System** (User interactions)
- **UI Toolkit (UIElements)** (Modern UI design)

## How to Run
1. Clone the repository.
2. Open the project in Unity 6.
3. Ensure dependencies (VContainer, UniRx) are installed via UPM.
4. Press Play in the Unity Editor.
