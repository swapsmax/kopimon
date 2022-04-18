## Welcome to Kopimón's Github Wiki

Kopimon is a pixelised, Singapore-themed, role-playing game with multiplayer capabilities. 

What is the aim of this game? It's simple, we promise! You start with a starter kopimon, and explore the world around. As you walk around, you will be handed quests by non-player characters (NPCs) which will lead to rewards and other locations being unlocked. Fight other wild enemy kopimons, defeat them and emerge victorious as you level up. Are you willing to do what it takes to save the world of Kopimon from the pandemic?


## Table of Contents



## Background and Motivation

Gathertown was a widely used platform that offered a virtual space and meeting room, especially during remote working and socialising during the COVID-19 pandemic. The platform was welcomed by many communities around the world as it created opportunities of conferencing and socialising during a time when many did not think such forms of human interaction were possible. It made the best out of a difficult time where face-to-face interactions were difficult.

Another application which caught our attention was Pokemon. Pokemon is the app that the first version was based off of, a simple tile-based pixel game that has lasted many decades. This led us to be curious about why this was so, and we were intrigued to know why such a simple game was so widely popular, bridging across generations. We were curious to see if we could recreate a similar game with simple-looking functions that are actually not easy to code and design.



## Objectives

Create an application or software that best emulates the experience that Gathertown created during the pandemic. The application we would like to use is a game - relevant and relatable to Singaporeans of all age groups regardless of their differences. Game has to be simple and easy to understand, and easy on the eye for that purpose. We want to instil a sense of local pride or wonder at the unique elements that Singapore possesses. Highlighting the diverse melting pot of cultures and diversity in nature in Singapore. Emphasise on both the underappreciated aspects of Singapore as well (views-wise) and popular tourist attractions (world class, globally-renowned) 



## Review of Literature/Technology

“Pencils, Paints, or Pixels?: How Aesthetic Choices of Indie Games Affect Interactive Experience” by Alvarez, Gonzalo (2016) 
This study talks about how indie games (i.e. pixel art and other hand-drawn art styles) survive in today’s world, despite the release of games with newer technologies such as photorealistic graphics and smooth animation. On pixel art specifically, the author mentioned that there is a sense of nostalgia when such an art style is used. It is said that the classics of video games are built on pixel art. In the early beginnings of the game history, most games were made using pixel art. As time passed, less and less people would have lived in the early era of video games and are exposed to more advanced technology such as 3D graphics or virtual reality. Nostalgia would be less of an influence to entice gamers to play pixel-art games. Born from hardware limitations, pixel art has now instead become an artistic choice to build a certain atmosphere of the game scene and bring an unique aesthetic to the game. The Last Night by the Odd Tales is one such game that had a breakthrough by creating cinematics visuals with pixel art. As Pokemon was first released in 1996, and is still highly raved about, we want to bring back this nostalgic game to many but more relatable in the Singapore context.

“Once upon a game: Exploring video game nostalgia and its impact on well-being.” by Tim Wulf, Nicholas D. Bowman, John A. Valez, Johannes Breuer (2020)	
This study explores the psychological effects and benefits of past-related gaming, which considers storylines, graphics, and other aspects of games which might invoke nostalgia in the user. It was found that past memories are more strongly associated with stronger emotions, on both the enjoyment and challenge ends of the spectrums. Social memories are also closely linked to nostalgia.
https://psycnet.apa.org/record/2018-48742-001 - study of the psychological effects and benefits of past-related gaming, it was found that past memories more strongly associated with enjoyment and challenge (basically makes people feel more strongly) and social memories are more likely to involve close others.

This nostalgia, coupled with the pride of Singapore and its elements, can appeal to our target audience’s pathos. 



## Design & Implementation

**Design considerations/choice of components**

For previous designs, we felt that there were too many use cases, and decided to focus on one or two main elements to form a cohesive game that came together and served a specific purpose. This would allow our application to be more purposeful and for our design of both technical functionalities and artistic elements.
The decision to cut down on the quantity of components also allowed for a more specific cut down on the number of components to focus on a game on itself without other distractions or unnecessary elements. This allows us to zero in on what we found important, which was invoking a sense of pride.
We decided to use the Unity Game Engine - real time, cross-platform support, collaborative, C++ - as we were planning to create a working game at the end of it. Unity also provides a high level of flexibility and modifiability in terms of the design and art. 

