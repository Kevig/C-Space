public class Action_CameraZoom : Action, IZoom {

	public ZoomControl zoomControl { get; set; }
	
	public Action_CameraZoom(ZoomControl control) {
		this.zoomControl = control;
		this.EventListeners();
	}

	public void Start() { }

	private void EventListeners() {
		CameraZoom.Zoom_In += this.zoomControl.In;
		CameraZoom.Zoom_Out += this.zoomControl.Out;
	}
}
