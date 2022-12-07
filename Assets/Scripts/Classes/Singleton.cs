using UnityEngine;

// Ref - https://blog.mzikmund.com/2019/01/a-modern-singleton-in-unity/
public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
	private static readonly System.Lazy<T> LazyInstance = new System.Lazy<T>(Create);
	private static T Create() {
		var owner = new GameObject($"{typeof(T).Name} (singleton)");
		var instance = owner.AddComponent<T>();
		DontDestroyOnLoad(owner);
		return instance;
	}
}