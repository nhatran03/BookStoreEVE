namespace BookStore.Domain.Entities
{
	public interface IEntityTranslation
	{
		string Language { get; set; }
	}

	public interface IEntityTranslation<TEntity, TPrimaryKeyOfMultiLigualEntity> : IEntityTranslation
	{
		TEntity Core { get; set; }

		TPrimaryKeyOfMultiLigualEntity CoreId { get; set; }
	}
	public interface IEntityTranslation<TEntity> : IEntityTranslation<TEntity,int>
	{

	}
}
