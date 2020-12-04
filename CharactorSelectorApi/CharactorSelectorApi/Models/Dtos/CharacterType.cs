using System.ComponentModel;

namespace CharactorSelectorApi.Models.Dtos
{
    public enum CharacterType
    {
        Default,
        [Description("General")] General,
        [Description("Customise")] Customise
    }
}