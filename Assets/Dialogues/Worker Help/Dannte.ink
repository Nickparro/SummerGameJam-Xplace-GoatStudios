EXTERNAL ChangeState(stateName)

Please, no. Not my room...#speaker:Dannte #portrait:Dannte
Oh my God! Someone help! HELP!#speaker:Worker #portrait:Worker
This can't be happening. Not my boy. Please, wake up...#speaker:Dannte #portrait:Dannte
Elias, please... Please wake up...
Who could have done this? Why my son? I have to do something!
    *[Wait for help]
        I must wait for the captain to solve this. #objective:Wait for the captain
        ~ChangeState("Trust Bellboy")
        ->DONE
    *[Investigate]
        ~ChangeState("Dont trust Bellboy")
        I have to find the one responsible, even if I have to do it alone.#objective: Find the killer
        ->DONE