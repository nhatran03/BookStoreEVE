using System.Collections.Generic;

namespace BookStore.Domain.Entities
{
	public interface IMultiLingualEntity<TTranslation> 
		where TTranslation : class, IEntityTranslation
	{
		ICollection<TTranslation> Translations { get; set; }
	}
}
