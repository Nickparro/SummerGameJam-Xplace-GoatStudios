EXTERNAL ChangeState(stateName)

Please, no. Not my room...#speaker:Dannte #portrait:Dannte
This can't be happening. Not my boy. Please, wake up...
Elias, please... Please wake up...
    *[Wait for help]
        -> Wait
    *[Find the one responsible]
        -> Leave
=== Wait ===
~ChangeState("Trust Bellboy")
I must wait for the captain to solve this.
->DONE

=== Leave ===
~ChangeState("Dont trust Bellboy")
I have to find the one responsible, even if I have to do it alone.
->DONE