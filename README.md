# IT8010: IT Project - University of Cincinnati

## Project Synopsis
  This Unity project is part of a wider research project that investigates the process of designing engaging and educational video games. Often, educational video games suffer from a lack of resources; namely time, money, and professional expertise. Students are quick to notice that these games do not live up to the games they play in their free time and become uninterested in the game quickly. 
  The first part of the research analyzes existing titles such as *Kerbal Space Program*, *Variant: Limits*, and *Minecraft* that deliver an exciting game-based learning experience. What makes these titles, and the others analyzed, different from most educational games? What makes them engaging and exciting to students? Guidelines were crafted to capture the aspects of these games that made them both engaging experiences and effective learning tools. 
  To display how these guidelines can be utilized, a game mechanic was designed using the guidelines. The game mechanic gives players the ability to change factors of the sinusoidal function specific objects are moving with. Players can see how the object’s movement and the 2D graph displayed on the game UI updates as factors are changed. The objective of the tool is to give students a better understanding of how sinusoidal functions behave. The game mechanic could be placed in a larger game that would teach mathematics to secondary students in an engaging and immersive experience. More details on what the larger game could look like are included in the Future Work section. The game mechanic, also known as the “Wave Tool”,  is what is included in this Unity project. 

## Important Information
Unity Verion: `2020.3.5f1`
Prototype Scene: `\StarterAssets\ThirdPersonController\Scenes`

## Research Questions
  The first research question below is answered by the construction of a set of guidelines after analyzing video games that have effectively used game-based learning. These guidelines can be viewed in the paper and are presented in the presentation as well.

**Q1** What elements of video games using digital game-based learning make them effective in engaging students and teaching at the same time? 

The second research question is answered by the design of the “Wave Tool.” A brief of the design process is included below. To see the details, please refer to the paper and/or presentation.

**Q2** How can an engaging and effective game mechanic be designed to teach high school mathematics? 

## Problem Statement
  Mathematics courses remain some of the most difficult work for students in secondary and higher education institutions. Performing poorly in mathematics discourages students from pursuing STEM careers. There is no concrete consensus as to why students in the U.S. tend to score the lowest in mathematics, however many hypothesize it has to do with the dry and repetitive teaching style mathematics is typically taught. These methods typically focus on getting students to memorize material for examinations instead of teaching critical thinking and problem-solving skills. To address these issues, researchers have long considered the use of video games as supplemental teaching material.

## Design/Implemendation Methodology
  To begin designing the wave tool, the learning objectives were solidified and then mapped to specific elements of the game mechanic (these can be viewed in the paper). There were also several non-functional requirements recorded for the design of the game mechanic which addressed the guideline concerning aesthetics (see the paper included above for more details). Once the functional and non-functional requirements were laid out, the game mechanic functionality was mapped out.
*Wave tool functionality flow:*
1. Activate the wave tool
  - Left trigger on gamepad
  - Right mouse button on desktop
2. Objects in the environment that can be changed by the wave tool are highlighted
3. As the player hovers over an intractable object, the object changes a different color
4. While hovering over an intractable, the player fires the wave tool
East Button on gamepad
  - F key on desktop
5. UI opens on the right hand of the player’s screen. Contains a 2D graph of the sinusoidal function currently representing the object’s movement as well as the function itself. There are text boxes where the player may change the function’s values.
6. As the player changes values in the function, the 2D graph is updated and the object’s movement also updates to match the new values.  
7. The player can exit the tool
  - South button on gamepad
  - F key on desktop

  After the game mechanic design was mapped out, a high-fidelity prototype was made in Unity Game Engine version 2020.3.5f1.

## Limitations & Implications
  The big limitation faced during this research was resources. There were approximately three and a half months to develop a research problem, complete research, and write this paper while at the same time designing and developing a prototype. In addition, all this work was completed by one individual who was a full-time student and working park time. 
	With limited time and a one-person team consisting of a full-time student, the idea of designing and prototyping a game even with just one level was off the table. Especially after spending time researching other games using game-based learning and learning about all the work that went into writing, designing characters, environments, gameplay, programming, and more to make an enjoyable and exciting gameplay experience on top of learning. I am not an expert in any of these areas, therefore I wanted to focus on creating the game mechanic that would be used to help teach high school students mathematics. After all, providing a new tool in the form of a video game to teach secondary mathematics was the impetus for this research in the first place. 
  However, the game mechanic was not designed without thinking about the larger game the tool could fit into. In fact, the game was brainstormed first and then the game mechanic was separated and developed in further detail to finish an aspect of the game for the project deadline. The preliminary idea of the action-adventure, puzzle game is included in Appendix D of the paper. The game idea is rather broad, but this leaves the game idea flexible to change as the game mechanics are tested and developed.

## Future Work
  Before more work is put into developing a larger game, however, the tool needs to undergo more research and testing. The current evaluation plan is designed to get initial feedback on the game mechanic prototype. Feedback will help determine if the feature is worth further research and development. Expected results are also discussed in the paper. It includes notes on how the 2D graph is being rendered currently and how it should be improved in the future (see the paper for details). Following this round of evaluation, a demo level with puzzles created for the wave tool will need to be created. Evaluations should then focus on determining how engaging and educational the mechanic truly is. The demo level will give players a better understanding of how the feature would be placed into an actual game and whether the gameplay is actually engaging and educational. 

## Conclusion
  Designing the “wave tool” serves as an example or motivation for other researchers and/or game developers on how to interweave game-based learning into engaging and exciting games. The process shows that with proper design, time, and expertise, education can be interwoven into appealing and exciting video games.
  Conclusions concerning research question 1 and the guidelines developed are discussed in the paper. 


## Credits
- Wave Tool Functionality Programming - Emily Bender 
- UI Design and Art Assets - Emily Bender 
- Third Person Controller and Environment - [Starter Assets - Third Person Character Controller] (https://assetstore.unity.com/packages/essentials/starter-assets-third-person-character-controller-196526#description)
