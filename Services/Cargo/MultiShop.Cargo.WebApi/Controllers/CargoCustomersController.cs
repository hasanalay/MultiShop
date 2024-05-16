using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;

        public CargoCustomersController(ICargoCustomerService cargoCustomerService)
        {
            _cargoCustomerService = cargoCustomerService;
        }

        [HttpGet]
        public IActionResult GetCargoCustomersList()
        {
            var values = _cargoCustomerService.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCustomerById(int id)
        {
            var value = _cargoCustomerService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
        {
            // I  can use AutoMapper here  to avoid creating a new CargoCustomer object.
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
                Name = createCargoCustomerDto.Name,
                Surname = createCargoCustomerDto.Surname,
                Email = createCargoCustomerDto.Email,
                Phone = createCargoCustomerDto.Phone,
                District = createCargoCustomerDto.District,
                City = createCargoCustomerDto.City,
                Address = createCargoCustomerDto.Address
            };
            _cargoCustomerService.TInsert(cargoCustomer);
            return Ok("The cargo company created succesfully!");
        }

        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            // I  can use AutoMapper here  to avoid creating a new CargoCustomer object.
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
                CargoCustomerId = updateCargoCustomerDto.CargoCustomerId,
                Name = updateCargoCustomerDto.Name,
                Surname = updateCargoCustomerDto.Surname,
                Email = updateCargoCustomerDto.Email,
                Phone = updateCargoCustomerDto.Phone,
                District = updateCargoCustomerDto.District,
                City = updateCargoCustomerDto.City,
                Address = updateCargoCustomerDto.Address
            };
            _cargoCustomerService.TUpdate(cargoCustomer);
            return Ok("The cargo company updated succesfully!");
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveCargoCustomer(int id)
        {
            _cargoCustomerService.TDelete(id);
            return Ok("The cargo company removed succesfully!");
        }
    }
}
