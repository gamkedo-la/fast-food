using System.Collections;
using System.Collections.Generic;
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
        RESTART
    }

#region Unity Functions
    private void Awake() {
        //instance
        if (!instance){
            Configure();
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void OnDisable() {
        Dispose();
    }
#endregion

#region Public Functions
//Three different jobs
    public void PlayAudio(GameSoundEnum _sound) {
        Debug.Log("should be actually playing, but instead adding?");
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
                    Log("Registering audio ["+_obj.sound+"]");
                }
            }
        }
    }

    private IEnumerator RunAudioJob(AudioJob _job) {
        AudioTrack _track = GetAudioTrack(_job.sound);
        Debug.Log(_track.source.clip);
        _track.source.clip = GetAudioClipFromAudioTrack(_job.sound, _track);
        Debug.Log("inside RunAudioJob");
        switch (_job.action) {
            case AudioAction.START:
                _track.source.Play();
                Log("Playing "+_job.sound);
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
        Log("Job count: "+m_JobTable.Count);

        yield return null;
    }

    private void AddJob(AudioJob _job){
        //remove conflicting jobs
        RemoveConflictingJobs(_job.sound);

        // start job
        IEnumerator _jobRunner = RunAudioJob(_job);
        StartCoroutine(_jobRunner);
        m_JobTable.Add(_job.sound, _jobRunner);
        Log("Adding job on ["+_job.sound+"] with operation: "+_job.action);
    }

    private void RemoveJob(GameSoundEnum _sound){
        if (!m_JobTable.ContainsKey(_sound)){
            LogWarning("Trying to stop a job ["+_sound+"] that is not running.");
            return;
        }

        Log("Removing job of [" + _sound + "]");
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
        Debug.Log("(AudioTrack)m_AudioTable[_sound]: " + (AudioTrack)m_AudioTable[_sound]);
        return (AudioTrack)m_AudioTable[_sound];
    }

    private AudioClip GetAudioClipFromAudioTrack(GameSoundEnum _sound, AudioTrack _track){
        Debug.Log("inside GetAudioClipFromAudioTrack");
        foreach (AudioObject _obj in _track.audio){
            if (_obj.sound == _sound) {
                Debug.Log("_obj.clip: " + _obj.clip);
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