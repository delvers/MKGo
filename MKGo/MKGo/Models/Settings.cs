// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace MKGo
{
  /// <summary>
  /// This is the Settings static class that can be used in your Core solution or in any
  /// of your client applications. All settings are laid out the same exact way with getters
  /// and setters. 
  /// </summary>
  public static class Settings
  {
    private static ISettings AppSettings
    {
      get
      {
        return CrossSettings.Current;
      }
    }

    #region Setting Constants

    private const string CurrentTourKey = "currentTour";
    private static readonly string CurrentTourDefault = string.Empty;

    #endregion


    public static string currentTour
    {
      get
      {
        return AppSettings.GetValueOrDefault<string>(CurrentTourKey, CurrentTourDefault);
      }
      set
      {
        AppSettings.AddOrUpdateValue<string>(CurrentTourKey, value);
      }
    }


  }
}