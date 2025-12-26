using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.FooterAddressCommands
{
    public class RemoveFooterAddressCommand:IRequest
    {
        public int FoooterAddressId { get; set; }

        public RemoveFooterAddressCommand(int foooterAddressId)
        {
            FoooterAddressId = foooterAddressId;
        }
    }
}
