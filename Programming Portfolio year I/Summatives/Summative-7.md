# Summative 7

## Challenge Description

You've been tasked to refactor some code that has been written for a fantasy game.

The goal is to make it so that it is easy to expand the number of characters in the game. Currently there are just three - a ranger, a barbarian and a mage, but they are grouped together in a single Character class.

Currently the individual character behaviour is managed using a characterType string. This is not a scalable solution, and should be removed in favour of a more extensible and scalable approach.

The reason that this is not scalable is because as you add more character types the code will get more complex. You should already be able to see how an instance of a barbarian class has datamembers about arrows - which is something only the ranger cares about.

Your job is to try to split this class into three separate classes (Ranger, Barbarian, and Mage). The three classes should inherit from a Character class, which can deal with things that are common to all characters. There are also some bugs present in the code for you to find and fix.

Characters can perform actions that are specific to their class. Some actions cost energy. A character should not be able to perform an action from another character. A character should not be able to perform an action if they are already knocked out.

The Ranger should start with their maximum of 10 hitpoints and 8 energy. The ranger starts with 10 arrows, which he can fire at other characters using 1 energy point and damaging the target for 1 hitpoint. The ranger can also collect all the arrows he has fired.

The Barbarian should start with their maximum of 18 hitpoints and 12 energy. The Barbarian can swing his axe at other characters for 3 energy, damaging them for 3 hitpoints.

The Mage should start with their maximum of 8 hitpoints and 8 energy. The Mage can throw a fireball for 2 energy, doing 2 hitpoints of damage. The mage can also Heal a target (which could be himself) by 5 hitpoints for 1 energy.

