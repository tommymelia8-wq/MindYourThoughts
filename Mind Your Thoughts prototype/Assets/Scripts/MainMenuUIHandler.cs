using UnityEngine;
using UnityEngine.SceneManagement;
///
/// Controls the main menu buttons and loading new scenes
/// 
public class MainMenuUIHandler : MonoBehaviour
{
     // loads the  game scene
   public void Play()
   {
        SceneManager.LoadScene("GameScene");
   }

     // Loads the tutorial scene
   public void Tutorial()
   {
        SceneManager.LoadScene("Tutorial");
   }

     // shows player controls
   public void Controls()
   {
     // moves camera to show controls, allows player to change controls
   }

     // closes the game
   public void Quit()
   {
        Application.Quit();
   }
}
