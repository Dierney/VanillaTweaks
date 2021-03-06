﻿
using System;
using System.IO;
using Terraria;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ModLoader;

namespace VanillaTweaks
{
	//I should probably rewrite this whole thing but I'll get to it once tML officially supports config files.

	public static class Config
	{
		static string ConfigPath = Path.Combine(Main.SavePath, "Mod Configs", "Vanilla Tweaks.json");
		static string OldConfigFolderPath = Path.Combine(Main.SavePath, "Mod Configs", "Vanilla Tweaks");
		static string OldConfigPath = Path.Combine(OldConfigFolderPath, "config.json");
		static string OldConfigVersionPath = Path.Combine(OldConfigFolderPath, "config.version");
		
		static readonly Preferences Settings = new Preferences(ConfigPath);
		
		public static bool GladiatorArmorTweak = true;
		const string GladiatorArmorTweakKey = "GladiatorArmorTweak";
		
		public static bool ObsidianArmorTweak = true;
		const string ObsidianArmorTweakKey = "ObsidianArmorTweak";
		
		public static bool MeteorArmorDamageTweak = true;
		const string MeteorArmorDamageTweakKey = "MeteorArmorDamageTweak";
		
		public static bool EskimoArmorTweak = true;
		const string EskimoArmorTweakKey = "EskimoArmorTweak";

		public static bool EskimoArmorDropTweak = true;
		const string EskimoArmorDropTweakKey = "EskimoArmorDropTweak";
		
		public static bool RainArmorTweak = true;
		const string RainArmorTweakKey = "RainArmorTweak";
		
		public static bool HammerTweaks = true;
		const string HammerTweaksKey = "HammerTweaks";
		
		public static bool NightsEdgeAutoswing = true;
		const string NightsEdgeAutoswingKey = "NightsEdgeAutoswing";
		
		public static bool TrueSwordsAutoswing = true;
		const string TrueSwordsAutoswingKey = "TrueSwordsAutoswing";
		
		public static bool SwatHelmetTweak = true;
		const string SwatHelmetTweakKey = "SwatHelmetTweak";
		
		public static bool SkullTweak = true;
		const string SkullTweakKey = "SkullTweak";
		
		public static bool FishBowlTweak = true;
		const string FishBowlTweakKey = "FishBowlTweak";
		
		public static bool SandstoneRename = true;
		const string SandstoneRenameKey = "SandstoneRename";
		
		public static bool CobaltShieldRename = true;
		const string CobaltShieldRenameKey = "CobaltShieldRename";
		
		public static bool BoneBlockFix = true;
		const string BoneBlockFixKey = "BoneBlockFix";
		
		public static bool GoldCritterDropTweak = true;
		const string GoldCritterDropTweakKey = "GoldCritterDropTweak";
		
		public static float ExtractSpeedMultiplier = 5f;
		const string ExtractSpeedMultiplierKey = "ExtractSpeedMultiplier";
		
		public static int JestersArrowCraft = 50;
		const string JestersArrowCraftKey = "JestersArrowCraft";
		
		public static bool FavoriteTooltipRemove = true;
		const string FavoriteTooltipRemoveKey = "FavoriteTooltipRemove";
		
		public static bool WhoopieCushionTweak = true;
		const string WhoopieCushionTweakKey = "EasterEgg";
		
        public static bool CoinsTweak = true;
		const string CoinsTweakKey = "CoinRecipesAtEndofList";		
		
        public static int MolotovCraft = 25;
		const string MolotovTweakKey = "MolotovBlueGelCraft";		
		
		public static bool VikingHelmetTweak = true;
		const string VikingHelmetTweakKey = "VikingHelmetTweak";
		
		public static bool CactusArmorTweak = true;
		const string CactusArmorTweakKey = "CactusArmorTweak";
				
		public static bool MeteorArmorDefenseTweak = true;
		const string MeteorArmorDefenseTweakKey = "MeteorArmorDefenseTweak";
		
