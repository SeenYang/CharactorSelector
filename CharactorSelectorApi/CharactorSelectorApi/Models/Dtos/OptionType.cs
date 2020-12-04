using System.ComponentModel;

namespace CharactorSelectorApi.Models.Dtos
{
    public enum OptionType
    {
        Default,
        [Description("General")] General,
        [Description("Customise")] Customise
    }
}