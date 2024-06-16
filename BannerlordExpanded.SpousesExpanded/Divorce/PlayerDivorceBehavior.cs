﻿using BannerlordExpanded.SpousesExpanded.Utility;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;

namespace BannerlordExpanded.SpousesExpanded.Divorce
{
    public class PlayerDivorceBehavior : CampaignBehaviorBase
    {
        public override void RegisterEvents()
        {
            CampaignEvents.OnGameLoadedEvent.AddNonSerializedListener(this, AddDialog);
        }

        public override void SyncData(IDataStore dataStore)
        {

        }

        void AddDialog(CampaignGameStarter gameStarter)
        {
            gameStarter.AddPlayerLine("BannerlordExpandedSpousesExpanded_SpouseDialog_Divorce", "BannerlordExpandedSpousesExpanded_SpouseDialog_Start", "BannerlordExpandedSpousesExpanded_SpouseDialog_DivorceReply", "{=BE_SE_DV001}I am tired of our marriage. Let's divorce and go our separate ways.",
               null,
               null
               );
            gameStarter.AddDialogLine("BannerlordExpandedSpousesExpanded_SpouseDialog_DivorceConfirmation", "BannerlordExpandedSpousesExpanded_SpouseDialog_DivorceReply", "BannerlordExpandedSpousesExpanded_SpouseDialog_DivorceConfirmation", "{=BE_SE_DV002}A-Are you sure about this?[if:convo_dismayed][ib:nervous]", null, null);


            gameStarter.AddPlayerLine("BannerlordExpandedSpousesExpanded_SpouseDialog_DivorceConfirmation_Yes", "BannerlordExpandedSpousesExpanded_SpouseDialog_DivorceConfirmation", "hero_leave", "{=BE_SE_DV003}Yes, I am sure.", null,
                () =>
                {
                    Divorce(Hero.OneToOneConversationHero);
                });

            gameStarter.AddPlayerLine("BannerlordExpandedSpousesExpanded_SpouseDialog_DivorceConfirmation_No", "BannerlordExpandedSpousesExpanded_SpouseDialog_DivorceConfirmation", "lord_pretalk", "{=BE_SE_DV004}No, I was just joking with you!", null, null);
        }

        void Divorce(Hero hero)
        {
            if (SpousesExpandedUtil.DivorceHero(hero))
            {

                if (hero.GovernorOf != null)
                {
                    ChangeGovernorAction.RemoveGovernorOf(hero);
                }
                CampaignEventDispatcher.Instance.OnCompanionRemoved(hero, RemoveCompanionAction.RemoveCompanionDetail.Fire);

                if (hero.Father != null)
                {
                    hero.Clan = hero.Father.Clan;
                }
                else if (hero.Mother != null)
                {
                    hero.Clan = hero.Mother.Clan;
                }
                else
                {
                    KillCharacterAction.ApplyByRemove(hero);
                }


                MakeHeroFugitiveAction.Apply(hero);
            }
        }
    }
}
