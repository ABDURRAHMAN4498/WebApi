﻿using Business.Abstracts;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreates
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public CreatedBrandResponse Add(CreatedBrandRequest createBrandRequest)
        {
            //busniness rules

            //mapping
            Brand brand = new();
            brand.Name = createBrandRequest.Name;

            _brandDal.Add(brand);
            //mapping
            CreatedBrandResponse createdBrandResponse = new CreatedBrandResponse();
            createdBrandResponse.Name = createBrandRequest.Name;
            createdBrandResponse.Id = 4;
            createdBrandResponse.CreateDate = brand.CreateDate;
            return createdBrandResponse;
        }

        public List<GetAllBrandResponse> GetAll()
        {
            List<Brand> brands = _brandDal.GetAll();
            List<GetAllBrandResponse> getAllBrandResponses = new List<GetAllBrandResponse>();
            foreach (var brand in brands)
            {
                GetAllBrandResponse getAllBrandResponse = new GetAllBrandResponse();
                getAllBrandResponse.Name = brand.Name;
                getAllBrandResponse.Id = brand.Id;
                getAllBrandResponse.CreateDate = brand.CreateDate;
                
                getAllBrandResponses.Add(getAllBrandResponse);
            }
            return getAllBrandResponses;
        }
    }
}
