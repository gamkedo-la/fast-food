using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    //members
    public static AudioController instance;

    public bool debug;
    public AudioTrack[] tracks;

    private Hashtable m_AudioTable; //relationship between audio types (key) and audio tracks (value)
    private Hashtable m_JobTable; // relationship between audio types (key) and jobs (value)

    [System.Serializable]
    public class AudioObject {
        public AudioType type;
        public AudioClip clip;
    }

    [System.Serializable]
    public class AudioTrack {
        public AudioSource source;
        public AudioObject[] audio;
    }

    private class AudioJob {
        public AudioAction action;
        public AudioType type;

        public AudioJob(AudioAction _action, AudioType _type){
            action = _action;
            type = _type;
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
//Three different jobs, job types
    public void PlayAudio(AudioType _type) {
        Debug.Log("should be actually playing, but instead adding?");
        AddJob(new AudioJob(AudioAction.START, _type));
    }

    public void StopAudio(AudioType _type) {
        AddJob(new AudioJob(AudioAction.STOP, _type));
    }

    public void RestartAudio(AudioType _type) {
        AddJob(new AudioJob(AudioAction.RESTART, _type));
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
                if (m_AudioTable.ContainsKey(_obj.type)) {
                    LogWarning("You are trying to register audio ["+_obj.type+"] that has already been reigstered.");
                } else {
                    m_AudioTable.Add(_obj.type, _track);
                    Log("Registering audio ["+_obj.type+"]");
                }
            }
        }
    }

    private IEnumerator RunAudioJob(AudioJob _job) {
        AudioTrack _track = GetAudioTrack(_job.type);
        Debug.Log(_track.source.clip);
        _track.source.clip = GetAudioClipFromAudioTrack(_job.type, _track);
        Debug.Log("inside RunAudioJob");
        switch (_job.action) {
            case AudioAction.START:
                _track.source.Play();
                Log("Playing "+_job.type);
            break;

            case AudioAction.STOP:
                _track.source.Stop(); 
            break;

            case AudioAction.RESTART:
                _track.source.Stop();
                _track.source.Play();
            break;
        }

        m_JobTable.Remove(_job.type);
        Log("Job count: "+m_JobTable.Count);

        yield return null;
    }

    private void AddJob(AudioJob _job){
        //remove conflicting jobs
        RemoveConflictingJobs(_job.type);

        // start job
        IEnumerator _jobRunner = RunAudioJob(_job);
        StartCoroutine(_jobRunner);
        m_JobTable.Add(_job.type, _jobRunner);
        Log("Adding job on ["+_job.type+"] with operation: "+_job.action);
    }

    private void RemoveJob(AudioType _type){
        if (!m_JobTable.ContainsKey(_type)){
            LogWarning("Trying to stop a job ["+_type+"] that is not running.");
            return;
        }

        Log("Removing job of [" + _type + "]");
        IEnumerator _runningJob = (IEnumerator)m_JobTable[_type];
        StopCoroutine(_runningJob);
        m_JobTable.Remove(_type);
    }

    private void RemoveConflictingJobs(AudioType _type) {
        // cancel the job if one exists with the same type
        if (m_JobTable.ContainsKey(_type)) {
            RemoveJob(_type);
        }

        // cancel jobs that share the same audio track
        AudioType _conflictAudio = AudioType.None;
        AudioTrack _audioTrackNeeded = GetAudioTrack(_type, "Get Audio Track Needed");
        foreach (DictionaryEntry _entry in m_JobTable) {
            AudioType _audioType = (AudioType)_entry.Key;
            AudioTrack _audioTrackInUse = GetAudioTrack(_audioType, "Get Audio Track In Use");
            if (_audioTrackInUse.source == _audioTrackNeeded.source) {
                _conflictAudio = _audioType;
                break;
            }
        }
        if (_conflictAudio != AudioType.None) {
            RemoveJob(_conflictAudio);
        }
    }

    private AudioTrack GetAudioTrack(AudioType _type, string _job="") {
        
        if (!m_AudioTable.ContainsKey(_type)) {
            LogWarning("You are trying to <color=#fff>"+_job+"</color> for ["+_type+"] but no track was found supporting this audio type.");
            return null;
                }
        Debug.Log("(AudioTrack)m_AudioTable[_type]: " + (AudioTrack)m_AudioTable[_type]);
        return (AudioTrack)m_AudioTable[_type];
    }

    private AudioClip GetAudioClipFromAudioTrack(AudioType _type, AudioTrack _track){
        Debug.Log("inside GetAudioClipFromAudioTrack");
        foreach (AudioObject _obj in _track.audio){
            if (_obj.type == _type) {
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
