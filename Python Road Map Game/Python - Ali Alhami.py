
# ================================================
#   Game name: Journey to gold  in libya
#   
#            By: Ali Mohamed Alhami 
# ================================================




# This determines the class player

class Player:
    """The player will hold the  names, positions, and inventory.
    Attributes:
        name (str): Player's name
        position (str): Current location
        inventory (list): coollect only [4] items
    """
    def __init__(self, name):
        self.name = name
        self.position = "start"
        self.inventory = []

    def show_inventory(self):
        """Display current inventory items."""
        print(f"\n Inventory: {', '.join(self.inventory) if self.inventory else 'Empty'}")

    def drop_item(self):
        """Allow player to remove items from inventory."""
        if not self.inventory:
            print("Inventory is empty!")
            return
        
        print("\nItems:")
        for idx, item in enumerate(self.inventory, 1):
            print(f"{idx}. {item}")
            
        try:
            choice = int(input("Enter item NUMBER to drop (0 to cancel): "))
            if 1 <= choice <= len(self.inventory):
                dropped = self.inventory.pop(choice-1)
                print(f" Dropped {dropped}!")
        except:
            print(" Invalid input!")

# This consists the class of the location.

class Location:
    """ This shows the  game location with the  activity.
    Attributes:
        description (str): Location details
        exits (dict): Available exits
        item (str): Collectible item
        requires (str): Item needed to enter
        npc (str): NPC description
    """
    def __init__(self, description, exits, item=None, requires=None, npc=None):
        self.description = description
        self.exits = exits
        self.item = item
        self.requires = requires
        self.npc = npc

# This determines the creation of the places .

def Create_Places ():
    
    return {
        "start": Location(
            description=" Mediterranean Sea. Go north.",
            exits={"north": "coastal_road"},
            item="Oil"
        ),
        "coastal_road": Location(
            description=" Coastal Road. Exits: north/south.",
            exits={"north": "tripoli", "south": "start"},
            item="Sword"
        ),
        "tripoli": Location(
            description=" Tripoli (Capital). Exits: north/east/south.",
            exits={"north": "Misrata", "east": "Benghazi", "south": "coastal_road"}
        ),
        "Misrata": Location(
            description=" Misrata. Peaceful city. Exit: south.",
            exits={"south": "tripoli"}
        ),
        "Benghazi": Location(
            description=" Benghazi Market. Trade here! Exits: west/north.",
            exits={"west": "tripoli", "north": "Desert"},
            item="gold_coin",
            npc="Trader"
        ),
        "Desert": Location(
            description=" Sahara Desert. Exits: south/east.",
            exits={"south": "Benghazi", "east": "Tobruk"},
            item="Shovel"
        ),
        "Tobruk": Location(
            description=" Tobruk. Exits: west/north.",
            exits={"west": "Desert", "north": "Ghadames"},
            requires="Shovel"
        ),
        "Ghadames": Location(
            description=" Ghadames is  a desert and need oil for a 4 wheel car. Exits: south/east.",
            exits={"south": "Tobruk", "east": "Sebratah"},
            requires="Oil"
        ),
        "Sebratah": Location(
            description=" Sebratah . Final checkpoint! Exits: west/east.",
            exits={"west": "Ghadames", "east": "Gold"},
            item="key"
        ),
        "Gold": Location(
            description=" You found the gold and the game is finished. YOU WIN!",
            exits={},
            requires="key"
        )
    }

# This shows the NPC system handling.

def handle_npc(location, player):
    """Manage NPC activity."""
    if location.npc == "Trader":
        print("\n Trader: 'Trade gold coin for water!'")
        action = input("Trade? (yes/no): ").lower()
        if action == "yes" and "gold_coin" in player.inventory:
            player.inventory.remove("gold_coin")
            player.inventory.append("water")
            print("You got water!")
        else:
            print("Trader: 'please come back with the coin you poor!'")

# This is the main game loop .

def main():
    """Main game loop handling movement and activity."""
    world = Create_Places ()
    player = Player(input("Enter your name: "))
    
    print("\n=== Libya gold founder ===")
    print("Find the key in Sebratah  to win!\n")



    while True:
        current = world[player.position]
        
        # This Displays location header.

        print("\n" + "=" * 40)
        print(f" {player.position.replace('_', ' ').title()}")
        print("=" * 40)
        print(current.description)
        
        # This Show NPC activity.

        if current.npc:
            handle_npc(current, player)
            
        # This Show exits.

        print(f"\n Exits: {', '.join(current.exits.keys())}")
        
        # Item handling.

        if current.item:
            action = input(f"\n Pick up {current.item}? (yes/no): ").lower()
            if action == "yes":
                if len(player.inventory) < 4:
                    player.inventory.append(current.item)
                    print(f" Got {current.item}!")
                    current.item = None
                else:
                    print(" Inventory full! (Max 4)")
                    drop = input("Drop item? (yes/no): ").lower()
                    if drop == "yes":
                        player.drop_item()
        
        # This is inventory management.

        player.show_inventory()
        if input("\nDrop item? (yes/no): ").lower() == "yes":
            player.drop_item()
            
        # This is the movement handling.

        move = input(f"\n Direction ({'/'.join(current.exits)}) or 'quit': ").lower()
        if move == "quit":
            print("Thanks for playing!")
            break
            
        if move in current.exits:
            dest = current.exits[move]
            dest_loc = world[dest]
            
            # this the Checks location requirements.

            if dest_loc.requires and dest_loc.requires not in player.inventory:
                print(f" Need {dest_loc.requires} to enter!")
                continue
                
            player.position = dest
            print(f"\n Moving {move} to {dest.replace('_', ' ')}...")
            
            # This will be  showed or printed if you win.

            if dest == "Gold":
                print("\n    Congratulations  You reached the Gold alloy .  My all respect to you. Ali Mohamed Alhami")
                break
        else:
            print(" sorry it's Invalid direction!")

if __name__ == "__main__":
    main()

# This the end of my Python code.