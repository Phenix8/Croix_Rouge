/* [REMOVE THIS LINE]
 * [REMOVE THIS LINE] To use this template, make a copy named SequencerCommand<YourCommand>, where
 * [REMOVE THIS LINE] "<YourCommand>" is the name of your sequencer command. Example: For a command
 * [REMOVE THIS LINE] named Foo, name the script SequencerCommandFoo.
 * [REMOVE THIS LINE]
 * [REMOVE THIS LINE] Then remove the lines that start with "[REMOVE THIS LINE]" and add your code
 * [REMOVE THIS LINE] where the comments indicate.
 * [REMOVE THIS LINE]*/
using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;
using FMODUnity;
using FMOD;
using DG.Tweening;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{

    public class SequencerCommandStopNormalSoundPlaying : SequencerCommand

    {
        public void Start()
        {

            string soundName = GetParameter(0);
            
            // Add your initialization code here. You can use the GetParameter***() and GetSubject()
            // functions to get information from the command's parameters. You can also use the
            // Sequencer property to access the SequencerCamera, CameraAngle, Speaker, Listener,
            // SubtitleEndTime, and other properties on the sequencer. If IsAudioMuted() is true,
            // the player has muted audio.
            //
            // If your sequencer command only does something immediately and then finishes,
            // you can call Stop() here and remove the Update() method:
            //

            StopSound(soundName);

            UnityEngine.Debug.Log("TEEEEEST  " + soundName);

            this.Stop();
        }

        public void Update()
        {
            // Add any update code here. When the command is done, call Stop().
            // If you've called stop above in Start(), you can delete this method.
        }

        public void OnDestroy()
        {
            // Add your finalization code here. This is critical. If the sequence is cancelled and this
            // command is marked as "required", then only Start() and OnDestroy() will be called.
            // Use it to clean up whatever needs cleaning at the end of the sequencer command.
            // If you don't need to do anything at the end, you can delete this method.
        }
           
        void StopSound(string soundName)
        {
            GameObject target = GameObject.Find(soundName + "Emitter");            
            target.GetComponent<AudioSource>().Stop();
            UnityEngine.Debug.Log("Stop " + soundName);
            Destroy(target);
        }



    }


}
