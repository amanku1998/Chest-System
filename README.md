GamePlay Video link : https://mega.nz/file/FDFHTSqb#NhkBN6kd7o1d89Zcu6ZAS7nMAeW58-kRDysrGUSQ058
Playable link : https://outscal.com/kuaman12020/game/play-chestsystem-game-1

Game Description
This is a dynamic, slot-and-chest-based casual game designed to keep players engaged with its rewarding mix of chance and strategy. Players interact with slots to unlock chests, earn valuable in-game currency (coins and gems), and experience smooth, event-driven gameplay.

Core Systems & Architecture
Service Locator Pattern:
A centralized GameService acts as the access point for all major game systems. Built as a Singleton, it ensures consistent and efficient communication across the game.

• SlotService: Handles slot interactions, chest triggers, and slot-to-chest mappings.
• ChestService: Controls chest states, unlock timers, and reward distribution.
• EventService: Provides a flexible, event-driven structure using an observer-based system.
• CurrencyHandler: Manages coin and gem updates with precise tracking.

MVC (Model-View-Controller) Pattern:

Slot System:
• Model: Stores slot data, states, and business logic for generating chests.
• View: Displays slot visuals, manages user interactions, and provides feedback.
• Controller: Connects the model and view, manages slot operations, and communicates chest-related events.

Chest System:
• Model: Maintains chest data, states, and reward logic.
• View: Displays chest animations, state changes, and user interface elements.
• Controller: Handles chest operations, triggers animations, and integrates with the slot system.

Observer Pattern:
• Implemented through the EventService, enabling seamless communication between components using C# events and delegates.
• OnSlotSelect: Updates the UI and evaluates chest states when a slot is selected.
• OnFailedString: Displays error feedback (e.g., insufficient gems).

Key Features:
• Engaging Gameplay: Unlock chests, collect rewards, and progress through event-driven mechanics.
• Modular & Extensible Design: Easily adaptable for adding new features or expanding existing systems.
• Real-Time Feedback: Immediate on-screen responses to actions and errors ensure a polished experience.
