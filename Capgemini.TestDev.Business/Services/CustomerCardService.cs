using Capgemini.TestDev.Domain.Entities;
using Capgemini.TestDev.Domain.Interfaces.Repositories;
using Capgemini.TestDev.Domain.Interfaces.UoW;
using Capgemini.TestDev.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini.TestDev.Business.Services
{
    public class CustomerCardService
    {
        private readonly ICustomerCardRepository _customerCardRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerCardService(ICustomerCardRepository customerCardRepository, IUnitOfWork unitOfWork)
        {
            _customerCardRepository = customerCardRepository;
            _unitOfWork = unitOfWork;
        }

        public ResponseSaveCardNumber SaveCard(RequestSaveCardNumber request)
        {
            try
            {
                if(request == null)
                {
                    throw new Exception("Invalid request"); 
                }

                var genToken = GenerateTokenByCard(request);
                CustomerCard newCustomerCard = new CustomerCard()
                {
                    CardNumber = request.CardNumber,
                    CustomerId = request.CustomerId,
                    CVV = request.CVV,
                    Token = genToken
                };

                _customerCardRepository.Save(newCustomerCard);
                _unitOfWork.CommitAsync();

                ResponseSaveCardNumber respCardNumber = new ResponseSaveCardNumber()
                {
                    CardId = newCustomerCard.CardId,
                    CreationDate = new DateTime(),
                    Token = newCustomerCard.Token
                };

                return respCardNumber; 

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }   

        public async Task<bool> ValidateToken(ValidateToken validate)
        {
            var getCardNumber = await _customerCardRepository.GetByCardId(validate.CardId);
            if (getCardNumber == null)
            {
                return false; 
            }
            return true; 
        }

        private Guid GenerateTokenByCard(RequestSaveCardNumber req)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                string input = req.CardNumber.ToString();
                var formatToken = input.Substring(input.Length - 4); 
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(formatToken);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                Guid g = new Guid(hashBytes);
                return g; 
            }
        }
    }
}
