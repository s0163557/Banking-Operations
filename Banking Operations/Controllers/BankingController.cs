using Banking_Operations.Data;
using Banking_Operations.Interfaces;
using Banking_Operations.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Banking_Operations.Controllers
{
    public class BankingController : Controller
    {
        private IBankServicesRepository _repository;
        private UserManager<Client> _clientManager;
        public BankingController(IBankServicesRepository repository, UserManager<Client> clientManager) 
        {
            _clientManager = clientManager;
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            Client client = await _clientManager.FindByNameAsync(User.Identity.Name);
            IEnumerable<BankService> bankServices = await _repository.GetByClientIdAsync(client.Id);
            return View(bankServices);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BankingModel bankingModel)
        {
            if (!ModelState.IsValid)
            {
                return View(bankingModel);
            }

            Client client = await _clientManager.FindByNameAsync(User.Identity.Name);

            BankService bankService = new BankService
            {
                BankServiceName = bankingModel.BankServiceName,
                TermOfRendering = bankingModel.TermOfRendering,
                ComissionType = bankingModel.ComissionType,
                Debt = bankingModel.Debt,
                BankServiceStatus = false,
                ClientId = client.Id
            };
            _repository.Add(bankService);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(BankService bankService)
        {
            BankService newBankService = await _repository.GetByIdAsync(bankService.Id);

            BankingModel bankingModel = new BankingModel
            {
                ServiceID = newBankService.Id,
                BankServiceName = newBankService.BankServiceName,
                TermOfRendering = newBankService.TermOfRendering,
                ComissionType = newBankService.ComissionType,
                Debt = newBankService.Debt,
                ClientId = newBankService.ClientId
            }; 
            return View(bankingModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(BankService bankService)
        {
            BankService newBankService = await _repository.GetByIdAsync(bankService.Id);

            BankingModel bankingModel = new BankingModel
            {
                ServiceID = newBankService.Id,
                BankServiceName = newBankService.BankServiceName,
                TermOfRendering = newBankService.TermOfRendering,
                ComissionType = newBankService.ComissionType,
                Debt = newBankService.Debt,
                ClientId = newBankService.ClientId,
                BankServiceState = newBankService.BankServiceStatus
            };
            return View(bankingModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BankingModel bankingModel)
        {
            Client client = await _clientManager.FindByNameAsync(User.Identity.Name);
            var bankService = new BankService
            {
                Id = bankingModel.ServiceID,
                BankServiceName = bankingModel.BankServiceName,
                TermOfRendering = bankingModel.TermOfRendering,
                ComissionType = bankingModel.ComissionType,
                Debt = bankingModel.Debt,
                BankServiceStatus = Convert.ToBoolean(bankingModel.BankServiceState),
                ClientId = client.Id
            };
            _repository.Update(bankService);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            var bankService = await _repository.GetByIdAsync(id);
            _repository.Delete(bankService);
            return RedirectToAction("Index");
        }
    }
}
