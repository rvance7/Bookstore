using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment5.Infrastructure;
using Assignment5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assignment5.Pages
{
    public class DonateModel : PageModel
    {
        private IBookstoreRepository repository;

        public DonateModel (IBookstoreRepository repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }

        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(long bookId, string returnUrl)
        {
            Book book = repository.Books
            .FirstOrDefault(p => p.BookId == bookId);
            Cart.AddItem(book, 1);
            return RedirectToPage(new { returnUrl = returnUrl });
        }

        //public IActionResult OnPost(long bookId, string returnUrl)
        //{
        //    Book book = repository.Books.FirstOrDefault(p => p.BookId == bookId);

        //    Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

        //    Cart.AddItem(book, 1);

        //    HttpContext.Session.SetJson("cart", Cart);

        //    return RedirectToPage(new { returnUrl = returnUrl });
        //}

        public IActionResult OnPostRemove(long bookId, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl =>
            cl.Book.BookId == bookId).Book);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
