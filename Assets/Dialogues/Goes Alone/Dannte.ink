EXTERNAL ChangeState(stateName)

Please, no. Not my room...#speaker:Dannte #portrait:Dannte
This can't be happening. Not my boy. Please, wake up...
Elias, please... Please wake up...
Who could have done this? Why my son? I have to do something!
    *[Wait for help]
        ~ChangeState("Trust Bellboy")
        I must wait for the captain to solve this.
        ->DONE
    *[Investigate]
        ~ChangeState("Dont trust Bellboy")
        I have to find the one responsible, even if I have to do it alone.
        ->DONE
