using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using Obeliskial_Content;
using UnityEngine;
using static ZealotSkin.CustomFunctions;
using static ZealotSkin.Plugin;
using static ZealotSkin.DescriptionFunctions;
using static ZealotSkin.ZealotSkinFunctions;
using System.Text;
using TMPro;
using Obeliskial_Essentials;

namespace ZealotSkin
{
    [HarmonyPatch]
    internal class Traits
    {
        // list of your trait IDs

        public static string[] simpleTraitList = ["trait0", "trait1a", "trait1b", "trait2a", "trait2b", "trait3a", "trait3b", "trait4a", "trait4b"];

        public static string[] myTraitList = simpleTraitList.Select(trait => subclassname + trait).ToArray(); // Needs testing

        public static string trait0 = myTraitList[0];
        // static string trait1b = myTraitList[1];
        public static string trait2a = myTraitList[3];
        public static string trait2b = myTraitList[4];
        public static string trait4a = myTraitList[7];
        public static string trait4b = myTraitList[8];

        // public static int infiniteProctection = 0;
        // public static int bleedInfiniteProtection = 0;
        public static bool isDamagePreviewActive = false;

        public static bool isCalculateDamageActive = false;
        public static int infiniteProctection = 0;

        public static string debugBase = "Binbin - Testing " + heroName + " ";


        // public static void DoCustomTrait(string _trait, ref Trait __instance)
        // {
        //     // get info you may need
        //     Enums.EventActivation _theEvent = Traverse.Create(__instance).Field("theEvent").GetValue<Enums.EventActivation>();
        //     Character _character = Traverse.Create(__instance).Field("character").GetValue<Character>();
        //     Character _target = Traverse.Create(__instance).Field("target").GetValue<Character>();
        //     int _auxInt = Traverse.Create(__instance).Field("auxInt").GetValue<int>();
        //     string _auxString = Traverse.Create(__instance).Field("auxString").GetValue<string>();
        //     CardData _castedCard = Traverse.Create(__instance).Field("castedCard").GetValue<CardData>();
        //     Traverse.Create(__instance).Field("character").SetValue(_character);
        //     Traverse.Create(__instance).Field("target").SetValue(_target);
        //     Traverse.Create(__instance).Field("theEvent").SetValue(_theEvent);
        //     Traverse.Create(__instance).Field("auxInt").SetValue(_auxInt);
        //     Traverse.Create(__instance).Field("auxString").SetValue(_auxString);
        //     Traverse.Create(__instance).Field("castedCard").SetValue(_castedCard);
        //     TraitData traitData = Globals.Instance.GetTraitData(_trait);
        //     List<CardData> cardDataList = [];
        //     List<string> heroHand = MatchManager.Instance.GetHeroHand(_character.HeroIndex);
        //     Hero[] teamHero = MatchManager.Instance.GetTeamHero();
        //     NPC[] teamNpc = MatchManager.Instance.GetTeamNPC();

        //     if (!IsLivingHero(_character))
        //     {
        //         return;
        //     }

        //     if (_trait == trait0)
        //     {
        //         string traitName = traitData.TraitName;
        //         string traitId = _trait;
        //         LogDebug($"Handling Trait {traitId}: {traitName}");
        //         // trait0:
        //         // if (MatchManager.Instance.GetCurrentRound() != 0)
        //         // {
        //         //     return;
        //         // }
        //         // At the start of combat, gain 1 inspire
        //         _character.SetAuraTrait(_character, "inspire", 1);
        //     }


        //     else if (_trait == trait2a)
        //     {
        //         // trait2a
        //         // When you play a book, gain 1 energy, apply 1 thorns, 1 block to all heroes.
        //         string traitName = traitData.TraitName;
        //         string traitId = _trait;

