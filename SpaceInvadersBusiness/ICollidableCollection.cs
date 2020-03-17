namespace SpaceInvadersBusiness
{
	public interface ICollidableCollection
	{
		int Length { get; }

		ICollidable this[int index] { get; }
	}
}
