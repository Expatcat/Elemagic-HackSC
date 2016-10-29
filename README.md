# Elemagic-HackSC
Unity, Oculus Rift, and Myo Project created at HackSC

Project Overview:
  Our team at HackSC used the Oculus Rift, the Myo Armband, and
  Unity Engine to create a virtual environment that the user can
  interact with. The player will be able to use the power of fire,
  water, earth, and air in order to experience the full functionality
  of the Myo Armband, all while inside an Oculus Rift. This includes
  launching fireballs, firing boulders, shooting streams of water, and
  even flying, all without touching a keyboard.
  
Technical Description:
  In order to grant the user control over different elements, we
  used the gesture functionality of Myo Armband and created Elemagic
  so that, with a simple outstretch of the hand, a fireball would
  emerge from the in-game player's arm. Integrating the Myo into
  Unity was actually rather simple, for the engine can already detect
  poses, and all that we, as developers, had to do, was write conditional
  statements based on what pose the Myo was recognizing. From there,
  scripts that we wrote would create a projectile, or transform the player,
  to give the illusion of firing objects or flying. In this sense,
  gesture control with the Myo simply replaced key presses. The Oculus
  itself came with a prefab that we only had to drop into Unity, and from there,
  it would act as a main camera.

