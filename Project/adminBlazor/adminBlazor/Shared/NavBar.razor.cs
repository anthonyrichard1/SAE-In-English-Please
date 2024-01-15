using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace adminBlazor.Shared
{
    public partial class NavBar
    {
        [Inject]
        public IStringLocalizer<NavBar> Localizer { get; set; }
    }
}

