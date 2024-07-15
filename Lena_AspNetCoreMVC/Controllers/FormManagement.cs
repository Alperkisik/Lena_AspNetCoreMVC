using Application.Forms.Services.Abstract;
using Domain.Common;
using Domain.Dtos;
using Lena_AspNetCoreMVC.Authentication.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lena_AspNetCoreMVC.Controllers
{
    [Authorize]
    public class FormManagement : Controller
    {
        private readonly IFormService formService;

        public FormManagement(IFormService formService)
        {
            this.formService = formService;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var data = await formService.GetAllForms(cancellationToken);

            return View(data);
        }

        public async Task<IActionResult> FormDetailed(int FormId, CancellationToken cancellationToken)
        {
            if (FormId <= 0) return BadRequest();

            var form = await formService.GetFormById(FormId, cancellationToken);

            if (form == null) return NotFound();

            return View(form);
        }

        public async Task<IActionResult> AddForm(Form form, CancellationToken cancellationToken)
        {
            form.CreatedAt = DateTime.Now;
            form.CreatedBy = (int)User.GetId()!;

            var result = await formService.AddFormAsync(form, cancellationToken);

            return Json(result);
        }
    }
}
