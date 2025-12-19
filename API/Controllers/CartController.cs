using System;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CartController : BaseApiController
{
    private readonly ICartService _cartService;

    public CartController(ICartService cartService)
    {
        _cartService = cartService;
    }

    [HttpGet]
    public async Task<ActionResult<ShoppingCart>> GetCartById(string id)
    {
        if (string.IsNullOrEmpty(id))
            return BadRequest("Cart ID is required");

        var cart = await _cartService.GetCartAsync(id);

        return Ok(cart ?? new ShoppingCart { Id = id });
    }

    [HttpPost]
    public async Task<ActionResult<ShoppingCart>> UpdateCart(ShoppingCart cart)
    {
        if (cart == null)
            return BadRequest("Cart is null");

        try
        {
            var updatedCart = await _cartService.SetCartAsync(cart);

            if (updatedCart == null)
                return BadRequest("Problem updating cart");

            return Ok(updatedCart);
        }
        catch (Exception ex)
        {
            Console.WriteLine("CART ERROR: " + ex.Message);
            return StatusCode(500, $"Server Error: {ex.Message}");
        }
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteCart(string id)
    {
        if (string.IsNullOrEmpty(id))
            return BadRequest("Cart ID is required");

        var result = await _cartService.DeleteCartAsync(id);

        if (!result)
            return BadRequest("Problem deleting cart");

        return Ok();
    }
}