		public static bool PharaohSetTweak = true;
		const string PharaohSetTweakKey = "PharaohSetTweak";

		public static bool CrimsonArmorTweak = true;
		const string CrimsonArmorTweakKey = "CrimsonArmorTweak";

		public static bool UndeadMinerTweak = true;
		const string UndeadMinerTweakKey = "UndeadMinerDrop";

		public static bool FishingPoleTweak = true;
		const string FishingPoleTweakKey = "FishingPoleTweaks";
		
		public static void Load()
		{
			if(Directory.Exists(OldConfigFolderPath))
			{
				if(File.Exists(OldConfigPath))
				{
					VanillaTweaks.Log("Found config file in old folder! Moving config...");
					File.Move(OldConfigPath, ConfigPath);
				}
				if(File.Exists(OldConfigVersionPath))
					File.Delete(OldConfigVersionPath);
				if(Directory.GetFiles(OldConfigFolderPath).Length == 0 && Directory.GetDirectories(OldConfigFolderPath).Length == 0)
					Directory.Delete(OldConfigFolderPath);
				else
					VanillaTweaks.Log("Old config folder still cotains some files/directories. They will not get deleted.");
			}
			if(!ReadConfig())
			{
				SetDefaults();
				VanillaTweaks.Log("Failed to read config file! Creating config...");
			}
			SaveConfig();
		}

		public static void SetDefaults()
		{
			GladiatorArmorTweak = true;
			ObsidianArmorTweak = true;
			MeteorArmorDefenseTweak = true;
			MeteorArmorDamageTweak = true;
			EskimoArmorTweak = true;
			EskimoArmorDropTweak = true;
			HammerTweaks = true;
			RainArmorTweak = true;
			NightsEdgeAutoswing = true;
			TrueSwordsAutoswing = true;
			SwatHelmetTweak = true;
			SkullTweak = true;
			FishBowlTweak = true;
			SandstoneRename = true;
			CobaltShieldRename = true;
			GoldCritterDropTweak = true;
			BoneBlockFix = true;
			ExtractSpeedMultiplier = 5f;
			JestersArrowCraft = 50;
			FavoriteTooltipRemove = true;
			WhoopieCushionTweak = true;
			CoinsTweak = true;
			MolotovCraft = 25;
			VikingHelmetTweak = true;
			CactusArmorTweak = true;
			PharaohSetTweak = true;
			CrimsonArmorTweak = true;
			UndeadMinerTweak = true;
			FishingPoleTweak = true;
		}
		
