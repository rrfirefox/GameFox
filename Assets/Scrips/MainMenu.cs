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

        // Reproducir música solo si está activada y no está ya sonando
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

        // Aplicar cambios visuales y lógicos
        ApplyMusicState();

        // Iniciar música si se acaba de activar
        if (musicOn && !music.isPlaying)
        {
            music.Play();
        }
    }

    void ApplyMusicState()
    {
        // Mutea o desmutea el audio
        music.mute = !musicOn;

        // Cambiar texto del botón según estado
        btnSound.GetComponentInChildren<TMP_Text>().text = musicOn ? "Silenciar Música" : "Activar Música";
    }
}
