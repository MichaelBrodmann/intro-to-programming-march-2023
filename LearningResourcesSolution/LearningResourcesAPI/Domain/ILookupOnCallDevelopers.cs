using LearningResourcesAPI.Models;

namespace LearningResourcesAPI.Domain;

public interface ILookupOnCallDevelopers
{
    Task<StatusHelpInfo> GetCurrentOnCallDeveloperAsync();
}
