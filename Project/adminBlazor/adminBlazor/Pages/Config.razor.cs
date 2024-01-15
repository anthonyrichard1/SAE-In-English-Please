using Microsoft.AspNetCore.Components;
using adminBlazor.Models;
using Microsoft.Extensions.Options;
namespace adminBlazor.Pages
{
    public partial class Config
    {
        [Inject]
        public IConfiguration Configuration { get; set; }
  

        private CreatorOptions creatorOptions;

        protected override void OnInitialized()
        {
            base.OnInitialized();

            creatorOptions = new CreatorOptions();
            Configuration.GetSection(CreatorOptions.Creators).Bind(creatorOptions);

            if (creatorOptions.Name == null)
            {
                return;
            }

        }
    }
}

