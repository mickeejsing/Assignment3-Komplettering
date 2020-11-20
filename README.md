# Assignment3-1DV607

## A work by Mikael Eriksson, Christoffer Lindow and Ivan Badal.

### Information

This work includes updated and refatored source code. It also icludes a class diagram. The class diagram has been updated to reflect the refactored program. The added and modified classes, is marked with a yellow background color for clarety. The relationtions between added and modified classes is visualised as red lines. 

You can find the class diagram in folder named "diagrams".

### Instructions

To run this applications, just download the source code and write "dotnet run" in the terminal.
If you wish to change the rules for who wins on equal score, change the boolean isDealerWinnerEqual from true to false in model -> rules -> BasicResultStrategy.


### Completion

1. Hidden Dependency: Fix: hidden dependency between the controller and the view. []

2. Strategy: OK in general. Fix: there should be 2 implementations for the IResultStrategy. []

3. Fix: Soft17 not implemented. []

4. Refactoring: Fix: code duplication in the model (rules namespace). []

- Det finns kodduplicering i filerna AmericanNewGameStrategy.cs & InternationalNewGameStrategy.cs.