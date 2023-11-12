using Banking_Operations.Data;
using Banking_Operations.Interfaces;
using Banking_Operations.Models;
using Microsoft.AspNetCore.Mvc;

namespace Banking_Operations.Controllers
{
    public class BankingController : Controller
    {
        private IBankServicesRepository _repository;
        public BankingController(IBankServicesRepository repository) 
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<BankService> bankServices = await _repository.GetAll();
            return View(bankServices);
        }
    }
}