		public static bool ReadConfig()
		{
			if(Settings.Load())
			{
				Settings.Get(GladiatorArmorTweakKey, ref GladiatorArmorTweak);
				Settings.Get(ObsidianArmorTweakKey, ref ObsidianArmorTweak);
				Settings.Get(MeteorArmorDefenseTweakKey, ref MeteorArmorDefenseTweak);
				Settings.Get(MeteorArmorDamageTweakKey, ref MeteorArmorDamageTweak);
				Settings.Get(EskimoArmorTweakKey, ref EskimoArmorTweak);
				Settings.Get(EskimoArmorDropTweakKey, ref EskimoArmorDropTweak);
				Settings.Get(RainArmorTweakKey, ref RainArmorTweak);
				Settings.Get(HammerTweaksKey, ref HammerTweaks);
				Settings.Get(NightsEdgeAutoswingKey, ref NightsEdgeAutoswing);
				Settings.Get(TrueSwordsAutoswingKey, ref TrueSwordsAutoswing);
				Settings.Get(SwatHelmetTweakKey, ref SwatHelmetTweak);
				Settings.Get(SkullTweakKey, ref SkullTweak);
				Settings.Get(FishBowlTweakKey, ref FishBowlTweak);
				Settings.Get(SandstoneRenameKey, ref SandstoneRename);
				Settings.Get(CobaltShieldRenameKey, ref CobaltShieldRename);
				Settings.Get(BoneBlockFixKey, ref BoneBlockFix);
				Settings.Get(GoldCritterDropTweakKey, ref GoldCritterDropTweak);
				Settings.Get("ExtractSpeedMulitplier", ref ExtractSpeedMultiplier); //bit of a typo there :P
				Settings.Get(ExtractSpeedMultiplierKey, ref ExtractSpeedMultiplier);
				Settings.Get(JestersArrowCraftKey, ref JestersArrowCraft);
				Settings.Get(FavoriteTooltipRemoveKey, ref FavoriteTooltipRemove);
				Settings.Get(VikingHelmetTweakKey, ref VikingHelmetTweak);
				Settings.Get(CactusArmorTweakKey, ref CactusArmorTweak);
				Settings.Get(MolotovTweakKey, ref MolotovCraft);
				Settings.Get(WhoopieCushionTweakKey, ref WhoopieCushionTweak);
				Settings.Get(CoinsTweakKey, ref CoinsTweak);
				Settings.Get(PharaohSetTweakKey, ref PharaohSetTweak);
				Settings.Get(CrimsonArmorTweakKey, ref CrimsonArmorTweak);
				Settings.Get(UndeadMinerTweakKey, ref UndeadMinerTweak);
				Settings.Get(FishingPoleTweakKey, ref FishingPoleTweak);
				return true;
			}
			return false;
		}
		
		public static void SaveConfig()
		{
			Settings.Clear();
			Settings.Put(GladiatorArmorTweakKey, GladiatorArmorTweak);
			Settings.Put(ObsidianArmorTweakKey, ObsidianArmorTweak);
			Settings.Put(MeteorArmorDefenseTweakKey, MeteorArmorDefenseTweak);
			Settings.Put(MeteorArmorDamageTweakKey, MeteorArmorDamageTweak);
			Settings.Put(EskimoArmorTweakKey, EskimoArmorTweak);
			Settings.Put(EskimoArmorDropTweakKey, EskimoArmorDropTweak);
			Settings.Put(RainArmorTweakKey, RainArmorTweak);
			Settings.Put(PharaohSetTweakKey, PharaohSetTweak);
			Settings.Put(VikingHelmetTweakKey, VikingHelmetTweak);
			Settings.Put(CactusArmorTweakKey, CactusArmorTweak);
			Settings.Put(HammerTweaksKey, HammerTweaks);
			Settings.Put(NightsEdgeAutoswingKey, NightsEdgeAutoswing);
			Settings.Put(TrueSwordsAutoswingKey, TrueSwordsAutoswing);
			Settings.Put(SwatHelmetTweakKey, SwatHelmetTweak);
			Settings.Put(SkullTweakKey, SkullTweak);
			Settings.Put(FishBowlTweakKey, FishBowlTweak);
			Settings.Put(SandstoneRenameKey, SandstoneRename);
			Settings.Put(CobaltShieldRenameKey, CobaltShieldRename);
			Settings.Put(BoneBlockFixKey, BoneBlockFix);
			Settings.Put(GoldCritterDropTweakKey, GoldCritterDropTweak);
			Settings.Put(ExtractSpeedMultiplierKey, ExtractSpeedMultiplier);
			Settings.Put(JestersArrowCraftKey, JestersArrowCraft);
			Settings.Put(FavoriteTooltipRemoveKey, FavoriteTooltipRemove);
			Settings.Put(MolotovTweakKey, MolotovCraft);
			Settings.Put(WhoopieCushionTweakKey, WhoopieCushionTweak);
			Settings.Put(CoinsTweakKey, CoinsTweak);
			Settings.Put(CrimsonArmorTweakKey, CrimsonArmorTweak);
			Settings.Put(UndeadMinerTweakKey, UndeadMinerTweak);
			Settings.Put(FishingPoleTweakKey, FishingPoleTweak);
			Settings.Save();
		}
		
