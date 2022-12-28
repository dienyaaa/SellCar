using Microsoft.AspNetCore.Mvc;

namespace IO.Swagger.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CarController : ControllerBase
    {
        List<Car> cars;

        [HttpPost]
        public Car Create(Car car)
        {
            cars.Append(car);
            return cars.Last();
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var toDelete = cars.FirstOrDefault(m => m.Id == id);
            cars.Remove(toDelete);
        }

        [HttpGet]
        public List<Car> GetAll()
        {
            return cars;
        }

        [HttpPut]
        public Car Update(Car car)
        {
            var toUpdate = cars.FirstOrDefault(m => m.Id == car.Id);
            if (toUpdate != null)
            {
                toUpdate = car;
            }
            return toUpdate;
        }

        [HttpGet]
        public Car Get(Guid id)
        {
            return cars.FirstOrDefault(m => m.Id == id);
        }
    }
}