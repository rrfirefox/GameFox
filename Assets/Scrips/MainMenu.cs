using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public Button btnStart;
    public Button btnSound;
    public Button btnExit;
    public AudioSource music;

    private bool musicOn = true;

    void Start()
    {
        // Cargar estado guardado del usuario
        musicOn = PlayerPrefs.GetInt("MusicOn", 1) == 1;

        // Aplicar el estado de sonido
        ApplyMusicState();

        // Reproducir m�sica solo si est� activada y no est� ya sonando
        if (musicOn && !music.isPlaying)
        {
            music.Play();
        }

        // Asignar funciones a los botones
        btnStart.onClick.AddListener(() => SceneManager.LoadScene("Test2")); // Cambia "Test2" por tu escena real
        btnSound.onClick.AddListener(ToggleMusic);
        btnExit.onClick.AddListener(() => Application.Quit());
    }

    void ToggleMusic()
    {
        // Cambiar estado y guardar preferencia
        musicOn = !musicOn;
        PlayerPrefs.SetInt("MusicOn", musicOn ? 1 : 0);

        // Aplicar cambios visuales y l�gicos
        ApplyMusicState();

        // Iniciar m�sica si se acaba de activar
        if (musicOn && !music.isPlaying)
        {
            music.Play();
        }
    }

    void ApplyMusicState()
    {
        // Mutea o desmutea el audio
        music.mute = !musicOn;

        // Cambiar texto del bot�n seg�n estado
        btnSound.GetComponentInChildren<TMP_Text>().text = musicOn ? "Silenciar M�sica" : "Activar M�sica";
    }
}