		public static void LoadFKConfig()
		{
			var setting = FKTModSettings.ModSettingsAPI.CreateModSettingConfig(VanillaTweaks.Instance);

			setting.AddComment("Features marked with an asterisk (*) require an item reset to update properly.\n" +
			                   "An item can be reset by either re-entering the world or by placing the item on an Item Frame, Weapon Rack or Mannequin.");
			setting.AddComment("Features marked with two asterisks (**) require a mod reload to update properly.");
			setting.AddComment("Most values are only modifiable in singleplayer.");
			
			const float commentScale = 0.8f;
			
			setting.AddComment("Defense increased*, set bonus: +15% crit chance", commentScale);
			setting.AddBool(GladiatorArmorTweakKey, "Gladiator Armor Tweaks", false);
			setting.AddComment("+3% ranged crit chance for each piece, set bonus: +10% move speed and shadow trail", commentScale);
			setting.AddBool(ObsidianArmorTweakKey, "Obsidian Armor Tweaks", false);
			setting.AddComment("Defense decreased", commentScale);
			setting.AddBool(MeteorArmorDefenseTweakKey, "Meteor Armor Defense Tweaks*", false);
			setting.AddComment("Remove magic damage boosts from Meteor Armor", commentScale);
			setting.AddBool(MeteorArmorDamageTweakKey, "Meteor Armor Damage Tweaks", false);
			setting.AddComment("Defense increased*, immunity to cold water, set bonus: Warmth buff, immunity to Frostburn, Chilled and Frozen", commentScale);
			setting.AddBool(EskimoArmorTweakKey, "Eskimo Armor Tweaks", false);
			setting.AddComment("3% chance to drop Eskimo Armor instead of 0.67% (twice as much in Expert Mode)", commentScale);
			setting.AddBool(EskimoArmorDropTweakKey, "Eskimo Armor Drop Increase", false);
			setting.AddComment("Rain Armor is now Vanity", commentScale);
			setting.AddBool(RainArmorTweakKey, "Rain Armor Tweaks*", false);
			setting.AddComment("Viking Helmet gives 5% damage when used with Iron or Lead armor", commentScale);
			setting.AddBool(VikingHelmetTweakKey, "Iron or Lead Viking Tweaks", false);
			setting.AddComment("Changes the set bonus of cactus to 25% thorns", commentScale);
			setting.AddBool(CactusArmorTweakKey, "Cactus Armor Tweaks", false);
			setting.AddComment("Changes Pharaoh's vanity set to Summoner armor", commentScale);
			setting.AddBool(PharaohSetTweakKey, "Pharaoh Set Tweaks*", false);
			setting.AddComment("Crimson Armor now only increases melee damage instead of all damage", commentScale);
			setting.AddBool(CrimsonArmorTweakKey, "Crimson Set Tweaks*", false);
			setting.AddComment("Rebalances a few hammers/hamaxes", commentScale);
			setting.AddBool(HammerTweaksKey, "Hammer Tweaks*", false);
			setting.AddBool(NightsEdgeAutoswingKey, "Night's Edge Autoswing*", true);
			setting.AddBool(TrueSwordsAutoswingKey, "True Swords Autoswing*", true);
			setting.AddComment("+14 defense, +15% ranged damage (all types), +5% ranged crit chance\n" + 
			                   "If Miscellania is installed, equipping a SWAT Helmet and a Reinforced Vest grants a set bonus", commentScale);
			setting.AddBool(SwatHelmetTweakKey, "SWAT Helmet Tweaks*", false);
			setting.AddComment("Flips the Skull sprite so that it faces to the right like other armor/vanity", commentScale);
			setting.AddBool(SkullTweakKey, "Skull Flip", true);
			setting.AddComment("+1 defense", commentScale);
			setting.AddBool(FishBowlTweakKey, "Fish Bowl Tweaks*", false);
			setting.AddComment("Undead Miners drop Mining Armor a lot more often and are detected by Lifeform Analyzer", commentScale);
			setting.AddBool(UndeadMinerTweakKey, "Undead Miner Drops", false);
			setting.AddComment("Sitting Duck Fishing Pole is Hardmode only and the Mechanic's Rod is sold more often\n" +
			                   "If Miscellania is installed, the Mechanic's Rod will also be sold more often. (disable in that mod's config)", commentScale);
			setting.AddBool(FishingPoleTweakKey, "Fishing Pole Tweaks", false);
			setting.AddComment("Renames items such as Sandstone Brick to Sand Brick", commentScale);
			setting.AddBool(SandstoneRenameKey, "Rename Sandstone Items**", true);
			setting.AddComment("Renames the Cobalt Shield to Guardian's Shield", commentScale);
			setting.AddBool(CobaltShieldRenameKey, "Rename Cobalt Shield**", true);
			setting.AddComment("Bone Block Walls craft back into Bones**, Bone Blocks drop raw Bones when mined", commentScale);
			setting.AddBool(BoneBlockFixKey, "Bone Block Fix", false);
			setting.AddComment("Gold critters drop 1 Gold when killed (still sell for 5 Gold when sold)", commentScale);
			setting.AddBool(GoldCritterDropTweakKey, "Gold Critters Drop Coins", false);
			setting.AddFloat(ExtractSpeedMultiplierKey, "Extractinator Speed Multiplier", 0f, 5f, false);
			setting.AddBool(FavoriteTooltipRemoveKey, "Remove \"Favorite Item\" Tooltips", true);
			setting.AddComment("Setting this value to 0 will remove the recipe entirely", commentScale);
			setting.AddInt(JestersArrowCraftKey, "Jester's Arrows Crafted per Star**", 0, 100, false);
			setting.AddComment("Allows crafting Molotov Cocktails with regular Gel\nAdjust number to change the amount of Gel per every 5 cocktails, or set to 0 to remove the recipe", commentScale);
			setting.AddInt(MolotovTweakKey, "Molotov Craft Tweaks**", 0, 100, false);
			setting.AddComment("Puts coin conversion recipes at the end of recipe list", commentScale);
			setting.AddBool(CoinsTweakKey, "Coin Recipe Sort**", true);
			setting.AddBool(WhoopieCushionTweakKey, "Super Fun Easter Egg*", true);
		}
		
