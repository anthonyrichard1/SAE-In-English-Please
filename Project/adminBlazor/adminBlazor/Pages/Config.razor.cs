using Microsoft.AspNetCore.Components;
using adminBlazor.Models;
using Microsoft.Extensions.Options;
namespace adminBlazor.Pages
{
    public partial class Config
    {
        [Inject]
        public IConfiguration Configuration { get; set; }
  

        private UserOptions userOptions;

        protected override void OnInitialized()
        {
            base.OnInitialized();


            userOptions = Configuration.GetSection(UserOptions.User).Get<UserOptions>();

        }
    }
}

