using System.Collections.Generic;
using UnityEngine;

public delegate bool MessageHandlerDelegate(Message message);

public class MessagingSystem : SingletonComponent<MessagingSystem> {
    public static MessagingSystem Instance
    {
        get { return ((MessagingSystem)_Instance); }
        set { _Instance = value; }
    }

    private Dictionary<string, List<MessageHandlerDelegate>> _listenerDict = new Dictionary<string, List<MessageHandlerDelegate>>();
    private Queue<Message> _messageQueue = new Queue<Message>();
    private const int _maxQueueProcessingTime = 16667;
    private System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();

    public bool AttachListener(System.Type type, MessageHandlerDelegate handler) {
        if (type == null) {
            Debug.Log("MessagingSystem: AttachListener failed due to having no " + 
                      "message type specified");
            return false;
        }

        string msgType = type.Name;
        if (!_listenerDict.ContainsKey(msgType)) {
            _listenerDict.Add(msgType, new List<MessageHandlerDelegate>());
        }

        List<MessageHandlerDelegate> listenerList = _listenerDict[msgType];
        if (listenerList.Contains(handler)) {
            return false; // listener already in list
        }

        listenerList.Add(handler);
        return true;
    }

    public bool DetachListener(System.Type type, MessageHandlerDelegate handler) {
        if (type == null) {
            Debug.Log("MessagingSystem: DetachListener failed due to having no " + 
                      "message type specified");
            return false;
        }

        string msgType = type.Name;

        if (!_listenerDict.ContainsKey(type.Name)) {
            return false;
        }

        List<MessageHandlerDelegate> listenerList = _listenerDict[msgType];
        if (!listenerList.Contains(handler)) {
            return false;
        }
        listenerList.Remove(handler);
        return true;
    }

    public bool QueueMessage(Message msg) {
        if (!_listenerDict.ContainsKey(msg.type)) {
            return false;
        }
        _messageQueue.Enqueue(msg);
        return true;
    }

    public bool TriggerMessage(Message msg) {
        string msgType = msg.type;
        if (!_listenerDict.ContainsKey(msgType)) {
            Debug.Log("MessagingSystem: Message \"" + msgType + "\" has no listeners!");
            return false; // no listeners for message so ignore it
        }

        List<MessageHandlerDelegate> listenerList = _listenerDict[msgType];

        for (int i = 0; i < listenerList.Count; ++i) {
            if (listenerList[i](msg))
                return true; // message consumed by the delegate
        }
        return true;
    }

    void Update() {
        timer.Start();
        while (_messageQueue.Count > 0) {
            if (_maxQueueProcessingTime > 0.0f) {
                if (timer.Elapsed.Milliseconds > _maxQueueProcessingTime) {
                    timer.Stop();
                    return;
                }
            }

            Message msg = _messageQueue.Dequeue();
            if (!TriggerMessage(msg)) {
                Debug.Log("Error when processing message: " + msg.type);
            }
        }
    }
}