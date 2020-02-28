using System.Threading.Tasks;
using eShop.API.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using eShop.API.ViewModel;
using eShop.API.Models;
using AutoMapper;

namespace eShop.API.Controllers
{
  [Route("api/[Controller]")]
  public class OrdersController : Controller
  {
    private readonly IAPIRepository _dutchRepository;
    private readonly ILogger<OrdersController> _logger;
    private readonly IMapper _mapper;

    public OrdersController(IAPIRepository dutchRepository,
    ILogger<OrdersController> logger, IMapper mapper)
    {
      _dutchRepository = dutchRepository;
      _logger = logger;
      _mapper=mapper;
    }

    [HttpGet]
    public IActionResult Get(bool includeItem = true)
    {
      try
      {
        //var userName = User.Identity.Name;
        var results = _dutchRepository.GetAllOrders(includeItem);
        return Ok(_mapper.Map<IEnumerable<Order>, IEnumerable<OrderViewModel>>(results));
      }
      catch (Exception ex)
      {
        _logger.LogError($"Failed to get orders: {ex}");
        return BadRequest("Failed to get orders");
      }
    }

    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
      try
      {
        var order = _dutchRepository.GetOrderById("", id);
        if (order != null) return Ok((order));
        return NotFound();
      }
      catch (Exception ex)
      {
        _logger.LogError($"Failed to get order: {ex}");
        return BadRequest("Failed to get order");
      }
    }
    
    /// <summary>
    /// Frombody param is used to mention specifically that the data is supposed to come from the body 
    /// and not from the url query string. 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>

    [HttpPost]
    public async Task<IActionResult> Post([FromBody]OrderViewModel model)
    {
      //add the order to the database
      try
      {
        if (ModelState.IsValid)
        {
          var newOrder = _mapper.Map<OrderViewModel, Order>(model);
          if (newOrder.OrderDate == DateTime.MinValue)
          {
            newOrder.OrderDate = DateTime.Now;
          }

         // var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
          //newOrder.User = currentUser;

          _dutchRepository.AddOrder(newOrder);

          if (_dutchRepository.SaveAll())
          {
            var vm = _mapper.Map<Order, OrderViewModel>(newOrder);

            return Created($"/api/orders/{newOrder.Id}", _mapper.Map<Order, OrderViewModel>(newOrder));
          }
        }
        else
        {
          return BadRequest(ModelState);
        }

      }
      catch (System.Exception ex)
      {
        _logger.LogError($"Failed to add a new order: {ex}");
      }
      return BadRequest("Failed to add a new order");
    }
  }
}