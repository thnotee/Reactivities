using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace Application.Activites
{
    public class Delete
    {
        public class Command : IRequest
        {

            public Guid Id {get; set;}
        }

        public class Handeler : IRequestHandler<Command>
        {
        private readonly DataContext _context;
            public Handeler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
               var activity = await _context.Activities.FindAsync(request.Id);
            
                _context.Remove(activity);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}