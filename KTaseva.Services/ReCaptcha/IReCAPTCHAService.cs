using KTaseva.ViewModels.ReCaptcha;
using System.Threading.Tasks;

namespace KTaseva.Services.ReCaptcha
{
    public interface IReCAPTCHAService
    {
        public Task<ReCAPTCHAResponse> Verify(string token);
    }
}