**Implementation**

UI Implementation

The native Unity UI allows for the assembling of sprites into scenes. We had a choice between implementing the sprites in a 2D or 3D form - so we decided to go with a 2.5D form factor as seen in the original Pokemon game. All sprites were assembled inside of Unity and the Object Colliders were created in order to prevent players or objects from going over each other which would make the game unrealistic.

User Authentication

In order to authenticate users logging-in to the game as well as handle the creation of user accounts, Firebase was used. This allowed us to maintain a secure authentication and transmission of the user data into the database as well as allow for flexibility in creating functions such as ‘password reset’.

Collaboration

Working together is crucial in any project. Unity Collaborate, Plastic SCM, and GitHub were used for the development of this game. Unity Collaborate and Plastic SCM enabled us to save, share, and sync our Unity Project in a cloud-hosted environment. Using Collaborate allowed the entire team to contribute to a Project, regardless of location or role. GitHub also made it possible for multiple people to push changes to the main file and create pull requests to pull new changes made by others onto their computer to further work on the latest version of the project.

Game Development

This game was developed on the Unity Game Engine. Unity is a cross-platform game engine developed by Unity Technologies, which is primarily used to develop video games and simulations for computers, consoles and mobile devices. When it comes to graphics, Unity is known for its high quality, next-level visual effects. The highly customizable rendering technology that the game engine offers, along with a variety of intuitive tools, facilitate the creation of fantastic looking games. Therefore, we took advantage of the many Unity features such as Collaborate, Assets and more to build this game for cross-compatibility with Windows and Mac devices. It also allowed us to code custom features for our game using C#, making the development of the game a flexible and creative process.

Asset Creation

Pixilart was used in the asset creation of all the pixel-art in the game. This includes the entire UI of the game (excluding Login scene background, chat boxes, and text fields in the login and multiplayer screens). The flexibility in choosing the dimensions of our art in terms of pixels really allowed us to define our own height and width as well as the quality of the designs we want to make - whether it be more pixelated or less. 


**Excluded features**

Video Chat Function

A functioning video chat function for virtual meet-ups was built in the early stages of the game development by implementing the Agora frameworks. However, this was later temporarily discontinued in order to no0t further complicate the game mechanics as well as to achieve our objectives of making the game simple and easy to understand for everyone.



## Conclusion and Recommendation

**Conclusion**

In summary, our team was able to successfully deploy a single-player and multiplayer game as we intended to. By using modern technological tools and widely used, industry standard softwares and frameworks, we were successfully able to deploy all our intended features into the game and use collaborative technology to ensure efficiency in doing so. We were also successfully able to localise the game to the Singapore context and design custom assets for it in order to beautify the game UI and make it visually beautiful and appealing to players.


**Limitations**

Since this game was created with the intention of single-player and that multiplayer functions were added afterwards, this makes it difficult to add other frameworks and functions involving multiplayer and more servers as the different frameworks may not necessarily be compatible and work together to transmit and pull the same information from the database. This would inevitably require anyone to have to pay for their own server and host the game on it plus re-do chunks of code in the game for the compatibility and for the game to work smoothly if more multiplayer features are to be added.

**Recommendation for Future Works**

There can be an expansion of the maps, adding on more elements such as views and animals. This essentially means having a greater pool of elements that allow for more variations of challenges or adding depth to the storyline(s), all while using the same functions that are already implemented.
Additional features can be further introduced as well, developing the multiplayer side of the game to allow for collaborative party quests. This will mean a greater level of interaction between players.
Customization of characters and Kopimons can be included at the homes of the players. This can be a form of motivation for players to play the game more and grow more attached to their own character in the game.
To be more user-friendly for players, functional buttons like user manual, settings, and exit battle can be added to the game UI. Wit the UI improved and functional buttons more complete, the game shall provide a better experience for players in the future. 