		public static void UpdateFKConfig()
		{
			FKTModSettings.ModSetting setting;
			if(FKTModSettings.ModSettingsAPI.TryGetModSetting(VanillaTweaks.Instance, out setting))
			{
				setting.Get(GladiatorArmorTweakKey, ref GladiatorArmorTweak);
				setting.Get(ObsidianArmorTweakKey, ref ObsidianArmorTweak);
				setting.Get(MeteorArmorDefenseTweakKey, ref MeteorArmorDefenseTweak);
				setting.Get(EskimoArmorTweakKey, ref EskimoArmorTweak);
				setting.Get(EskimoArmorDropTweakKey, ref EskimoArmorDropTweak);
				setting.Get(RainArmorTweakKey, ref RainArmorTweak);
				setting.Get(HammerTweaksKey, ref HammerTweaks);
				setting.Get(NightsEdgeAutoswingKey, ref NightsEdgeAutoswing);
				setting.Get(TrueSwordsAutoswingKey, ref TrueSwordsAutoswing);
				setting.Get(SwatHelmetTweakKey, ref SwatHelmetTweak);
				setting.Get(SkullTweakKey, ref SkullTweak);
				setting.Get(FishBowlTweakKey, ref FishBowlTweak);
				setting.Get(SandstoneRenameKey, ref SandstoneRename);
				setting.Get(CobaltShieldRenameKey, ref CobaltShieldRename);
				setting.Get(BoneBlockFixKey, ref BoneBlockFix);
				setting.Get(GoldCritterDropTweakKey, ref GoldCritterDropTweak);
				setting.Get(ExtractSpeedMultiplierKey, ref ExtractSpeedMultiplier);
				setting.Get(FavoriteTooltipRemoveKey, ref FavoriteTooltipRemove);
				setting.Get(JestersArrowCraftKey, ref JestersArrowCraft);
				setting.Get(VikingHelmetTweakKey, ref VikingHelmetTweak);
				setting.Get(CactusArmorTweakKey, ref CactusArmorTweak);
				setting.Get(MeteorArmorDamageTweakKey, ref MeteorArmorDamageTweak);
				setting.Get(MolotovTweakKey, ref MolotovCraft);
				setting.Get(PharaohSetTweakKey, ref PharaohSetTweak);
				setting.Get(WhoopieCushionTweakKey, ref WhoopieCushionTweak);
				setting.Get(CoinsTweakKey, ref CoinsTweak);
				setting.Get(CrimsonArmorTweakKey, ref CrimsonArmorTweak);
				setting.Get(UndeadMinerTweakKey, ref UndeadMinerTweak);
				setting.Get(FishingPoleTweakKey, ref FishingPoleTweak);
			}
		}
		
