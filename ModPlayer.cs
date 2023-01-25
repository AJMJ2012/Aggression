using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria;

namespace Aggression
{
    public class MPlayer : ModPlayer {
		private uint AITime = 0;

		float Speed = 0;
		public override void PostUpdate() {
			if (AITime++ % 30 == 0 || Speed == 0) { // only set once per 30 ticks
				Speed = Config.Server.PlayerSpeed;
			}
			if (Speed > 1) {
				for (int i = 1; i < Speed; i++) {
					if (Player.velocity != Vector2.Zero) {
						Player.position += Collision.AnyCollisionWithSpecificTiles(Player.position, Player.velocity, Player.width, Player.height, Main.tileSolid);
					}
				}
			}
		}
		public override float UseTimeMultiplier(Item item) {
			return 1f / Config.Server.ItemUpdates;
		}
		public override float UseAnimationMultiplier(Item item) {
			return 1f / Config.Server.ItemSpeed;
		}
	}
}
