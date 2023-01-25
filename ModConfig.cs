using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System;
using Terraria.ModLoader.Config;
using Terraria.ModLoader;
using Terraria;

namespace Aggression {
	[Label("Server Config")]
	public class ServerConfig : ModConfig {
		public override ConfigScope Mode => ConfigScope.ServerSide;
		public static ServerConfig Instance;

		[Header("NPCs")]
		[Label("NPC Updates")]
		[Slider]
		[Range(1, 10)]
		[DefaultValue(1)]
		public int NPCUpdates = 1;

		[Label("NPC Speed")]
		[Slider]
		[Range(1, 10)]
		[DefaultValue(1)]
		public int NPCSpeed = 1;

		[Header("Bosses")]
		[Label("Boss Updates")]
		[Slider]
		[Range(1, 10)]
		[DefaultValue(1)]
		public int BossUpdates = 1;

		[Label("Boss Speed")]
		[Slider]
		[Range(1, 10)]
		[DefaultValue(1)]
		public int BossSpeed = 1;

		[Header("Projectiles")]
		[Label("Enemy Projectile Updates")]
		[Slider]
		[Range(1, 10)]
		[DefaultValue(1)]
		public int EnemyProjectileUpdates = 1;

		[Label("Enemy Projectile Speed")]
		[Slider]
		[Range(1, 10)]
		[DefaultValue(1)]
		public int EnemyProjectileSpeed = 1;

		[Label("Projectile Updates")]
		[Slider]
		[Range(1, 10)]
		[DefaultValue(1)]
		public int ProjectileUpdates = 1;

		[Label("Projectile Speed")]
		[Slider]
		[Range(1, 10)]
		[DefaultValue(1)]
		public int ProjectileSpeed = 1;

		[Header("Minions")]
		[Label("Minion Updates")]
		[Slider]
		[Range(1, 10)]
		[DefaultValue(1)]
		public int MinionUpdates = 1;

		[Label("Minion Speed")]
		[Slider]
		[Range(1, 10)]
		[DefaultValue(1)]
		public int MinionSpeed = 1;

		[Header("Items")]
		[Label("Item Use Speed")]
		[Slider]
		[Range(1, 10)]
		[DefaultValue(1)]
		public int ItemUpdates = 1;

		[Label("Item Animation Speed")]
		[Slider]
		[Range(1, 10)]
		[DefaultValue(1)]
		public int ItemSpeed = 1;

		[Label("Player Speed")]
		[Slider]
		[Range(1, 10)]
		[DefaultValue(1)]
		public int PlayerSpeed = 1;

		public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message) {
			return true;
		}
	}

	public static class Config {
		public static ServerConfig Server => ServerConfig.Instance;
	}
}
