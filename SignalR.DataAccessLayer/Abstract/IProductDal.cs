using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Abstract
{
	public interface IProductDal : IGenericDal<Product>
	{
		List<Product> GetProductsWithCategories();
		int ProductCount();
		int ProductCountByCategoryNameHamburger();
		int ProductCountByCategoryNameIcecek();
		decimal ProductPriceAvg();
		string ProductNameByMaxPrice();
		string ProductNameByMinPrice();
		decimal ProductPriceAvgByHamburger();
	}
}
