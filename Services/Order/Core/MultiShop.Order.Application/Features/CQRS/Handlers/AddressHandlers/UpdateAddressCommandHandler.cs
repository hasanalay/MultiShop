using System;
using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
	public class UpdateAddressCommandHandler
	{
        private readonly IRepository<Address> _repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateAddressCommand updateAddressCommand)
        {
            var values = await _repository.GetByIdAsync(updateAddressCommand.AddressId);

            values.UserId = updateAddressCommand.UserId;
            values.District = updateAddressCommand.District;
            values.City = updateAddressCommand.City;
            values.Detail = updateAddressCommand.Detail;

            await _repository.UpdateAsync(values);
        }
    }
}