        //         if (CanIncrementTraitActivations(traitId) && _castedCard.HasCardType(Enums.CardType.Book))
        //         {
        //             LogDebug($"Handling Trait {traitId}: {traitName}");
        //             _character.ModifyEnergy(1);
        //             ApplyAuraCurseToAll("block", 1, AppliesTo.Heroes, _character, useCharacterMods: true);
        //             ApplyAuraCurseToAll("thorns", 1, AppliesTo.Heroes, _character, useCharacterMods: true);
        //             IncrementTraitActivations(traitId);
        //         }
        //     }



        //     else if (_trait == trait2b)
        //     {
        //         // trait 2b:  
        //         // +1 to all Curse Charges
        //         // At the start of your turn, apply 1 Burn/Chill/Spark to a random monster.
        //         string traitName = traitData.TraitName;
        //         string traitId = _trait;
        //         LogDebug($"Handling Trait {traitId}: {traitName}");
        //         Character randNPC = GetRandomCharacter(teamNpc);
        //         randNPC.SetAuraTrait(_character, "burn", 1);
        //         randNPC.SetAuraTrait(_character, "chill", 1);
        //         randNPC.SetAuraTrait(_character, "spark", 1);
        //     }

        //     else if (_trait == trait4a)
        //     {
        //         // trait4a:
        //         // Fortify and Sharp on heroes increases all damage by 0.25


        //     }

        //     else if (_trait == trait4b)
        //     {
        //         string traitName = traitData.TraitName;
        //         string traitId = _trait;
        //         LogDebug($"Handling Trait {traitId}: {traitName}");
        //         // trait4b:
        //         // at end of your turn, transorm elemental to dark
        //         foreach (NPC npc in teamNpc)
        //         {
        //             if (!IsLivingNPC(npc))
        //             {
        //                 continue;
        //             }
        //             int nDark = npc.GetAuraCharges("burn") + npc.GetAuraCharges("spark") + npc.GetAuraCharges("chill");
        //             npc.HealAuraCurse(GetAuraCurseData("burn"));
        //             npc.HealAuraCurse(GetAuraCurseData("chill"));
        //             npc.HealAuraCurse(GetAuraCurseData("spark"));
        //             npc.SetAuraTrait(_character, "dark", nDark);
        //         }
        //     }

        // }

        // [HarmonyPrefix]
        // [HarmonyPatch(typeof(Trait), "DoTrait")]
        // public static bool DoTrait(Enums.EventActivation _theEvent, string _trait, Character _character, Character _target, int _auxInt, string _auxString, CardData _castedCard, ref Trait __instance)
        // {
        //     if ((UnityEngine.Object)MatchManager.Instance == (UnityEngine.Object)null)
        //         return false;
        //     Traverse.Create(__instance).Field("character").SetValue(_character);
        //     Traverse.Create(__instance).Field("target").SetValue(_target);
        //     Traverse.Create(__instance).Field("theEvent").SetValue(_theEvent);
        //     Traverse.Create(__instance).Field("auxInt").SetValue(_auxInt);
        //     Traverse.Create(__instance).Field("auxString").SetValue(_auxString);
        //     Traverse.Create(__instance).Field("castedCard").SetValue(_castedCard);
        //     if (Content.medsCustomTraitsSource.Contains(_trait) && myTraitList.Contains(_trait))
        //     {
        //         DoCustomTrait(_trait, ref __instance);
        //         return false;
        //     }
        //     return true;
        // }


        // [HarmonyPrefix]
        // [HarmonyPatch(typeof(MatchManager), "CastCardAction")]
        // // [HarmonyPriority(Priority.Last)]
        // public static void CastCardActionPrefix(
        //     MatchManager __instance,
        //     CardData _cardActive,
        //     Transform targetTransformCast,
        //     CardItem theCardItem,
        //     string _uniqueCastId,
        //     bool _automatic,
        //     CardData _card,
        //     int _cardIterationTotal,
        //     int _cardSpecialValueGlobal,
        //     ref List<string>[] ___HeroDeckVanish,
        //     ref List<string>[] ___HeroDeck
        //     )

