EXTERNAL ChangeState(stateName)

What's going on here?#speaker:Bellboy #portrait:Bellboy
His son... someone shot his son!#speaker:Worker #portrait:Worker
I'm calling security. They need to know about this immediately.#speaker:Bellboy #portrait:Bellboy
Who could have done this? Why my son? I will find them. They will pay for this.#speaker:Dannte #portrait:Dannte
    *[Wait for help]
        -> Wait
    *[Find the one responsible]
        -> Leave
=== Wait ===
I must wait for the captain to solve this.
~ChangeState("Trust Bellboy")
->DONE

=== Leave ===
I have to find the one responsible, even if I have to do it alone.
~ChangeState("Dont trust Bellboy")
->DONE
