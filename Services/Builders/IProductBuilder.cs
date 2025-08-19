using E_CommerceAPI.Models.Classes.ProductProperties;
using E_CommerceAPI.Models.Classes.ProductProperties.Enums;

namespace E_CommerceAPI.Services.Builders
{
    public interface IProductBuilder
    {

        IProductBuilder SetName(string name);
        IProductBuilder SetPrice(double price);
        IProductBuilder SetImages(List<ProductImage> Images);
        IProductBuilder? SetSize(ProductSize size);
        IProductBuilder SetCategory(ProductCategory category);
        IProductBuilder? SetDimensions(int Width, int Height);
        Product Build();
    }
}