        // {
        //     bool nonNull = targetTransformCast != null && _cardActive != null && __instance != null;
        //     if (!nonNull)
        //     {
        //         LogDebug("CastCardActionPrefix - targetTransformCast, _cardActive, or __instance is null ");
        //         return;
        //     }
        //     if (_cardActive.CardName != "Recompilation Formula")
        //     {
        //         return;
        //     }
        //     Hero heroActive = __instance.GetHeroHeroActive();
        //     if (heroActive == null)
        //     {
        //         return;
        //     }
        //     Enums.CardPlace from = Enums.CardPlace.Vanish;
        //     Enums.CardPlace to = Enums.CardPlace.RandomDeck;
        //     Enums.CardClass cardClass = Enums.CardClass.Mage;

        //     LogDebug("CastCardActionPrefix - Shuffling Vanish Pile into deck");
        //     int energyReductionPermanent = 0;
        //     int heroActiveInd = __instance.GetHeroActive();

        //     if (from == Enums.CardPlace.Vanish)
        //     {
        //         for (int index = ___HeroDeckVanish[heroActiveInd].Count - 1; index >= 0; --index)
        //         {
        //             CardData cardData = __instance.GetCardData(___HeroDeckVanish[heroActiveInd][index]);
        //             bool flag = false;
        //             if (cardClass == Enums.CardClass.None)
        //                 flag = true;
        //             if (cardData.HasCardType(Enums.CardType.Injury) || cardData.CardClass == Enums.CardClass.Injury || cardData.CardClass == Enums.CardClass.Monster || cardData.CardClass == Enums.CardClass.Boon || cardData.IsPetCast)
        //                 flag = false;
        //             if (flag)
        //             {
        //                 if (energyReductionPermanent != 0)
        //                     cardData.EnergyReductionPermanent += energyReductionPermanent;
        //                 if (to == Enums.CardPlace.RandomDeck)
        //                     ___HeroDeck[heroActiveInd].Insert(__instance.GetRandomIntRange(0, ___HeroDeck[heroActiveInd].Count), ___HeroDeckVanish[heroActiveInd][index]);
        //                 ___HeroDeckVanish[heroActiveInd].RemoveAt(index);
        //             }
        //         }
        //     }
        //     if (to != Enums.CardPlace.RandomDeck && to != Enums.CardPlace.BottomDeck && to != Enums.CardPlace.TopDeck)
        //         return;
        //     DrawDeckPile(__instance, __instance.CountHeroDeck() + 1);
        //     // __instance.MoveCards(Enums.CardPlace.Vanish, Enums.CardPlace.RandomDeck, Enums.CardClass.None, 0);
        // }

        // [HarmonyPrefix]
        // [HarmonyPatch(typeof(MatchManager), "CastCard")]
        // public static void CastCardPrefix(
        //     MatchManager __instance,
        //     CardItem theCardItem = null,
        //     bool _automatic = false,
        //     CardData _card = null,
        //     int _energy = -1,
        //     int _posInTable = -1,
        //     bool _propagate = true)
        // {
        //     bool isNull = theCardItem == null;
        //     if (isNull)
        //     {
        //         LogDebug("CastCardPrefix - Null CardItem");
        //         return;
        //     }
        //     if (theCardItem.CardData.CardName != "Recompilation Formula")
        //     {
        //         return;
        //     }
        //     Hero heroActive = __instance.GetHeroHeroActive();
        //     if (heroActive == null)
        //     {
        //         return;
        //     }
        //     LogDebug("CastCardPrefix - Shuffling Vanish Pile into deck");
        //     __instance.MoveCards(Enums.CardPlace.Vanish, Enums.CardPlace.RandomDeck, Enums.CardClass.None, 0);
        // }



