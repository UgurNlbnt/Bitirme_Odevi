using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.FeatureCommands
{
    public class RemoveFeatureCommand: IRequest
    {
        public int FeaturId { get; set; }

        public RemoveFeatureCommand(int featurId)
        {
            FeaturId = featurId;
        }
    }
}
