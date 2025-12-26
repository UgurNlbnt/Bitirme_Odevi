using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Commands.BannerCommands
{
    public class RemoveBannerCommand
    {
        public int BannerId { get; set; }

        public RemoveBannerCommand(int bannerId)
        {
            BannerId = bannerId;
        }
    }
}
