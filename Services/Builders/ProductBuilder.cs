using E_CommerceAPI.Models.Classes.ProductProperties;
using E_CommerceAPI.Models.Classes.ProductProperties.Enums;

namespace E_CommerceAPI.Services.Builders
{
    public class ProductBuilder : IProductBuilder
    {
        Product Product = new Product();
        public Product Build()
        {
            return Product;
        }

        public IProductBuilder SetCategory(ProductCategory category)
        {
            Product.Category = category;
            return this;
        }

        public IProductBuilder? SetDimensions(int width, int height)
        {

            Product.Dimensions = new Dimensions(width, height);
            return this;
        }

        public IProductBuilder SetImages(List<ProductImage> Images)
        {
            Product.Images = Images;
            return this;
        }

        public IProductBuilder SetName(string name)
        {
            Product.Name = name;
            return this;
        }

        public IProductBuilder SetPrice(double price)
        {
            Product.Price = price;
            return this;
        }

        public IProductBuilder? SetSize(ProductSize size)
        {
            Product.Size = size;
            return this;
        }
    }
}

