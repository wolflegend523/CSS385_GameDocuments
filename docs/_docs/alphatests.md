---
permalink: /alphatests/
title: Alpha Playtests
layout: single
sidebar: 
  nav: "docs"
---

For the **Alpha** version of our game, we implemented the combat system. We did not have enemy AI yet, so it was a 2-player game. Players could move, attack, and kill the opposing characters. 

&nbsp;  
# 5/8/2023 Playtest
## Summary
We conducted a playtest with our classmates on May 8, 2023. This playtest had 19 playtesters and used the in-class google forms sheet to collect feedback.
- AVG Fun rating: 4.11 / 5.0
- AVG Innovation rating: 4.17 / 5.0
- AVG Technical Challenge rating: 4.67 / 5.0

## Analysis
#### What Players Liked
- Many of the players mentioned they liked the art, visuals, battle map, and animations
- Some players mentioned that pathfinding and movement mechanic was satisfying and fun
- Two players mentioned they liked the strategy that comes from the different characters’ traits (birds fly, deer hit hard)
- One player mentioned that the controls were intuitive 

#### What Frustrated/Confused Players
- Many players were confused about how the turn system works and why they could only move one character per turn
- Many players wanted a tutorial system or more information about the state and controls of the game 
- Many players did not understand why the birds could move over obstacles
- Some players mentioned it was hard to tell how much damage characters were dealing
- Some players were confused about the game’s objectives
- Two players were frustrated they couldn't cancel their movement
- One player wanted some indication of how many squares a character could move
- One player wanted the grid to be more obvious

#### Small Bugs Mentioned
- Our deer characters did not yet have death animations or mechanics implemented, so they just went to negative health
- Once one of the eagle characters died it would break the turn system
- Our indicator UI elements for which characters can be selected blend into the background

&nbsp;  
# Conclusions
Here are some of our main takeaways and plans to implement the feedback we received:
- Add an end turn button so that players do not need to use all their movements to continue
- Add an undo movement button to allow backing out of a movement
- Add a tutorial box to explain the turn system and movement/attacking controls
- Make it clear how the player characters have different traits (e.g., birds can fly) by adding more UI elements
- Update indicators to make which characters can be moved clear
- Fix the deer and eagle death bugs
- Consider adding a grid overlay on top of the battle map
- Consider adding a scene at the beginning to explain the objectives


&nbsp;  
the raw results of the google forms document can be found [here.](https://docs.google.com/spreadsheets/d/1j6m5TQvm0KblXe3o7wGeTp_Ivj0Wv7WpBHxaITdI-jA/edit?usp=sharing)


