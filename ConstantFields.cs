using System.Reflection;
using MicIndicator;
using Photon.Voice.Unity;
// using Everything;

internal class ConstantFields
{

    private static PropertyInfo infiniteStamina = null;
    public static PropertyInfo GetInfiniteStaminaField()
    {
        if (infiniteStamina == null)
        {
            var fields = typeof(Character).GetProperties();
            foreach (var field in fields)
            {
                if (field.Name.ToLower().Contains("infinitestam"))
                {
                    // Plugin.Logger.LogError("FOUD  THING");
                    infiniteStamina = field;
                    break;
                }
            }
        }
        return infiniteStamina;
    }

    private static FieldInfo ampPeak = null;
    public static FieldInfo GetVoiceAudioField()
    {
        if (ampPeak == null)
        {
            var fields = typeof(Photon.Voice.AudioUtil.LevelMeterFloat).GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
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

    private static FieldInfo fallDamageTime = null;
    public static FieldInfo GetFallDamageTime()
    {
        if (fallDamageTime == null)
        {
            var fields = typeof(CharacterMovement).GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var field in fields)
            {
                Plugin.Logger.LogError(field.Name);
                if (field.Name.ToLower().Contains("falldamagetime"))
                {
                    // Plugin.Logger.LogError("FOUD  THING2");
                    fallDamageTime = field;
                    break;
                }
            }
        }
        return fallDamageTime;
    }

}