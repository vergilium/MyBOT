using Microsoft.Extensions.Localization;

namespace MyBOT.Activities.Abstract{
    public interface IActivityFactory{
        IActivity CreateMainMenu(IStringLocalizer<SharedResource> sharedLocalizer);
    }
}