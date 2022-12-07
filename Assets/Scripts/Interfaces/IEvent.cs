using UnityEngine;
public interface IEvent {
		void Trigger(InputItem inputItem);
		void TriggerEvent(KeyCode direction, InputState state);
}
