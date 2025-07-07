using System.Reflection;
using MicIndicator;
using Photon.Voice.Unity;

// using Everything;

internal class ConstantFields
{

    private static FieldInfo ampPeak = null;

    public static FieldInfo GetVoiceAudioField()
    {
        if (ampPeak == null)
        {
            var fields = typeof(Photon.Voice.AudioUtil.LevelMeterFloat).GetFields(
                BindingFlags.Instance | BindingFlags.NonPublic
            );
            foreach (var field in fields)
            {
                // Plugin.Logger.LogError(field.Name);
                if (field.Name.ToLower().Contains("amppeak"))
                {
                    // Plugin.Logger.LogError("FOUD  THING");
                    ampPeak = field;
                    break;
                }
            }
        }
        return ampPeak;
    }

    private static FieldInfo ampPeakShort = null;

    public static FieldInfo GetVoiceAudioFieldShort()
    {
        if (ampPeakShort == null)
        {
            var fields = typeof(Photon.Voice.AudioUtil.LevelMeterShort).GetFields(
                BindingFlags.Instance | BindingFlags.NonPublic
            );
            foreach (var field in fields)
            {
                // Plugin.Logger.LogError(field.Name);
                if (field.Name.ToLower().Contains("amppeak"))
                {
                    // Plugin.Logger.LogError("FOUD  THING");
                    ampPeakShort = field;
                    break;
                }
            }
        }
        return ampPeakShort;
    }
}
