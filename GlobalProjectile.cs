using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria;

namespace Aggression
{
    public class GProjectile : GlobalProjectile {
		public override bool InstancePerEntity { get { return true; } }
		private uint AITime = 0;
		int Updates = 0;
		float Speed = 0;
		int baseTimeLeft = 0;

		public override GProjectile Clone(Projectile projectile, Projectile projectileClone)
		{
			return (GProjectile)this.MemberwiseClone();
		}

		public override void SetDefaults(Projectile projectile) {
			projectile.timeLeft *= (projectile.aiStyle == 20 || projectile.aiStyle == 75 ? Config.Server.ItemUpdates : projectile.minionSlots > 0 || projectile.sentry ? Config.Server.MinionUpdates : projectile.friendly ? Config.Server.ProjectileUpdates : Config.Server.EnemyProjectileUpdates);
			projectile.timeLeft /= (projectile.aiStyle == 20 || projectile.aiStyle == 75 ? Config.Server.ItemSpeed : projectile.minionSlots > 0 || projectile.sentry ? Config.Server.MinionSpeed : projectile.friendly ? Config.Server.ProjectileSpeed : Config.Server.EnemyProjectileSpeed);
		}

		public override void AI(Projectile projectile) {
			if (AITime++ % 30 == 0 || Updates == 0) { // only set once per 30 ticks
				Updates = (projectile.aiStyle == 20 || projectile.aiStyle == 75 ? Config.Server.ItemUpdates : projectile.minionSlots > 0 || projectile.sentry ? Config.Server.MinionUpdates : projectile.friendly ? Config.Server.ProjectileUpdates : Config.Server.EnemyProjectileUpdates);
				Speed = (projectile.aiStyle == 20 || projectile.aiStyle == 75 ? Config.Server.ItemSpeed : projectile.minionSlots > 0 || projectile.sentry ? Config.Server.MinionSpeed : projectile.friendly ? Config.Server.ProjectileSpeed : Config.Server.EnemyProjectileSpeed);
			}
			if ((Updates == 1 || AITime % Updates > 0) && Speed > 1) {
				for (int i = 1; i < Speed; i++) {
					Vector2 newSpeed = projectile.velocity / (float)Updates;
					if (newSpeed != Vector2.Zero) {
						Vector2 newPostion = projectile.position + newSpeed;
						if (projectile.tileCollide) newPostion = projectile.position + Collision.AnyCollisionWithSpecificTiles(projectile.position, newSpeed, projectile.width, projectile.height, Main.tileSolid);
						projectile.position = newPostion;
					}
				}
			}
			if (Updates > 1 && AITime % Updates > 0) {
				projectile.AI();
			}
		}
	}
}
