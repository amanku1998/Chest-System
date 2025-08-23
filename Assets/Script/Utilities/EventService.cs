using System;

public class EventService
{
    public EventController<SlotController> OnSlotSelect { get; private set; }
    public EventController<FailedStringType> OnFailedUnlock { get; private set; }

    public EventService()
    {
        OnSlotSelect = new EventController<SlotController>();
        OnFailedUnlock = new EventController<FailedStringType>();
    }
}

public class EventController<T>
{
    public event Action<T> baseEvent;
    public void InvokeEvent(T type) => baseEvent?.Invoke(type);
    public void AddListener(Action<T> listener) => baseEvent += listener;
    public void RemoveListener(Action<T> listener) => baseEvent -= listener;
}
