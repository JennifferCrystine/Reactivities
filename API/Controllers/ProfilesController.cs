using Application.Profiles.Commands;
using Application.Profiles.DTOs;
using Application.Profiles.Queries;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ProfilesController : BaseApiController
{
    [HttpPost("add-photo")]
    public async Task<ActionResult<Photo>> AddPhotoAsync(IFormFile file)
    {
        return HandleResult(await Mediator.Send(new AddPhoto.Command { File = file }));
    }

    [HttpGet("{userId}/photos")]
    public async Task<ActionResult<List<Photo>>> GetPhotosForUserAsync(string userId)
    {
        return HandleResult(await Mediator.Send(new GetProfilePhoto.Query { UserId = userId }));
    }

    [HttpDelete("{photoId}/photos")]
    public async Task<ActionResult> DeletePhotoAsync(string photoId)
    {
        return HandleResult(await Mediator.Send(new DeletePhoto.Command { PhotoId = photoId }));
    }

    [HttpPut("{photoId}/setMain")]
    public async Task<ActionResult> SetMainPhotoAsync(string photoId)
    {
        return HandleResult(await Mediator.Send(new SetMainPhoto.Command { PhotoId = photoId }));
    }

    [HttpGet("{userId}")]
    public async Task<ActionResult<UserProfile>> GetProfileAsync(string userId)
    {
        return HandleResult(await Mediator.Send(new GetProfile.Query { UserId = userId }));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> EditProfileAsync([FromRoute] string id, EditProfile.Command command)
    {
        command.Id = id;
        return HandleResult(await Mediator.Send(command));
    }

    [HttpPost("{userId}/follow")]
    public async Task<ActionResult> FollowToggleAsync(string userId)
    {
        return HandleResult(await Mediator.Send(new FollowToggle.Command{ TargetUserId = userId }));
    }

    [HttpGet("{userId}/follow-list")]
    public async Task<ActionResult> GetFollowingsAsync(string userId, string predicate)
    {
        return HandleResult(await Mediator.Send(new GetFollowings.Query{ UserId = userId, Predicate = predicate }));
    }

    [HttpGet("{userId}/activities")]
    public async Task<ActionResult> GetUserActivitiesAsync(string userId, [FromQuery] string filter)
    {
        return HandleResult(await Mediator.Send(new GetUserActivities.Query{ UserId = userId, Filter = filter }));
    }

}
