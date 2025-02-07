# Process Journal
**Reminders**

![this is a photo of xys](Media/stick-bug-get-stickbugged-lol.gif)

[this is a link](https://www.youtube.com/watch?v=dQw4w9WgXcQ)

**bold**

_italics_

[project for class today](//Projects/Journal.md)

## January 23rd - Make a thing

#### Thoughts about Twine and using Twine as an engine
- I want to take advantage of the fact that it is mostly 
imagination and written.
- trying to make the hyperlink not too clunky ? and try 
  and integrate it.
- maybe dive into a possible idea for a future project in 
  this class?

#### Ideas/concepts
1. A blind detective or someone that does not see well 
conventionally

2. A communication device with someone like lifeline 
   game 2015 type deal
   - journal of someone magical type ( feeling like a 
      conversation) (learning about that world)
   - Someone in trouble and only communication grounded in 
     real life ( basically a puzzle game but with additional steps and a proxy.)
   - log of a crew or something that is increased making you on the edge of your seat ( so just a book but instead a making it “electronic”)

#### playtest-ish feedback

- reading is long lmao 
- someone who finished it and knew about mythology 
- liked the idea of helping someone in communication 
- More hints of what the mural and story mean since it wasn’t too obvious 
- People used the back around immediately, maybe making a save to go back or take advantage of it. People would go back with that arrow instead of setting up something. 
- People doesn't stay on the death screen too long, so if there is a timed even,t don’t make it too long


## January 30rd
[This week's project](https://github.com/Noe235/CART315/tree/main/Projects/Week%202%20FaillingAsleep/FallingAsleep) <br>

Idea for a collector type of game. 
Ideas:
- A dodging type of game like subway surfers?
- A beginning of a rhythm game like prosekai
- A simple collection game nothing fancy
- A game where you grow bigger when you eat things

probably going to try and do the prosekai-ish. So restraining the player to a specific position. The position will be stored in an array probably like this:
myPos []= new position maybe vector 3?

then do the same for the dropper and change the frequency.
change the sprite for a guitar and notes
adding some sound and a little menu page just to start it.


Testing out the code tonight and if it doesn’t work going back ot the basic collecting game


_**REMINDER FOR NOE**_ <br>
if you have a number with points, and you have this error <br>
``Cannot convert expression of type 'double' to type 'float'`` <br>
you need to put “f” at the end of the number to tell it its a float still

### Process
Lots of random error that I am not even sure why it happened <br>
Errors like: 
- ``Null reference type``
- ``Cannot acess a non-static method``
- ``Play OneShot``

The rest was alright, I had forgotten how to access a array but got my 
friend to help me out.<br>
I found some nice assets on Craftpix to give a bit of personality to the 
little exercise. +the sound effects were not too hard to implement <br>
I kind of see this as a little game that each row does a sound and ten you 
can make some music or have it randomized and making some non-scripted music 
but still sounding good. <br>
I did use the pentatonic scale on C3 to get some notes that would not sound 
dissonant from one another.<br>

### Future implementations
Possible implementations that I would like or center around something
- Making random prefabs that would be chosen to fall down.
- attaching the note to the line that it is falling from.
- making or finding a minecart sprite
- adding bg music to have the notes have a bg
- adding start and end state

### Class
Feedback tips for future journal entry
- use EZGIF to add some gif and take photos of the process <br>
Which reminds me I should have put that as a byproduct of not being able to 
  use playoneshot, I used playatthispoint and got a slight pan on the sound<br>

Prototypes kind
- look/feel
  - non functional really just to show
- roles
  - user flow, kickstarter videos
- implementation
  - really trying how it feel while being functional. <br>

Prototype goals

- to understand
- to communicate
- 

**all to answer a question**

## Feb 4th-6th
[This week's project Pong](https://github.com/Noe235/CART315/tree/main/Projects/Week%203%20Pong/pawngTemplate)  <br> 

### ideation
I was thinking about games like it takes two and chained together as a pon 
variant where you would work together. So with this in mind I was looking of 
how to make a rope that would constraint the players as I can think how I 
can constraint the player with most likely some math to calculate the 
distance and put a maximum to to but I wasn't sure how to illustrated it. So 
I found this video and I am using the rope bridge part but without the 
capsule collider so I can show visually if they are too far. <br>

![games](Media/Chained.webp)

![gameFred](Media/breadandfred.jpg)

Video used:

[Rope video/physics?](https://www.youtube.com/watch?v=iGlD3f-5JpA)

[checking distance between points](https://www.youtube.com/watch?v=VpK2NgmddkQ)

### Problems/ what left to do
- I can't figure out how I am going to attach the rope to the object
- I don't know how one I have reached the max distance i'll make the person 
  be able to not go further but still to move toward the other player
- Link the score to a text
- maybe add color or sound?
- maybe add end screen and restart
- add high score?

I discovered the magic of joints and hinge though. They seem really useful 
to know about just not fully sure I understand how to make them work with an 
object that is not static.

Alright change of plan we are making a who can hit hte ball the most and 
seperating the screen in two. I changed idea since I couldn't do the chain 
and I didn't want to go back to the same orignal game.

I want to add some ball to appear over time but for now everything works so 
I'll add it after commit

tiny problem the score are on the balls, but its fixed I got the middle wall 
to have the scoring script that access the variable of each ball to then put 
the scores together, there is defenitly a better way to do this but since I 
don't have much time nad we kind of already know we fucked up by putting 
everything on the ball we knew that its wasn't that efficient.

### possible improvements 
- add a game over screen maybe with lives
- OMG THE SPEED OF THE PADDLE CHANGES WITH SCREEN SIZE, probably do something 
  about that
- add that more ball will spawn over time, could have been possible but 
  would need to rearrange some components and make new scripts.
- sometime the ball gets stuck horizontally

![ponggame](Media/Ponggame.gif)

### Class

push error: 
- 1 if the original files are different and were not pulled
- push fail because of too big file: bottom right git icon, you can undo it 
- third party is for asset store and things oyu don't want to share

bit trip beat