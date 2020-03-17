using Microsoft.Xna.Framework;

namespace SpaceInvadersBusiness
{
	public interface ICollidable
	{
		bool Alive
		{
			get;
			set;
		}
		Rectangle BoundingBox
		{
			get;
			set;
		}
	}
}
