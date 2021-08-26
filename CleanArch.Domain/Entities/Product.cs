using CleanArch.Domain.Validation;

namespace CleanArch.Domain.Entities
{
    public sealed class Product: Entity
    {
        public string  Name { get; private set; }
        public string  Description { get; private set; }
        public decimal Price { get; private set; }
        public int  Stock { get; private set; }
        public string  Image { get; private set; }
        public Product(string name , string description, decimal price , int stock, string image)
        {
            ValidationDomain(name , description , price, stock, image);
        }

        public Product(int id, string name , string description, decimal price , int stock, string image)
        {
            DomainExceptionValidation.When(id < 0 ,"Invalid Id Value");
            Id = id;
            ValidationDomain(name , description , price, stock, image);
        }

        public void Update (string name , string description, decimal price , int stock, string image, int categoryId)
        {
            ValidationDomain(name, description, price , stock, image);
            CategoryId = categoryId;
        }
        
        private void ValidationDomain(string name , string description, decimal price , int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), 
                "Name invalid , name is required");

            DomainExceptionValidation.When(name.Length < 3 , 
                "Name invalid , too short , minimum 3 characters");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description), 
                "description invalid , description is required");

            DomainExceptionValidation.When(description.Length < 5 , 
                "description invalid , too short , minimum 5 characters");

            DomainExceptionValidation.When(price < 0, "price invalid");     

            DomainExceptionValidation.When(stock < 0, "stock invalid ");

            DomainExceptionValidation.When(image.Length >  250, 
                "invalid image name, too long  maximum 250  characteres");   

            Name = name;
            Description = description; 
            Price = price;
            Stock = stock;
            Image = image;        
    
        }

        public int CategoryId { get; set; }
        public Category Category { get;  set; }
    }
}