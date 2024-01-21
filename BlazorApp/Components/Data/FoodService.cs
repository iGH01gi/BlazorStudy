namespace BlazorApp.Components.Data;

public class FoodService
{
    public class Food
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }
    
    public interface IFoodService
    {
        IEnumerable<Food> GetFoods();
    }
    
    public class KoreanFoodService : IFoodService
    {
        public IEnumerable<Food> GetFoods()
        {
            return new List<Food>
            {
                new Food { Name = "Kimchi", Price = 10000 },
                new Food { Name = "Bibimbap", Price = 8000 },
                new Food { Name = "Bulgogi", Price = 15000 },
                new Food { Name = "Samgyeopsal", Price = 20000 },
                new Food { Name = "Japchae", Price = 10000 },
            };
        }
    }
    
    public class FastFoodService : IFoodService
    {
        public IEnumerable<Food> GetFoods()
        {
            return new List<Food>
            {
                new Food { Name = "Hamburger", Price = 5000 },
                new Food { Name = "Cheeseburger", Price = 6000 },
                new Food { Name = "French Fries", Price = 3000 },
                new Food { Name = "Chicken Nuggets", Price = 4000 },
                new Food { Name = "Onion Rings", Price = 4000 },
            };
        }
    }
    
    public class PaymentService
    {
        private IFoodService _service;
        
        public PaymentService(IFoodService service)  //스프링처럼 자동 DI 해줌 (Program.cs 에서 IFoodService의 구현체로 설정한것이 자동으로 DI 됨. 그러기 위해서는 PaymentService도 싱글톤등록(스프링빈 같은) 해줘야 함)
        {
            _service = service;
        }
        
        //TODO
    }
    
    # region 스프링빈 같은것의 생명주기 3가지 모드 테스트
    
    public class SingletonService : IDisposable
    {
        public Guid ID { get; set; }

        public SingletonService()
        {
            ID = Guid.NewGuid();
        }
        
        public void Dispose()
        {
            Console.WriteLine($"SingletonService disposed");
        }
    }
    
    public class TransientService : IDisposable
    {
        public Guid ID { get; set; }

        public TransientService()
        {
            ID = Guid.NewGuid();
        }
        
        public void Dispose()
        {
            Console.WriteLine($"TransientService disposed");
        }
    }
    
    public class ScopedService : IDisposable
    {
        public Guid ID { get; set; }

        public ScopedService()
        {
            ID = Guid.NewGuid();
        }
        
        public void Dispose()
        {
            Console.WriteLine($"ScopedService disposed");
        }
    }
    
    # endregion
    

    
}