        // [HarmonyPostfix]
        // [HarmonyPatch(typeof(AtOManager), "GlobalAuraCurseModificationByTraitsAndItems")]
        // public static void GlobalAuraCurseModificationByTraitsAndItemsPostfix(ref AtOManager __instance, ref AuraCurseData __result, string _type, string _acId, Character _characterCaster, Character _characterTarget)
        // {
        //     // LogInfo($"GACM {subclassName}");

        //     Character characterOfInterest = _type == "set" ? _characterTarget : _characterCaster;
        //     string traitOfInterest;
        //     switch (_acId)
        //     {
        //         // trait4a:
        //         // Fortify and Sharp on heroes increases all damage by 0.25

        //         case "fortify":
        //             traitOfInterest = trait4a;
        //             if (IfCharacterHas(characterOfInterest, CharacterHas.Trait, traitOfInterest, AppliesTo.Heroes))
        //             {
        //                 __result.AuraDamageType2 = Enums.DamageType.All;
        //                 __result.AuraDamageIncreasedPerStack2 = 0.25f;
        //             }
        //             break;
        //         case "sharp":
        //             traitOfInterest = trait4a;
        //             if (IfCharacterHas(characterOfInterest, CharacterHas.Trait, traitOfInterest, AppliesTo.Heroes))
        //             {
        //                 __result.AuraDamageType4 = Enums.DamageType.All;
        //                 __result.AuraDamageIncreasedPerStack4 = 0.25f;
        //             }
        //             break;
        //     }
        // }

        // [HarmonyPostfix]
        // [HarmonyPatch(typeof(Character), "GetAuraCurseQuantityModification")]
        // public static void GetAuraCurseQuantityModificationPostfix(Character __instance, ref int __result, string id, Enums.CardClass CC, ref bool ___useCache)
        // {
        //     string traitOfInterest = trait2b;

        //     if (!(IsLivingHero(__instance) && __instance.HaveTrait(traitOfInterest) && !GetAuraCurseData(id).IsAura))
        //     {
        //         return;
        //     }
        //     LogDebug("GetAuraCurseQuantityModificationPostfix - Handling Increased Curse Charges");
        //     // int quantityModification = 0;
        //     // Dictionary<string, int> auraCurseModifiers = __instance.GetTraitAuraCurseModifiers();
        //     // if (auraCurseModifiers != null && auraCurseModifiers.ContainsKey(id))
        //     //     quantityModification += auraCurseModifiers[id];
        //     __result += 1;
        //     // ___useCache = false;

        // }


        // // [HarmonyPostfix]
        // // [HarmonyPatch(typeof(CardData), nameof(CardData.SetDescriptionNew))]
        // // public static void SetDescriptionNewPostfix(ref CardData __instance, bool forceDescription = false, Character character = null, bool includeInSearch = true)
        // // {
        // //     // LogInfo("executing SetDescriptionNewPostfix");
        // //     if (__instance == null)
        // //     {
        // //         LogDebug("Null Card");
        // //         return;
        // //     }

        // //     StringBuilder stringBuilder1 = new StringBuilder();
        // //     if (!cardsToPrependDescription.Contains(__instance.Id))
        // //     {
        // //         return;
        // //     }
        // //     if (!Globals.Instance.CardsDescriptionNormalized.ContainsKey(__instance.Id))
        // //     {
        // //         LogError($"missing card Id {__instance.Id}");
        // //         return;
        // //     }
        // //     string currentDescription = Globals.Instance.CardsDescriptionNormalized[__instance.Id];
        // //     stringBuilder1.Append(currentDescription);
        // //     // PrependDescriptionsToCards(__instance, ref stringBuilder1);
        // //     // BinbinNormalizeDescription(ref __instance, stringBuilder1);
        // // }

