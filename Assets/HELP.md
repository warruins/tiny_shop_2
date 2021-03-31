# Demo Reel

This is my attempt to give you some very, very simple and basic exmaples of how to make a game UI interactive. Some common behaviors I cover:

- Open/close menus
- Inventory interactions (selection)
- Shop interactions (buying/selling)
- Dragging and dropping

IMPORTANT: I'm not trying to provide *The Way*. These are hopefully just a simple way to understand how Unity handles this challenges at a fundamental level. There are many different ways to do these things and hopefully these examples are a good starting point to experimenting with your own solutions.


## Shop Buy/Sell

I tried to make this as simple as I was able, but shop interactions are complex in nature. Think about it this way:

- The "Shop" has to know when a player picks something.
- The "Shop" has to know information about what was picked.
- The "Shop" has to keep track of ALL items that are picked.
- Items have to be displayed somehow.
- Items have unique statuses (selected/not).

Important concepts:
- `IPointer*` handlers detect mouse events.
- Raycasting is complicated. All you need to know is its used to detect which objects are being touched by the mouse.

### Details

* `Canvas.UI`: Trade transactions. Keeps track of what's selected and how much its worth.
* `Button`: Updates gold values on the screen.
* `Canvas.Background`: Provides the inventory graphic in the background.
* `ItemBox`: Displays a gold border around items that are selected.
* `Item/Loot`*: Holds all data about the item. 

> NOTE: I named the related script `Loot` to avoid confusion with Unity's `Item` object. Loot is an item.

To set this up you need 3 scripts: one for trade, one for displaying the status of item boxes and one for holding data about items. Then you'll make all 3 interact with each other for the final result.

**Setup:**
* `Canvas.Background`: add an `Image` component in the inspector. This is so that there's always an inventory background, even when items aren't selected or present.
* `ItemBox`:  add a `Canvas Group` component in the inspector. This will let you control the visibility, interactable and raycasting.
* `Item`: the `Image` component has Raycasting set to false! This allows the mouse to be detected by the object beneath the item. In this case, by the Itembox.
