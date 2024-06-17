EXTERNAL ChangeState(stateName)

Hello, how can I help you? #speaker:Captain #portrait:red
    * [Open door, please]
        -> OpenDoor
    * [Nothing]
        -> Back
    
=== OpenDoor ===
~ChangeState("Captain Called")

Sure thing!
->DONE

=== Back ===
Goodbye!
->DONE
