using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    //References to the AudioMixer for game volume adjustments
    public AudioMixer audioMixer;

    //A reference to the dropdown menu for the resolutions so it can be dynamically updated
    public TMPro.TMP_Dropdown resoltionDropdown;

    //An array of resolutions that will be filled with all the resolutions the players monitor can use
    Resolution[] resolutions;

    private void Start()
    {
        //Fills the resolution array will all the users availible resolutions but checking and filtering out all different refresh rates.
        resolutions = Screen.resolutions;

        //Clears the the dropdown menu to start fresh each boot up of the game
        resoltionDropdown.ClearOptions();

        //A List of strings to hold all of the resolutions as text
        List<string> options = new List<string>();

        //An index for the players current screen resolution
        int currentResolutionIndex = 0;

        //A loop to go through all the resolutions in the resolution array and adds each availible resolution to the list as "1920 x 1080" etc
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + " " + resolutions[i].refreshRate + "Hz";
            options.Add(option);

            //A check to match an availible resolution with the players current resolution then sets the index as that resolution index
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        //Adds all the resolution strings to the dropdown - then adds the current resolution as the first option - then refreshes the dropdown
        resoltionDropdown.AddOptions(options);
        resoltionDropdown.value = currentResolutionIndex;
        resoltionDropdown.RefreshShownValue();
    }

    //Allows for volume change with a UI slider and is set up in the editor
    public void setVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    //Allows for the game quality to be changed and is set up in the editor
    public void setQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    //Allows for fullscreen changes from a checkbox and is set up in the editor
    public void setFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    //Allows for the resoltion to be changed from the drop down and is set up in the editor
    public void SetResolution(int resolutionIndex)
    {
        //Creates a variable of type Resolution and sets it as the wanted resolution from the resolutions array
        Resolution resolution = resolutions[resolutionIndex];

        //Sets the screens resolution as the wanted resolution
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