		class MultiplayerSyncWorld : ModWorld
		{
			public override void NetSend(BinaryWriter writer)
			{
				var data = new BitsByte(
					GladiatorArmorTweak,
					ObsidianArmorTweak,
					MeteorArmorDamageTweak,
					RainArmorTweak,
					HammerTweaks,
					NightsEdgeAutoswing,
					TrueSwordsAutoswing,
					SwatHelmetTweak
				);
				writer.Write((byte)data);
				data = new BitsByte(
					FishBowlTweak,
					BoneBlockFix,
					GoldCritterDropTweak,
					EskimoArmorTweak,
					VikingHelmetTweak,
					PharaohSetTweak,
					MeteorArmorDefenseTweak,
					CactusArmorTweak
				);
				writer.Write((byte)data);
				data = new BitsByte(
					EskimoArmorDropTweak,
					CrimsonArmorTweak,
					UndeadMinerTweak,
					FishingPoleTweak
				);
				writer.Write((byte)data);
				writer.Write(ExtractSpeedMultiplier);
				writer.Write((short)JestersArrowCraft);
				writer.Write((short)MolotovCraft);
			}
			
			public override void NetReceive(BinaryReader reader)
			{
				SaveConfig();

				var data = (BitsByte)reader.ReadByte();
				GladiatorArmorTweak = data[0];
				ObsidianArmorTweak = data[1];
				MeteorArmorDamageTweak = data[2];
				RainArmorTweak = data[3];
				HammerTweaks = data[4];
				NightsEdgeAutoswing = data[5];
				TrueSwordsAutoswing = data[6];
				SwatHelmetTweak = data[7];

				data = reader.ReadByte();
				FishBowlTweak = data[0];
				BoneBlockFix = data[1];
				GoldCritterDropTweak = data[2];
				EskimoArmorTweak = data[3];
				VikingHelmetTweak = data[4];
				PharaohSetTweak = data[5];
				MeteorArmorDefenseTweak = data[6];
				CactusArmorTweak = data[7];

				data = reader.ReadByte();
				EskimoArmorDropTweak = data[0];
				CrimsonArmorTweak = data[1];
				UndeadMinerTweak = data[2];
				FishingPoleTweak = data[3];

				ExtractSpeedMultiplier = reader.ReadSingle();
				JestersArrowCraft = reader.ReadInt16();
				MolotovCraft = reader.ReadInt16();
			}
		}
		
		class MultiplayerSyncPlayer : ModPlayer
		{
			public override void PlayerDisconnect(Player player)
			{
				ReadConfig();
			}
		}
	}
}
