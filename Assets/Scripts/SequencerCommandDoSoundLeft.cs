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

    public class SequencerCommandDoSoundLeft : SequencerCommand

    {
        public void Start()
        {

            string soundName = GetParameter(0);
            float delay = float.Parse(GetParameter(1));
            float volume = float.Parse(GetParameter(2));
            int loop = int.Parse(GetParameter(3));
            Vector3 pos = new Vector3(float.Parse(GetParameter(4)), float.Parse(GetParameter(5)), float.Parse(GetParameter(6)));
            Vector3 Endpos = new Vector3(float.Parse(GetParameter(7)), float.Parse(GetParameter(8)), float.Parse(GetParameter(9)));
            float tweenDuration = float.Parse(GetParameter(10));
            // Add your initialization code here. You can use the GetParameter***() and GetSubject()
            // functions to get information from the command's parameters. You can also use the
            // Sequencer property to access the SequencerCamera, CameraAngle, Speaker, Listener,
            // SubtitleEndTime, and other properties on the sequencer. If IsAudioMuted() is true,
            // the player has muted audio.
            //
            // If your sequencer command only does something immediately and then finishes,
            // you can call Stop() here and remove the Update() method:
            //

            InstanciateSound(soundName, delay, volume, loop, pos, Endpos, tweenDuration);

            

            
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

        void InstanciateSound(string eventName, float delay, float volume, int intBoolLoop, Vector3 pos, Vector3 endPos, float tweenDuration = 2)
        {

            GameObject newGO = new GameObject(eventName + "Emitter") as GameObject;//Instantiate(prefabEmitter, pos, Quaternion.identity) as GameObject;
            newGO.transform.position = pos;
            StudioEventEmitter newEmitter = newGO.AddComponent<StudioEventEmitter>() as StudioEventEmitter;
            newEmitter.Event = eventName;
            newEmitter.SetParameter("Volume", volume);
            if (endPos != Vector3.zero)
            {
                
                StartCoroutine(SoundCouroutine(newEmitter, delay, Vector3.zero, tweenDuration));
            }
            else
            {
                StartCoroutine(SoundCouroutine(newEmitter, delay, Vector3.zero, tweenDuration));
            }

            
        }

        IEnumerator SoundCouroutine(StudioEventEmitter emitter, float delay, Vector3 endPos, float tweenDuration)
        {
            yield return new WaitForSeconds(delay);
            UnityEngine.Debug.Log("sound played  " + emitter);
            emitter.gameObject.transform.DOMove(endPos, tweenDuration);
            emitter.Play();
            Stop();
        }

    }


}
