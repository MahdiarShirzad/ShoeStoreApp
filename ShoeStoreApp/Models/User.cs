﻿namespace ShoeStoreApp.Models;

public class User
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public List<CartItem> Cart { get; set; } = new List<CartItem>();
}