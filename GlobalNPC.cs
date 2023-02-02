using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

using DALib.Checks;

namespace Aggression
{
    public class GNPC : GlobalNPC {
		public override bool InstancePerEntity { get { return true; } }
		private uint AITime = 0;
		int Updates = 1;
		float Speed = 1;

		public override GNPC Clone(NPC npc, NPC npcClone)
		{
			return (GNPC)this.MemberwiseClone();
		}

		public override void AI(NPC npc) {
			if (AITime++ % 30 == 0 || Updates == 0) { // only set once per 30 ticks
				Updates = (NPCID.Sets.ProjectileNPC[npc.type] ? (npc.friendly ? Config.Server.ProjectileUpdates : Config.Server.EnemyProjectileUpdates) : npc.IsBossOrPieceOrChildOf() ? Config.Server.BossUpdates : Config.Server.NPCUpdates);
				Speed = (NPCID.Sets.ProjectileNPC[npc.type] ? (npc.friendly ? Config.Server.ProjectileSpeed : Config.Server.EnemyProjectileSpeed) : npc.IsBossOrPieceOrChildOf() ? Config.Server.BossSpeed : Config.Server.NPCSpeed);
			}
			if ((Updates == 1 || AITime % Updates > 0) && Speed > 1) {
				for (int i = 1; i < Speed; i++) {
					Vector2 newSpeed = npc.velocity / (float)Updates;
					if (newSpeed != Vector2.Zero) {
						Vector2 newPostion = npc.position + newSpeed;
						if (!npc.noTileCollide) newPostion = npc.position + Collision.AnyCollisionWithSpecificTiles(npc.position, newSpeed, npc.width, npc.height, Main.tileSolid);
						npc.position = newPostion;
					}
				}
			}
			if (Updates > 1 && AITime % Updates > 0) {
				npc.AI();
			}
		}
	}
}