        // // [HarmonyPostfix]
        // // [HarmonyPatch(typeof(CardItem), nameof(CardItem.SetCard))]
        // // public static void SetCardPostfix(
        // //     ref CardItem __instance,
        // //     ref TMP_Text ___descriptionTextTM,
        // //     string id,
        // //     bool deckScale = true,
        // //     Hero _theHero = null,
        // //     NPC _theNPC = null,
        // //     bool GetFromGlobal = false,
        // //     bool _generated = false)
        // // {
        // //     LogDebug($"SetCardPostfix {id}");
        // //     if ((__instance != null && __instance.CardData != null && (__instance.CardData.Id == "ZealotSkinformula" || __instance.CardData.CardName == "Recompilation Formula")) || id == "ZealotSkinformula")
        // //     {

        // //         // __instance.CardData.SetDescriptionNew(true);

        // //         string cardId = id.Split("_")[0];
        // //         string newD = Globals.Instance.CardsDescriptionNormalized[cardId];
        // //         ___descriptionTextTM.text = newD;
        // //         LogDebug($"SetCardPostfix - formula description for {__instance.CardData.Id} - {newD}");
        // //     }
        // //     else if (__instance != null && __instance.CardData != null)
        // //     {
        // //         LogDebug($"RedrawDescriptionPrecalculated - card name {__instance.CardData.CardName}");
        // //     }
        // // }

        // // [HarmonyPostfix]
        // // [HarmonyPatch(typeof(CardItem), nameof(CardItem.RedrawDescriptionPrecalculated))]

        // // public static void RedrawDescriptionPrecalculatedPostfix(ref CardItem __instance, ref TMP_Text ___descriptionTextTM, Hero theHero, bool includeInSearch = true)
        // // {
        // //     LogDebug($"RedrawDescriptionPrecalculatedPostfix {__instance?.CardData?.Id ?? "null"}");

        // //     if (__instance != null && __instance.CardData != null && (__instance.CardData.Id == "ZealotSkinformula" || __instance.CardData.CardName == "Recompilation Formula"))
        // //     {
        // //         // __instance.CardData.SetDescriptionNew();
        // //         ___descriptionTextTM.text = "testing2";
        // //         // Traverse.Create(__instance).Field("").SetValue("testing2");
        // //         LogDebug($"RedrawDescriptionPrecalculated - formula description {__instance.CardData.CardName} {__instance.CardData.DescriptionNormalized}");
        // //     }
        // //     else if (__instance != null && __instance.CardData != null)
        // //     {
        // //         LogDebug($"RedrawDescriptionPrecalculated - card name {__instance.CardData.CardName}");
        // //     }

        // // }


        // [HarmonyPrefix]
        // [HarmonyPatch(typeof(CharacterItem), nameof(CharacterItem.CalculateDamagePrePostForThisCharacter))]
        // public static void CalculateDamagePrePostForThisCharacterPrefix()
        // {
        //     isDamagePreviewActive = true;
        // }
        // [HarmonyPostfix]
        // [HarmonyPatch(typeof(CharacterItem), nameof(CharacterItem.CalculateDamagePrePostForThisCharacter))]
        // public static void CalculateDamagePrePostForThisCharacterPostfix()
        // {
        //     isDamagePreviewActive = false;
        // }


        // [HarmonyPrefix]
        // [HarmonyPatch(typeof(MatchManager), nameof(MatchManager.SetDamagePreview))]
        // public static void SetDamagePreviewPrefix()
        // {
        //     isDamagePreviewActive = true;
        // }
        // [HarmonyPostfix]
        // [HarmonyPatch(typeof(MatchManager), nameof(MatchManager.SetDamagePreview))]
        // public static void SetDamagePreviewPostfix()
        // {
        //     isDamagePreviewActive = false;
        // }

        // [HarmonyPrefix]
        // [HarmonyPatch(typeof(Character), nameof(Character.BeginTurn))]
        // public static void BeginTurnPrefix(ref Character __instance)
        // {

        //     infiniteProctection = 0;
        // }

    }
}

