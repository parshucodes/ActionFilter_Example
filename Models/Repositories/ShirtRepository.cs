namespace WebApplication1.Models.Repositories
{
    public static class ShirtRepository
    {
        private static List<Shirt> shirt = new List<Shirt>()
        {
            new Shirt{ShirtId=1, Brand="my brrand", Color="red", Gender="Men", Price=34, Size=18 },
            new Shirt{ShirtId=2, Brand="my jac", Color="pink", Gender="women", Price=24, Size=13 },
            new Shirt{ShirtId=3, Brand="my more", Color="candy", Gender="Men", Price=84, Size=9 },
            new Shirt{ShirtId=4, Brand="my nike", Color="gilltew", Gender="Men", Price=34, Size=13 }
        };

        public static List<Shirt> GetAllShirt()
        { return shirt; }
        public static bool shirtExists(int id)
        {
            return shirt.Any(x=> x.ShirtId == id);
        }
        public static Shirt? shirtById(int id)
        {
            return shirt.FirstOrDefault(x=> x.ShirtId == id);
        }

        public static Shirt? GetShirtByProperties(string? brand, string? gender, string? color, int? size)
        {
            return shirt.FirstOrDefault(x => !string.IsNullOrWhiteSpace(brand)&& !string.IsNullOrWhiteSpace(x.Brand)
            && x.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase)&&
            !string.IsNullOrWhiteSpace(gender) && !string.IsNullOrWhiteSpace(x.Gender)
            && x.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase) &&
            !string.IsNullOrWhiteSpace(color) && !string.IsNullOrWhiteSpace(x.Color)
            && x.Color.Equals(color, StringComparison.OrdinalIgnoreCase) &&
            size.HasValue &&
            x.Size.HasValue &&
            size.Value == x.Size.Value
            );
        }

        public static void Addshirt(Shirt shirtw)
        {
            int maxId = shirt.Max(x => x.ShirtId);
            shirtw.ShirtId = maxId+1;
            shirt.Add(shirtw);
        }
        public static void UpdateShirte(Shirt shirtw)
        {
            var shirttoupdate = shirt.First(x=>x.ShirtId == shirtw.ShirtId);
            shirttoupdate.Brand = shirtw.Brand;
            shirttoupdate.Price = shirtw.Price;
            shirttoupdate.Gender = shirtw.Gender;
            shirttoupdate.Color = shirtw.Color;
            shirttoupdate.Size = shirtw.Size;
        }
    }
}
