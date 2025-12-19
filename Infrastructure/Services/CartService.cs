using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using System.Text.Json;

namespace Infrastructure.Services
{
    public class CartService : ICartService
    {
        // Thread-safe in-memory storage
        private readonly ConcurrentDictionary<string, ShoppingCart> _carts = new();

        public Task<bool> DeleteCartAsync(string key)
        {
            return Task.FromResult(_carts.TryRemove(key, out _));
        }

        public Task<ShoppingCart?> GetCartAsync(string key)
        {
            _carts.TryGetValue(key, out var cart);
            return Task.FromResult(cart);
        }

        public Task<ShoppingCart?> SetCartAsync(ShoppingCart cart)
        {
            _carts[cart.Id] = cart;
            return Task.FromResult(cart);
        }
    }
}
