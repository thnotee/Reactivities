using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Application.Activites;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activites
{
    public class Create
    {
        public class Command : IRequest
        {
            public Activity Activity { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                //SaveChangesAsync 가 호출될 때 데이터베이스에 삽입되도록 합니다.
                //따라서 Add 에는 Async가 사용될 필요가 없다. 
                _context.Activities.Add(request.Activity);
                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}

