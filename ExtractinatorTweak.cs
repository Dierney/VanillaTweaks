﻿using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System.Linq;

namespace VanillaTweaks
{
	//original code by Hulvdan, modified by goldenapple
	class ExtractinatorTweak : GlobalItem
	{
		struct ExtractableItem
		{
			public ExtractableItem(Item item)
			{
				UseTime = item.useTime;
				UseAnimation = item.useAnimation;
				Name = item.Name;
			}
			public int UseTime;
			public int UseAnimation;
			public string Name;
		}

		static int[] VanillaExtractables = { ItemID.SiltBlock, ItemID.SlushBlock, ItemID.DesertFossil };
		static Dictionary<int, ExtractableItem> ExtractItemsCache = new Dictionary<int, ExtractableItem>();
//		static string Boost = " [Boosted]";

//		private static ExtractableItem GetItemValue(int i)
//		{
//			ExtractableItem v;
//			if (ExtractableItemsCache.TryGetValue(i, out v))
//				return v;
//			return new ExtractableItem(2, 4, "BFMTWEAKERROR");
//		}

		static void SpeedUpExtract(Item item)
		{
			if(Config.ExtractSpeedMultiplier == 1f)
				return;
			
			if(Main.tile[Player.tileTargetX, Player.tileTargetY].type == TileID.Extractinator)
			{
				if(!ExtractItemsCache.ContainsKey(item.type) && IsExtractable(item))
					ExtractItemsCache.Add(item.type, new ExtractableItem(item));
			}
			
			if(ExtractItemsCache.ContainsKey(item.type))
			{
				var extractItem = ExtractItemsCache[item.type];
				if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == TileID.Extractinator)
				{
					//useTime must be 2 or higher or else items dissapear
					item.useTime = Math.Max(2, (int)(extractItem.UseTime / Config.ExtractSpeedMultiplier));
					//useAnimation less than 4 looks really weird as there aren't enough frames
					item.useAnimation = Math.Max(6, (int)(extractItem.UseAnimation / Config.ExtractSpeedMultiplier));
//					item.SetNameOverride(extractItem.Name + Boost);
				}
				else
				{
//					item.SetNameOverride(extractItem.Name);
					item.useTime = extractItem.UseTime;
					item.useAnimation = extractItem.UseAnimation;
				}
			}
		}

		/*
  public override bool UseItem(Item item, Player player)
  {
  if (bfmtweaks.tweak_extractinator)
  ExtractinatorTweaker.onItemUse(item);
  
  return false;
  }*/

//		public override void UpdateInventory(Item item, Player player)
//		{
//			//if (bfmtweaks.tweak_extractinator)
//			if(Config.ExtractSpeedMultipltier != 1f)
//				ExtractinatorTweak.OnItemUse(item);
//		}
		
		public override bool CanUseItem(Item item, Player player)
		{
			SpeedUpExtract(item);
			return base.CanUseItem(item, player);
		}
		
		static bool IsExtractable(Item item)
		{
			if(VanillaExtractables.Contains(item.type))
				return true;
			
			int resultType = 0;
			int resultStack = 0;
			ItemLoader.ExtractinatorUse(ref resultType, ref resultStack, item.type);
			return resultType != 0 || resultStack != 0;
		}
	}
}