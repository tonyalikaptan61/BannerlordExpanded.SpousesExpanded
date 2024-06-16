﻿using BannerlordExpanded.SpousesExpanded.Utility;
using Helpers;
using TaleWorlds.CampaignSystem;

namespace BannerlordExpanded.SpousesExpanded.BaseSpouseDialog.Behaviors
{
    public class BaseWifeDialogBehavior : CampaignBehaviorBase
    {

        public override void RegisterEvents()
        {
            CampaignEvents.OnGameLoadedEvent.AddNonSerializedListener(this, OnGameLoaded);
        }

        public override void SyncData(IDataStore dataStore)
        {

        }

        void OnGameLoaded(CampaignGameStarter gameStarter)
        {
            AddDialogs(gameStarter);
        }

        void AddDialogs(CampaignGameStarter gameStarter)
        {
            gameStarter.AddPlayerLine("BannerlordExpandedSpousesExpanded_SpouseDialog", "hero_main_options", "BannerlordExpandedSpousesExpanded_SpouseDialog", "{=BE_SE_SD001}{?SPOUSE.GENDER}My wife{?}My husband{\\?}, I would like to talk to you about something.",
                () =>
                {
                    if (!SpousesExpandedUtil.IsPlayerSpouse(Hero.OneToOneConversationHero))
                        return false;
                    StringHelpers.SetCharacterProperties("SPOUSE", Hero.OneToOneConversationHero.CharacterObject, null, false);
                    return true;
                }, null);
            gameStarter.AddDialogLine("BannerlordExpandedSpousesExpanded_SpouseDialog_Start", "BannerlordExpandedSpousesExpanded_SpouseDialog", "BannerlordExpandedSpousesExpanded_SpouseDialog_Start", "{=BE_SE_SD002}What is it?", null, null);
            gameStarter.AddPlayerLine("BannerlordExpandedSpousesExpanded_SpouseDialog_Cancel", "BannerlordExpandedSpousesExpanded_SpouseDialog_Start", "lord_pretalk", "{=BE_SE_SD003}Nevermind.", null, null);
        }
    }
}
