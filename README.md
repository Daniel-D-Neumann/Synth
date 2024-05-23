# Synth Tool
## How to use the tool
### Music Generation
- Clicking on a button will make it the selected button and also switch whether the note in that position will be generated or not.
- From here the buttons at the top of the program can be used to edit the details of the selected note
- Note Activated? will change whether the note will be activated or not
- Note Held? determines whether the note will be held down onto the next note or not (The next note must also check the note held button to continue holding the note down, but the volume is based on the first note to be held)
- Note Volume is a slider for 1 - 10 that sets how loud the note will play 
![image](https://github.com/Daniel-D-Neumann/Synth/assets/115144777/b8983a20-97fa-43df-bc09-b8ae9694a76a)

### Navigation
- **Octave**
  : Selecting the buttons 1 - 6 will change what the selected note will play it's octave at. Octaves at 2 and below are very low and should ideally be used for base noises alone.
    
  ![image](https://github.com/Daniel-D-Neumann/Synth/assets/115144777/9dde9c98-0e43-4a4e-80d5-18c22918566c)

- **Generator Type**
  : Selecting the tabs: Sin, Saw, Square, Triangle, White, Pink will change what wave type is used to play the selected note

  ![image](https://github.com/Daniel-D-Neumann/Synth/assets/115144777/742b1645-1f50-455f-ae78-05cbec50b504)

  
- **Page**
  : Selecting the buttons 1 - 15 will change when the note will play, 1 at (0,0) is the first note to be played, 15 at (7,0) is the last note to be played

  ![image](https://github.com/Daniel-D-Neumann/Synth/assets/115144777/d4997144-dca4-47c2-a32e-fdb3df8939a1)

### Generation
- Pressing the Generate button at the bottom of the program will generate music based on the selected notes from the grid above. Notes that play at the same time will be overlayed with each other. Try adjusting the volume of notes you find difficult to hear.
- In order to play or export your selected music it must first be generated using this button. After playing or exporting the audio must be re-generated.

![image](https://github.com/Daniel-D-Neumann/Synth/assets/115144777/5ed68bc7-59a4-47f1-a6a5-3e8aeb3adc21)

### Playback
- Pressing the Play button will play the currently generated music on a seperate thread.
- If you have not pressed the generate button you will not be able to press the play button.

  ![image](https://github.com/Daniel-D-Neumann/Synth/assets/115144777/8e09081d-164d-4ae6-b747-5cd736f2d034)

### Exporting
- Pressing the Export as WAV button will save your generated music to the Output folder
- If the filename provided for your output is invalid the program will prompt you with what is wrong with it
- If you have not pressed the generate button you will not be able to export

![image](https://github.com/Daniel-D-Neumann/Synth/assets/115144777/f498ddfb-b493-4e24-9789-071d3818efff)

##
Enjoy! ☺
