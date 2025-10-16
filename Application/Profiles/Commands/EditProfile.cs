using Application.Core;
using Application.Profiles.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Profiles.Commands;

public class EditProfile
{
    public class Command : IRequest<Result<Unit>>
    {
        public required UserProfile UserProfile { get; set; }

        public class Handler(AppDbContext context) : IRequestHandler<Command, Result<Unit>>
        {
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var profile = await context.Users
                    .SingleOrDefaultAsync(x => x.Id == request.UserProfile.Id, cancellationToken: cancellationToken);

                if (profile == null) return Result<Unit>.Failure("Profile not found", 404);

                profile.DisplayName = request.UserProfile.DisplayName;
                profile.Bio = request.UserProfile.Bio;
                
                var result = await context.SaveChangesAsync(cancellationToken) > 0;

                return result
                    ? Result<Unit>.Success(Unit.Value)
                    : Result<Unit>.Failure("Problem saving user profile to DB", 400);
            }
        }
    }

}
