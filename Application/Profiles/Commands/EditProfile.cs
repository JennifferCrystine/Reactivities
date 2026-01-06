using Application.Core;
using Application.Interfaces;
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
        public string Id { get; set; } = "";
        public required string DisplayName { get; set; }
        public string? Bio { get; set; }

        public class Handler(AppDbContext context, IUserAccessor userAccessor) : IRequestHandler<Command, Result<Unit>>
        {
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await userAccessor.GetUserAsync();

                if (user.Id != request.Id) return Result<Unit>.Failure("Profile not found", 404);

                var profile = await context.Users
                    .SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);

                if (profile == null) return Result<Unit>.Failure("Profile not found", 404);

                profile.DisplayName = request.DisplayName;
                profile.Bio = request.Bio;
                
                var result = await context.SaveChangesAsync(cancellationToken) > 0;

                return result
                    ? Result<Unit>.Success(Unit.Value)
                    : Result<Unit>.Failure("Problem saving user profile to DB", 400);
            }
        }
    }

}
