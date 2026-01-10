using Application.Core;
using Application.Profiles.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Profiles.Queries;

public class GetUserActivities
{
    public class Query : IRequest<Result<List<UserActivityDTO>>>
    {
        public required string UserId { get; set; }
        public string Filter { get; set; } = "hosting";
    }

    public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Query, Result<List<UserActivityDTO>>>
    {
        public async Task<Result<List<UserActivityDTO>>> Handle(Query request, CancellationToken cancellationToken)
        {
            var query =  context.ActivityAttendees
                .Where(u => u.UserId == request.UserId)
                .Select(x => x.Activity)
                .Distinct()
                .OrderBy(x => x.Date)
                .AsQueryable();
            
            query = request.Filter switch 
            {
                "past" => query
                    .Where(x => x.Date <= DateTime.UtcNow),
                "future" => query
                    .Where(x => x.Date >= DateTime.UtcNow),
                "hosting" => query
                    .Where(x => x.Attendees.Any(u => u.IsHost && u.UserId == request.UserId)),
                _ => query
            };

            var userActivities = await query
                .ProjectTo<UserActivityDTO>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return Result<List<UserActivityDTO>>.Success(userActivities);        
        }
    }
}
