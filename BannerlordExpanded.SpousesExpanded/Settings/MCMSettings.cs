using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Base.Global;

namespace BannerlordExpanded.SpousesExpanded.Settings
{
    internal class MCMSettings : AttributeGlobalSettings<MCMSettings>
    {
        public override string Id => "BannerlordExpanded.SpousesExpanded";

        public override string DisplayName => "BE - Spouses Expanded";

        public override string FolderName => "BannerlordExpanded.SpousesExpanded";

        public override string FormatType => "xml";



        [SettingPropertyGroup("{=BE_SE_OP002}Player Polygamy", GroupOrder = 0)]
        [SettingPropertyBool("{=BE_SE_OP001}Enable", RequireRestart = true, IsToggle = true)]
        public bool PolygamyEnabled { get; set; } = true;

        [SettingPropertyGroup("{=BE_SE_OP003}I Dont Want Your Eldest Member", GroupOrder = 1)]
        [SettingPropertyBool("{=BE_SE_OP001}Enable", HintText = "{=BE_SE_OP004}Enable the option to choose any of the clan's marry-able characters for marriage instead of only the oldest one.", RequireRestart = true, IsToggle = true)]
        public bool DontWantEldestMemberEnabled { get; set; } = true;

        [SettingPropertyGroup("{=BE_SE_OP005}Marriage Offer For Player", GroupOrder = 1)]
        [SettingPropertyBool("{=BE_SE_OP001}Enable", RequireRestart = true, IsToggle = true)]
        public bool MarriageOfferForPlayerEnabled { get; set; } = true;

        [SettingPropertyGroup("{=BE_SE_OP006}Player Divorce", GroupOrder = 1)]
        [SettingPropertyBool("{=BE_SE_OP001}Enable", RequireRestart = true, IsToggle = true)]
        public bool DivorceEnabled { get; set; } = true;
    }
}
