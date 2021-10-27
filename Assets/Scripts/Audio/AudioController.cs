using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    //members
    public static AudioController instance;

    public bool debug;
    public AudioTrack[] tracks;

    private Hashtable m_AudioTable; //relationship between audio sounds (key) and audio tracks (value)
    private Hashtable m_JobTable; // relationship between audio sounds (key) and jobs (value)

    [System.Serializable]
    public class AudioObject {
        public GameSoundEnum sound;
        public AudioClip clip;
    }

    [System.Serializable]
    public class AudioTrack {
        public AudioSource source;
        public AudioObject[] audio;
    }

    private class AudioJob {
        public AudioAction action;
        public GameSoundEnum sound;

        public AudioJob(AudioAction _action, GameSoundEnum _sound){
            action = _action;
            sound = _sound;
        }
    }

    private enum AudioAction {
        START,
        STOP,
        RESTART,
        ONESHOT
    }

#region Unity Functions
    private void Awake() {
        //instance
        if (!instance){
            Configure();
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene ();
        string sceneName = currentScene.name;

        switch (sceneName)
        {
            case "MainMenu":
                instance.PlayAudio(GameSoundEnum.Music_Main_Menu);
                break;
            case "MainMenu1":
                instance.PlayAudio(GameSoundEnum.Music_Main_Menu);
                break;
            case "Gameplay":
                instance.PlayAudio(GameSoundEnum.Music_Level);
                break;
            default:
                break;
        }
    }

    private void OnDisable() {
        Dispose();
    }
#endregion

#region Public Functions
//Three different jobs
    public void OneShot(GameSoundEnum _sound){
        AddJob(new AudioJob(AudioAction.ONESHOT, _sound));
    }

    public void PlayAudio(GameSoundEnum _sound) {
        AddJob(new AudioJob(AudioAction.START, _sound));
    }

    public void StopAudio(GameSoundEnum _sound) {
        AddJob(new AudioJob(AudioAction.STOP, _sound));
    }

    public void RestartAudio(GameSoundEnum _sound) {
        AddJob(new AudioJob(AudioAction.RESTART, _sound));
    }


#endregion

#region Private Functions

    private void Configure(){
        instance = this;
        m_AudioTable = new Hashtable();
        m_JobTable = new Hashtable();
        GenerateAudioTable();
    }

    private void Dispose(){
        foreach (DictionaryEntry _entry in m_JobTable) {
            IEnumerator _job = (IEnumerator)_entry.Value;
            StopCoroutine(_job);
        }
    }

    private void GenerateAudioTable() {
        foreach(AudioTrack _track in tracks) {
            foreach(AudioObject _obj in _track.audio){
                //do not duplicate keys
                if (m_AudioTable.ContainsKey(_obj.sound)) {
                    LogWarning("You are trying to register audio ["+_obj.sound+"] that has already been reigstered.");
                } else {
                    m_AudioTable.Add(_obj.sound, _track);
                }
            }
        }
    }

    public GameSoundEnum ConvertCustomerOrderStringToGameSoundEnum(string customerOrderString)
    {
        switch (customerOrderString)
        {
            //English

                //Order Hamburger
            case "I would like a hamburger":
                return GameSoundEnum.English_Order_Hamburger;
            case "I would like a hamburger with lettuce.":
                return GameSoundEnum.English_Order_Hamburger_Lettuce;
            case "I would like a hamburger with tomato.":
                return GameSoundEnum.English_Order_Hamburger_Tomato;
            case "I would like a hamburger with onion.":
                return GameSoundEnum.English_Order_Hamburger_Onion;
            case "I would like a hamburger with lettuce and tomato.":
                return GameSoundEnum.English_Order_Hamburger_Lettuce_Tomato;
            case "I would like a hamburger with lettuce and onion.":
                return GameSoundEnum.English_Order_Hamburger_Lettuce_Onion;
            case "I would like a hamburger with tomato and onion.":
                return GameSoundEnum.English_Order_Hamburger_Tomato_Onion;
            case "I would like a hamburger with lettuce, tomato, and onion.":
                return GameSoundEnum.English_Order_Hamburger_Lettuce_Tomato_Onion;
                //Order Chicken Doner
            case "I would like a chicken doner":
                return GameSoundEnum.English_Order_Chicken_Doner;
            case "I would like a chicken doner with lettuce.":
                return GameSoundEnum.English_Order_Chicken_Doner_Lettuce;
            case "I would like a chicken doner with tomato.":
                return GameSoundEnum.English_Order_Chicken_Doner_Tomato;
            case "I would like a chicken doner with onion.":
                return GameSoundEnum.English_Order_Chicken_Doner_Onion;
            case "I would like a chicken doner with lettuce and tomato.":
                return GameSoundEnum.English_Order_Chicken_Doner_Lettuce_Tomato;
            case "I would like a chicken doner with lettuce and onion.":
                return GameSoundEnum.English_Order_Chicken_Doner_Lettuce_Onion;
            case "I would like a chicken doner with tomato and onion.":
                return GameSoundEnum.English_Order_Chicken_Doner_Tomato_Onion;
            case "I would like a chicken doner with lettuce, tomato, and onion.":
                return GameSoundEnum.English_Order_Chicken_Doner_Lettuce_Tomato_Onion;

            //Albanian

                //Order Hamburger
            case "Un� dua nj� hamburger":
                return GameSoundEnum.Albanian_Order_Hamburger;
            case "Un� dua nj� hamburger me marule.":
                return GameSoundEnum.Albanian_Order_Hamburger_Lettuce;
            case "Un� dua nj� hamburger me domate.":
                return GameSoundEnum.Albanian_Order_Hamburger_Tomato;
            case "Un� dua nj� hamburger me qep�.":
                return GameSoundEnum.Albanian_Order_Hamburger_Onion;
            case "Un� dua nj� hamburger me marule dhe domate.":
                return GameSoundEnum.Albanian_Order_Hamburger_Lettuce_Tomato;
            case "Un� dua nj� hamburger me marule dhe qep�.":
                return GameSoundEnum.Albanian_Order_Hamburger_Lettuce_Onion;
            case "Un� dua nj� hamburger me domate dhe qep�.":
                return GameSoundEnum.Albanian_Order_Hamburger_Tomato_Onion;
            case "Un� dua nj� hamburger me marule, tomato, dhe qep�.":
                return GameSoundEnum.Albanian_Order_Hamburger_Lettuce_Tomato_Onion;

                //Order Chicken Doner
            case "Un� dua nj� doner pule":
                return GameSoundEnum.Albanian_Order_Chicken_Doner;
            case "Un� dua nj� doner pule me marule.":
                return GameSoundEnum.Albanian_Order_Chicken_Doner_Lettuce;
            case "Un� dua nj� doner pule me domate.":
                return GameSoundEnum.Albanian_Order_Chicken_Doner_Tomato;
            case "Un� dua nj� doner pule me qep�.":
                return GameSoundEnum.Albanian_Order_Chicken_Doner_Onion;
            case "Un� dua nj� doner pule me marule dhe domate.":
                return GameSoundEnum.Albanian_Order_Chicken_Doner_Lettuce_Tomato;
            case "Un� dua nj� doner pule me marule dhe qep�.":
                return GameSoundEnum.Albanian_Order_Chicken_Doner_Lettuce_Onion;
            case "Un� dua nj� doner pule me domate dhe qep�.":
                return GameSoundEnum.Albanian_Order_Chicken_Doner_Tomato_Onion;
            case "Un� dua nj� doner pule me marule, tomato, dhe qep�.":
                return GameSoundEnum.Albanian_Order_Chicken_Doner_Lettuce_Tomato_Onion;

            default:
                return GameSoundEnum.English_Order_Hamburger;
                
        }
    }
    private IEnumerator RunAudioJob(AudioJob _job) {
        AudioTrack _track = GetAudioTrack(_job.sound);
        _track.source.clip = GetAudioClipFromAudioTrack(_job.sound, _track);
        switch (_job.action) {
            case AudioAction.ONESHOT:
                _track.source.PlayOneShot(_track.source.clip);
            break;
            case AudioAction.START:
                _track.source.Play();
            break;

            case AudioAction.STOP:
                _track.source.Stop(); 
            break;

            case AudioAction.RESTART:
                _track.source.Stop();
                _track.source.Play();
            break;
        }

        m_JobTable.Remove(_job.sound);

        yield return null;
    }

    private void AddJob(AudioJob _job){
        //remove conflicting jobs
        RemoveConflictingJobs(_job.sound);

        // start job
        IEnumerator _jobRunner = RunAudioJob(_job);
        StartCoroutine(_jobRunner);
        m_JobTable.Add(_job.sound, _jobRunner);
    }

    private void RemoveJob(GameSoundEnum _sound){
        if (!m_JobTable.ContainsKey(_sound)){
            LogWarning("Trying to stop a job ["+_sound+"] that is not running.");
            return;
        }

        IEnumerator _runningJob = (IEnumerator)m_JobTable[_sound];
        StopCoroutine(_runningJob);
        m_JobTable.Remove(_sound);
    }

    private void RemoveConflictingJobs(GameSoundEnum _sound) {
        // cancel the job if one exists with the same sound
        if (m_JobTable.ContainsKey(_sound)) {
            RemoveJob(_sound);
        }

        // cancel jobs that share the same audio track
        GameSoundEnum _conflictAudio = GameSoundEnum.None;
        AudioTrack _audioTrackNeeded = GetAudioTrack(_sound, "Get Audio Track Needed");
        foreach (DictionaryEntry _entry in m_JobTable) {
            GameSoundEnum _GameSoundEnum = (GameSoundEnum)_entry.Key;
            AudioTrack _audioTrackInUse = GetAudioTrack(_GameSoundEnum, "Get Audio Track In Use");

            //TEMP WORKAROUND: fix me
            if (_audioTrackInUse == null || _audioTrackNeeded == null)
            {
                return;
            }

            if (_audioTrackInUse.source == _audioTrackNeeded.source) {
                _conflictAudio = _GameSoundEnum;
                break;
            }
        }
        if (_conflictAudio != GameSoundEnum.None) {
            RemoveJob(_conflictAudio);
        }
    }

    private AudioTrack GetAudioTrack(GameSoundEnum _sound, string _job="") {
        
        if (!m_AudioTable.ContainsKey(_sound)) {
            LogWarning("You are trying to <color=#fff>"+_job+"</color> for ["+_sound+"] but no track was found supporting this audio sound.");
            return null;
                }
        return (AudioTrack)m_AudioTable[_sound];
    }

    private AudioClip GetAudioClipFromAudioTrack(GameSoundEnum _sound, AudioTrack _track){
        foreach (AudioObject _obj in _track.audio){
            if (_obj.sound == _sound) {
                return _obj.clip;
            }
        }
        return null;
    }

    private void Log(string _msg){
        if (!debug) return;
        Debug.Log("[Audio Controller]: "+_msg);
    }

    private void LogWarning(string _msg){
        if (!debug) return;
        Debug.LogWarning("[Audio Controller]: "+_msg);
    }
#endregion

}
