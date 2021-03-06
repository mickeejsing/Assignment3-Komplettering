# Assignment3-1DV607

## A work by Mikael Eriksson, Christoffer Lindow and Ivan Badal.

### Information

This work includes updated and refatored source code. It also icludes a class diagram. The class diagram has been updated to reflect the refactored program. The added classes is marked with a yellow background color for clarity. The relationtions between added and modified classes is visualised as red lines. 

You can find the class diagram in folder named "diagrams".

### Instructions

To run this applications, just download the source code and write "dotnet run" in the terminal.

### Completion

1. Hidden Dependency: Fix: hidden dependency between the controller and the view. [x]

2. Strategy: OK in general. Fix: there should be 2 implementations for the IResultStrategy. [x]

3. Fix: Soft17 not implemented. [x]

4. Refactoring: Fix: code duplication in the model (rules namespace). [x]

## Assignment

- Remove the bad, hidden, dependency between the controller and view (new game, hit, stand)

- Design and implement a new rule variant for when the dealer should take one more card. The new variant is “Soft 17″, use the same design pattern already present for Hit. Soft 17 means that the dealer has 17 but in a combination of Ace and 6 (for example Ace, two, two, two). This means that the Dealer can get another card valued at 10 but still have 17 as the value of the ace is reduced to 1. Using the soft 17 rule the dealer should take another card (compared to the original rule when the dealer only takes cards on a score of 16 or lower).

- Design and implement a variable rule for who wins the game. This variation could, for example, change who wins on an equal score (in one implementation the Dealer wins, in the other the Player). The design should make it easy to add other variants without changing the Dealer. Use the same design pattern as used in the Soft 17 design.

- The code for getting a card from the deck, show the card and give it to a player is duplicated in a number of places. Make a refactoring to remove this duplication and that supports low coupling/high cohesion (i.e. check how you can evaluate different solutions to the problem and select the one that gives the best result according to low coupling/high cohesion). The code that is duplicated is similar to this:
Card c = deck.GetCard();
c.Show(true/false)
player.DealCard(c);