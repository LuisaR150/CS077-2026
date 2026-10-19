Play Before load:
	Input/action: Click Play before loading media
	Predicted result: App handles the missing media without crashing
	Observed result: App handles the missing media without crashing. "Load a supported local file first"

Cancel file selection:
	Input/action: Open file picker and click Cancel.
	Predicted result: App remains usable; no unwanted file is loaded
	Observed result: File selection is able to be closed.

Supported media:
	Input/action: Select a supported media file and click Play.
	Predicted result: Media begins playing
	Observed result: media begins playing

Pause:
	Input/action: Click Pause during playback.
	Predicted result: Playback pauses
	Observed result: playback pauses

Stop:
	Input/action: Click Stop during playback.
	Predicted result: Playback stops
	Observed result: playback stops

Replay:
	Input/action: Play media again after stopping.
	Predicted result: Playback starts again
	Observed result: playback starts again

Invalid media:
	Input/action: Try selecting an unsupported or invalid media file.
	Predicted result: App handles the error without crashing
	Observed result: app handles the error, files are loaded yet obviously no audio plays

Blank URL:
	Input/action: Submit an empty URL.
	Predicted result: App rejects it or shows a clear message
	Observed result: a message shows saying to enter a valid link

Invalid URL:
	Input/action: Submit malformed or unsupported URL text.
	Predicted result: App rejects it or explains the problem
	Observed result: invalid urls handles safely

No selected link:
	Input/action: Click the open-link control without selecting a link.
	Predicted result: App handles the missing selection safely
	Observed result: app handles the missing selection safely

Valid browser link:
	Input/action: Select a valid HTTP/HTTPS link and open it.
	Predicted result: Link opens in the browser
	Observed result: link opens in the browser

Export:
	Input/action: Export or save the notes.
	Predicted result: File is created with the expected content
	Observed result: File is created with the expected content.

Reopen:
	Input/action: Open the exported notes file.
	Predicted result: Saved text appears correctly
	Observed result: saved text appears correctly.

Image cancel:
	Input/action: Open Choose artwork and click Cancel.
	Predicted result: Current artwork remains unchanged
	Observed result: current artwork remains unchanged.