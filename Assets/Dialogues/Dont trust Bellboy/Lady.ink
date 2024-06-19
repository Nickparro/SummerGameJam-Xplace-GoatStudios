EXTERNAL ChangeState(stateName)

Oh, I'm so sorry. I didn't see you there.#speaker:Dannte #portrait:Dannte
No harm done.#speaker:Lady #portrait:Lady
You seem distressed.
Is everything alright?
    *[Trust her]
        ~ChangeState("Trust Lady")
        My son... he was just murdered in our room. I don't know what to do.#speaker:Dannte #portrait:Dannte
        That's terrible.#speaker:Lady #portrait:Lady
        I did hear some strange noises earlier...
        And I saw a suspicious man heading down to the lower deck, towards the boiler room. #objective:Go to the boilers in the lower floor.
        You did? #speaker:Dannte #portrait:Dannte
        Can you describe him?
        Yes, he was tall, with a lean build.#speaker:Lady #portrait:Lady
        He had a peculiar way of walking, almost like he was trying to avoid attention.
        This is it. This is the lead I needed.#speaker:Dannte #portrait:Dannte
        Thank you.
        You've been very helpful.
        What's your name?
        Vivian. And yours?#speaker:Lady #portrait:Lady
        Dannte. Thank you, Vivian. I won't forget this.#speaker:Dannte #portrait:Dannte
        Be careful, Dante.#speaker:Lady #portrait:Lady
        The boiler room is not a place for the faint-hearted.
        I will. And I'll find him. I owe him that.#speaker:Dannte #portrait:Dannte
        ->DONE
        
    *[Don't trust her]
        ~ChangeState("Kitchen Lady")
        
        ... #speaker:Dannte #portrait:Dannte
        Yes, everything is alright.
        Ok, be careful next time!#speaker:Lady #portrait:Lady
        ->DONE
        