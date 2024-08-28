using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.IRepository;
using Shop.Domain.SellerAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Sellers
{
    public class SellerDomainService : ISellerDomainService
    {
        private readonly ISellerRepository _repository;

        public SellerDomainService(ISellerRepository repository)
        {
            _repository = repository;
        }

        public bool IsValidSellerInformation(Seller seller)
        {
            var sellerInfoExist=_repository.Exists(x=>x.NationalCode == seller.NationalCode||x.UserId==seller.UserId);
            return !sellerInfoExist;
        }

        public bool NationalCodeExistInDataBase(string nationalCode)
        {
            return _repository.Exists(x => x.NationalCode == nationalCode);
            
        }
    }
}
