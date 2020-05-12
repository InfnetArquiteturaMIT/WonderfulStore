﻿using System;
using System.Collections.Generic;
using System.Text;
using WonderfulStore.Application.Cqrs.Commands;
using WonderfulStore.Application.Models.Interfaces;
using WonderfulStore.Domain.Entities;
using WonderfulStore.Domain.Interfaces.Repositories;

namespace WonderfulStore.Application
{
    public class ProductApiApp
    {
        private readonly IMediatorHandler _bus;
        private readonly IProductRepository _productRepository;

        public ProductApiApp(IMediatorHandler bus, IProductRepository productRepository)
        {
            _bus = bus;
            _productRepository = productRepository;
        }

        //############## COMMANDS ################
        public void AddProduct(Product product)
        {
            _bus.SendCommand<AddProductCommand>(new AddProductCommand { Product = product }, AddProductCommand.CommandQueueName);
        }

        public void UpdateProduct(Product product)
        {
            _bus.SendCommand<UpdateProductCommand>(new UpdateProductCommand { Product = product }, UpdateProductCommand.CommandQueueName);
        }
        //########################################

        
        //############# QUERIES ##############
        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepository.ReadAll();
        }
        //####################################

    }
}